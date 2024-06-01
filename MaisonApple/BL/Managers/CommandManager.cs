// ---------------------------------------------------------------
// Copyright (c). All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------
using AutoMapper;
using BL.Interfaces;
using DAL;
using DTO;
using Entities;
using Microsoft.AspNetCore.Identity;

namespace BL.Managers
{
    public class CommandManager : ICommandManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userStore;
        private readonly IMailService _mailService;
        public CommandManager(IUnitOfWork unitOfWork, IMapper mapper,UserManager<User> userManager, IMailService mailService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userStore = userManager;
            _mailService = mailService;
        }
        public async Task<int> Add(AddCommandDto commandDto)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();

                var command = _mapper.Map<Command>(commandDto);
                await _unitOfWork.RepoCommand.Add(command);
                await _unitOfWork.CommitTransactionAsync();
                await _unitOfWork.SaveAsync();

                foreach (var orderDto in commandDto.Orders)
                {
                   var order = _mapper.Map<Order>(orderDto);
                    order.CommandId = command.Id;
                  
                    await _unitOfWork.BeginTransactionAsync();
                    await _unitOfWork.RepoOrder.Add(order);
                    await _unitOfWork.CommitTransactionAsync();
                    await _unitOfWork.SaveAsync();
               
                }
                await SendCommandSendedMail(commandDto);
                return command.Id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                var Payment = await _unitOfWork.RepoCommand.Get(id);
                await _unitOfWork.BeginTransactionAsync();
                await _unitOfWork.RepoCommand.Delete(Payment);
                await _unitOfWork.CommitTransactionAsync();
                await _unitOfWork.SaveAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<IEnumerable<CommandDto>> Get()
        {
            try
            {
                var commands = await _unitOfWork.RepoCommand.Get();

                var commandDtos =_mapper.Map<IEnumerable<CommandDto>>(commands);
                foreach (var commandDto in commandDtos)
                {
                    var user = await _userStore.FindByIdAsync(commandDto.UserId);
                    commandDto.User = _mapper.Map <RegisterUserDto> (user);
                    var orders = await _unitOfWork.RepoOrder.GetOrdersByCommanId(commandDto.Id);
                    commandDto.Orders = _mapper.Map<List<OrderDto>>(orders);
                }
               

                return commandDtos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<CommandDto> Get(int id)
        {
            try
            {
                var Payment = await _unitOfWork.RepoCommand.Get(id);
                var PaymentDto = _mapper.Map<CommandDto>(Payment);
                return PaymentDto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<CommandDto> Update(CommandDto PaymentDto)
        {
            try
            {
                var Payment = new Command();
                _mapper.Map(PaymentDto, Payment);
                await _unitOfWork.BeginTransactionAsync();
                await _unitOfWork.RepoCommand.Update(Payment);
                await _unitOfWork.CommitTransactionAsync();
                await _unitOfWork.SaveAsync();
                return _mapper.Map<CommandDto>(Payment);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task AcceptCommmand(AddCommandDto commandDto)
        {
            try
            {
                var testStock = true;
                foreach (var orderDto in commandDto.Orders)
                {

                    var product = await _unitOfWork.RepoProduct.Get(orderDto.ProductId);
                    product.StockQuantity -= orderDto.Quantity;
                    if(product.StockQuantity >= 0)
                    {
                        await _unitOfWork.BeginTransactionAsync();
                        await _unitOfWork.RepoProduct.Update(product);
                        await _unitOfWork.CommitTransactionAsync();
                        await _unitOfWork.SaveAsync();

                        if (product.StockQuantity < 3)
                        {
                            var adminNotification = new Notification { Date = DateTime.Now, Title = $"Inventaire", Description = $"Stock du produit {product.Name} est en basse" };

                            var users = await _userStore.GetUsersInRoleAsync("ADMIN");

                            foreach (var user in users)
                            {
                                adminNotification.UserId = user.Id;
                                await _unitOfWork.BeginTransactionAsync();
                                await _unitOfWork.RepoNotification.Add(adminNotification);
                                await _unitOfWork.CommitTransactionAsync();
                                await _unitOfWork.SaveAsync();
                            }

                        }
                    }else
                    {
                        testStock = false;
                    }

                } if(testStock)
                {
                    commandDto.CommandStatus = CommandStatusDto.Accepted;
                    var command = _mapper.Map<Command>(commandDto);
                    var notification = new Notification { Date = DateTime.Now, UserId = commandDto.UserId, Title = $"Commande Acceptée", Description = $"Votre Commande de reference {commandDto.Reference} est bien acceptée" };
                    await _unitOfWork.BeginTransactionAsync();
                    await _unitOfWork.RepoCommand.Update(command);
                    await _unitOfWork.RepoNotification.Add(notification);
                    await _unitOfWork.CommitTransactionAsync();
                    await _unitOfWork.SaveAsync();

                    await SendAcceptCommandMail(commandDto);
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task RejectCommmand(int commandId)
        {
            try
            {
                var commandDto = await Get(commandId);

                    commandDto.CommandStatus = CommandStatusDto.Rejected;
                    var command = _mapper.Map<Command>(commandDto);
                    var notification = new Notification { Date = DateTime.Now, UserId = commandDto.UserId, Title = $"Commande Rejetée" , Description = $"Votre Commande de reference {commandDto.Reference} est bien rejetée" };
                    await _unitOfWork.BeginTransactionAsync();
                    await _unitOfWork.RepoCommand.Update(command);
                    await _unitOfWork.RepoNotification.Add(notification);
                    await _unitOfWork.CommitTransactionAsync();
                    await _unitOfWork.SaveAsync();
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public async Task<IEnumerable<CommandDto>> GetCommandsByUser(string userId)
        {
            try
            {
                var commands = await _unitOfWork.RepoCommand.Query(n => n.UserId == userId);

                return _mapper.Map<IEnumerable<CommandDto>>(commands);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        private async Task SendAcceptCommandMail(AddCommandDto commandDto)
        {
            string subject = $"Votre Commande de referenc {commandDto.Reference} a ete bien accepté";

            var produits = string.Empty;
            foreach(var order in commandDto.Orders)
            {
                produits = produits + "" + $"{order.Quantity} items du produit {order.ProductId}";
            }
            string body = $"Bonjour,\r\n\r\n" +
                $"Nous sommes ravis de vous annoncer que votre commande de reference {commandDto.Reference} a ete bien acceptée.\r\n\r\n" +
                $"Deatils de la commande : \r\n\r\n" +
                $"Date :{commandDto.Date} \r\n\r\n" +
                $"Amount :{commandDto.Amount} \r\n\r\n" +
                $"Liste des produits commandées : {produits}\r\n\r\n" +
                $"Merci pour votre confiance.\r\n\r\n" +
                $"Equipe Maison D'apple,\n" +
                $"Cordialement";


            var user = await _userStore.FindByIdAsync(commandDto.UserId);
            await _mailService.SendEmail(user.Email, subject, body, null, null);
        }
        private async Task SendCommandSendedMail(AddCommandDto commandDto)
        {
            string subject = $"Votre Commande de referenc {commandDto.Reference} est sous traitement";

            var produits = string.Empty;
            foreach (var order in commandDto.Orders)
            {
                var productName = (await _unitOfWork.RepoProduct.Get(order.ProductId)).Name;
                produits = produits + "" + $"{order.Quantity} items du produit {productName}";
            }
            string body = $"Bonjour,\r\n\r\n" +
                $"Votre commande de reference {commandDto.Reference} est en cours de traitement.On vous infomre son etat tres bientot\r\n\r\n" +
                $"Deatils de la commande : \r\n\r\n" +
                $"Date :{commandDto.Date} \r\n\r\n" +
                $"Amount :{commandDto.Amount} \r\n\r\n" +
                $"Liste des produits commandées : {produits}\r\n\r\n" +
                $"Merci pour votre confiance.\r\n\r\n" +
                $"Equipe Maison D'apple,\n" +
                $"Cordialement";

            var user = await _userStore.FindByIdAsync(commandDto.UserId);

            await _mailService.SendEmail(user.Email, subject, body, null, null);
        }
    }
}
