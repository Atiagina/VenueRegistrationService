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
