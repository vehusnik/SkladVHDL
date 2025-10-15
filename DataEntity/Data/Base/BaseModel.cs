using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntity.Data.Base
{
    public abstract class BaseModel : IDataErrorInfo
    {
        #region "validace" 

        string IDataErrorInfo.Error
        {
            get
            {

                throw new NotSupportedException("IdataErrorInfo.Error is not supported," +
                "use IDataErrorInfo.this [propertyName] instead");
            }
        }
        string IDataErrorInfo.this[string propertyName] => OnValidate(propertyName);


        protected virtual string OnValidate(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName))
            {
                throw new ArgumentNullException("Iinvalid property name", propertyName);
                
            }
            string error = string.Empty;
            var value = this.GetType().GetProperty(propertyName)?.GetValue(this, null);
            var results = new List<ValidationResult>(1);
            var context = new ValidationContext(this) { MemberName = propertyName };

            var result = Validator.TryValidateProperty(value, context, results);
            if (!result)
            {
                var validationResult = results.First();
                error = validationResult.ErrorMessage ?? string.Empty;
            }
            return error;

        }
        #endregion
        [Timestamp]
        public required byte[] RowVersion { get; set; }
        public DateTime DatumVytvoreni { get; set; } = DateTime.Now;

    }
}