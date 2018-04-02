// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium {
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
    public class CfxMenuModel : CfxBaseLibrary {

        internal static CfxMenuModel Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            bool isNew = false;
            var wrapper = (CfxMenuModel)weakCache.GetOrAdd(nativePtr, () =>  {
                isNew = true;
                return new CfxMenuModel(nativePtr);
            });
            if(!isNew) {
                CfxApi.cfx_release(nativePtr);
            }
            return wrapper;
        }


        internal CfxMenuModel(IntPtr nativePtr) : base(nativePtr) {}

        /// <summary>
        /// Create a new MenuModel with the specified |delegate|.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_menu_model_capi.h">cef/include/capi/cef_menu_model_capi.h</see>.
        /// </remarks>
        public static CfxMenuModel Create(CfxMenuModelDelegate @delegate) {
            return CfxMenuModel.Wrap(CfxApi.MenuModel.cfx_menu_model_create(CfxMenuModelDelegate.Unwrap(@delegate)));
        }

        /// <summary>
        /// Returns true (1) if this menu is a submenu.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_menu_model_capi.h">cef/include/capi/cef_menu_model_capi.h</see>.
        /// </remarks>
        public bool IsSubmenu {
            get {
                return 0 != CfxApi.MenuModel.cfx_menu_model_is_sub_menu(NativePtr);
            }
        }

        /// <summary>
        /// Returns the number of items in this menu.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_menu_model_capi.h">cef/include/capi/cef_menu_model_capi.h</see>.
        /// </remarks>
        public int Count {
            get {
                return CfxApi.MenuModel.cfx_menu_model_get_count(NativePtr);
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
            return 0 != CfxApi.MenuModel.cfx_menu_model_clear(NativePtr);
        }

        /// <summary>
        /// Add a separator to the menu. Returns true (1) on success.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_menu_model_capi.h">cef/include/capi/cef_menu_model_capi.h</see>.
        /// </remarks>
        public bool AddSeparator() {
            return 0 != CfxApi.MenuModel.cfx_menu_model_add_separator(NativePtr);
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
            var __retval = CfxApi.MenuModel.cfx_menu_model_add_item(NativePtr, commandId, label_pinned.Obj.PinnedPtr, label_pinned.Length);
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
            var __retval = CfxApi.MenuModel.cfx_menu_model_add_check_item(NativePtr, commandId, label_pinned.Obj.PinnedPtr, label_pinned.Length);
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
            var __retval = CfxApi.MenuModel.cfx_menu_model_add_radio_item(NativePtr, commandId, label_pinned.Obj.PinnedPtr, label_pinned.Length, groupId);
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
            var __retval = CfxApi.MenuModel.cfx_menu_model_add_sub_menu(NativePtr, commandId, label_pinned.Obj.PinnedPtr, label_pinned.Length);
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
            return 0 != CfxApi.MenuModel.cfx_menu_model_insert_separator_at(NativePtr, index);
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
            var __retval = CfxApi.MenuModel.cfx_menu_model_insert_item_at(NativePtr, index, commandId, label_pinned.Obj.PinnedPtr, label_pinned.Length);
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
            var __retval = CfxApi.MenuModel.cfx_menu_model_insert_check_item_at(NativePtr, index, commandId, label_pinned.Obj.PinnedPtr, label_pinned.Length);
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
            var __retval = CfxApi.MenuModel.cfx_menu_model_insert_radio_item_at(NativePtr, index, commandId, label_pinned.Obj.PinnedPtr, label_pinned.Length, groupId);
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
            var __retval = CfxApi.MenuModel.cfx_menu_model_insert_sub_menu_at(NativePtr, index, commandId, label_pinned.Obj.PinnedPtr, label_pinned.Length);
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
            return 0 != CfxApi.MenuModel.cfx_menu_model_remove(NativePtr, commandId);
        }

        /// <summary>
        /// Removes the item at the specified |index|. Returns true (1) on success.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_menu_model_capi.h">cef/include/capi/cef_menu_model_capi.h</see>.
        /// </remarks>
        public bool RemoveAt(int index) {
            return 0 != CfxApi.MenuModel.cfx_menu_model_remove_at(NativePtr, index);
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
            return CfxApi.MenuModel.cfx_menu_model_get_index_of(NativePtr, commandId);
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
            return CfxApi.MenuModel.cfx_menu_model_get_command_id_at(NativePtr, index);
        }

        /// <summary>
        /// Sets the command id at the specified |index|. Returns true (1) on success.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_menu_model_capi.h">cef/include/capi/cef_menu_model_capi.h</see>.
        /// </remarks>
        public bool SetCommandIdAt(int index, int commandId) {
            return 0 != CfxApi.MenuModel.cfx_menu_model_set_command_id_at(NativePtr, index, commandId);
        }

        /// <summary>
        /// Returns the label for the specified |commandId| or NULL if not found.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_menu_model_capi.h">cef/include/capi/cef_menu_model_capi.h</see>.
        /// </remarks>
        public string GetLabel(int commandId) {
            return StringFunctions.ConvertStringUserfree(CfxApi.MenuModel.cfx_menu_model_get_label(NativePtr, commandId));
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
            return StringFunctions.ConvertStringUserfree(CfxApi.MenuModel.cfx_menu_model_get_label_at(NativePtr, index));
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
            var __retval = CfxApi.MenuModel.cfx_menu_model_set_label(NativePtr, commandId, label_pinned.Obj.PinnedPtr, label_pinned.Length);
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
            var __retval = CfxApi.MenuModel.cfx_menu_model_set_label_at(NativePtr, index, label_pinned.Obj.PinnedPtr, label_pinned.Length);
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
            return (CfxMenuItemType)CfxApi.MenuModel.cfx_menu_model_get_type(NativePtr, commandId);
        }

        /// <summary>
        /// Returns the item type at the specified |index|.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_menu_model_capi.h">cef/include/capi/cef_menu_model_capi.h</see>.
        /// </remarks>
        public CfxMenuItemType GetTypeAt(int index) {
            return (CfxMenuItemType)CfxApi.MenuModel.cfx_menu_model_get_type_at(NativePtr, index);
        }

        /// <summary>
        /// Returns the group id for the specified |commandId| or -1 if invalid.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_menu_model_capi.h">cef/include/capi/cef_menu_model_capi.h</see>.
        /// </remarks>
        public int GetGroupId(int commandId) {
            return CfxApi.MenuModel.cfx_menu_model_get_group_id(NativePtr, commandId);
        }

        /// <summary>
        /// Returns the group id at the specified |index| or -1 if invalid.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_menu_model_capi.h">cef/include/capi/cef_menu_model_capi.h</see>.
        /// </remarks>
        public int GetGroupIdAt(int index) {
            return CfxApi.MenuModel.cfx_menu_model_get_group_id_at(NativePtr, index);
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
            return 0 != CfxApi.MenuModel.cfx_menu_model_set_group_id(NativePtr, commandId, groupId);
        }

        /// <summary>
        /// Sets the group id at the specified |index|. Returns true (1) on success.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_menu_model_capi.h">cef/include/capi/cef_menu_model_capi.h</see>.
        /// </remarks>
        public bool SetGroupIdAt(int index, int groupId) {
            return 0 != CfxApi.MenuModel.cfx_menu_model_set_group_id_at(NativePtr, index, groupId);
        }

        /// <summary>
        /// Returns the submenu for the specified |commandId| or NULL if invalid.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_menu_model_capi.h">cef/include/capi/cef_menu_model_capi.h</see>.
        /// </remarks>
        public CfxMenuModel GetSubmenu(int commandId) {
            return CfxMenuModel.Wrap(CfxApi.MenuModel.cfx_menu_model_get_sub_menu(NativePtr, commandId));
        }

        /// <summary>
        /// Returns the submenu at the specified |index| or NULL if invalid.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_menu_model_capi.h">cef/include/capi/cef_menu_model_capi.h</see>.
        /// </remarks>
        public CfxMenuModel GetSubmenuAt(int index) {
            return CfxMenuModel.Wrap(CfxApi.MenuModel.cfx_menu_model_get_sub_menu_at(NativePtr, index));
        }

        /// <summary>
        /// Returns true (1) if the specified |commandId| is visible.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_menu_model_capi.h">cef/include/capi/cef_menu_model_capi.h</see>.
        /// </remarks>
        public bool IsVisible(int commandId) {
            return 0 != CfxApi.MenuModel.cfx_menu_model_is_visible(NativePtr, commandId);
        }

        /// <summary>
        /// Returns true (1) if the specified |index| is visible.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_menu_model_capi.h">cef/include/capi/cef_menu_model_capi.h</see>.
        /// </remarks>
        public bool IsVisibleAt(int index) {
            return 0 != CfxApi.MenuModel.cfx_menu_model_is_visible_at(NativePtr, index);
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
            return 0 != CfxApi.MenuModel.cfx_menu_model_set_visible(NativePtr, commandId, visible ? 1 : 0);
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
            return 0 != CfxApi.MenuModel.cfx_menu_model_set_visible_at(NativePtr, index, visible ? 1 : 0);
        }

        /// <summary>
        /// Returns true (1) if the specified |commandId| is enabled.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_menu_model_capi.h">cef/include/capi/cef_menu_model_capi.h</see>.
        /// </remarks>
        public bool IsEnabled(int commandId) {
            return 0 != CfxApi.MenuModel.cfx_menu_model_is_enabled(NativePtr, commandId);
        }

        /// <summary>
        /// Returns true (1) if the specified |index| is enabled.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_menu_model_capi.h">cef/include/capi/cef_menu_model_capi.h</see>.
        /// </remarks>
        public bool IsEnabledAt(int index) {
            return 0 != CfxApi.MenuModel.cfx_menu_model_is_enabled_at(NativePtr, index);
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
            return 0 != CfxApi.MenuModel.cfx_menu_model_set_enabled(NativePtr, commandId, enabled ? 1 : 0);
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
            return 0 != CfxApi.MenuModel.cfx_menu_model_set_enabled_at(NativePtr, index, enabled ? 1 : 0);
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
            return 0 != CfxApi.MenuModel.cfx_menu_model_is_checked(NativePtr, commandId);
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
            return 0 != CfxApi.MenuModel.cfx_menu_model_is_checked_at(NativePtr, index);
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
            return 0 != CfxApi.MenuModel.cfx_menu_model_set_checked(NativePtr, commandId, @checked ? 1 : 0);
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
            return 0 != CfxApi.MenuModel.cfx_menu_model_set_checked_at(NativePtr, index, @checked ? 1 : 0);
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
            return 0 != CfxApi.MenuModel.cfx_menu_model_has_accelerator(NativePtr, commandId);
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
            return 0 != CfxApi.MenuModel.cfx_menu_model_has_accelerator_at(NativePtr, index);
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
            return 0 != CfxApi.MenuModel.cfx_menu_model_set_accelerator(NativePtr, commandId, keyCode, shiftPressed ? 1 : 0, ctrlPressed ? 1 : 0, altPressed ? 1 : 0);
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
            return 0 != CfxApi.MenuModel.cfx_menu_model_set_accelerator_at(NativePtr, index, keyCode, shiftPressed ? 1 : 0, ctrlPressed ? 1 : 0, altPressed ? 1 : 0);
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
            return 0 != CfxApi.MenuModel.cfx_menu_model_remove_accelerator(NativePtr, commandId);
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
            return 0 != CfxApi.MenuModel.cfx_menu_model_remove_accelerator_at(NativePtr, index);
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
            var __retval = CfxApi.MenuModel.cfx_menu_model_get_accelerator(NativePtr, commandId, out keyCode, out shiftPressed_unwrapped, out ctrlPressed_unwrapped, out altPressed_unwrapped);
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
            var __retval = CfxApi.MenuModel.cfx_menu_model_get_accelerator_at(NativePtr, index, out keyCode, out shiftPressed_unwrapped, out ctrlPressed_unwrapped, out altPressed_unwrapped);
            shiftPressed = shiftPressed_unwrapped != 0;
            ctrlPressed = ctrlPressed_unwrapped != 0;
            altPressed = altPressed_unwrapped != 0;
            return 0 != __retval;
        }

        /// <summary>
        /// Set the explicit color for |commandId| and |colorType| to |color|.
        /// Specify a |color| value of 0 to remove the explicit color. If no explicit
        /// color or default color is set for |colorType| then the system color will
        /// be used. Returns true (1) on success.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_menu_model_capi.h">cef/include/capi/cef_menu_model_capi.h</see>.
        /// </remarks>
        public bool SetColor(int commandId, CfxMenuColorType colorType, CfxColor color) {
            return 0 != CfxApi.MenuModel.cfx_menu_model_set_color(NativePtr, commandId, (int)colorType, CfxColor.Unwrap(color));
        }

        /// <summary>
        /// Set the explicit color for |commandId| and |index| to |color|. Specify a
        /// |color| value of 0 to remove the explicit color. Specify an |index| value
        /// of -1 to set the default color for items that do not have an explicit color
        /// set. If no explicit color or default color is set for |colorType| then the
        /// system color will be used. Returns true (1) on success.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_menu_model_capi.h">cef/include/capi/cef_menu_model_capi.h</see>.
        /// </remarks>
        public bool SetColorAt(int index, CfxMenuColorType colorType, CfxColor color) {
            return 0 != CfxApi.MenuModel.cfx_menu_model_set_color_at(NativePtr, index, (int)colorType, CfxColor.Unwrap(color));
        }

        /// <summary>
        /// Returns in |color| the color that was explicitly set for |commandId| and
        /// |colorType|. If a color was not set then 0 will be returned in |color|.
        /// Returns true (1) on success.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_menu_model_capi.h">cef/include/capi/cef_menu_model_capi.h</see>.
        /// </remarks>
        public bool GetColor(int commandId, CfxMenuColorType colorType, ref CfxColor color) {
            return 0 != CfxApi.MenuModel.cfx_menu_model_get_color(NativePtr, commandId, (int)colorType, ref color.color);
        }

        /// <summary>
        /// Returns in |color| the color that was explicitly set for |commandId| and
        /// |colorType|. Specify an |index| value of -1 to return the default color in
        /// |color|. If a color was not set then 0 will be returned in |color|. Returns
        /// true (1) on success.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_menu_model_capi.h">cef/include/capi/cef_menu_model_capi.h</see>.
        /// </remarks>
        public bool GetColorAt(int index, CfxMenuColorType colorType, ref CfxColor color) {
            return 0 != CfxApi.MenuModel.cfx_menu_model_get_color_at(NativePtr, index, (int)colorType, ref color.color);
        }

        /// <summary>
        /// Sets the font list for the specified |commandId|. If |fontList| is NULL
        /// the system font will be used. Returns true (1) on success. The format is
        /// "&lt;FONT_FAMILY_LIST>,[STYLES] &lt;SIZE>", where: - FONT_FAMILY_LIST is a comma-
        /// separated list of font family names, - STYLES is an optional space-
        /// separated list of style names (case-sensitive
        ///   "Bold" and "Italic" are supported), and
        /// - SIZE is an integer font size in pixels with the suffix "px".
        /// 
        /// Here are examples of valid font description strings: - "Arial, Helvetica,
        /// Bold Italic 14px" - "Arial, 14px"
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_menu_model_capi.h">cef/include/capi/cef_menu_model_capi.h</see>.
        /// </remarks>
        public bool SetFontList(int commandId, string fontList) {
            var fontList_pinned = new PinnedString(fontList);
            var __retval = CfxApi.MenuModel.cfx_menu_model_set_font_list(NativePtr, commandId, fontList_pinned.Obj.PinnedPtr, fontList_pinned.Length);
            fontList_pinned.Obj.Free();
            return 0 != __retval;
        }

        /// <summary>
        /// Sets the font list for the specified |index|. Specify an |index| value of
        /// -1 to set the default font. If |fontList| is NULL the system font will be
        /// used. Returns true (1) on success. The format is
        /// "&lt;FONT_FAMILY_LIST>,[STYLES] &lt;SIZE>", where: - FONT_FAMILY_LIST is a comma-
        /// separated list of font family names, - STYLES is an optional space-
        /// separated list of style names (case-sensitive
        ///   "Bold" and "Italic" are supported), and
        /// - SIZE is an integer font size in pixels with the suffix "px".
        /// 
        /// Here are examples of valid font description strings: - "Arial, Helvetica,
        /// Bold Italic 14px" - "Arial, 14px"
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_menu_model_capi.h">cef/include/capi/cef_menu_model_capi.h</see>.
        /// </remarks>
        public bool SetFontListAt(int index, string fontList) {
            var fontList_pinned = new PinnedString(fontList);
            var __retval = CfxApi.MenuModel.cfx_menu_model_set_font_list_at(NativePtr, index, fontList_pinned.Obj.PinnedPtr, fontList_pinned.Length);
            fontList_pinned.Obj.Free();
            return 0 != __retval;
        }
    }
}
