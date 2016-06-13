// Copyright (c) 2014-2015 Wolfgang Borgsmüller
// All rights reserved.
// 
// Redistribution and use in source and binary forms, with or without 
// modification, are permitted provided that the following conditions 
// are met:
// 
// 1. Redistributions of source code must retain the above copyright 
//    notice, this list of conditions and the following disclaimer.
// 
// 2. Redistributions in binary form must reproduce the above copyright 
//    notice, this list of conditions and the following disclaimer in the 
//    documentation and/or other materials provided with the distribution.
// 
// 3. Neither the name of the copyright holder nor the names of its 
//    contributors may be used to endorse or promote products derived 
//    from this software without specific prior written permission.
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS 
// "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT 
// LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS 
// FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE 
// COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, 
// INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, 
// BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS 
// OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND 
// ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR 
// TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE 
// USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

// Generated file. Do not edit.


using System;

namespace Chromium
{
	/// <summary>
	/// Supports creation and modification of menus. See CfxMenuId for the
	/// command ids that have default implementations. All user-defined command ids
	/// should be between MENU_ID_USER_FIRST and MENU_ID_USER_LAST. The functions of
	/// this structure can only be accessed on the browser process the UI thread.
	/// </summary>
	/// <remarks>
	/// See also the original CEF documentation in
	/// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_menu_model_capi.h">cef/include/capi/cef_menu_model_capi.h</see>.
	/// </remarks>
	public class CfxMenuModel : CfxBase {

        static CfxMenuModel () {
            CfxApiLoader.LoadCfxMenuModelApi();
        }

        private static readonly WeakCache weakCache = new WeakCache();

        internal static CfxMenuModel Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            lock(weakCache) {
                var wrapper = (CfxMenuModel)weakCache.Get(nativePtr);
                if(wrapper == null) {
                    wrapper = new CfxMenuModel(nativePtr);
                    weakCache.Add(wrapper);
                } else {
                    CfxApi.cfx_release(nativePtr);
                }
                return wrapper;
            }
        }


        internal CfxMenuModel(IntPtr nativePtr) : base(nativePtr) {}

        /// <summary>
        /// Returns the number of items in this menu.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_menu_model_capi.h">cef/include/capi/cef_menu_model_capi.h</see>.
        /// </remarks>
        public int Count {
            get {
                return CfxApi.cfx_menu_model_get_count(NativePtr);
            }
        }

        /// <summary>
        /// Clears the menu. Returns true (1) on success.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_menu_model_capi.h">cef/include/capi/cef_menu_model_capi.h</see>.
        /// </remarks>
        public bool Clear() {
            return 0 != CfxApi.cfx_menu_model_clear(NativePtr);
        }

        /// <summary>
        /// Add a separator to the menu. Returns true (1) on success.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_menu_model_capi.h">cef/include/capi/cef_menu_model_capi.h</see>.
        /// </remarks>
        public bool AddSeparator() {
            return 0 != CfxApi.cfx_menu_model_add_separator(NativePtr);
        }

        /// <summary>
        /// Add an item to the menu. Returns true (1) on success.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_menu_model_capi.h">cef/include/capi/cef_menu_model_capi.h</see>.
        /// </remarks>
        public bool AddItem(int commandId, string label) {
            var label_pinned = new PinnedString(label);
            var __retval = CfxApi.cfx_menu_model_add_item(NativePtr, commandId, label_pinned.Obj.PinnedPtr, label_pinned.Length);
            label_pinned.Obj.Free();
            return 0 != __retval;
        }

        /// <summary>
        /// Add a check item to the menu. Returns true (1) on success.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_menu_model_capi.h">cef/include/capi/cef_menu_model_capi.h</see>.
        /// </remarks>
        public bool AddCheckItem(int commandId, string label) {
            var label_pinned = new PinnedString(label);
            var __retval = CfxApi.cfx_menu_model_add_check_item(NativePtr, commandId, label_pinned.Obj.PinnedPtr, label_pinned.Length);
            label_pinned.Obj.Free();
            return 0 != __retval;
        }

