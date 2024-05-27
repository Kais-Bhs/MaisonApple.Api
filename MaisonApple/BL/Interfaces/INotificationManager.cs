using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace BL.Interfaces
{
    public interface INotificationManager
    {
        Task<int> Add(NotificationDto NotificationDto);
        Task Delete(int id);

        Task<IEnumerable<NotificationDto>> Get();

        Task<NotificationDto> Get(int id);

        Task<NotificationDto> Update(NotificationDto NotificationDto);
    }
}
