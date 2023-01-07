using System;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Serialization;
using DDDSample1.Domain.Shared;

namespace DDDSample1.Domain.Armazens {
    [Owned]
    [DataContract]
    public class Altitude : IValueObject {
        [DataMember(Name = "Altitude")]
        private Double altitude;

        public Altitude() {}

        public Altitude(Double altitude) {
            this.altitude = altitude;
        }

        public Double GetAltitude => altitude;

        public override bool Equals(object obj) {
            if (ReferenceEquals(null, obj))
                return false;
            if (!(obj is Altitude))
                return false;

            Altitude altitude = (Altitude) obj;

            return this.altitude.Equals(altitude.altitude);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.altitude);
        }
    }
}