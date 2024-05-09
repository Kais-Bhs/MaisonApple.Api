// ---------------------------------------------------------------
// Copyright (c). All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace BL
{
    public class JWTConfiguration
    {
        /// <summary>
        /// Le nom du modèle GPT à utiliser.
        /// </summary>
        [JsonProperty("ValidIss")]
        public string? ValidIss { get; set; }
        /// <summary>
        /// Le nom du modèle GPT à utiliser.
        /// </summary>
        [JsonProperty("ValidAud")]
        public string? ValidAud { get; set; }
        /// <summary>
        /// Le nombre maximum de tokens à générer dans les réponses du modèle GPT.
        /// </summary>
        [JsonProperty("SecritKey")]
        public string? SecritKey { get; set; }
        /// <summary>
        /// Initialise la configuration avec des valeurs spécifiques fournies via IOptions.
        /// </summary>
        /// <param name="options">Les options contenant les valeurs de configuration.</param>
        public void Initialize(IOptions<JWTConfiguration> options)
        {
            ValidIss = options.Value.ValidIss;
            ValidAud = options.Value.ValidAud;
            SecritKey = options.Value.SecritKey;
        }
    }
}
