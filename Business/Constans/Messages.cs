using System.Runtime.Serialization;
using Core.Entities.Concrete;

namespace Business.Constans;

public static class Messages
{
    public static string ProductAdded = "Ürün eklendi.";
    public static string ProductNameInvalid = "Ürün ismi geçersiz";
    public static string MaintenanceTime = "Bakım Zamanı!";
    public static string ProductsListed = "Ürünler listelendi.";
    public static string ProductCountOfCategoryError = "Bir kategoride 10'dan fazla ürün olamaz";
    public static string ProductNameAlreadyExists = "Ürün ismi kayıtlı lütfen başka isim giriniz";
    public static string AuthorizationDenied="Yetkiniz yok!";
    public static string UserRegistered = "Hesap oluşturuldu";
    public static string UserNotFound = "Kullanıcı bulunamadı";
    public static string PasswordError = "Şifreniz Yanlış";
    public static string SuccessfulLogin = "Giriş yapıldı";
    public static string UserAlreadyExists = "Kullanıcı kayıtlı";
    public static string AccessTokenCreated = "Token oluşturuldu";
}