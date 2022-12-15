using System;
using System.Text.RegularExpressions;
using DDDSample1.Domain.Shared;

namespace DDDSample1.Domain.Armazens.Validator {
    public class ArmazemValidator : IValidator {
        private const String ID_REGEX = "^([A-Z]|[0-9]){3}$";
        private const String COD_POSTAL_REGEX = "^[0-9]{4}-[0-9]{3}$";
        private const Int32 DESIGNACAO_LENGTH_MAX = 50;
        private const Int16 NUMERO_PORTA_MAX = 9999;
        private const Double LATITUDE_MIN = -90;
        private const Double LATITUDE_MAX = 90;
        private const Double LONGITUDE_MIN = -180;
        private const Double LONGITUDE_MAX = 180;

        public bool IsValid(params Object[] listParameter) {
            if (!Regex.IsMatch((String) listParameter[0], ID_REGEX))
                throw new BusinessRuleValidationException("Formato inválido do Identificador do Armazem;\nO Identificador do Armazem deve ser composto por 3 caratéres alfanuméricos;");
            if (String.IsNullOrEmpty(((String) listParameter[1])) || ((String) listParameter[1]).Length > DESIGNACAO_LENGTH_MAX)
                throw new BusinessRuleValidationException("Formato inválido da Designacao do Armazem;\nA Designacao do Armazem é um texto obrigatório com um máximo de 50 caratéres;");
            if (!Regex.IsMatch((String) listParameter[2], COD_POSTAL_REGEX))
                throw new BusinessRuleValidationException("Formato inválido do Código Postal do Armazem;\nO Código Postal deve seguir o formato utilizado em Portugal;");
            if (((Int16) listParameter[3]) > NUMERO_PORTA_MAX || ((Int16) listParameter[3]) < 0)
                throw new BusinessRuleValidationException("Formato inválido do Número da Porta do Armazem;\nO Número da Porta ultrapassa o limite máximo estabelecido (9999);");
            if (String.IsNullOrEmpty(((String) listParameter[4])))
                throw new BusinessRuleValidationException("Necessário estipular o Nome da Rua do Armazem;");
            if (String.IsNullOrEmpty(((String) listParameter[5])))
                throw new BusinessRuleValidationException("Necessário estipular a Localidade do Armazem;");
            if (String.IsNullOrEmpty(((String) listParameter[6])))
                throw new BusinessRuleValidationException("Necessário estipular o País do Armazem;");
            if (String.IsNullOrEmpty(((String) listParameter[7])))
                throw new BusinessRuleValidationException("Necessário estipular o Municipio do Armazem;");
            if (((Double) listParameter[8]) > LATITUDE_MAX || ((Double) listParameter[8]) < LATITUDE_MIN)
                throw new BusinessRuleValidationException("Formato inválido da Latitude do Armazem;\nO valor da Latitude deve ser entre \"-90\" e \"90\";");
            if (((Double) listParameter[9]) > LONGITUDE_MAX || ((Double) listParameter[9]) < LONGITUDE_MIN)
                throw new BusinessRuleValidationException("Formato inválido da Longitude do Armazem;\nO valor da Longitude deve ser entre \"-180\" e \"180\";");
            return true;
        }
    }
}