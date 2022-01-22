namespace Kaczmarek.BeersCatalogue.DaoFile
{
    internal interface IConverter<Model, Stored>
    {
        Stored Convert(Model model);
        Model Convert(Stored stored);
    }
}
