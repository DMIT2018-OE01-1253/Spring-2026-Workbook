<Query Kind="Program">
  <Connection>
    <ID>2837cd29-a98c-4fc4-b5d3-5efbababb91f</ID>
    <NamingServiceVersion>3</NamingServiceVersion>
    <Persist>true</Persist>
    <Server>(local)</Server>
    <AllowDateOnlyTimeOnly>true</AllowDateOnlyTimeOnly>
    <UseMicrosoftDataSqlClient>true</UseMicrosoftDataSqlClient>
    <DisplayName>Contoso</DisplayName>
    <EncryptTraffic>true</EncryptTraffic>
    <DeferDatabasePopulation>true</DeferDatabasePopulation>
    <Database>Contoso</Database>
    <MapXmlToString>false</MapXmlToString>
    <DriverData>
      <SkipCertificateCheck>true</SkipCertificateCheck>
    </DriverData>
  </Connection>
</Query>

void Main()
{
	string lastName = "a";
	TestMessage().Dump();
	"Customers that last name contains a character a".Dump();
	GetAllCustomersContainsLastName(lastName).Dump();	
}

// You can define other methods, fields, classes and namespaces here
public List<Customer> GetAllCustomersContainsLastName(string lastName) 
{
	return Customers
			.Where(x => x.LastName.Contains(lastName))
			.Select(x => x)
			.ToList();
}

public string TestMessage()
{
	return "This is a test.";
}