using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace DBdriver
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IDBDriverToRoster" в коде и файле конфигурации.
    [ServiceContract]
    public interface IDBDriverToRoster
    {

        [OperationContract]
        List<Roster> GetAllRosters();
        
        [OperationContract]
        void AddRoster(Roster roster);
    }
}
