namespace Archivos
{
    /// <summary>
    /// Interface para leer y guardar archivos
    /// </summary>
    /// <typeparam name="T">Parámetro genérico</typeparam>
    public interface IArchivo<T>
    {
        bool Guardar(string archivo, T datos);
        bool Leer(string archivo, out T datos);
    }
}
