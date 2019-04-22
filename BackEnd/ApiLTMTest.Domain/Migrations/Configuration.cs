namespace ApiLTMTest.Domain.Migrations
{
    using ApiLTMTest.Domain.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApiLTMTest.Domain.Context.ApiLTMTestContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApiLTMTest.Domain.Context.ApiLTMTestContext context)
        {
        }
    }
}
