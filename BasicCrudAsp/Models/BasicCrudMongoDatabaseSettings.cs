using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicCrudAsp.Models
{
    /// <summary>
    /// <b>Classe de configuração do DB</b>
    /// Os parâmetros estão em appsettings.json
    /// </summary>
    public class BasicCrudMongoDatabaseSettings : IBasicCrudMongoDatabaseSettings
    {
        public string GamesCollectionName { get; set; }
        public string ConnectionString { get; set ; }
        public string DatabaseName { get; set ; }
    }
}
