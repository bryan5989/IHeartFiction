/* Maintained By Johnathan P. Irvin
 *
 * ======== Disclaimer ========
 * This software may use 3rd party libraries, that have their own seperate licenses.
 * This software uses the GNU, General Public License (GPL v3) as defined at the link below.
 * https://www.gnu.org/licenses/gpl-3.0.en.html
 */

using System;
using System.Runtime.Serialization;

namespace IHeartFiction.Domain.Exceptions
{
    public class CommentDoesNotExist : Exception
    {
        /// <inheritdoc />
        public CommentDoesNotExist()
        {
        }

        /// <inheritdoc />
        public CommentDoesNotExist(string message) : base(message)
        {
        }

        /// <inheritdoc />
        public CommentDoesNotExist(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <inheritdoc />
        protected CommentDoesNotExist(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
