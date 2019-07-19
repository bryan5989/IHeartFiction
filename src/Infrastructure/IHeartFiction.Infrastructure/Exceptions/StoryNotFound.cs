/* Maintained By Johnathan P. Irvin
 *
 * ======== Disclaimer ========
 * This software may use 3rd party libraries, that have their own seperate licenses.
 * This software uses the GNU, General Public License (GPL v3) as defined at the link below.
 * https://www.gnu.org/licenses/gpl-3.0.en.html
 */

using System;
using System.Runtime.Serialization;

namespace IHeartFiction.Infrastructure.Exceptions
{
    public class StoryNotFound : Exception
    {
        /// <inheritdoc />
        public StoryNotFound()
        {
        }

        /// <inheritdoc />
        public StoryNotFound(string message) : base(message)
        {
        }

        /// <inheritdoc />
        public StoryNotFound(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <inheritdoc />
        protected StoryNotFound(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
