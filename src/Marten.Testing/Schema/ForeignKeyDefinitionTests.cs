﻿using System;
using Marten.Schema;
using Marten.Testing.Documents;
using Shouldly;
using Xunit;

namespace Marten.Testing.Schema
{
    public class ForeignKeyDefinitionTests
    {
        private readonly DocumentMapping _userMapping = DocumentMapping.For<User>();
        private readonly DocumentMapping _issueMapping = DocumentMapping.For<Issue>();

        [Fact]
        public void default_key_name()
        {
            new ForeignKeyDefinition("user_id", _issueMapping, _userMapping).KeyName.ShouldBe("mt_doc_issue_user_id_fkey");
        }

        [Fact]
        public void generate_ddl()
        {
            var expected = string.Join(Environment.NewLine,
                "ALTER TABLE mt_doc_issue",
                "ADD CONSTRAINT mt_doc_issue_user_id_fkey FOREIGN KEY (user_id)",
                "REFERENCES mt_doc_user (id);");
            new ForeignKeyDefinition("user_id", _issueMapping, _userMapping).ToDDL()
                .ShouldBe(expected);
        }
    }
}