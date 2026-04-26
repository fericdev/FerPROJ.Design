using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerPROJ.Design.FormModels {
    public class OAuthCredentialModel {
        public Installed installed { get; set; } = new Installed();
    }
    public class  Installed {
        public string client_id { get; set; } = "PBq9a2Oe\u002Byxg8GUUsSQxwfKF1acALPci4xN\u002BSKyw5ILxHa1BT8JETfJ6Uwrihv4XZzAJDA0UthEF89UJySz4OtkPoixAXuBUAxehGj5MxV0=";
        public string project_id { get; set; } = "4fHMjW3ewIKvfFFPpYl36nVUyxvpfarb5HaCfkCygeU=";
        public string auth_uri { get; set; } = "KTB0Wnb98ZG/E9Z4mJpllqJRK5dXpdZWYrwClUoEBDM1NMsv2LygKNHUm/aAflcC";
        public string token_uri { get; set; } = "FpEkqIT0DhJtq5vCWS4\u002BVATdL9qwNcw2wNHqg2anUiO1dgBb5PsasfVPkX9A/sX0";
        public string auth_provider_x509_cert_url { get; set; } = "230iQ3lOKVSm6txwSPUlGVDaUUMAh53Nl\u002BObMqxWB1b9S3jSXBC0LNHv2IZnykR4";
        public string client_secret { get; set; } = "yOciMoMOakwhRrmBbeR/fhBQkQdifFjUOkg6vvC2CkxMvrFZrAwsrknUlnzwO/xu";
        public string redirect_uris { get; set; } = "zaMxd9v6TC9tvbTuX3bZ/DK/8AI1JYdIgPd\u002BwyTIuUI=";
    }
}
