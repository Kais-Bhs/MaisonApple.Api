using AutoMapper;
using BL.Interfaces;
using DAL;
using DTO;
using Entities;

namespace BL.Managers
{
    public class NotificationManager : INotificationManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public NotificationManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<int> Add(NotificationDto NotificationDto)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();

                var notification = _mapper.Map<Notification>(NotificationDto);
                await _unitOfWork.RepoNotification.Add(notification);
                await _unitOfWork.CommitTransactionAsync();
                await _unitOfWork.SaveAsync();
                return notification.Id;
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
                var Notification = await _unitOfWork.RepoNotification.Get(id);
                await _unitOfWork.BeginTransactionAsync();
                await _unitOfWork.RepoNotification.Delete(Notification);
                await _unitOfWork.CommitTransactionAsync();
                await _unitOfWork.SaveAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<IEnumerable<NotificationDto>> Get()
        {
            try
            {
                var Notifications = await _unitOfWork.RepoNotification.Get();
                return _mapper.Map<IEnumerable<NotificationDto>>(Notifications);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<NotificationDto> Get(int id)
        {
            try
            {
                var Notification = await _unitOfWork.RepoNotification.Get(id);
                var NotificationDto = _mapper.Map<NotificationDto>(Notification);
                return NotificationDto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<NotificationDto> Update(NotificationDto NotificationDto)
        {
            try
            {
                var Notification = new Notification();
                _mapper.Map(NotificationDto, Notification);
                await _unitOfWork.BeginTransactionAsync();
                await _unitOfWork.RepoNotification.Update(Notification);
                await _unitOfWork.CommitTransactionAsync();
                await _unitOfWork.SaveAsync();
                return _mapper.Map<NotificationDto>(Notification);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public async Task<IEnumerable<NotificationDto>> GetNotificationByUser(string userId)
        {
            try
            {
                var notifications = await _unitOfWork.RepoNotification.Query(n => n.UserId == userId);

                return _mapper.Map<IEnumerable<NotificationDto>>(notifications);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
