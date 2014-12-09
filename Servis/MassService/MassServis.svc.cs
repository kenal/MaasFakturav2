using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Mass.Data;
using System.Collections.ObjectModel;
using System.Data.Linq;

namespace MassService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    [ServiceContract]
    public class MassService 
    {
      [OperationContract]
        public bool LoginValidacija(string username, string pass)
    {
        using(DataBaseModelDataContext context = new DataBaseModelDataContext())
    {
        
        var x = from a in context.tbl_korisniks where (a.username==username && a.password==pass) select a;
        if (x != null)
            return true;
        else
            return false;
    }
    }
       
    }
}
