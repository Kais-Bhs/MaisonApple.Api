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
        public CommandManager(IUnitOfWork unitOfWork, IMapper mapper,UserManager<User> userManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userStore = userManager;
        }
        public async Task<int> Add(CommandDto commandDto)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();

                var payment = _mapper.Map<Command>(commandDto);
                await _unitOfWork.RepoCommand.Add(payment);
                await _unitOfWork.CommitTransactionAsync();
                await _unitOfWork.SaveAsync();

                foreach (var orderDto in commandDto.Orders)
                {
                   var order = _mapper.Map<Order>(orderDto);
                    order.PaymentId = payment.Id;
                  
                    await _unitOfWork.BeginTransactionAsync();
                    await _unitOfWork.RepoOrder.Add(order);
                    await _unitOfWork.CommitTransactionAsync();
                    await _unitOfWork.SaveAsync();
               
                }
        
                return payment.Id;
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
                    var orders = (await _unitOfWork.RepoOrder.Query(o => o.PaymentId == commandDto.Id)).ToList();
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

        public async Task AcceptCommmand(CommandDto commandDto)
        {
            try
            {
                foreach (var orderDto in commandDto.Orders)
                {
                    var product = await _unitOfWork.RepoProduct.Get(orderDto.ProductId);
                    product.StockQuantity -= orderDto.Quantity;
                    await _unitOfWork.BeginTransactionAsync();
                    await _unitOfWork.RepoProduct.Update(product);
                    await _unitOfWork.CommitTransactionAsync();
                    await _unitOfWork.SaveAsync();
                    if (product.StockQuantity < 3)
                    {
                        var adminNotification = new Notification { Date = DateTime.Now, Title = $"Stock du produit {product.Name} est en basse" };

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
                }
                commandDto.CommandStatus = CommandStatusDto.Accepted;
                    var command = _mapper.Map<Command>(commandDto);
                    var notification = new Notification { Date = DateTime.Now, UserId = commandDto.UserId, Title = $"Votre Commande de reference {commandDto.Reference} est bien acceptée" };
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

        public async Task RejectCommmand(int commandId)
        {
            try
            {
                var commandDto = await Get(commandId);

                    commandDto.CommandStatus = CommandStatusDto.Rejected;
                    var command = _mapper.Map<Command>(commandDto);
                    var notification = new Notification { Date = DateTime.Now, UserId = commandDto.UserId, Title = $"Votre Commande de reference {commandDto.Reference} est bien rejetée" };
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
    }
}
