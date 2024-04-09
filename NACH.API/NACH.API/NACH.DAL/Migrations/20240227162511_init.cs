using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NACH.DAL.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ACCT_TYPE_MST",
                columns: table => new
                {
                    BANK_CD = table.Column<string>(type: "varchar(4)", unicode: false, maxLength: 4, nullable: false),
                    BRANCH_CD = table.Column<string>(type: "varchar(4)", unicode: false, maxLength: 4, nullable: false),
                    TRAN_CD = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ACCT_TYPE = table.Column<string>(type: "varchar(4)", unicode: false, maxLength: 4, nullable: false),
                    TYPE_NM = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    CBS_CD = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    VERIFY_STATUS = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: false),
                    CREATED_DT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MODIFIED_DT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CREATED_BY = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    MODIFIED_BY = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    CREATED_IP = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    MODIFIED_IP = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACCT_TYPE_MST", x => new { x.BANK_CD, x.BRANCH_CD, x.TRAN_CD });
                });

            migrationBuilder.CreateTable(
                name: "BANK_IIN_MST",
                columns: table => new
                {
                    BRANCH_CD = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    TRAN_CD = table.Column<int>(type: "int", maxLength: 11, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BANK_CODE = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    BANK_NM = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IIN_STATUS = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    BANK_IIN = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    ENTRY_BY = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ENTRY_DT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ENTRY_PC_NM = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    MODIFY_BY = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    MODIFY_DT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MODIFY_PC_NM = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    TYPE_OF_BANK = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    IFSC_STATUS = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    IFSC = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    MICR_STATUS = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    MICR = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: true),
                    APBS_FLAG = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    ACHCR_FLAG = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    ACHDR_FLAG = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BANK_IIN_MST", x => new { x.BANK_CODE, x.BRANCH_CD, x.TRAN_CD });
                });

            migrationBuilder.CreateTable(
                name: "BANK_MASTER",
                columns: table => new
                {
                    BANK_CD = table.Column<string>(type: "varchar(6)", unicode: false, maxLength: 6, nullable: false),
                    BANK_IIN = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    BANK_NM = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    BANK_CATEGORY = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    ADDRESS = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    CITY_NM = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    REG_DT = table.Column<DateTime>(type: "datetime2", unicode: false, nullable: true),
                    BSR_CODE = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    UNIQUE_FIULD = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CONTACT_PERSON = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    DESIGNATION = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    PIN_CODE = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    STATE_CD = table.Column<int>(type: "int", unicode: false, maxLength: 2, nullable: true),
                    COUNTRY_CD = table.Column<int>(type: "int", unicode: false, maxLength: 2, nullable: true),
                    PHONE = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    MOBILE = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    EMAIL = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    FAX = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: true),
                    UTILITY_VERSION = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    DATA_STARUCTURE_VERSION = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    CTR_COUNT = table.Column<int>(type: "int", unicode: false, nullable: true),
                    NTR_COUNT = table.Column<int>(type: "int", unicode: false, nullable: true),
                    STR_COUNT = table.Column<int>(type: "int", unicode: false, nullable: true),
                    CCR_COUNT = table.Column<int>(type: "int", unicode: false, nullable: true),
                    CREATED_DT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MODIFIED_DT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CREATED_BY = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    MODIFIED_BY = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    CREATED_IP = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    MODIFIED_IP = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BANK_MASTER", x => x.BANK_CD);
                });

            migrationBuilder.CreateTable(
                name: "BRANCH_MST",
                columns: table => new
                {
                    BANK_CD = table.Column<string>(type: "varchar(6)", unicode: false, maxLength: 6, nullable: false),
                    BRANCH_CD = table.Column<string>(type: "varchar(6)", unicode: false, maxLength: 6, nullable: false),
                    BRANCH_NM = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    ADDRESS = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CITY_NM = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    PINCODE = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    STATE_CD = table.Column<int>(type: "int", maxLength: 2, nullable: true),
                    COUNTRY_CD = table.Column<int>(type: "int", nullable: true),
                    CONTACT_PERSON = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    PHONE = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    MOBILE = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    EMAIL = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    MICR_CD = table.Column<string>(type: "varchar(12)", unicode: false, maxLength: 12, nullable: true),
                    IFSC_CD = table.Column<string>(type: "varchar(11)", unicode: false, maxLength: 11, nullable: true),
                    BASE_MICR_BR = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: true),
                    FAX = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: true),
                    CBS_CD = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    CREATED_DT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MODIFIED_DT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CREATED_BY = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    MODIFIED_BY = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    CREATED_IP = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    MODIFIED_IP = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BRANCH_MST", x => new { x.BANK_CD, x.BRANCH_CD });
                });

            migrationBuilder.CreateTable(
                name: "CANCEL_REASON_CODE",
                columns: table => new
                {
                    BANK_CD = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    TRAN_CD = table.Column<int>(type: "int", maxLength: 11, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    REASON_CD = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    ASSIGN_BY = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    CREATED_DT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MODIFIED_DT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CREATED_BY = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    MODIFIED_BY = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    CREATED_IP = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    MODIFIED_IP = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CANCEL_REASON_CODE", x => new { x.BANK_CD, x.TRAN_CD, x.REASON_CD });
                });

            migrationBuilder.CreateTable(
                name: "CITY_MST",
                columns: table => new
                {
                    TRAN_CD = table.Column<int>(type: "int", maxLength: 11, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CITY_NM = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    STATE_CD = table.Column<int>(type: "int", maxLength: 11, nullable: true),
                    STATUS = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: false),
                    CREATED_DT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MODIFIED_DT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CREATED_BY = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    MODIFIED_BY = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    CREATED_IP = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    MODIFIED_IP = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CITY_MST", x => x.TRAN_CD);
                });

            migrationBuilder.CreateTable(
                name: "COMP_MST",
                columns: table => new
                {
                    SELLER_ID = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    BANK_CD = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    USER_ID = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    TRAN_DT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PASSWORD = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    COMP_NM = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MOBILE_NO1 = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    MOBILE_NO2 = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    EMAIL_ID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ADDRESS1 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ADDRESS2 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CITY_CD = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    STATE_CD = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    COUNTRY_CD = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PIN_CODE = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    REGISTRATION_DT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LICENCE_DT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LICENCE_NUMERIC = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    STATUS = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    CREATED_DT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MODIFIED_DT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CREATED_BY = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    MODIFIED_BY = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    CREATED_IP = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    MODIFIED_IP = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COMP_MST", x => new { x.SELLER_ID, x.BANK_CD, x.USER_ID });
                });

            migrationBuilder.CreateTable(
                name: "COUNTRY_MST",
                columns: table => new
                {
                    TRAN_CD = table.Column<int>(type: "int", unicode: false, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    COUNTRY_NM = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    SORT_NM = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: true),
                    PHONE_CODE = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: true),
                    CREATED_DT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MODIFIED_DT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CREATED_BY = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    MODIFIED_BY = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    CREATED_IP = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    MODIFIED_IP = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COUNTRY_MST", x => x.TRAN_CD);
                });

            migrationBuilder.CreateTable(
                name: "DATA_IMP_TEMPLATE_DTL",
                columns: table => new
                {
                    BANK_CD = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    BRANCH_CD = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    TRAN_CD = table.Column<int>(type: "int", maxLength: 20, nullable: false),
                    SR_CD = table.Column<int>(type: "int", maxLength: 6, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DB_COLUMN_NM = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    COL_PK_FLAG = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    DATA_TYPE = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    NUM_SCALE = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    VALIDATION_SQL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    COL_SEQ_NO = table.Column<int>(type: "int", maxLength: 6, nullable: false),
                    COL_SIZE = table.Column<int>(type: "int", maxLength: 20, nullable: false),
                    FROM_VAL = table.Column<int>(type: "int", maxLength: 20, nullable: true),
                    TO_VAL = table.Column<int>(type: "int", maxLength: 20, nullable: true),
                    DEFAULT_VAL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    COL_DESC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    COL_FORMAT = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DATA_IMP_TEMPLATE_DTL", x => new { x.BANK_CD, x.BRANCH_CD, x.TRAN_CD, x.SR_CD });
                });

            migrationBuilder.CreateTable(
                name: "DATA_IMP_TEMPLATE_HDR",
                columns: table => new
                {
                    BANK_CD = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    BRANCH_CD = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    TRAN_CD = table.Column<int>(type: "int", maxLength: 20, nullable: false),
                    TRAN_DT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ECB_TABLE_NM = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    FILE_TYPE = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    FILE_PATH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ACTIVE_STATUS = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    REMARKS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ENTRY_BY = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    ENTRY_DT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MODIFY_BY = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    MODIFY_DT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ENTRY_PC_NM = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    MODIFY_PC_NM = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    DELIMITER_CD = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    DELIMITER_SIGN = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DATA_IMP_TEMPLATE_HDR", x => new { x.BANK_CD, x.BRANCH_CD, x.TRAN_CD });
                });

            migrationBuilder.CreateTable(
                name: "DUMMY",
                columns: table => new
                {
                    row_no = table.Column<int>(type: "int", maxLength: 1, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DUMMY", x => x.row_no);
                });

            migrationBuilder.CreateTable(
                name: "FILE_TYPE_MST",
                columns: table => new
                {
                    FILE_TYPE_CD = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    FILE_TYPE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FILE_FORMAT = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FILE_TYPE_MST", x => x.FILE_TYPE_CD);
                });

            migrationBuilder.CreateTable(
                name: "FORM_MST",
                columns: table => new
                {
                    FORM_NM = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FORM_CAPTION = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SEQ_NO = table.Column<int>(type: "int", maxLength: 11, nullable: true),
                    TYPE = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    MAIN_FORM = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    FORM_SAVE = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    FORM_UPDATE = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    FORM_DELETE = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    FORM_SHOW = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    FORM_VIEW = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    FORM_AUTO_AUTH = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FORM_MST", x => x.FORM_NM);
                });

            migrationBuilder.CreateTable(
                name: "INW_CLR_CHQ_DTL",
                columns: table => new
                {
                    TRAN_CD = table.Column<int>(type: "int", maxLength: 11, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ACCT_CD = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CHEQUE_NO = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    TRAN_DT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BANK_CD = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    BRANCH_CD = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    ACCT_TYPE = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    CUSTOMER_ID = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    CHQ_DT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BENF_NM = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CHQ_AMT = table.Column<decimal>(type: "decimal(14,2)", nullable: true),
                    REMARKS = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CHQ_IMG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    REASON_CD = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    EXP_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EXP_STATUS = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    IP_ADDRESS = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    SHORT_ACCT = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INW_CLR_CHQ_DTL", x => new { x.TRAN_CD, x.ACCT_CD, x.CHEQUE_NO });
                });

            migrationBuilder.CreateTable(
                name: "LOGIN_MST",
                columns: table => new
                {
                    USER_ID = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    BANK_CD = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    USER_PASS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PASS_SALT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BRANCH_CD = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    USER_NM = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ACTIVE_STATUS = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    ROLE_CD = table.Column<int>(type: "int", nullable: false),
                    REMARKS = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    TOKEN_ID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LAST_ACTIVITY = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LAST_ACTIVITY_TYPE = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    OFFICER_NM = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    DESIGNATION = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    ADDRESS = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CITY_NM = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PINCODE = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    STATE_CD = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    COUNTRY_CD = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    PHONE = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    MOBILE_NO = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    FAX = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    EMAIL_ID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OTP_CD = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    OTP_STATUS = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    LAST_LOGIN_DT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CUST_USER_NM = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    RESET_FLAG = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    NPCI_USER = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    LOCK_OUT_END = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LOCK_OUT_ENABLED = table.Column<bool>(type: "bit", nullable: false),
                    ACCESS_FAILED_COUNT = table.Column<int>(type: "int", nullable: false),
                    REFRESH_TOKEN = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    REFRESH_TOKEN_EXPIRY_TIME = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SESSION_ID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CREATED_DT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MODIFIED_DT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CREATED_BY = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    MODIFIED_BY = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    CREATED_IP = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    MODIFIED_IP = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOGIN_MST", x => x.USER_ID);
                });

            migrationBuilder.CreateTable(
                name: "MAIL_SMS_TEMP_MST",
                columns: table => new
                {
                    TYPE = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    NACH_TYPE = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TEMP_NM = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TRAN_CD = table.Column<int>(type: "int", maxLength: 20, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TEMP_ID = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    SUBJECT = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MESSAGE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SMS_TEMP_ID = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    STATUS = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    INT_CUST_STATUS = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    DEFAULT_1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DEFAULT_2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DEFAULT_3 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ENTRY_BY = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ENTRY_DT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MODIFY_BY = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    MODIFY_DT = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MAIL_SMS_TEMP_MST", x => new { x.TYPE, x.NACH_TYPE, x.TEMP_NM });
                });

            migrationBuilder.CreateTable(
                name: "MANDATE_MST",
                columns: table => new
                {
                    BANK_CD = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    BRANCH_CD = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    TRAN_CD = table.Column<int>(type: "int", maxLength: 11, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TRAN_DT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    REF_NO = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    MNDT_FILE_NM = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MSG_ID = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: true),
                    CRE_DT_TM = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    SPN_BANK_CORP_ID = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: true),
                    SPN_BANK_IFSC = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    SPN_BANK_NM = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DEST_BANK_IFSC = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    DEST_BANK_NM = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MNDT_REQ_ID = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: true),
                    UMR_NO = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    MNDT_CATEGORY = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    MNDT_TYPE = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: true),
                    SEQ_TYPE = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    FRQCY = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    FRST_COLLTN_DT = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    FNL_COLLTN_DT = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    COLLTN_AMT = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    CR_NM = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CR_ACCT_NO = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: true),
                    CR_AGT_IFSC = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    CR_AGT_NM = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DR_NM = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DR_REF_NO = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: true),
                    DR_SCHEME = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: true),
                    DR_PHNO = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: true),
                    DR_MOBNO = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: true),
                    DR_EMAIL = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DR_OTHER = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: true),
                    DR_ACCT_NO = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: true),
                    DR_ACCT_TYPE = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: true),
                    DR_AGT_IFSC = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    DR_AGT_NM = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MNDT_F_IMG = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    MNDT_D_IMG = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    FILE_NM = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    STATUS = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MANDATE_MST", x => new { x.BANK_CD, x.BRANCH_CD, x.TRAN_CD });
                });

            migrationBuilder.CreateTable(
                name: "MNDT_DTL",
                columns: table => new
                {
                    TRAN_CD = table.Column<int>(type: "int", maxLength: 11, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BANK_CD = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    BRANCH_CD = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    UMR_NO = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    ACCT_CD = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    TRAN_DT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MNDT_STATUS = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    CANCEL_REASON_CD = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    OTHR_REASON = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    MNDT_REASON_CD = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    MNDT_RESPONSE = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ENTER_DT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ENTER_BY = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    RESPONSE_DT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RESPONSE_BY = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    IP_ADDRESS = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    SMS_SEND = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    MNDT_ACCEPT = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    ACCEPT = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    CHENNAL = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MNDT_DTL", x => new { x.TRAN_CD, x.BANK_CD, x.BRANCH_CD, x.UMR_NO, x.ACCT_CD });
                });

            migrationBuilder.CreateTable(
                name: "MNDT_MST",
                columns: table => new
                {
                    TRAN_CD = table.Column<int>(type: "int", maxLength: 11, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UMR_NO = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    ACCT_CD = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    BANK_CD = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    BRANCH_CD = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    CUSTOMER_ID = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    MNDT_CREDT_TE = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    SPNSR_BANK_NM = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SPNSR_IFSC_CD = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    MNDT_NM = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MNDT_AMT = table.Column<decimal>(type: "decimal(14,2)", nullable: true),
                    MNDT_REMARKS = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    MNDT_FREQUENCY = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    ENTER_DT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ENTER_BY = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    RESPONSE_DT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RESPONSE_BY = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    IP_ADDRESS = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MNDT_MST", x => new { x.TRAN_CD, x.UMR_NO, x.ACCT_CD });
                });

            migrationBuilder.CreateTable(
                name: "NACH_ACCOUNT_MST",
                columns: table => new
                {
                    ENTERED_BANK_CD = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    ENTERED_BRANCH_CD = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    ACCT_NO = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TRAN_DT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BRANCH_CD = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    CUSTOMER_NO = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    PROD_TYPE = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    INT_TYPE = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    ACCT_NM = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TYPE_ID = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    AADHAAR_NO = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    PAN_NO = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    SEC_ACCT_NM = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SEC_PAN_NO = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    MOBILE_NO = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    STATUS = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    ENTRY_BY = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ENTRY_DT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ENTRY_PC_NM = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    MODIFY_BY = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    MODIFY_DT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MODIFY_PC_NM = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    BR_MICR_CD = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    OLD_ACCT_TYPE = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    OLD_ACCT_NO = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ACCT_NO2 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NACH_ACCOUNT_MST", x => new { x.ENTERED_BANK_CD, x.ENTERED_BRANCH_CD, x.ACCT_NO });
                });

            migrationBuilder.CreateTable(
                name: "NACH_APBS_REG_MST",
                columns: table => new
                {
                    ENTERED_BANK_CD = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    ENTERED_BRANCH_CD = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    TRAN_CD = table.Column<int>(type: "int", maxLength: 20, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TRAN_DT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AADHAAR_NO = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    BRANCH_CD = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    PROD_TYPE = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    ACCT_NO = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    STATUS = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    DEACTIVE_DT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UPLOAD = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    UPLOAD_DT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UPLOAD_FILE_NM = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PREVIOUS_BANK_FLAG = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    PREVIOUS_BANK_IIN = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    MAKE_BY = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    MAKE_DT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MAKE_PC_NM = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    VERIFY_BY = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    VERIFY_DT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VERIFY_PC_NM = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    VERIFY_STATUS = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    REJECT_REASON = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    REJECT_OTHER_REASON = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NACH_APBS_REG_MST", x => new { x.ENTERED_BANK_CD, x.ENTERED_BRANCH_CD, x.TRAN_CD });
                });

            migrationBuilder.CreateTable(
                name: "NACH_APBS_UID_RESP",
                columns: table => new
                {
                    ENTERED_BANK_CD = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    ENTERED_BRANCH_CD = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    TRAN_CD = table.Column<int>(type: "int", maxLength: 20, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TRAN_DT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FILE_NM = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AADHAAR_NO = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    FILE_CD = table.Column<int>(type: "int", maxLength: 11, nullable: true),
                    MAPPED_IIN = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    SCHEME = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    MANDATE_CUST_DATE = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    MAPPING_STATUS = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    UID_RESULT = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ACCEPTED = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    UID_REASON_CODE = table.Column<int>(type: "int", maxLength: 11, nullable: true),
                    MAKE_BY = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    MAKE_DT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MAKE_PC_NM = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    VERIFY_BY = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    VERIFY_DT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VERIFY_PC_NM = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    VERIFY_STATUS = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    REJECT_REASON = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    REJECT_OTHER_REASON = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NACH_APBS_UID_RESP", x => new { x.ENTERED_BANK_CD, x.ENTERED_BRANCH_CD, x.TRAN_CD, x.TRAN_DT, x.FILE_NM, x.AADHAAR_NO });
                });

            migrationBuilder.CreateTable(
                name: "NACH_CONFIG_COLUMN",
                columns: table => new
                {
                    BANK_CD = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    PARA_CD = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PARA_TYPE = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PARA_VALUE = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    COL_FLAG = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NACH_CONFIG_COLUMN", x => new { x.BANK_CD, x.PARA_CD, x.PARA_TYPE });
                });

            migrationBuilder.CreateTable(
                name: "NACH_DBTL_AV_DTL",
                columns: table => new
                {
                    ENTERED_BANK_CD = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    ENTERED_BRANCH_CD = table.Column<int>(type: "int", maxLength: 5, nullable: false),
                    TRAN_CD = table.Column<int>(type: "int", maxLength: 20, nullable: false),
                    SR_CD = table.Column<int>(type: "int", maxLength: 20, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RECORD_ID = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    RECORD_REF_NO = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    BEN_IFSC_CD = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    BEN_ACCT_NO = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: true),
                    BEN_ACCT_NM = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LPG_CONS_ID = table.Column<string>(type: "nvarchar(17)", maxLength: 17, nullable: true),
                    VALID_FLAG = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    BEN_NM_FLAG = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    RSP_BEN_NM = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AADHAAR_NO = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    BRANCH_CD = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    PROD_TYPE = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    ACCT_NO = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    JOINT_ACCT_FLAG = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    PRIMARY_PAN_NO = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    SECONDARY_PAN_NO = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    PRIMARY_ACCT_NAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SECONDARY_ACCT_NAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ACCT_TYPE = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NACH_DBTL_AV_DTL", x => new { x.ENTERED_BANK_CD, x.ENTERED_BRANCH_CD, x.TRAN_CD, x.SR_CD });
                });

            migrationBuilder.CreateTable(
                name: "NACH_DBTL_AV_MST",
                columns: table => new
                {
                    ENTERED_BANK_CD = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    ENTERED_BRANCH_CD = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    TRAN_CD = table.Column<int>(type: "int", maxLength: 20, nullable: false),
                    TRAN_DT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CONFIG_CD = table.Column<int>(type: "int", maxLength: 20, nullable: true),
                    FILE_NM = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    HEADER_ID = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    ORG_CD = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    RSP_CD = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    FILE_UPDT = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    FILE_REF_NO = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    TOTAL_TRN = table.Column<int>(type: "int", maxLength: 11, nullable: true),
                    FILLER = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RET_CONFIG_CD = table.Column<int>(type: "int", maxLength: 20, nullable: true),
                    ENTRY_BY = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ENTRY_DT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ENTRY_PC_NM = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    MODIFY_BY = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    MODIFY_DT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MODIFY_PC_NM = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    VERIFY_BY = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    VERIFY_DT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VERIFY_PC_NM = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    VERIFY_STATUS = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    REJECT_REASON = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    REJECT_OTHER_REASON = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DBTL_TYPE = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    NACH_TYPE = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NACH_DBTL_AV_MST", x => new { x.ENTERED_BANK_CD, x.ENTERED_BRANCH_CD, x.TRAN_CD });
                });

            migrationBuilder.CreateTable(
                name: "NACH_DBTL_OMC_MST",
                columns: table => new
                {
                    TRAN_CD = table.Column<int>(type: "int", maxLength: 11, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BANK_CD = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    CODE = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    OMC_NM = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LPG_ID = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NACH_DBTL_OMC_MST", x => new { x.TRAN_CD, x.BANK_CD, x.CODE });
                });

            migrationBuilder.CreateTable(
                name: "NACH_DBTL_REG_MST",
                columns: table => new
                {
                    ENTERED_BANK_CD = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    ENTERED_BRANCH_CD = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    TRAN_CD = table.Column<int>(type: "int", maxLength: 20, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    REG_DT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BRANCH_CD = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    PROD_TYPE = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    ACCT_NO = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OMC_CD = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LPG_CONS_ID = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    AADHAAR_NO = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    REMARKS = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    STATUS = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    DEACTIVE_DT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UPLOAD = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    UPLOAD_DT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UPLOAD_FILE_NM = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MAKE_BY = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    MAKE_DT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MAKE_PC_NM = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    VERIFY_BY = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    VERIFY_DT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VERIFY_PC_NM = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    VERIFY_STATUS = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    REJECT_REASON = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    REJECT_OTHER_REASON = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NACH_DBTL_REG_MST", x => new { x.ENTERED_BANK_CD, x.ENTERED_BRANCH_CD, x.TRAN_CD });
                });

            migrationBuilder.CreateTable(
                name: "NACH_FILE_CONFIG_DTL",
                columns: table => new
                {
                    BANK_CD = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    TRAN_CD = table.Column<int>(type: "int", maxLength: 20, nullable: false),
                    SR_CD = table.Column<int>(type: "int", maxLength: 11, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CONFIG_FLAG = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    COLUMN_SEQ = table.Column<int>(type: "int", maxLength: 11, nullable: false),
                    VALUE_DESC = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    START = table.Column<int>(type: "int", maxLength: 11, nullable: false),
                    COL_SIZE = table.Column<int>(type: "int", maxLength: 11, nullable: false),
                    END = table.Column<int>(type: "int", maxLength: 11, nullable: false),
                    ALIGNMENT = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    VALUE_TYPE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DEFAULT_VALUE = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    FILL_BY = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    FILL_BY_VALUE = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    VALUE_FORMAT = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MODIFY_BY = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    MODIFY_DT = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NACH_FILE_CONFIG_DTL", x => new { x.BANK_CD, x.TRAN_CD, x.SR_CD, x.CONFIG_FLAG });
                });

            migrationBuilder.CreateTable(
                name: "NACH_FILE_CONFIG_MST",
                columns: table => new
                {
                    BANK_CD = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    TRAN_CD = table.Column<int>(type: "int", maxLength: 20, nullable: false),
                    NACH_TYPE = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CONFIG_NM = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CONFIG_TYPE = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    DELIMITER_CD = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    DELIMITER_SIGN = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    FILE_FORMAT = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    FILE_NM = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SKIP_ROW_FLAG = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    TRN_TYPE = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    TRN_BRANCH_CD = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    TRN_PROD_TYPE = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    TRN_ACCT_NO = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CHRG_FLAG = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    CHRG_BRANCH_CD = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    CHRG_PROD_TYPE = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    CHRG_ACCT_NO = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    RET_TRN_TYPE = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    RET_CHRG_FLAG = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    ENTRY_BY = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ENTRY_DT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ENTRY_PC_NM = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    MODIFY_BY = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    MODIFY_DT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MODIFY_PC_NM = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    CBS_CONFIG_CD = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    RET_CONFIG_CD = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NACH_FILE_CONFIG_MST", x => new { x.BANK_CD, x.TRAN_CD });
                });

            migrationBuilder.CreateTable(
                name: "NACH_FILE_ERROR_LOG",
                columns: table => new
                {
                    ENTERED_BANK_CD = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    ENTERED_BRANCH_CD = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    TRAN_CD = table.Column<int>(type: "int", maxLength: 20, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PROCESS_TYPE = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    FILE_NM = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NACH_FILE_ERROR_LOG", x => new { x.ENTERED_BANK_CD, x.ENTERED_BRANCH_CD, x.TRAN_CD, x.PROCESS_TYPE });
                });

            migrationBuilder.CreateTable(
                name: "NACH_IO_TRN_DTL",
                columns: table => new
                {
                    ENTERED_BANK_CD = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    ENTERED_BRANCH_CD = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    TRAN_CD = table.Column<int>(type: "int", maxLength: 20, nullable: false),
                    SR_CD = table.Column<int>(type: "int", maxLength: 20, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NACH_ID = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    NACH_SEQ_NO = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    TRN_REF_NO = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BRANCH_CD = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    PROD_TYPE = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    ACCT_NO = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DEST_ACCT_NO = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DEST_BANK_IIN = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    DEST_IFSC_MICR = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    DEST_ACCT_TYPE = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    DEST_ACCT_NM = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SPON_BANK_IIN = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    LF_NO = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    UMRN = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    AADHAAR_NO = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    USER_NO = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    USER_NM = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    AMOUNT = table.Column<decimal>(type: "decimal(16,2)", nullable: true),
                    CHECKSUM = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    CONFIRMED = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    STATUS = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    RETURN_REASON_CD = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NACH_IO_TRN_DTL", x => new { x.ENTERED_BANK_CD, x.ENTERED_BRANCH_CD, x.TRAN_CD, x.SR_CD });
                });

            migrationBuilder.CreateTable(
                name: "NACH_IO_TRN_DTL_REPO",
                columns: table => new
                {
                    ENTERED_BANK_CD = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    ENTERED_BRANCH_CD = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    TRAN_CD = table.Column<int>(type: "int", maxLength: 20, nullable: false),
                    SR_CD = table.Column<int>(type: "int", maxLength: 20, nullable: false),
                    ACCT_NO = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AADHAAR_NO = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    CBS_ACCT_OP_DT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CBS_ACCT_NO = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CBS_BRANCH_CD = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    CBS_PROD_TYPE = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    CBS_CUSTOMER_NO = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CBS_INT_TYPE = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    CBS_ACCT_NM = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CBS_AADHAAR_NO = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    CBS_MOBILE_NO = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    CBS_ACCT_STATUS = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    AMOUNT = table.Column<decimal>(type: "decimal(14,2)", nullable: true),
                    FILE_STATUS = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    ACCT_STATUS = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    RETURN_REASON_CD = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    TRN_TYPE = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    UMR_NO = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NACH_IO_TRN_DTL_REPO", x => new { x.ENTERED_BANK_CD, x.ENTERED_BRANCH_CD, x.TRAN_CD, x.SR_CD });
                });

            migrationBuilder.CreateTable(
                name: "NACH_IO_TRN_MST",
                columns: table => new
                {
                    ENTERED_BANK_CD = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    ENTERED_BRANCH_CD = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    TRAN_CD = table.Column<int>(type: "int", maxLength: 20, nullable: false),
                    NACH_TYPE = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    TRAN_DT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CONFIG_CD = table.Column<int>(type: "int", maxLength: 20, nullable: true),
                    RET_CONFIG_CD = table.Column<int>(type: "int", maxLength: 20, nullable: true),
                    FILE_NM = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    NACH_ID = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    BANK_IIN = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    TOTAL_TRN = table.Column<int>(type: "int", maxLength: 20, nullable: true),
                    TOTAL_TRN_AMT = table.Column<double>(type: "float", nullable: true),
                    ST_DATE = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    ST_CYCLE = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    USER_NM = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    USER_NO = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    TRN_REF_NO = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TRN_TYPE = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    GL_BRANCH_CD = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    GL_PROD_TYPE = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    GL_ACCT_NO = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ENTRY_BY = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ENTRY_DT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ENTRY_PC_NM = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    MODIFY_BY = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    MODIFY_DT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MODIFY_PC_NM = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    CBS_CONFIG_CD = table.Column<int>(type: "int", maxLength: 20, nullable: true),
                    VERIFY_BY = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    VERIFY_DT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VERIFY_PC_NM = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    VERIFY_STATUS = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    REJECT_REASON = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    REJECT_OTHER_REASON = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NACH_IO_TRN_MST", x => new { x.ENTERED_BANK_CD, x.ENTERED_BRANCH_CD, x.TRAN_CD });
                });

            migrationBuilder.CreateTable(
                name: "NACH_IW_MANDATE_MST",
                columns: table => new
                {
                    ENTERED_BANK_CD = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    ENTERED_BRANCH_CD = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    TRAN_CD = table.Column<int>(type: "int", maxLength: 20, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TRAN_DT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    REF_NO = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    FILE_NM = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MNDT_FILE_NM = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MSG_ID = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    CRE_DT_TM = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    SPN_BANK_CORP_ID = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: true),
                    SPN_BANK_IFSC = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    SPN_BANK_NM = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DEST_BANK_IFSC = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    DEST_BANK_NM = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MNDT_REQ_ID = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    UMR_NO = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    MNDT_CATEGORY = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    MNDT_TYPE = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: true),
                    SEQ_TYPE = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    FRQCY = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    FRST_COLLTN_DT = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    FNL_COLLTN_DT = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    COLLTN_AMT = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: true),
                    CR_NM = table.Column<string>(type: "nvarchar(140)", maxLength: 140, nullable: true),
                    CR_ACCT_NO = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CR_AGT_IFSC = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    CR_AGT_NM = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DR_NM = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DR_REF_NO = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: true),
                    DR_SCHEME = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: true),
                    DR_PHNO = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: true),
                    DR_MOBNO = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: true),
                    DR_EMAIL = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DR_OTHER = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: true),
                    DR_ACCT_NO = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DR_ACCT_TYPE = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: true),
                    DR_AGT_IFSC = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    DR_AGT_NM = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MNDT_IW_XML = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MNDT_F_IMG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MNDT_D_IMG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    STATUS = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    REASON_CD = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    ACCT_NO = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ENTRY_BY = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ENTRY_DT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ENTRY_PC_NM = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    MODIFY_BY = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    MODIFY_DT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MODIFY_PC_NM = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    VERIFY_BY = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    VERIFY_DT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VERIFY_PC_NM = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    VERIFY_STATUS = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    REJECT_REASON = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    REJECT_OTHER_REASON = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DATE_OF_MANDATE = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NACH_IW_MANDATE_MST", x => new { x.ENTERED_BANK_CD, x.ENTERED_BRANCH_CD, x.TRAN_CD });
                });

            migrationBuilder.CreateTable(
                name: "NACH_MMS_CATEGORY_MST",
                columns: table => new
                {
                    TRAN_CD = table.Column<int>(type: "int", maxLength: 11, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CATEGORY_CD = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    ACH_TYPE = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    CATEGORY_DESC = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NACH_MMS_CATEGORY_MST", x => new { x.TRAN_CD, x.CATEGORY_CD });
                });

            migrationBuilder.CreateTable(
                name: "NACH_MMS_OW_REPOSITORY",
                columns: table => new
                {
                    ENTERED_BANK_CD = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    ENTERED_BRANCH_CD = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    TRAN_CD = table.Column<int>(type: "int", maxLength: 20, nullable: false),
                    SR_CD = table.Column<int>(type: "int", maxLength: 20, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MANDATE_TYPE = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    NACH_TRN_TYPE = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    TRAN_DT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BRANCH_CD = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    PROD_TYPE = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    ACCT_NO = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DEST_BANK_IIN = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DEST_ACCT_TYPE = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    DEST_ACCT_NO = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DEST_ACCT_NM = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CONTACT_1 = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: true),
                    CONTACT_2 = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: true),
                    EMAIL_ID = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: true),
                    OTHER_DTL = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: true),
                    SCHEME_TYPE = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: true),
                    DEF_TRAN_CD = table.Column<int>(type: "int", maxLength: 20, nullable: true),
                    CHEQUE_NO = table.Column<int>(type: "int", maxLength: 20, nullable: true),
                    AMOUNT = table.Column<double>(type: "float", nullable: false),
                    COMM_AMT = table.Column<double>(type: "float", nullable: true),
                    SER_CHRG_AMT = table.Column<double>(type: "float", nullable: true),
                    START_DT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VALID_UPTO_CNCL = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    VALID_UPTO = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EXEC_TYPE = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    FEQ_TYPE = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    REMARKS = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    STATUS = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    DEACTIVE_DT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MNDT_JPG_IMG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MNDT_TIF_IMG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DEST_CNTRY_CD = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    DEST_AREA_PHNO = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    CATEGORY_CD = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    UMRN = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    MSG_ID = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    FILE_NM = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ACCEPTED = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    REASON_CD = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    AMEND = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    AMEND_DT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AMEND_REASON_CD = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    AMEND_FILE_NM = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CANCEL_REASON_CD = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    CANCEL_FILE_NM = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    REF_NO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    REQ_EXP_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    REQ_STATUS = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    RESP_XML = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RESP_DT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    REQ_XML = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MAKE_BY = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    MAKE_DT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MAKE_PC_NM = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    VERIFY_BY = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    VERIFY_DT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VERIFY_PC_NM = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    VERIFY_STATUS = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    REJECT_REASON = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    REJECT_OTHER_REASON = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NACH_MMS_OW_REPOSITORY", x => new { x.ENTERED_BANK_CD, x.ENTERED_BRANCH_CD, x.TRAN_CD, x.SR_CD });
                });

            migrationBuilder.CreateTable(
                name: "NACH_MMS_REASON_MST",
                columns: table => new
                {
                    TRAN_CD = table.Column<int>(type: "int", maxLength: 11, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    REASON_CD = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    REASON_TYPE = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    REASON_DESC = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NACH_MMS_REASON_MST", x => x.TRAN_CD);
                });

            migrationBuilder.CreateTable(
                name: "NACH_OAC_DTL",
                columns: table => new
                {
                    ENTERED_BANK_CD = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    ENTERED_BRANCH_CD = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    TRAN_CD = table.Column<int>(type: "int", maxLength: 6, nullable: false),
                    SR_CD = table.Column<int>(type: "int", maxLength: 6, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NACH_ID = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    RECORD_REF_NO = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    IFSC_CD = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    OLD_ACCT_TYPE = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    OLD_ACCT_NO = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    OLD_ACCT_NM = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    USER_NO = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    USER_NM = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    TRN_REF_NO = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    VALID_FLAG = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    REASON_CD = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    ACCT_NO = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NACH_OAC_DTL", x => new { x.ENTERED_BANK_CD, x.ENTERED_BRANCH_CD, x.TRAN_CD, x.SR_CD });
                });

            migrationBuilder.CreateTable(
                name: "NACH_OAC_MST",
                columns: table => new
                {
                    ENTERED_BANK_CD = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    ENTERED_BRANCH_CD = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    TRAN_CD = table.Column<int>(type: "int", maxLength: 20, nullable: false),
                    TRAN_DT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CONFIG_CD = table.Column<int>(type: "int", maxLength: 20, nullable: true),
                    FILE_NM = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    NACH_ID = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    ORG_CD = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    RSP_CD = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    FILE_UPDT = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    FILE_REF_NO = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    TOTAL_TRN = table.Column<int>(type: "int", maxLength: 11, nullable: true),
                    RET_CONFIG_CD = table.Column<int>(type: "int", maxLength: 20, nullable: true),
                    ENTRY_BY = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ENTRY_DT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ENTRY_PC_NM = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    VERIFY_BY = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    VERIFY_DT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VERIFY_PC_NM = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    VERIFY_STATUS = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    REJECT_REASON = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    REJECT_OTHER_REASON = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NACH_OAC_MST", x => new { x.ENTERED_BANK_CD, x.ENTERED_BRANCH_CD, x.TRAN_CD });
                });

            migrationBuilder.CreateTable(
                name: "NACH_OW_MANDATE_MST",
                columns: table => new
                {
                    ENTERED_BANK_CD = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    ENTERED_BRANCH_CD = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    TRAN_CD = table.Column<int>(type: "int", maxLength: 20, nullable: false),
                    AMEND_CD = table.Column<int>(type: "int", maxLength: 20, nullable: false),
                    MANDATE_TYPE = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    NACH_TRN_TYPE = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    TRAN_DT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BRANCH_CD = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    PROD_TYPE = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    ACCT_NO = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DEST_BANK_IIN = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DEST_ACCT_TYPE = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    DEST_ACCT_NO = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DEST_ACCT_NM = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CONTACT_1 = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: true),
                    CONTACT_2 = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: true),
                    EMAIL_ID = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: true),
                    OTHER_DTL = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: true),
                    SCHEME_TYPE = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: true),
                    DEF_TRAN_CD = table.Column<int>(type: "int", maxLength: 20, nullable: true),
                    CHEQUE_NO = table.Column<int>(type: "int", maxLength: 20, nullable: true),
                    AMOUNT = table.Column<decimal>(type: "decimal(14,2)", nullable: false),
                    COMM_AMT = table.Column<decimal>(type: "decimal(14,2)", nullable: true),
                    SER_CHRG_AMT = table.Column<decimal>(type: "decimal(14,2)", nullable: true),
                    START_DT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VALID_UPTO_CNCL = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    VALID_UPTO = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EXEC_TYPE = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    FEQ_TYPE = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    REMARKS = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    STATUS = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    DEACTIVE_DT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MNDT_JPG_IMG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MNDT_TIF_IMG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DEST_CNTRY_CD = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    DEST_AREA_PHNO = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    CATEGORY_CD = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    UMRN = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    MSG_ID = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    FILE_NM = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ACCEPTED = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    REASON_CD = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    AMEND = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    AMEND_DT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AMEND_REASON_CD = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    AMEND_FILE_NM = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CANCEL_REASON_CD = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    CANCEL_FILE_NM = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    REF_NO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    REQ_EXP_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    REQ_STATUS = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    RESP_XML = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RESP_DT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    REQ_XML = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EXPORT_STATUS = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    MAKE_BY = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    MAKE_DT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MAKE_PC_NM = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    VERIFY_BY = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    VERIFY_DT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VERIFY_PC_NM = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    VERIFY_STATUS = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    REJECT_REASON = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    REJECT_OTHER_REASON = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NACH_OW_MANDATE_MST", x => new { x.ENTERED_BANK_CD, x.ENTERED_BRANCH_CD, x.TRAN_CD, x.AMEND_CD });
                });

            migrationBuilder.CreateTable(
                name: "NACH_OW_RESPONSE_MST",
                columns: table => new
                {
                    ENTERED_BANK_CD = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    ENTERED_BRANCH_CD = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    TRAN_CD = table.Column<int>(type: "int", maxLength: 20, nullable: false),
                    TRAN_DT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MNDT_FILE_NM = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    MSG_ID = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: true),
                    CRE_DT_TM = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: true),
                    UMRN = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: true),
                    SPN_BANK_NM = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DEST_BANK_NM = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MNDT_IW_XML = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    STATUS = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    REASON_CD = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    ENTRY_BY = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    MODIFY_BY = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ENTRY_DT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MODIFY_DT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ENTRY_PC_NM = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    MODIFY_PC_NM = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NACH_OW_RESPONSE_MST", x => new { x.ENTERED_BANK_CD, x.ENTERED_BRANCH_CD, x.TRAN_CD });
                });

            migrationBuilder.CreateTable(
                name: "NACH_OW_SCHDL_DTL",
                columns: table => new
                {
                    ENTERED_BANK_CD = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    ENTERED_BRANCH_CD = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    TRAN_CD = table.Column<int>(type: "int", maxLength: 11, nullable: false),
                    SR_CD = table.Column<int>(type: "int", maxLength: 11, nullable: false),
                    SCHDL_DT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AMOUNT = table.Column<int>(type: "int", maxLength: 11, nullable: false),
                    STATUS = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    TRN_REF_NO = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UPLOAD_FILE_NM = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    UPLOAD = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    UPLOAD_DT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EXPORT_CNT = table.Column<int>(type: "int", maxLength: 11, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NACH_OW_SCHDL_DTL", x => new { x.ENTERED_BANK_CD, x.ENTERED_BRANCH_CD, x.TRAN_CD, x.SR_CD });
                });

            migrationBuilder.CreateTable(
                name: "NACH_OW_TRN_DTL",
                columns: table => new
                {
                    SR_CD = table.Column<int>(type: "int", maxLength: 20, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ENTERED_BANK_CD = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    ENTERED_BRANCH_CD = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    TRAN_CD = table.Column<int>(type: "int", maxLength: 20, nullable: false),
                    NACH_ID = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    NACH_SEQ_NO = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    TRN_REF_NO = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BRANCH_CD = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    PROD_TYPE = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    ACCT_NO = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DEST_ACCT_NO = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DEST_BANK_IIN = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    DEST_IFSC_MICR = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    DEST_ACCT_TYPE = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    DEST_ACCT_NM = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SPON_BANK_IIN = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    LF_NO = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    UMRN = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    AADHAAR_NO = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    USER_NO = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    USER_NM = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    AMOUNT = table.Column<decimal>(type: "decimal(14,2)", nullable: true),
                    CHECKSUM = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    CONFIRMED = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    STATUS = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    RETURN_REASON_CD = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NACH_OW_TRN_DTL", x => x.SR_CD);
                });

            migrationBuilder.CreateTable(
                name: "NACH_OW_TRN_MST",
                columns: table => new
                {
                    ENTERED_BANK_CD = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    ENTERED_BRANCH_CD = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    TRAN_CD = table.Column<int>(type: "int", maxLength: 20, nullable: false),
                    NACH_TYPE = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    TRAN_DT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CONFIG_CD = table.Column<int>(type: "int", maxLength: 20, nullable: true),
                    RET_CONFIG_CD = table.Column<int>(type: "int", maxLength: 20, nullable: true),
                    FILE_NM = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    NACH_ID = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    BANK_IIN = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    TOTAL_TRN = table.Column<int>(type: "int", maxLength: 20, nullable: true),
                    TOTAL_TRN_AMT = table.Column<decimal>(type: "decimal(14,2)", nullable: false),
                    ST_DATE = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    ST_CYCLE = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    USER_NM = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    USER_NO = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    TRN_REF_NO = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TRN_TYPE = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    GL_BRANCH_CD = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    GL_PROD_TYPE = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    GL_ACCT_NO = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ENTRY_BY = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ENTRY_DT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ENTRY_PC_NM = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    MODIFY_BY = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    MODIFY_DT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MODIFY_PC_NM = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NACH_OW_TRN_MST", x => new { x.ENTERED_BANK_CD, x.ENTERED_BRANCH_CD, x.TRAN_CD });
                });

            migrationBuilder.CreateTable(
                name: "NACH_RETURN_REASON_MST",
                columns: table => new
                {
                    TRAN_CD = table.Column<int>(type: "int", maxLength: 11, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NACH_TYPE = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    REASON_CD = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    REASON_DESC = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CHRG_AMT = table.Column<decimal>(type: "decimal(12,2)", nullable: true),
                    CBS_REASON_CD = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NACH_RETURN_REASON_MST", x => new { x.TRAN_CD, x.NACH_TYPE });
                });

            migrationBuilder.CreateTable(
                name: "NACH_TYPE_MST",
                columns: table => new
                {
                    TRAN_CD = table.Column<int>(type: "int", maxLength: 11, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NACH_TYPE = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    STATUS = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NACH_TYPE_MST", x => new { x.TRAN_CD, x.NACH_TYPE });
                });

            migrationBuilder.CreateTable(
                name: "NPCI_RESPONSE_DTL",
                columns: table => new
                {
                    TRAN_CD = table.Column<int>(type: "int", maxLength: 11, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ACCT_CD = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CHEQUE_NO = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    TRAN_DT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BANK_CD = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    BRANCH_CD = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    TRANSACTION_CD = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    SAN = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CHEQUE_DT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CHEQUE_AMT = table.Column<decimal>(type: "decimal(14,2)", nullable: true),
                    PAYEE_NM = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DRAWEE_BRANCH_NM = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DRAWEE_BRANCH_CD = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    OPTIONAL1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OPTIONAL2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OPTIONAL3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    REJECT_REASON = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    IP_ADDRESS = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NPCI_RESPONSE_DTL", x => new { x.TRAN_CD, x.ACCT_CD, x.CHEQUE_NO });
                });

            migrationBuilder.CreateTable(
                name: "OTP_MST",
                columns: table => new
                {
                    OTP_ID = table.Column<int>(type: "int", unicode: false, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TRAN_DT = table.Column<DateTime>(type: "datetime", unicode: false, nullable: false),
                    MOBILE_NO = table.Column<string>(type: "varchar(13)", unicode: false, maxLength: 13, nullable: true),
                    OTP_CD = table.Column<string>(type: "varchar(6)", unicode: false, maxLength: 6, nullable: true),
                    OTP_SEND = table.Column<string>(type: "char(1)", unicode: false, maxLength: 1, nullable: true),
                    OTP_VERIFY = table.Column<string>(type: "char(1)", unicode: false, maxLength: 1, nullable: true),
                    EMAIL_ID = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    MAIL_OTP = table.Column<string>(type: "varchar(6)", unicode: false, maxLength: 6, nullable: true),
                    MAIL_SEND = table.Column<string>(type: "char(1)", unicode: false, maxLength: 1, nullable: true),
                    MAIL_OTP_VERIFY = table.Column<string>(type: "char(1)", unicode: false, maxLength: 1, nullable: true),
                    OTP_TYPE = table.Column<string>(type: "varchar(2)", unicode: false, maxLength: 2, nullable: true),
                    LATITUDE = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: true),
                    LONGITUDE = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: true),
                    IP_ADDRESS = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: true),
                    OTP_ATTEMP = table.Column<int>(type: "int", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OTP_MST", x => x.OTP_ID);
                });

            migrationBuilder.CreateTable(
                name: "OW_MNDT_RESPONSE_MST",
                columns: table => new
                {
                    BANK_CD = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    BRANCH_CD = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    TRAN_CD = table.Column<int>(type: "int", maxLength: 11, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TRAN_DT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MNDT_FILE_NM = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MSG_ID = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: true),
                    CRE_DT_TM = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    UMRN = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: true),
                    SPN_BANK_NM = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DEST_BANK_NM = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MNDT_IW_XML = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    STATUS = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    REASON_CD = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OW_MNDT_RESPONSE_MST", x => new { x.BANK_CD, x.BRANCH_CD, x.TRAN_CD });
                });

            migrationBuilder.CreateTable(
                name: "PAGE_NOTES_MST",
                columns: table => new
                {
                    PAGE_CD = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PAGE_NM = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DATA = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PAGE_NOTES_MST", x => x.PAGE_CD);
                });

            migrationBuilder.CreateTable(
                name: "PARAMETER_MST",
                columns: table => new
                {
                    BANK_CD = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    BRANCH_CD = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    PARA_CD = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    PARA_DESC = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PARA_VALUE = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PARAMETER_MST", x => new { x.BANK_CD, x.BRANCH_CD, x.PARA_CD });
                });

            migrationBuilder.CreateTable(
                name: "REJECT_REASON_CODE",
                columns: table => new
                {
                    BANK_CD = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    FILE_STATUS = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    FILE_STATUS_DESC_REJECT = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    REASON_CD = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    TRAN_CD = table.Column<int>(type: "int", maxLength: 11, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_REJECT_REASON_CODE", x => new { x.BANK_CD, x.FILE_STATUS, x.FILE_STATUS_DESC_REJECT, x.REASON_CD });
                });

            migrationBuilder.CreateTable(
                name: "ROLE_MST",
                columns: table => new
                {
                    BANK_CD = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    TRAN_CD = table.Column<int>(type: "int", maxLength: 11, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ROLE_NM = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    ROLE_TYPE = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ROLE_MST", x => x.BANK_CD);
                });

            migrationBuilder.CreateTable(
                name: "SELLER_MST",
                columns: table => new
                {
                    TRAN_CD = table.Column<int>(type: "int", maxLength: 11, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SELLER_ID = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    TRAN_DT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    COMP_NM = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CONTACT_PERSON_NM = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CONTACT1 = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: true),
                    CONTACT2 = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: true),
                    EMAIL_ID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ADDRESS1 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ADDRESS2 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CITY_CD = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    STATE_CD = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    COUNTRY_CD = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    PIN_CODE = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    DOMAIN_NM = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LOGO_ID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    COMP_INFO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WEB_SITE = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    PLAY_STORE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PASSWORD = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    STATUS = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    IP_ADDRESS = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SELLER_MST", x => new { x.TRAN_CD, x.SELLER_ID });
                });

            migrationBuilder.CreateTable(
                name: "SEQUENCE_MST",
                columns: table => new
                {
                    SEQUENCE_NM = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TranCd = table.Column<int>(type: "int", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SEQUENCE_MST", x => x.SEQUENCE_NM);
                });

            migrationBuilder.CreateTable(
                name: "STATE_MST",
                columns: table => new
                {
                    TRAN_CD = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    STATE_NM = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    COUNTRY_CD = table.Column<int>(type: "int", unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STATE_MST", x => x.TRAN_CD);
                });

            migrationBuilder.CreateTable(
                name: "TEMP_IO_MANDATE_MST",
                columns: table => new
                {
                    BANK_CD = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    BRANCH_CD = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    TRAN_CD = table.Column<int>(type: "int", maxLength: 20, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TRAN_DT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FILE_TYPE = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    FOLDER_NM = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    FILE_NM = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    XML_DATA = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    MNDT_F_IMG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MNDT_D_IMG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PROCESS = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    PROCESS_DT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IMP_TYPE = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    REF_NO = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ENTRY_BY = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ENTRY_DT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ENTRY_PC_NM = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ROLE_ID = table.Column<int>(type: "int", maxLength: 11, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TEMP_IO_MANDATE_MST", x => new { x.BANK_CD, x.BRANCH_CD, x.TRAN_CD });
                });

            migrationBuilder.CreateTable(
                name: "USER_ACTIVITY",
                columns: table => new
                {
                    TRAN_CD = table.Column<int>(type: "int", maxLength: 11, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BANK_CD = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    USER_ID = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    AUDIT_ID = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    AUD_TIMESTAMP = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LAST_ACTIVITY_DATA = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER_ACTIVITY", x => new { x.TRAN_CD, x.BANK_CD, x.USER_ID });
                });

            migrationBuilder.CreateTable(
                name: "USER_ACTIVITY_LOG",
                columns: table => new
                {
                    BANK_CD = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    USER_ID = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    LAST_ACTIVITY = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LAST_ACTIVITY_TYPE = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER_ACTIVITY_LOG", x => new { x.BANK_CD, x.USER_ID, x.LAST_ACTIVITY, x.LAST_ACTIVITY_TYPE });
                });

            migrationBuilder.CreateTable(
                name: "USER_BRANCH_PERMISSION",
                columns: table => new
                {
                    BANK_CD = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    BRANCH_CD = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    USER_NM = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    TRAN_CD = table.Column<int>(type: "int", maxLength: 11, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DEFAULT_SELECTION = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER_BRANCH_PERMISSION", x => new { x.BANK_CD, x.BRANCH_CD, x.USER_NM });
                });

            migrationBuilder.CreateTable(
                name: "USER_MST",
                columns: table => new
                {
                    TRAN_CD = table.Column<int>(type: "int", maxLength: 11, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SELLER_ID = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    USER_ID = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    BRANCH_CD = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    BANK_CD = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    TRAN_DT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PASSWORD = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PERSON_NAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PASS_HASH = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    LAST_LOGIN = table.Column<DateTime>(type: "datetime2", nullable: true),
                    USER_TYPE = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    MOBILE_NO1 = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    MOBILE_NO2 = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    EMAIL_ID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    STATUS = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    ADDRESS1 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ADDRESS2 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CITY_CD = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    STATE_CD = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    COUNTRY_CD = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    PIN_CODE = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    _2F_AUTH = table.Column<string>(name: "2F_AUTH", type: "nvarchar(1)", maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER_MST", x => new { x.TRAN_CD, x.SELLER_ID, x.USER_ID, x.BRANCH_CD });
                });

            migrationBuilder.CreateTable(
                name: "USER_PERMISSION",
                columns: table => new
                {
                    USER_ID = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    FORM_NM = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FORM_CAPTION = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SEQ_NO = table.Column<int>(type: "int", maxLength: 11, nullable: true),
                    TYPE = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    MAIN_FORM = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BTN_SAVE = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    BTN_UPDATE = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    BTN_DELETE = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    BTN_SHOW = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    FORM_OPEN = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    FORM_AUTO_AUTH = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER_PERMISSION", x => x.USER_ID);
                });

            migrationBuilder.CreateTable(
                name: "USER_PERMISSION_DTL",
                columns: table => new
                {
                    BANK_CD = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    BRANCH_CD = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    USER_ID = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    DEFAULT_SELECTION = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER_PERMISSION_DTL", x => new { x.BANK_CD, x.BRANCH_CD, x.USER_ID });
                });

            migrationBuilder.CreateTable(
                name: "USER_TIME_LOG",
                columns: table => new
                {
                    TRAN_CD = table.Column<int>(type: "int", unicode: false, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    USER_ID = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    BANK_CD = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: true),
                    BRANCH_CD = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: true),
                    CLOCKINTIME = table.Column<DateTime>(type: "datetime2", unicode: false, nullable: false),
                    CLOCKOUTTIME = table.Column<DateTime>(type: "datetime2", unicode: false, nullable: true),
                    WORKHOURS = table.Column<int>(type: "int", unicode: false, nullable: true),
                    WORKMINUTES = table.Column<int>(type: "int", unicode: false, nullable: true),
                    IN_LONGITUDE = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: false),
                    IN_LATITUDE = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: false),
                    OUT_LONGITUDE = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true),
                    OUT_LATITUDE = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true),
                    REMARKS = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER_TIME_LOG", x => new { x.TRAN_CD, x.USER_ID });
                });

            migrationBuilder.CreateTable(
                name: "VERIFY_REJECT_REASON",
                columns: table => new
                {
                    TRAN_CD = table.Column<int>(type: "int", maxLength: 11, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    REASON_CD = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    REASON_DESC = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VERIFY_REJECT_REASON", x => new { x.TRAN_CD, x.REASON_CD });
                });

            migrationBuilder.CreateIndex(
                name: "IX_CANCEL_REASON_CODE_TRAN_CD",
                table: "CANCEL_REASON_CODE",
                column: "TRAN_CD",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FILE_TYPE_MST_FILE_TYPE_CD",
                table: "FILE_TYPE_MST",
                column: "FILE_TYPE_CD",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_INW_CLR_CHQ_DTL_CHEQUE_NO",
                table: "INW_CLR_CHQ_DTL",
                column: "CHEQUE_NO",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_INW_CLR_CHQ_DTL_TRAN_CD",
                table: "INW_CLR_CHQ_DTL",
                column: "TRAN_CD",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MNDT_MST_TRAN_CD",
                table: "MNDT_MST",
                column: "TRAN_CD",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MNDT_MST_UMR_NO",
                table: "MNDT_MST",
                column: "UMR_NO",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NACH_APBS_REG_MST_AADHAAR_NO",
                table: "NACH_APBS_REG_MST",
                column: "AADHAAR_NO",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NACH_DBTL_AV_DTL_SR_CD",
                table: "NACH_DBTL_AV_DTL",
                column: "SR_CD",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NACH_DBTL_OMC_MST_TRAN_CD",
                table: "NACH_DBTL_OMC_MST",
                column: "TRAN_CD",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NACH_FILE_ERROR_LOG_PROCESS_TYPE",
                table: "NACH_FILE_ERROR_LOG",
                column: "PROCESS_TYPE",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NACH_MMS_CATEGORY_MST_TRAN_CD",
                table: "NACH_MMS_CATEGORY_MST",
                column: "TRAN_CD",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NACH_MMS_OW_REPOSITORY_SR_CD",
                table: "NACH_MMS_OW_REPOSITORY",
                column: "SR_CD",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NACH_OAC_DTL_SR_CD",
                table: "NACH_OAC_DTL",
                column: "SR_CD",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NACH_OW_TRN_DTL_SR_CD",
                table: "NACH_OW_TRN_DTL",
                column: "SR_CD",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NACH_RETURN_REASON_MST_TRAN_CD",
                table: "NACH_RETURN_REASON_MST",
                column: "TRAN_CD",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NACH_TYPE_MST_TRAN_CD",
                table: "NACH_TYPE_MST",
                column: "TRAN_CD",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NPCI_RESPONSE_DTL_CHEQUE_NO",
                table: "NPCI_RESPONSE_DTL",
                column: "CHEQUE_NO",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NPCI_RESPONSE_DTL_TRAN_CD",
                table: "NPCI_RESPONSE_DTL",
                column: "TRAN_CD",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PAGE_NOTES_MST_PAGE_CD",
                table: "PAGE_NOTES_MST",
                column: "PAGE_CD",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_REJECT_REASON_CODE_TRAN_CD",
                table: "REJECT_REASON_CODE",
                column: "TRAN_CD",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SELLER_MST_SELLER_ID",
                table: "SELLER_MST",
                column: "SELLER_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_STATE_MST_TRAN_CD",
                table: "STATE_MST",
                column: "TRAN_CD",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TEMP_IO_MANDATE_MST_TRAN_CD",
                table: "TEMP_IO_MANDATE_MST",
                column: "TRAN_CD",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_USER_ACTIVITY_TRAN_CD",
                table: "USER_ACTIVITY",
                column: "TRAN_CD",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_USER_BRANCH_PERMISSION_TRAN_CD",
                table: "USER_BRANCH_PERMISSION",
                column: "TRAN_CD",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_USER_MST_USER_ID",
                table: "USER_MST",
                column: "USER_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VERIFY_REJECT_REASON_TRAN_CD",
                table: "VERIFY_REJECT_REASON",
                column: "TRAN_CD",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ACCT_TYPE_MST");

            migrationBuilder.DropTable(
                name: "BANK_IIN_MST");

            migrationBuilder.DropTable(
                name: "BANK_MASTER");

            migrationBuilder.DropTable(
                name: "BRANCH_MST");

            migrationBuilder.DropTable(
                name: "CANCEL_REASON_CODE");

            migrationBuilder.DropTable(
                name: "CITY_MST");

            migrationBuilder.DropTable(
                name: "COMP_MST");

            migrationBuilder.DropTable(
                name: "COUNTRY_MST");

            migrationBuilder.DropTable(
                name: "DATA_IMP_TEMPLATE_DTL");

            migrationBuilder.DropTable(
                name: "DATA_IMP_TEMPLATE_HDR");

            migrationBuilder.DropTable(
                name: "DUMMY");

            migrationBuilder.DropTable(
                name: "FILE_TYPE_MST");

            migrationBuilder.DropTable(
                name: "FORM_MST");

            migrationBuilder.DropTable(
                name: "INW_CLR_CHQ_DTL");

            migrationBuilder.DropTable(
                name: "LOGIN_MST");

            migrationBuilder.DropTable(
                name: "MAIL_SMS_TEMP_MST");

            migrationBuilder.DropTable(
                name: "MANDATE_MST");

            migrationBuilder.DropTable(
                name: "MNDT_DTL");

            migrationBuilder.DropTable(
                name: "MNDT_MST");

            migrationBuilder.DropTable(
                name: "NACH_ACCOUNT_MST");

            migrationBuilder.DropTable(
                name: "NACH_APBS_REG_MST");

            migrationBuilder.DropTable(
                name: "NACH_APBS_UID_RESP");

            migrationBuilder.DropTable(
                name: "NACH_CONFIG_COLUMN");

            migrationBuilder.DropTable(
                name: "NACH_DBTL_AV_DTL");

            migrationBuilder.DropTable(
                name: "NACH_DBTL_AV_MST");

            migrationBuilder.DropTable(
                name: "NACH_DBTL_OMC_MST");

            migrationBuilder.DropTable(
                name: "NACH_DBTL_REG_MST");

            migrationBuilder.DropTable(
                name: "NACH_FILE_CONFIG_DTL");

            migrationBuilder.DropTable(
                name: "NACH_FILE_CONFIG_MST");

            migrationBuilder.DropTable(
                name: "NACH_FILE_ERROR_LOG");

            migrationBuilder.DropTable(
                name: "NACH_IO_TRN_DTL");

            migrationBuilder.DropTable(
                name: "NACH_IO_TRN_DTL_REPO");

            migrationBuilder.DropTable(
                name: "NACH_IO_TRN_MST");

            migrationBuilder.DropTable(
                name: "NACH_IW_MANDATE_MST");

            migrationBuilder.DropTable(
                name: "NACH_MMS_CATEGORY_MST");

            migrationBuilder.DropTable(
                name: "NACH_MMS_OW_REPOSITORY");

            migrationBuilder.DropTable(
                name: "NACH_MMS_REASON_MST");

            migrationBuilder.DropTable(
                name: "NACH_OAC_DTL");

            migrationBuilder.DropTable(
                name: "NACH_OAC_MST");

            migrationBuilder.DropTable(
                name: "NACH_OW_MANDATE_MST");

            migrationBuilder.DropTable(
                name: "NACH_OW_RESPONSE_MST");

            migrationBuilder.DropTable(
                name: "NACH_OW_SCHDL_DTL");

            migrationBuilder.DropTable(
                name: "NACH_OW_TRN_DTL");

            migrationBuilder.DropTable(
                name: "NACH_OW_TRN_MST");

            migrationBuilder.DropTable(
                name: "NACH_RETURN_REASON_MST");

            migrationBuilder.DropTable(
                name: "NACH_TYPE_MST");

            migrationBuilder.DropTable(
                name: "NPCI_RESPONSE_DTL");

            migrationBuilder.DropTable(
                name: "OTP_MST");

            migrationBuilder.DropTable(
                name: "OW_MNDT_RESPONSE_MST");

            migrationBuilder.DropTable(
                name: "PAGE_NOTES_MST");

            migrationBuilder.DropTable(
                name: "PARAMETER_MST");

            migrationBuilder.DropTable(
                name: "REJECT_REASON_CODE");

            migrationBuilder.DropTable(
                name: "ROLE_MST");

            migrationBuilder.DropTable(
                name: "SELLER_MST");

            migrationBuilder.DropTable(
                name: "SEQUENCE_MST");

            migrationBuilder.DropTable(
                name: "STATE_MST");

            migrationBuilder.DropTable(
                name: "TEMP_IO_MANDATE_MST");

            migrationBuilder.DropTable(
                name: "USER_ACTIVITY");

            migrationBuilder.DropTable(
                name: "USER_ACTIVITY_LOG");

            migrationBuilder.DropTable(
                name: "USER_BRANCH_PERMISSION");

            migrationBuilder.DropTable(
                name: "USER_MST");

            migrationBuilder.DropTable(
                name: "USER_PERMISSION");

            migrationBuilder.DropTable(
                name: "USER_PERMISSION_DTL");

            migrationBuilder.DropTable(
                name: "USER_TIME_LOG");

            migrationBuilder.DropTable(
                name: "VERIFY_REJECT_REASON");
        }
    }
}
