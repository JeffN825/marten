﻿using System.Linq;
using Marten.Linq;
using Marten.Services;
using Marten.Testing.Documents;
using Shouldly;
using Xunit;

namespace Marten.Testing.Linq
{
    public class select_transformations_Tests : DocumentSessionFixture<NulloIdentityMap>
    {
        [Fact]
        public void build_query_for_a_single_field()
        {
            theSession.Query<User>().Select(x => x.UserName).FirstOrDefault().ShouldBeNull();

            var cmd = theSession.Query<User>().Select(x => x.UserName).ToCommand(FetchType.FetchMany);

            cmd.CommandText.ShouldBe("select d.data ->> 'UserName' from mt_doc_user as d");
        }
    }
}