        /// <summary>
        /// Add a radio item to the menu. Only a single item with the specified
        /// |groupId| can be checked at a time. Returns true (1) on success.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_menu_model_capi.h">cef/include/capi/cef_menu_model_capi.h</see>.
        /// </remarks>
        public bool AddRadioItem(int commandId, string label, int groupId) {
            var label_pinned = new PinnedString(label);
            var __retval = CfxApi.cfx_menu_model_add_radio_item(NativePtr, commandId, label_pinned.Obj.PinnedPtr, label_pinned.Length, groupId);
            label_pinned.Obj.Free();
            return 0 != __retval;
        }

        /// <summary>
        /// Add a sub-menu to the menu. The new sub-menu is returned.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_menu_model_capi.h">cef/include/capi/cef_menu_model_capi.h</see>.
        /// </remarks>
        public CfxMenuModel AddSubmenu(int commandId, string label) {
            var label_pinned = new PinnedString(label);
            var __retval = CfxApi.cfx_menu_model_add_sub_menu(NativePtr, commandId, label_pinned.Obj.PinnedPtr, label_pinned.Length);
            label_pinned.Obj.Free();
            return CfxMenuModel.Wrap(__retval);
        }

        /// <summary>
        /// Insert a separator in the menu at the specified |index|. Returns true (1)
        /// on success.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_menu_model_capi.h">cef/include/capi/cef_menu_model_capi.h</see>.
        /// </remarks>
        public bool InsertSeparatorAt(int index) {
            return 0 != CfxApi.cfx_menu_model_insert_separator_at(NativePtr, index);
        }

        /// <summary>
        /// Insert an item in the menu at the specified |index|. Returns true (1) on
        /// success.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_menu_model_capi.h">cef/include/capi/cef_menu_model_capi.h</see>.
        /// </remarks>
        public bool InsertItemAt(int index, int commandId, string label) {
            var label_pinned = new PinnedString(label);
            var __retval = CfxApi.cfx_menu_model_insert_item_at(NativePtr, index, commandId, label_pinned.Obj.PinnedPtr, label_pinned.Length);
            label_pinned.Obj.Free();
            return 0 != __retval;
        }

        /// <summary>
        /// Insert a check item in the menu at the specified |index|. Returns true (1)
        /// on success.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_menu_model_capi.h">cef/include/capi/cef_menu_model_capi.h</see>.
        /// </remarks>
        public bool InsertCheckItemAt(int index, int commandId, string label) {
            var label_pinned = new PinnedString(label);
            var __retval = CfxApi.cfx_menu_model_insert_check_item_at(NativePtr, index, commandId, label_pinned.Obj.PinnedPtr, label_pinned.Length);
            label_pinned.Obj.Free();
            return 0 != __retval;
        }

        /// <summary>
        /// Insert a radio item in the menu at the specified |index|. Only a single
        /// item with the specified |groupId| can be checked at a time. Returns true
        /// (1) on success.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_menu_model_capi.h">cef/include/capi/cef_menu_model_capi.h</see>.
        /// </remarks>
        public bool InsertRadioItemAt(int index, int commandId, string label, int groupId) {
            var label_pinned = new PinnedString(label);
            var __retval = CfxApi.cfx_menu_model_insert_radio_item_at(NativePtr, index, commandId, label_pinned.Obj.PinnedPtr, label_pinned.Length, groupId);
            label_pinned.Obj.Free();
            return 0 != __retval;
        }

        /// <summary>
        /// Insert a sub-menu in the menu at the specified |index|. The new sub-menu is
        /// returned.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_menu_model_capi.h">cef/include/capi/cef_menu_model_capi.h</see>.
        /// </remarks>
        public CfxMenuModel InsertSubmenuAt(int index, int commandId, string label) {
            var label_pinned = new PinnedString(label);
            var __retval = CfxApi.cfx_menu_model_insert_sub_menu_at(NativePtr, index, commandId, label_pinned.Obj.PinnedPtr, label_pinned.Length);
            label_pinned.Obj.Free();
            return CfxMenuModel.Wrap(__retval);
        }

