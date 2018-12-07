//-----------------------------------------------------------------------
// <copyright file="VuforiaCameraAutoFocusController.cs" company="Bayhaksam">
//      Copyright (c) Bayhaksam. All rights reserved.
// </copyright>
// <author>Samet Kurumahmut</author>
//-----------------------------------------------------------------------

using Vuforia;

namespace Bayhaksam.Vuforia.Unity.Behaviour
{
	using UnityEngine;

	public class VuforiaCameraAutoFocusController : MonoBehaviour
	{
		#region Unity Methods
		protected virtual void Start()
		{
			var vuforia = VuforiaARController.Instance;
			vuforia.RegisterVuforiaStartedCallback(this.Focus);
			vuforia.RegisterOnPauseCallback(this.OnPaused);
		}
		#endregion

		#region Methods
		void Focus()
		{
			// Force autofocus.
			if (!CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO))
			{
				CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_NORMAL);
			}
		}

		void OnPaused(bool paused)
		{
			// resumed
			if (!paused)
			{
				this.Focus();
			}
		}
		#endregion
	}
}
