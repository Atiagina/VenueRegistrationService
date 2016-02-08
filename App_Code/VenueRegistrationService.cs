using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "VenueRegistrationService" in code, svc and config file together.
public class VenueRegistrationService : IVenueRegistrationService
{

    ShowTrackerEntities st = new ShowTrackerEntities();
    public int VenueRegistration(VenueLite v){
        Venue vt = new Venue();
        int result = st.usp_RegisterVenue(v.Name, v.Address, v.City, v.State, v.ZipCode, v.Phone, v.Email, v.WebPage, v.AgeRestriction, v.UserName, v.PasswordPlain);
        return result;
    }

   public  int VenueLogin(string username, string password) {

       int result = st.usp_venueLogin(username, password);
       if (result != -1)
       {
           var key = from k in st.VenueLogins
                     where k.VenueLoginUserName.Equals(username)
                     select new { k.VenueKey };
           foreach (var k in key)
           {
               result = (int)k.VenueKey;
           }
       }

       return result;
    }
}