        /// <summary>
        /// Removes the item with the specified |commandId|. Returns true (1) on
        /// success.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_menu_model_capi.h">cef/include/capi/cef_menu_model_capi.h</see>.
        /// </remarks>
        public bool Remove(int commandId) {
            return 0 != CfxApi.cfx_menu_model_remove(NativePtr, commandId);
        }

        /// <summary>
        /// Removes the item at the specified |index|. Returns true (1) on success.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_menu_model_capi.h">cef/include/capi/cef_menu_model_capi.h</see>.
        /// </remarks>
        public bool RemoveAt(int index) {
            return 0 != CfxApi.cfx_menu_model_remove_at(NativePtr, index);
        }

        /// <summary>
        /// Returns the index associated with the specified |commandId| or -1 if not
        /// found due to the command id not existing in the menu.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_menu_model_capi.h">cef/include/capi/cef_menu_model_capi.h</see>.
        /// </remarks>
        public int GetIndexOf(int commandId) {
            return CfxApi.cfx_menu_model_get_index_of(NativePtr, commandId);
        }

        /// <summary>
        /// Returns the command id at the specified |index| or -1 if not found due to
        /// invalid range or the index being a separator.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_menu_model_capi.h">cef/include/capi/cef_menu_model_capi.h</see>.
        /// </remarks>
        public int GetCommandIdAt(int index) {
            return CfxApi.cfx_menu_model_get_command_id_at(NativePtr, index);
        }

        /// <summary>
        /// Sets the command id at the specified |index|. Returns true (1) on success.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_menu_model_capi.h">cef/include/capi/cef_menu_model_capi.h</see>.
        /// </remarks>
        public bool SetCommandIdAt(int index, int commandId) {
            return 0 != CfxApi.cfx_menu_model_set_command_id_at(NativePtr, index, commandId);
        }

        /// <summary>
        /// Returns the label for the specified |commandId| or NULL if not found.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_menu_model_capi.h">cef/include/capi/cef_menu_model_capi.h</see>.
        /// </remarks>
        public string GetLabel(int commandId) {
            return StringFunctions.ConvertStringUserfree(CfxApi.cfx_menu_model_get_label(NativePtr, commandId));
        }

        /// <summary>
        /// Returns the label at the specified |index| or NULL if not found due to
        /// invalid range or the index being a separator.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_menu_model_capi.h">cef/include/capi/cef_menu_model_capi.h</see>.
        /// </remarks>
        public string GetLabelAt(int index) {
            return StringFunctions.ConvertStringUserfree(CfxApi.cfx_menu_model_get_label_at(NativePtr, index));
        }

        /// <summary>
        /// Sets the label for the specified |commandId|. Returns true (1) on success.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_menu_model_capi.h">cef/include/capi/cef_menu_model_capi.h</see>.
        /// </remarks>
        public bool SetLabel(int commandId, string label) {
            var label_pinned = new PinnedString(label);
            var __retval = CfxApi.cfx_menu_model_set_label(NativePtr, commandId, label_pinned.Obj.PinnedPtr, label_pinned.Length);
            label_pinned.Obj.Free();
            return 0 != __retval;
        }

        /// <summary>
        /// Set the label at the specified |index|. Returns true (1) on success.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_menu_model_capi.h">cef/include/capi/cef_menu_model_capi.h</see>.
        /// </remarks>
        public bool SetLabelAt(int index, string label) {
            var label_pinned = new PinnedString(label);
            var __retval = CfxApi.cfx_menu_model_set_label_at(NativePtr, index, label_pinned.Obj.PinnedPtr, label_pinned.Length);
            label_pinned.Obj.Free();
            return 0 != __retval;
        }

        /// <summary>
        /// Returns the item type for the specified |commandId|.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_menu_model_capi.h">cef/include/capi/cef_menu_model_capi.h</see>.
        /// </remarks>
        public CfxMenuItemType GetType(int commandId) {
            return (CfxMenuItemType)CfxApi.cfx_menu_model_get_type(NativePtr, commandId);
        }

