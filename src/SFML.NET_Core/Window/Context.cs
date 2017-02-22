using System;
using System.Runtime.InteropServices;
using System.Security;

namespace SFML.Window
{
    //////////////////////////////////////////////////////////////////
    /// <summary>
    /// This class defines a .NET interface to an SFML OpenGL Context
    /// </summary>
    //////////////////////////////////////////////////////////////////
    public class Context
    {
        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Default constructor
        /// </summary>
        ////////////////////////////////////////////////////////////
        public Context()
        {
            myThis = sfContext_create();
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Finalizer
        /// </summary>
        ////////////////////////////////////////////////////////////
        ~Context()
        {
            sfContext_destroy(myThis);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Activate or deactivate the context
        /// </summary>
        /// <param name="active">True to activate, false to deactivate</param>
        /// <returns>true on success, false on failure</returns>
        ////////////////////////////////////////////////////////////
        public bool SetActive(bool active)
        {
            return sfContext_setActive(myThis, active);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Get the settings of the context.
        /// </summary>
        ////////////////////////////////////////////////////////////
        public ContextSettings Settings
        {
            get { return sfContext_getSettings(myThis); }
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Global helper context
        /// </summary>
        ////////////////////////////////////////////////////////////
        public static Context Global
        {
            get
            {
                if (ourGlobalContext == null)
                    ourGlobalContext = new Context();

                return ourGlobalContext;
            }
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Provide a string describing the object
        /// </summary>
        /// <returns>String description of the object</returns>
        ////////////////////////////////////////////////////////////
        public string ToString()
        {
            return "[Context]";
        }

        private static Context ourGlobalContext = null;

        private IntPtr myThis = IntPtr.Zero;

        #region Imports
        [DllImport("csfml-window-2", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr sfContext_create();

        [DllImport("csfml-window-2", CallingConvention = CallingConvention.Cdecl)]
        static extern void sfContext_destroy(IntPtr View);

        [DllImport("csfml-window-2", CallingConvention = CallingConvention.Cdecl)]
        static extern bool sfContext_setActive(IntPtr View, bool Active);

        [DllImport("csfml-window-2", CallingConvention = CallingConvention.Cdecl)]
        static extern ContextSettings sfContext_getSettings(IntPtr View);
        #endregion
    }
}
