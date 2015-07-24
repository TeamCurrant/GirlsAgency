using System.Data.Entity.Migrations;



namespace GirlsAgencyOracle.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<OracleContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(OracleContext context)
        {

        }
    }
}