        /// <summary>
        /// Returns the item type at the specified |index|.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_menu_model_capi.h">cef/include/capi/cef_menu_model_capi.h</see>.
        /// </remarks>
        public CfxMenuItemType GetTypeAt(int index) {
            return (CfxMenuItemType)CfxApi.cfx_menu_model_get_type_at(NativePtr, index);
        }

        /// <summary>
        /// Returns the group id for the specified |commandId| or -1 if invalid.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_menu_model_capi.h">cef/include/capi/cef_menu_model_capi.h</see>.
        /// </remarks>
        public int GetGroupId(int commandId) {
            return CfxApi.cfx_menu_model_get_group_id(NativePtr, commandId);
        }

        /// <summary>
        /// Returns the group id at the specified |index| or -1 if invalid.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_menu_model_capi.h">cef/include/capi/cef_menu_model_capi.h</see>.
        /// </remarks>
        public int GetGroupIdAt(int index) {
            return CfxApi.cfx_menu_model_get_group_id_at(NativePtr, index);
        }

        /// <summary>
        /// Sets the group id for the specified |commandId|. Returns true (1) on
        /// success.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_menu_model_capi.h">cef/include/capi/cef_menu_model_capi.h</see>.
        /// </remarks>
        public bool SetGroupId(int commandId, int groupId) {
            return 0 != CfxApi.cfx_menu_model_set_group_id(NativePtr, commandId, groupId);
        }

        /// <summary>
        /// Sets the group id at the specified |index|. Returns true (1) on success.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_menu_model_capi.h">cef/include/capi/cef_menu_model_capi.h</see>.
        /// </remarks>
        public bool SetGroupIdAt(int index, int groupId) {
            return 0 != CfxApi.cfx_menu_model_set_group_id_at(NativePtr, index, groupId);
        }

        /// <summary>
        /// Returns the submenu for the specified |commandId| or NULL if invalid.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_menu_model_capi.h">cef/include/capi/cef_menu_model_capi.h</see>.
        /// </remarks>
        public CfxMenuModel GetSubmenu(int commandId) {
            return CfxMenuModel.Wrap(CfxApi.cfx_menu_model_get_sub_menu(NativePtr, commandId));
        }

        /// <summary>
        /// Returns the submenu at the specified |index| or NULL if invalid.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_menu_model_capi.h">cef/include/capi/cef_menu_model_capi.h</see>.
        /// </remarks>
        public CfxMenuModel GetSubmenuAt(int index) {
            return CfxMenuModel.Wrap(CfxApi.cfx_menu_model_get_sub_menu_at(NativePtr, index));
        }

        /// <summary>
        /// Returns true (1) if the specified |commandId| is visible.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_menu_model_capi.h">cef/include/capi/cef_menu_model_capi.h</see>.
        /// </remarks>
        public bool IsVisible(int commandId) {
            return 0 != CfxApi.cfx_menu_model_is_visible(NativePtr, commandId);
        }

        /// <summary>
        /// Returns true (1) if the specified |index| is visible.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_menu_model_capi.h">cef/include/capi/cef_menu_model_capi.h</see>.
        /// </remarks>
        public bool IsVisibleAt(int index) {
            return 0 != CfxApi.cfx_menu_model_is_visible_at(NativePtr, index);
        }

        /// <summary>
        /// Change the visibility of the specified |commandId|. Returns true (1) on
        /// success.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_menu_model_capi.h">cef/include/capi/cef_menu_model_capi.h</see>.
        /// </remarks>
        public bool SetVisible(int commandId, bool visible) {
            return 0 != CfxApi.cfx_menu_model_set_visible(NativePtr, commandId, visible ? 1 : 0);
        }

        /// <summary>
        /// Change the visibility at the specified |index|. Returns true (1) on
        /// success.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_menu_model_capi.h">cef/include/capi/cef_menu_model_capi.h</see>.
        /// </remarks>
        public bool SetVisibleAt(int index, bool visible) {
            return 0 != CfxApi.cfx_menu_model_set_visible_at(NativePtr, index, visible ? 1 : 0);
        }

