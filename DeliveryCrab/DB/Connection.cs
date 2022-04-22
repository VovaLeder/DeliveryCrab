namespace DeliveryCrab.DB
{
    public class Connection
    {
        static string Host = "localhost";
        static string Port = "5432";
        static string Database = "dcrab";
        static string Username = "postgres";
        static string Password = "1234";

        // Файл в гитигноре, так что любые изменения в нем не отразятся на других. 
        // Измените значения в соответствии с вашей конфигурацией
        // Скорее всего, отличаться будет только пароль ( надеюсь, по крайней мере ) :)

        public static string GetConnectionString()
        {
            return $"Host={Host};Port={Port};Database={Database};Username={Username};Password={Password}";
        }
    }
}
