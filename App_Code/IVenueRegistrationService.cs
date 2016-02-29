using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IVenueRegistrationService" in both code and config file together.
[ServiceContract]
public interface IVenueRegistrationService
{
    [OperationContract]
    int VenueRegistration(VenueLite v);

   [OperationContract]
    int VenueLogin(string username, string password);

   [OperationContract]
   int AddArtist(ArtistLite al);

   [OperationContract]
   int AddShow(ShowLite sl);

   [OperationContract]
   int AddShowDetails(ShowDetailsLite sdl);

}

[DataContract]

public class VenueLite
{
    [DataMember]
    public string Name { set; get; }

    [DataMember]
    public string Address { set; get; }

    [DataMember]
    public string City { set; get;}

    [DataMember]
    public string State { set; get; }

    [DataMember]
    public string ZipCode { set; get; }

    [DataMember]
    public string Phone { set; get; }

    [DataMember]
    public string Email { set; get; }

    [DataMember]
    public string WebPage { set; get; }

    [DataMember]
    public int AgeRestriction { set; get; }

    [DataMember]
    public string UserName { set; get; }

    [DataMember]
    public string PasswordPlain { set; get; }
}

[DataContract]
public class ArtistLite
{
    [DataMember]
    public string ArtistName { set; get; }

    [DataMember]
    public string Email { set; get; }

    [DataMember]
    public string WebPage { set; get; }


}

[DataContract]
public class ShowLite
{
   /* [DataMember]
    public string VenueName
    { set; get; } */

    [DataMember]
    public string ShowName { set; get; }

    [DataMember]
    public DateTime ShowDate { set; get; }

    [DataMember]
    public TimeSpan ShowTime { set; get; }

    [DataMember]
    public string ShowTicket { set; get; }

    [DataMember]
    public int VenueKey { set; get; }

}

[DataContract]

public class ShowDetailsLite
{

    
    [DataMember]
   public List<string> ArtistNames
   { set; get; }

    [DataMember]
    public int ArtistKey { set; get; }

    [DataMember]
    public TimeSpan ShowDetailArtistStartTime { set; get; }

    [DataMember]
    public string ShowDetailAdditional { set; get; }

    [DataMember]
    public int ShowKey { set; get; }

    [DataMember]
    public string ShowName { set; get; }

}
