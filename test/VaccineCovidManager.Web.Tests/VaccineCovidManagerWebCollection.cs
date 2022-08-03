using VaccineCovidManager.MongoDB;
using Xunit;

namespace VaccineCovidManager;

[CollectionDefinition(VaccineCovidManagerTestConsts.CollectionDefinitionName)]
public class VaccineCovidManagerWebCollection : VaccineCovidManagerMongoDbCollectionFixtureBase
{

}
