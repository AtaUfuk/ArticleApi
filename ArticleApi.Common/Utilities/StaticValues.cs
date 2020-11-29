namespace ArticleApi.Common.Utilities
{
    public static class StaticValues
    {
        #region Sonuc Mesajlar
        /// <summary>
        /// Başarılı işlem genel mesajıdır.
        /// </summary>
        public static readonly string SuccessMessage = "İşleminiz başarılı bir şekilde gerçekleşmiştir.";
        /// <summary>
        /// Hatalı işlem genel mesajıdır.
        /// </summary>
        public static readonly string ErrorMessage = "İşleminiz esnasında bir sorun ile karşılaşıldı, lütfen daha sonra tekrardan deneyiniz.";
        /// <summary>
        /// Boş ve/veya hiç bir değer eklenmemiş parametre hata mesajıdır.
        /// </summary>
        public static readonly string ErrorNullMessage = "{0} alan/alanlar boş bırakılamaz.";
        /// <summary>
        /// Geçerli bir mail formatı eklenmediğinde oluşan hata mesajıdır.
        /// </summary>
        public static readonly string ErrorMailRegexMessage = "{0} e-posta alan/alanlarına lütfen geçerli bir e-posta adresi/adresleri giriniz.";
        /// <summary>
        /// Geçerli bir dosya formatı eklenmediğinde oluşan hata mesajıdır.
        /// </summary>
        public static readonly string ErrorFileFormatMessage = "Lütfen geçerli bir dosya formatı ekleyiniz.Desteklenen dosya formatları:jpg,jpeg,png";
        /// <summary>
        /// Geçerli bir dosya ismi eklenmediğinde oluşan hata mesajıdır.
        /// </summary>
        public static readonly string ErrorFileNameMessage = "Lütfen dosya ismi içerisinde _ ve Türkçe karakterleri dışında başka bir özel karakter kullanmayınız.";
        /// <summary>
        /// Kullanıcı oturum açma esnasında alınan hata mesajıdır.
        /// </summary>
        public static readonly string ErrorUserAuthMessage = "Kullanıcı adı ve/veya şifre hatalıdır.";
        /// <summary>
        /// Oturum süresi sona ermesi durumunda oluşan hata mesajıdır.
        /// </summary>
        public static readonly string ErrorAuthKeyMessage = "Oturum süreniz sona erdiğinden tekrardan giriş yapmanız gerekmektedir.";
        /// <summary>
        /// Gönderilen mail bilgisinin boş olması durumunda oluşan hata mesajıdır.
        /// </summary>
        public static readonly string ErrorNullMailMessage = "{0} mail bilgisi boş bırakılamaz.";

        /// <summary>
        /// Dosyanın Base64 alanı boş bırakılırsa oluşan hata mesajıdır.
        /// </summary>
        public static readonly string ErrorFileNullBase64Message = "Dosyanın Base64 alanını boş bırakmayınız.";
        /// <summary>
        /// Dosyanın isim alanı boş bırakılırsa oluşan hata mesajıdır.
        /// </summary>
        public static readonly string ErrorNullFileNameMessage = "Dosyanın adı alanını boş bırakmayınız.";

        /// <summary>
        /// Belli bir kayıt/kayıtlar bulunamadığında oluşan hata mesajıdır.
        /// </summary>
        public static readonly string ErrorNullObjMessage = "Belirtilen kriterlere göre bir kayıt bulunamamıştır.";
        #endregion
        #region Sonuc Kodlari
        /// <summary>
        /// Genel hata kodudur.
        /// </summary>
        public static readonly int ErrorCode = 100;
        /// <summary>
        /// Boş ve/veya hiç bir değer eklenmemiş parametre hata kodudur.
        /// </summary>
        public static readonly int ErrorNullCode = 101;
        /// <summary>
        /// Geçerli bir mail formatı eklenmediğinde oluşan hata kodudur.
        /// </summary>
        public static readonly int ErrorMailRegexCode = 102;
        /// <summary>
        /// Geçerli bir dosya formatı eklenmediğinde oluşan hata kodudur.
        /// </summary>
        public static readonly int ErrorFileFormatCode = 103;
        /// <summary>
        /// Geçerli bir dosya ismi eklenmediğinde oluşan hata kodudur.
        /// </summary>
        public static readonly int ErrorFileNameCode = 104;
        /// <summary>
        /// Kullanıcı oturum açma esnasında alınan hata kodudur.
        /// </summary>
        public static readonly int ErrorUserAuthCode = 105;
        /// <summary>
        /// Oturum süresi sona ermesi durumunda oluşan hata kodudur.
        /// </summary>
        public static readonly int ErrorAuthKeyCode = 106;
        /// <summary>
        /// Gönderilen mail bilgisinin boş olması durumunda oluşan hata kodudur.
        /// </summary>
        public static readonly int ErrorNullMailCode = 107;
        /// <summary>
        /// Dosyanın Base64 alanı boş bırakılırsa oluşan hata kodudur.
        /// </summary>
        public static readonly int ErrorFileNullBase64Code = 108;
        /// <summary>
        /// Dosyanın isim alanı boş bırakılırsa oluşan hata kodudur.
        /// </summary>
        public static readonly int ErrorNullFileNameCode = 109;
        /// <summary>
        /// Belli bir kayıt/kayıtlar bulunamadığında oluşan hata mesajıdır.
        /// </summary>
        public static readonly int ErrorNullObjCode = 110;
        /// <summary>
        /// Bilgi amaçlı oluşturulan veriler için kullanılan koddur.
        /// </summary>
        public static readonly int InfoCode = 201;
        /// <summary>
        /// Başarılı işlem sonuç kodudur.
        /// </summary>
        public static readonly int SuccessCode = 200;
        #endregion

        #region Default Degerler
        /// <summary>
        /// Kullanıcı ilk oturum açma esnasında kullanılan değerdir
        /// </summary>
        public static readonly int DefUserId = 0;
        #endregion

    }
}
