using System.Data;
using System.Data.Common;
using System.Text;

namespace DicEspNahuatl.Datos
{
    /// <summary>
    /// This interface specifies the signature for a factory that
    /// takes a DataReader and creates a domain object from it.
    /// </summary>
    /// <typeparam name="TDomainObject">type of domain object to create.</typeparam>
    public interface IDomainObjectFactory<TDomainObject>
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="reader">Reader.</param>
        /// <returns></returns>
        TDomainObject Construct(IDataReader reader);
    }

    /// <summary>
    /// Interface.
    /// </summary>
    /// <typeparam name="TDomainObject">Objeto Domain.</typeparam>
    public interface IDomainObjectDisconnectedFactory<TDomainObject>
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="dataRow">Data Row.</param>
        /// <returns>dataRow</returns>
        TDomainObject Construct(DataRow dataRow);
    }
}