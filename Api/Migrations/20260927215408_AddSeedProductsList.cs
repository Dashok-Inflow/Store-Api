using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedProductsList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "id", "category", "description", "image", "name", "price", "special_tag" },
                values: new object[,]
                {
                    { 1, "Категория 3", "Формированию богатый отметить важные выбранный настолько задания плановых проект.", "https://placehold.co/200", "Большой Пластиковый Кошелек", 875.07000000000005, "Рекомендуемый" },
                    { 2, "Категория 3", "Внедрения предложений материально-технической за поэтапного.", "https://placehold.co/200", "Свободный Меховой Плащ", 938.88999999999999, "Популярный" },
                    { 3, "Категория 2", "Проблем воздействия порядка технологий задача что качественно.", "https://placehold.co/200", "Грубый Пластиковый Портмоне", 69.650000000000006, "Новинка" },
                    { 4, "Категория 3", "Структуры организационной процесс соответствующих оценить кругу сознания способствует.", "https://placehold.co/200", "Большой Резиновый Стул", 984.44000000000005, "Новинка" },
                    { 5, "Категория 2", "Участниками сомнений базы играет принципов финансовых.", "https://placehold.co/200", "Великолепный Стальной Сабо", 561.27999999999997, "Рекомендуемый" },
                    { 6, "Категория 3", "Активом сфера социально-экономическое опыт инновационный высокотехнологичная создание.", "https://placehold.co/200", "Великолепный Натуральный Ножницы", 72.019999999999996, "Новинка" },
                    { 7, "Категория 1", "Рамки отношении нами.", "https://placehold.co/200", "Потрясающий Кожанный Куртка", 405.05000000000001, "Новинка" },
                    { 8, "Категория 1", "Модель начало роль широким предложений общества.", "https://placehold.co/200", "Эргономичный Неодимовый Ботинок", 587.71000000000004, "Популярный" },
                    { 9, "Категория 3", "Поэтапного последовательного повседневная значимость широкому принципов.", "https://placehold.co/200", "Свободный Деревянный Портмоне", 639.78999999999996, "Рекомендуемый" },
                    { 10, "Категория 2", "Интересный этих показывает национальный сознания для организации равным постоянный поставленных.", "https://placehold.co/200", "Интеллектуальный Бетонный Стол", 365.69, "Новинка" },
                    { 11, "Категория 2", "Соответствующей внедрения разнообразный широкому реализация поэтапного форм национальный путь.", "https://placehold.co/200", "Великолепный Гранитный Свитер", 738.00999999999999, "Популярный" },
                    { 12, "Категория 1", "Деятельности предпосылки управление важные профессионального.", "https://placehold.co/200", "Свободный Натуральный Сабо", 659.20000000000005, "Популярный" },
                    { 13, "Категория 2", "Курс проблем для массового намеченных образом.", "https://placehold.co/200", "Невероятный Натуральный Стул", 639.09000000000003, "Рекомендуемый" },
                    { 14, "Категория 2", "Задач широкому представляет кругу.", "https://placehold.co/200", "Практичный Гранитный Ботинок", 732.34000000000003, "Рекомендуемый" },
                    { 15, "Категория 3", "Процесс управление различных сложившаяся курс.", "https://placehold.co/200", "Маленький Кожанный Шарф", 956.55999999999995, "Рекомендуемый" },
                    { 16, "Категория 3", "Важную укрепления таким.", "https://placehold.co/200", "Маленький Натуральный Куртка", 745.25999999999999, "Рекомендуемый" },
                    { 17, "Категория 2", "Начало от однако.", "https://placehold.co/200", "Потрясающий Хлопковый Компьютер", 752.48000000000002, "Новинка" },
                    { 18, "Категория 2", "Идейные представляет уточнения рост экономической постоянный дальнейшее задания.", "https://placehold.co/200", "Практичный Пластиковый Стул", 419.42000000000002, "Рекомендуемый" },
                    { 19, "Категория 1", "Важные проверки профессионального сущности в активности способствует отметить сомнений.", "https://placehold.co/200", "Великолепный Пластиковый Кошелек", 934.16999999999996, "Новинка" },
                    { 20, "Категория 3", "С понимание организации широким различных.", "https://placehold.co/200", "Интеллектуальный Деревянный Стол", 394.73000000000002, "Рекомендуемый" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 20);
        }
    }
}
