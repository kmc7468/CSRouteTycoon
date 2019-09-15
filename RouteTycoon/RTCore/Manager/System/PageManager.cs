using System;
using System.Windows.Forms;

namespace RouteTycoon.RTCore
{
	public static class PageManager
	{
		internal static RTUI.frmPage PageForm = null;
		private static Page nowpage = null;

		public static void SetPage(Page page, string password = "", bool disOldpage = false)
		{
			try
			{
				if (password != AccessManager.AccessKey)
				{
					if (!AccessManager.GetPluginPermission(AccessManager.PluginPermission.PageManager_SetPage))
						throw new UnabletoAccessPermission();
				}

				Page ctrl = page;

				ctrl.Dock = DockStyle.Fill;

				if (PageForm == null)
				{
					RTUI.frmPage tmp = new RTUI.frmPage();
					PageForm = tmp;
				}

				if (PageForm.Controls.Count > 0)
					if (PageForm.Controls[0] is Page)
						(PageForm.Controls[0] as Page).OnClose();

				ctrl.OnLoad();
				
				PageForm.Controls.Clear();
				PageForm.Controls.Add(ctrl);

				if (disOldpage && nowpage != null && !nowpage.IsDisposed)
					nowpage.Dispose();

				nowpage = ctrl;

				bool reet = PageForm.Visible;

				if(!reet)
				{
					PageForm.ShowDialog();
				}
				
				LogManager.SetPage(page);
			}
			catch (Exception ex)
			{
				Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		public static void Close(bool disPage = true, string password = "")
		{
			try
			{
				if (password != AccessManager.AccessKey)
					if (!AccessManager.GetPluginPermission(AccessManager.PluginPermission.PageManager_Close))
						throw new UnabletoAccessPermission();

				PageForm.Visible = false;
				PageForm.Controls.Clear();

				nowpage.OnClose();

				if (disPage && nowpage != null && !nowpage.IsDisposed)
					nowpage.Dispose();

				nowpage = null;
			}
			catch(Exception ex)
			{
				Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		public static Page GetNowPage(string password = "")
		{
			if (password != AccessManager.AccessKey)
			{
				if (!AccessManager.GetPluginPermission(AccessManager.PluginPermission.PageManager_GetPage))
					throw new Exception("접근 권한이 없습니다.");
			}

			return nowpage;
		}
	}
}