        /// <summary>
        /// Returns true (1) if the specified |commandId| is enabled.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_menu_model_capi.h">cef/include/capi/cef_menu_model_capi.h</see>.
        /// </remarks>
        public bool IsEnabled(int commandId) {
            return 0 != CfxApi.cfx_menu_model_is_enabled(NativePtr, commandId);
        }

        /// <summary>
        /// Returns true (1) if the specified |index| is enabled.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_menu_model_capi.h">cef/include/capi/cef_menu_model_capi.h</see>.
        /// </remarks>
        public bool IsEnabledAt(int index) {
            return 0 != CfxApi.cfx_menu_model_is_enabled_at(NativePtr, index);
        }

        /// <summary>
        /// Change the enabled status of the specified |commandId|. Returns true (1)
        /// on success.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_menu_model_capi.h">cef/include/capi/cef_menu_model_capi.h</see>.
        /// </remarks>
        public bool SetEnabled(int commandId, bool enabled) {
            return 0 != CfxApi.cfx_menu_model_set_enabled(NativePtr, commandId, enabled ? 1 : 0);
        }

        /// <summary>
        /// Change the enabled status at the specified |index|. Returns true (1) on
        /// success.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_menu_model_capi.h">cef/include/capi/cef_menu_model_capi.h</see>.
        /// </remarks>
        public bool SetEnabledAt(int index, bool enabled) {
            return 0 != CfxApi.cfx_menu_model_set_enabled_at(NativePtr, index, enabled ? 1 : 0);
        }

        /// <summary>
        /// Returns true (1) if the specified |commandId| is checked. Only applies to
        /// check and radio items.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_menu_model_capi.h">cef/include/capi/cef_menu_model_capi.h</see>.
        /// </remarks>
        public bool IsChecked(int commandId) {
            return 0 != CfxApi.cfx_menu_model_is_checked(NativePtr, commandId);
        }

        /// <summary>
        /// Returns true (1) if the specified |index| is checked. Only applies to check
        /// and radio items.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_menu_model_capi.h">cef/include/capi/cef_menu_model_capi.h</see>.
        /// </remarks>
        public bool IsCheckedAt(int index) {
            return 0 != CfxApi.cfx_menu_model_is_checked_at(NativePtr, index);
        }

        /// <summary>
        /// Check the specified |commandId|. Only applies to check and radio items.
        /// Returns true (1) on success.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_menu_model_capi.h">cef/include/capi/cef_menu_model_capi.h</see>.
        /// </remarks>
        public bool SetChecked(int commandId, bool @checked) {
            return 0 != CfxApi.cfx_menu_model_set_checked(NativePtr, commandId, @checked ? 1 : 0);
        }

        /// <summary>
        /// Check the specified |index|. Only applies to check and radio items. Returns
        /// true (1) on success.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_menu_model_capi.h">cef/include/capi/cef_menu_model_capi.h</see>.
        /// </remarks>
        public bool SetCheckedAt(int index, bool @checked) {
            return 0 != CfxApi.cfx_menu_model_set_checked_at(NativePtr, index, @checked ? 1 : 0);
        }

        /// <summary>
        /// Returns true (1) if the specified |commandId| has a keyboard accelerator
        /// assigned.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_menu_model_capi.h">cef/include/capi/cef_menu_model_capi.h</see>.
        /// </remarks>
        public bool HasAccelerator(int commandId) {
            return 0 != CfxApi.cfx_menu_model_has_accelerator(NativePtr, commandId);
        }

        /// <summary>
        /// Returns true (1) if the specified |index| has a keyboard accelerator
        /// assigned.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_menu_model_capi.h">cef/include/capi/cef_menu_model_capi.h</see>.
        /// </remarks>
        public bool HasAcceleratorAt(int index) {
            return 0 != CfxApi.cfx_menu_model_has_accelerator_at(NativePtr, index);
        }

