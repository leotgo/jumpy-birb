using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JumpBirdGame
{
    public class RoundRobinIndex
    {
        /* ------------------------------- Properties ------------------------------- */

        /// <summary>
        /// Retrieves the value for this index and increments its value.
        /// </summary>
        /// <value></value>
        public int Value
        {
            get
            {
                if(_value > _maxValue)
                {
                    _value = _minValue;
                }
                return _value++;
            }
        }

        /// <summary>
        /// Retrieves the value for this index without changing its content.
        /// </summary>
        /// <value></value>
        public int ConstValue
        {
            get => _value;
        }

        /* ----------------------------- Runtime Fields ----------------------------- */

        private int _value;
        private int _minValue;
        private int _maxValue;

        /* ------------------------------ Constructors ------------------------------ */

        public RoundRobinIndex(int min, int max)
        {
            _minValue = min;
            _maxValue = max;
            _value = min;
        }

        /* -------------------------------------------------------------------------- */
    }
}
