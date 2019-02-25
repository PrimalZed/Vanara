﻿using NUnit.Framework;
using System;
using System.Linq;
using System.Runtime.InteropServices;
using Vanara.InteropServices;
using static Vanara.PInvoke.Gdi32;
using static Vanara.PInvoke.User32;
using static Vanara.PInvoke.User32_Gdi;

namespace Vanara.PInvoke.Tests
{
	[TestFixture()]
	public class User32Tests
	{
		[Test()]
		public void CallNextHookExTest()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void ChildWindowFromPointExTest()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void DestroyIconTest()
		{
			throw new NotImplementedException();
		}

		[Test]
		public void EnumDisplayDevicesTest()
		{
			var devNum = 0U;
			var dd = DISPLAY_DEVICE.Default;
			while (EnumDisplayDevices(null, devNum, ref dd, EDD.EDD_GET_DEVICE_INTERFACE_NAME))
			{
				TestContext.WriteLine($"Name: {dd.DeviceName} : {dd.DeviceString}; State: {dd.StateFlags}");
				var dm = DEVMODE.Default;
				var mode = 0U;
				while (EnumDisplaySettings(dd.DeviceName, mode, ref dm))
				{
					TestContext.WriteLine($"   {mode}) {dm.dmBitsPerPel},{dm.dmPelsWidth},{dm.dmPelsHeight},{dm.dmDisplayFlags},{dm.dmDisplayFrequency}");
					mode++;
				}
				dm = DEVMODE.Default;
				mode = 0U;
				while (EnumDisplaySettingsEx(dd.DeviceName, mode, ref dm, EDS.EDS_ROTATEDMODE))
				{
					TestContext.WriteLine($"   {mode}) {dm.dmBitsPerPel},{dm.dmPelsWidth},{dm.dmPelsHeight},{dm.dmDisplayFlags},{dm.dmDisplayFrequency},{dm.dmDisplayOrientation},{dm.dmPosition}");
					mode++;
				}
				devNum++;
			}
		}

		[Test]
		public void DisplayConfigTest()
		{
			Assert.That(QueryDisplayConfig(QDC.QDC_ONLY_ACTIVE_PATHS, out var paths, out var modes, out var topId).Succeeded, Is.True);
			foreach (var mode in modes.Where(m => m.infoType == DISPLAYCONFIG_MODE_INFO_TYPE.DISPLAYCONFIG_MODE_INFO_TYPE_TARGET))
			{
				Assert.That(() => DisplayConfigGetDeviceInfo<DISPLAYCONFIG_TARGET_DEVICE_NAME>(mode.adapterId, mode.id, DISPLAYCONFIG_DEVICE_INFO_TYPE.DISPLAYCONFIG_DEVICE_INFO_GET_ADAPTER_NAME), Throws.Exception);
				Assert.That(() => DisplayConfigGetDeviceInfo<RECT>(mode.adapterId, mode.id), Throws.Exception);
				TestContext.WriteLine(DisplayConfigGetDeviceInfo<DISPLAYCONFIG_TARGET_DEVICE_NAME>(mode.adapterId, mode.id).monitorFriendlyDeviceName);
				TestContext.WriteLine(DisplayConfigGetDeviceInfo<DISPLAYCONFIG_ADAPTER_NAME>(mode.adapterId, mode.id).adapterDevicePath);
				TestContext.WriteLine(DisplayConfigGetDeviceInfo<DISPLAYCONFIG_TARGET_BASE_TYPE>(mode.adapterId, mode.id).baseOutputTechnology);
				TestContext.WriteLine(DisplayConfigGetDeviceInfo<DISPLAYCONFIG_SUPPORT_VIRTUAL_RESOLUTION>(mode.adapterId, mode.id).value);
				TestContext.WriteLine(DisplayConfigGetDeviceInfo<DISPLAYCONFIG_GET_ADVANCED_COLOR_INFO>(mode.adapterId, mode.id).colorEncoding);
				TestContext.WriteLine(DisplayConfigGetDeviceInfo<DISPLAYCONFIG_SDR_WHITE_LEVEL>(mode.adapterId, mode.id).SDRWhiteLevel);
				TestContext.WriteLine(DisplayConfigGetDeviceInfo<DISPLAYCONFIG_TARGET_PREFERRED_MODE>(mode.adapterId, mode.id).targetMode);
			}
			foreach (var path in paths.Where(p => p.targetInfo.targetAvailable))
			{
				TestContext.WriteLine(DisplayConfigGetDeviceInfo<DISPLAYCONFIG_SOURCE_DEVICE_NAME>(path.sourceInfo.adapterId, path.sourceInfo.id).viewGdiDeviceName);
			}
		}

		[Test()]
		public void GetActiveWindowTest()
		{
			var hwnd = GetActiveWindow();
			Assert.That(hwnd.IsNull, Is.False);
		}

		[Test]
		public void GetDisplayAutoRotationPreferencesTest()
		{
			Assert.That(GetDisplayAutoRotationPreferences(out var o));
			Assert.That(o, Is.EqualTo(ORIENTATION_PREFERENCE.ORIENTATION_PREFERENCE_NONE));
		}

		[Test]
		public void GetGestureConfigTest()
		{
			var array = new GESTURECONFIG[] { new GESTURECONFIG(GID.GID_ZOOM), new GESTURECONFIG(GID.GID_ROTATE), new GESTURECONFIG(GID.GID_PAN) };
			var aLen = (uint)array.Length;
			var b = GetGestureConfig(FindWindow(null, null), 0, 0, ref aLen, array, (uint)Marshal.SizeOf(typeof(GESTURECONFIG)));
			if (!b) Win32Error.ThrowLastError();
			Assert.That(b, Is.True);
			Assert.That(aLen, Is.GreaterThan(0));
			for (var i = 0; i < aLen; i++)
				TestContext.WriteLine($"{array[i].dwID} = {array[i].dwWant} / {array[i].dwBlock}");
		}

