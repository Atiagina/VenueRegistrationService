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


   public int AddArtist(ArtistLite al)
   {
       int result = 1;
       Artist a = new Artist();
       a.ArtistName = al.ArtistName;
       a.ArtistEmail = al.Email;
       a.ArtistWebPage = al.WebPage;
       a.ArtistDateEntered = DateTime.Now;


       try
       {

           st.Artists.Add(a);
           st.SaveChanges();
       }
       catch (Exception ex)
       {
           result = 0;
           throw ex;
       }

       return result;
      
   }

   public int AddShow(ShowLite sl)
   {
       int result = 1;


       Show s = new Show();
       

       var vk = from v in st.Shows
                where v.Venue.VenueName.Equals(sl.ShowName)
                select new { v.VenueKey };

       s.VenueKey = sl.VenueKey;
       s.ShowName = sl.ShowName;
       s.ShowDate = sl.ShowDate;
       s.ShowTime = sl.ShowTime;
       s.ShowTicketInfo = sl.ShowTicket;
       s.ShowDateEntered = DateTime.Now;
 
       try
       {

           st.Shows.Add(s);
           st.SaveChanges();
       }
       catch (Exception ex)
       {
           result = 0;
           throw ex;
       }
       return result;
   }

   public int AddShowDetails(ShowDetailsLite sdl)
   {
       int result = 1;


       ShowDetail sd = new ShowDetail();
     

       var shk = from sk in st.Shows
              where sk.ShowName.Equals(sdl.ShowName)
                select new { sk.ShowKey };

       int skey = 0;

       foreach (var i in shk)
       {
           skey = (int)i.ShowKey;
       }

       var ark = from ak in st.Artists
                 where ak.ArtistName.Equals(sdl.ArtistName)
                 select new { ak.ArtistKey };


    
       int akey = 0;

       foreach (var c in ark)
       {
           akey = (int)c.ArtistKey;
       }
      

       sd.ArtistKey = akey;
       sd.ShowKey = skey;
       sd.ShowDetailArtistStartTime = sdl.ShowDetailArtistStartTime;
       sd.ShowDetailAdditional = sdl.ShowDetailAdditional;


       try
       {

           st.ShowDetails.Add(sd);
           st.SaveChanges();
       }
       catch (Exception ex)
       {
           result = 0;
           throw ex;
       }

       return result;

   }
}
