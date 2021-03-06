﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace OpenGate.Admin.EntityFramework.PostgreSQL.Migrations.IdentityServerConfiguration
{
    public partial class AddClientManager : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApiClaims_ApiResources_ApiResourceId",
                table: "ApiClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_ApiProperties_ApiResources_ApiResourceId",
                table: "ApiProperties");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityProperties_IdentityResources_IdentityResourceId",
                table: "IdentityProperties");

            migrationBuilder.DropIndex(
                name: "IX_IdentityResources_Name",
                table: "IdentityResources");

            migrationBuilder.DropIndex(
                name: "IX_Clients_ClientId",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_ApiScopes_Name",
                table: "ApiScopes");

            migrationBuilder.DropIndex(
                name: "IX_ApiResources_Name",
                table: "ApiResources");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityProperties",
                table: "IdentityProperties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApiProperties",
                table: "ApiProperties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApiClaims",
                table: "ApiClaims");

            migrationBuilder.RenameTable(
                name: "IdentityProperties",
                newName: "IdentityResourceProperties");

            migrationBuilder.RenameTable(
                name: "ApiProperties",
                newName: "ApiResourceProperties");

            migrationBuilder.RenameTable(
                name: "ApiClaims",
                newName: "ApiResourceClaims");

            migrationBuilder.RenameIndex(
                name: "IX_IdentityProperties_IdentityResourceId",
                table: "IdentityResourceProperties",
                newName: "IX_IdentityResourceProperties_IdentityResourceId");

            migrationBuilder.RenameIndex(
                name: "IX_ApiProperties_ApiResourceId",
                table: "ApiResourceProperties",
                newName: "IX_ApiResourceProperties_ApiResourceId");

            migrationBuilder.RenameIndex(
                name: "IX_ApiClaims_ApiResourceId",
                table: "ApiResourceClaims",
                newName: "IX_ApiResourceClaims_ApiResourceId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "IdentityResources",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "DisplayName",
                table: "IdentityResources",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "IdentityResources",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "IdentityClaims",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "ClientSecrets",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(4000)",
                oldMaxLength: 4000);

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "ClientSecrets",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ClientSecrets",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(2000)",
                oldMaxLength: 2000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Scope",
                table: "ClientScopes",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "UserCodeType",
                table: "Clients",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProtocolType",
                table: "Clients",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "PairWiseSubjectSalt",
                table: "Clients",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LogoUri",
                table: "Clients",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(2000)",
                oldMaxLength: 2000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FrontChannelLogoutUri",
                table: "Clients",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(2000)",
                oldMaxLength: 2000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Clients",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ClientUri",
                table: "Clients",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(2000)",
                oldMaxLength: 2000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ClientName",
                table: "Clients",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ClientId",
                table: "Clients",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "ClientClaimsPrefix",
                table: "Clients",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BackChannelLogoutUri",
                table: "Clients",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(2000)",
                oldMaxLength: 2000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RedirectUri",
                table: "ClientRedirectUris",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(2000)",
                oldMaxLength: 2000);

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "ClientProperties",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(2000)",
                oldMaxLength: 2000);

            migrationBuilder.AlterColumn<string>(
                name: "Key",
                table: "ClientProperties",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "PostLogoutRedirectUri",
                table: "ClientPostLogoutRedirectUris",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(2000)",
                oldMaxLength: 2000);

            migrationBuilder.AlterColumn<string>(
                name: "Provider",
                table: "ClientIdPRestrictions",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "GrantType",
                table: "ClientGrantTypes",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "Origin",
                table: "ClientCorsOrigins",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "ClientClaims",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "ClientClaims",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "ApiSecrets",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(4000)",
                oldMaxLength: 4000);

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "ApiSecrets",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ApiSecrets",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ApiScopes",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "DisplayName",
                table: "ApiScopes",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ApiScopes",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "ApiScopeClaims",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ApiResources",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "DisplayName",
                table: "ApiResources",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ApiResources",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "IdentityResourceProperties",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(2000)",
                oldMaxLength: 2000);

            migrationBuilder.AlterColumn<string>(
                name: "Key",
                table: "IdentityResourceProperties",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "ApiResourceProperties",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(2000)",
                oldMaxLength: 2000);

            migrationBuilder.AlterColumn<string>(
                name: "Key",
                table: "ApiResourceProperties",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "ApiResourceClaims",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200);

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityResourceProperties",
                table: "IdentityResourceProperties",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApiResourceProperties",
                table: "ApiResourceProperties",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApiResourceClaims",
                table: "ApiResourceClaims",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ClientManagers",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    ClientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientManagers", x => new { x.ClientId, x.UserId });
                    table.ForeignKey(
                        name: "FK_ClientManagers_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ApiResourceClaims_ApiResources_ApiResourceId",
                table: "ApiResourceClaims",
                column: "ApiResourceId",
                principalTable: "ApiResources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApiResourceProperties_ApiResources_ApiResourceId",
                table: "ApiResourceProperties",
                column: "ApiResourceId",
                principalTable: "ApiResources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityResourceProperties_IdentityResources_IdentityResour~",
                table: "IdentityResourceProperties",
                column: "IdentityResourceId",
                principalTable: "IdentityResources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApiResourceClaims_ApiResources_ApiResourceId",
                table: "ApiResourceClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_ApiResourceProperties_ApiResources_ApiResourceId",
                table: "ApiResourceProperties");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityResourceProperties_IdentityResources_IdentityResour~",
                table: "IdentityResourceProperties");

            migrationBuilder.DropTable(
                name: "ClientManagers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityResourceProperties",
                table: "IdentityResourceProperties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApiResourceProperties",
                table: "ApiResourceProperties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApiResourceClaims",
                table: "ApiResourceClaims");

            migrationBuilder.RenameTable(
                name: "IdentityResourceProperties",
                newName: "IdentityProperties");

            migrationBuilder.RenameTable(
                name: "ApiResourceProperties",
                newName: "ApiProperties");

            migrationBuilder.RenameTable(
                name: "ApiResourceClaims",
                newName: "ApiClaims");

            migrationBuilder.RenameIndex(
                name: "IX_IdentityResourceProperties_IdentityResourceId",
                table: "IdentityProperties",
                newName: "IX_IdentityProperties_IdentityResourceId");

            migrationBuilder.RenameIndex(
                name: "IX_ApiResourceProperties_ApiResourceId",
                table: "ApiProperties",
                newName: "IX_ApiProperties_ApiResourceId");

            migrationBuilder.RenameIndex(
                name: "IX_ApiResourceClaims_ApiResourceId",
                table: "ApiClaims",
                newName: "IX_ApiClaims_ApiResourceId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "IdentityResources",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DisplayName",
                table: "IdentityResources",
                type: "character varying(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "IdentityResources",
                type: "character varying(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "IdentityClaims",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "ClientSecrets",
                type: "character varying(4000)",
                maxLength: 4000,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "ClientSecrets",
                type: "character varying(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ClientSecrets",
                type: "character varying(2000)",
                maxLength: 2000,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Scope",
                table: "ClientScopes",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserCodeType",
                table: "Clients",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProtocolType",
                table: "Clients",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PairWiseSubjectSalt",
                table: "Clients",
                type: "character varying(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LogoUri",
                table: "Clients",
                type: "character varying(2000)",
                maxLength: 2000,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FrontChannelLogoutUri",
                table: "Clients",
                type: "character varying(2000)",
                maxLength: 2000,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Clients",
                type: "character varying(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ClientUri",
                table: "Clients",
                type: "character varying(2000)",
                maxLength: 2000,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ClientName",
                table: "Clients",
                type: "character varying(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ClientId",
                table: "Clients",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ClientClaimsPrefix",
                table: "Clients",
                type: "character varying(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BackChannelLogoutUri",
                table: "Clients",
                type: "character varying(2000)",
                maxLength: 2000,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RedirectUri",
                table: "ClientRedirectUris",
                type: "character varying(2000)",
                maxLength: 2000,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "ClientProperties",
                type: "character varying(2000)",
                maxLength: 2000,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Key",
                table: "ClientProperties",
                type: "character varying(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PostLogoutRedirectUri",
                table: "ClientPostLogoutRedirectUris",
                type: "character varying(2000)",
                maxLength: 2000,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Provider",
                table: "ClientIdPRestrictions",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "GrantType",
                table: "ClientGrantTypes",
                type: "character varying(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Origin",
                table: "ClientCorsOrigins",
                type: "character varying(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "ClientClaims",
                type: "character varying(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "ClientClaims",
                type: "character varying(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "ApiSecrets",
                type: "character varying(4000)",
                maxLength: 4000,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "ApiSecrets",
                type: "character varying(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ApiSecrets",
                type: "character varying(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ApiScopes",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DisplayName",
                table: "ApiScopes",
                type: "character varying(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ApiScopes",
                type: "character varying(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "ApiScopeClaims",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ApiResources",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DisplayName",
                table: "ApiResources",
                type: "character varying(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ApiResources",
                type: "character varying(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "IdentityProperties",
                type: "character varying(2000)",
                maxLength: 2000,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Key",
                table: "IdentityProperties",
                type: "character varying(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "ApiProperties",
                type: "character varying(2000)",
                maxLength: 2000,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Key",
                table: "ApiProperties",
                type: "character varying(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "ApiClaims",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityProperties",
                table: "IdentityProperties",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApiProperties",
                table: "ApiProperties",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApiClaims",
                table: "ApiClaims",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityResources_Name",
                table: "IdentityResources",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clients_ClientId",
                table: "Clients",
                column: "ClientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApiScopes_Name",
                table: "ApiScopes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApiResources_Name",
                table: "ApiResources",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ApiClaims_ApiResources_ApiResourceId",
                table: "ApiClaims",
                column: "ApiResourceId",
                principalTable: "ApiResources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApiProperties_ApiResources_ApiResourceId",
                table: "ApiProperties",
                column: "ApiResourceId",
                principalTable: "ApiResources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityProperties_IdentityResources_IdentityResourceId",
                table: "IdentityProperties",
                column: "IdentityResourceId",
                principalTable: "IdentityResources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