		[Test()]
		public void GetWindowLongTest()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void GetWindowLong32Test()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void GetWindowLongPtrTest()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void LockWorkStationTest()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void RealGetWindowClassTest()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void RegisterHotKeyTest()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void RegisterWindowMessageTest()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void ScreenToClientTest()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void SendMessageTest()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void SendMessageTest1()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void SendMessageTest2()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void SendMessageTest3()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void SendMessageTest4()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void SendMessageTest5()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void SetWindowLongTest()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void SetWindowPosTest()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void SetWindowTextTest()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void ShutdownBlockReasonCreateTest()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void ShutdownBlockReasonDestroyTest()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void ShutdownBlockReasonQueryTest()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void ShutdownBlockReasonQueryTest1()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void UnhookWindowsHookExTest()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void UnregisterHotKeyTest()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void WindowFromPointTest()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void ExitWindowsExTest()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void DrawTextTest()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void GetClientRectTest()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void GetWindowRectTest()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void InvalidateRectTest()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void MapWindowPointsTest()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void MapWindowPointsTest1()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void MapWindowPointsTest2()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void SendMessageTest6()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void LoadImageTest()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void LoadStringTest()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void LoadStringTest1()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void SetWindowsHookExTest()
		{
			throw new NotImplementedException();
		}

		[Test]
		public void SystemParametersInfoGetTest()
		{
			// Try get bool value
			var ptr = new SafeHGlobalHandle(4);
			Assert.That(SystemParametersInfo(SPI.SPI_GETCLIENTAREAANIMATION, 0, (IntPtr)ptr, 0));
			var bval1 = ptr.ToStructure<uint>() > 0;
			Assert.That(bval1, Is.True);

			// Try get generic bool value
			Assert.That(SystemParametersInfo(SPI.SPI_GETCLIENTAREAANIMATION, out bool bval2));
			Assert.That(bval2, Is.True);

			// Try get integral value
			ptr = new SafeHGlobalHandle(4);
			Assert.That(SystemParametersInfo(SPI.SPI_GETFOCUSBORDERHEIGHT, 0, (IntPtr)ptr, 0));
			var uval1 = ptr.ToStructure<uint>();
			Assert.That(uval1, Is.Not.Zero);

			// Try get generic integral value
			Assert.That(SystemParametersInfo<uint>(SPI.SPI_GETFOCUSBORDERHEIGHT, out var uval2));
			Assert.That(uval2, Is.EqualTo(uval1));

			// Try get struct value
			ptr = SafeHGlobalHandle.CreateFromStructure<RECT>();
			Assert.That(SystemParametersInfo(SPI.SPI_GETWORKAREA, 0, (IntPtr)ptr, 0));
			var rval1 = ptr.ToStructure<RECT>();
			Assert.That(rval1.IsEmpty, Is.False);

			// Try get generic struct value
			Assert.That(SystemParametersInfo(SPI.SPI_GETWORKAREA, out RECT rval2));
			Assert.That(rval2, Is.EqualTo(rval1));

			// Try get string value
			var sb = new System.Text.StringBuilder(Kernel32.MAX_PATH, Kernel32.MAX_PATH);
			Assert.That(SystemParametersInfo(SPI.SPI_GETDESKWALLPAPER, (uint)sb.Capacity, sb, 0));
			Assert.That(sb, Has.Length.GreaterThan(0));
		}

		[Test]
		public void SystemParametersInfoSetTest()
		{
			// Try set bool value
			Assert.That(SystemParametersInfo(SPI.SPI_SETCLIENTAREAANIMATION, 0, IntPtr.Zero, SPIF.SPIF_SENDCHANGE));

			// Try set generic bool value
			Assert.That(SystemParametersInfo(SPI.SPI_SETCLIENTAREAANIMATION, true));

			// Try set integral value
			Assert.That(SystemParametersInfo(SPI.SPI_SETFOCUSBORDERHEIGHT, 0, (IntPtr)3, SPIF.SPIF_SENDCHANGE));

			// Try set generic integral value
			Assert.That(SystemParametersInfo(SPI.SPI_SETFOCUSBORDERHEIGHT, 1u));

			// Try set struct value
			Assert.That(SystemParametersInfo(SPI.SPI_GETWORKAREA, out RECT area));
			area.right /= 2;
			var ptr = SafeHGlobalHandle.CreateFromStructure(area);
			Assert.That(SystemParametersInfo(SPI.SPI_SETWORKAREA, (uint)System.Runtime.InteropServices.Marshal.SizeOf(typeof(RECT)), (IntPtr)ptr, SPIF.SPIF_SENDCHANGE));

			// Try set generic struct value
			area.right *= 2;
			Assert.That(SystemParametersInfo(SPI.SPI_SETWORKAREA, area));

			// Try set string value
			var sb = new System.Text.StringBuilder(Kernel32.MAX_PATH, Kernel32.MAX_PATH);
			Assert.That(SystemParametersInfo(SPI.SPI_GETDESKWALLPAPER, (uint)sb.Capacity, sb, 0));
			var wp = @"C:\Temp\tsnew256.png";
			Assert.That(SystemParametersInfo(SPI.SPI_SETDESKWALLPAPER, (uint)wp.Length, wp, SPIF.SPIF_SENDCHANGE));
			Assert.That(SystemParametersInfo(SPI.SPI_SETDESKWALLPAPER, (uint)sb.Length, sb.ToString(), SPIF.SPIF_SENDCHANGE));
		}
	}
}