namespace ConsoleApp15;

[Serializable]
struct Buyer
{
    public string FullName;          // Фамилия и инициалы
    public DateTime PurchaseDate;    // Дата покупки
    public double FirstHalfSum;      // Сумма за первое полугодие
    public double SecondHalfSum;     // Сумма за второе полугодие
    public double DiscountPercent;   // Процент скидки

    public override string ToString()
    {
        return $"ФИО: {FullName}, Дата покупки: {PurchaseDate.ToShortDateString()}, " +
               $"Первое полугодие: {FirstHalfSum}, Второе полугодие: {SecondHalfSum}, " +
               $"Скидка: {DiscountPercent}%";
    }
}