        /// <summary>
        /// Set the keyboard accelerator for the specified |commandId|. |keyCode| can
        /// be any virtual key or character value. Returns true (1) on success.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_menu_model_capi.h">cef/include/capi/cef_menu_model_capi.h</see>.
        /// </remarks>
        public bool SetAccelerator(int commandId, int keyCode, bool shiftPressed, bool ctrlPressed, bool altPressed) {
            return 0 != CfxApi.cfx_menu_model_set_accelerator(NativePtr, commandId, keyCode, shiftPressed ? 1 : 0, ctrlPressed ? 1 : 0, altPressed ? 1 : 0);
        }

        /// <summary>
        /// Set the keyboard accelerator at the specified |index|. |keyCode| can be
        /// any virtual key or character value. Returns true (1) on success.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_menu_model_capi.h">cef/include/capi/cef_menu_model_capi.h</see>.
        /// </remarks>
        public bool SetAcceleratorAt(int index, int keyCode, bool shiftPressed, bool ctrlPressed, bool altPressed) {
            return 0 != CfxApi.cfx_menu_model_set_accelerator_at(NativePtr, index, keyCode, shiftPressed ? 1 : 0, ctrlPressed ? 1 : 0, altPressed ? 1 : 0);
        }

        /// <summary>
        /// Remove the keyboard accelerator for the specified |commandId|. Returns
        /// true (1) on success.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_menu_model_capi.h">cef/include/capi/cef_menu_model_capi.h</see>.
        /// </remarks>
        public bool RemoveAccelerator(int commandId) {
            return 0 != CfxApi.cfx_menu_model_remove_accelerator(NativePtr, commandId);
        }

        /// <summary>
        /// Remove the keyboard accelerator at the specified |index|. Returns true (1)
        /// on success.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_menu_model_capi.h">cef/include/capi/cef_menu_model_capi.h</see>.
        /// </remarks>
        public bool RemoveAcceleratorAt(int index) {
            return 0 != CfxApi.cfx_menu_model_remove_accelerator_at(NativePtr, index);
        }

        /// <summary>
        /// Retrieves the keyboard accelerator for the specified |commandId|. Returns
        /// true (1) on success.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_menu_model_capi.h">cef/include/capi/cef_menu_model_capi.h</see>.
        /// </remarks>
        public bool GetAccelerator(int commandId, out int keyCode, out bool shiftPressed, out bool ctrlPressed, out bool altPressed) {
            int shiftPressed_unwrapped;
            int ctrlPressed_unwrapped;
            int altPressed_unwrapped;
            var __retval = CfxApi.cfx_menu_model_get_accelerator(NativePtr, commandId, out keyCode, out shiftPressed_unwrapped, out ctrlPressed_unwrapped, out altPressed_unwrapped);
            shiftPressed = shiftPressed_unwrapped != 0;
            ctrlPressed = ctrlPressed_unwrapped != 0;
            altPressed = altPressed_unwrapped != 0;
            return 0 != __retval;
        }

        /// <summary>
        /// Retrieves the keyboard accelerator for the specified |index|. Returns true
        /// (1) on success.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_menu_model_capi.h">cef/include/capi/cef_menu_model_capi.h</see>.
        /// </remarks>
        public bool GetAcceleratorAt(int index, out int keyCode, out bool shiftPressed, out bool ctrlPressed, out bool altPressed) {
            int shiftPressed_unwrapped;
            int ctrlPressed_unwrapped;
            int altPressed_unwrapped;
            var __retval = CfxApi.cfx_menu_model_get_accelerator_at(NativePtr, index, out keyCode, out shiftPressed_unwrapped, out ctrlPressed_unwrapped, out altPressed_unwrapped);
            shiftPressed = shiftPressed_unwrapped != 0;
            ctrlPressed = ctrlPressed_unwrapped != 0;
            altPressed = altPressed_unwrapped != 0;
            return 0 != __retval;
        }

        internal override void OnDispose(IntPtr nativePtr) {
            weakCache.Remove(nativePtr);
            base.OnDispose(nativePtr);
        }
    }
}
