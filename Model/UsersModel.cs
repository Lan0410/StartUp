using System.Collections.Generic;
using ISCommon.Model;
using System;

namespace IS.Model.Views
{
    public class UsersModel 
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public string FullName { get; set; }
        public string Alias { get; set; }
        public string TaxCode { get; set; }
        public string Image { get; set; }
        public int UserType { get; set; }
        public bool IsfirstLogin { get; set; }
        public bool IsLogin { get; set; }
        public string TokenKey { get; set; }
        public string IPLogin { get; set; }
        public bool UserDefault { get; set; }
        public DateTime? Birthday { get; set; }
        public string Tel { get; set; }
        public string Email { get; set; }
        public int Sex { get; set; }
        public string Address { get; set; }
        public int Active { get; set; }
        public string CountryCode { get; set; }
        public string ProvinceCode { get; set; }
        public string DistrictCode { get; set; }
        public string NationCode { get; set; }
        public string ReligionCode { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? LastModifyDate { get; set; }
        public string LastModifyBy { get; set; }
        public string ToHashValue(string password)
        {
            return ISCommon.Utility.ISSecurity.HashSHA256(UserName + Salt + password);
        }
        public bool ComparePass(string password)
        {
            return Password == ToHashValue(password);
        }
        public string Key { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string OldPassword { get; set; }
        public string strRoleId { get; set; }
        public string RePassword { get; set; }
        
        public FillterParameter Filter { get; set; }
    }

    public class UsersReturnModel : ErrorMessage
    {
        public List<UsersModel> Data { get; set; }
        public int TotalRecord { get; set; }
    }
    public class UsersModelParameter
    {

        public string Token { get; set; }
        public UsersModel Data { get; set; }
        public PageParameter Page { get; set; }

    }
    //public class LoginResponseModel
    //{
    //    public string ResponseCode { get; set; }
    //    public List<UsersRoleModel> ResponseMessage { get; set; }
    //    public UsersModel ExtraInfos { get; set; }
    //    public List<RoleFunctionPermissionModel> ExtendInfor { get; set; }
    //    public List<MenuModel> lstMenu { get; set; }
    //}
    public class JsonRs
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
        public int CountDB { get; set; }
        public bool LoginLock { get; set; }
        public int LoginCountFail { get; set; }
        public double TimeUnLock { get; set; }
    }
}
