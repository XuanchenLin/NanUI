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



namespace Chromium
{
	internal partial class CfxApiLoader {
        internal enum FunctionIndex {
            cfx_add_cross_origin_whitelist_entry,
            cfx_add_web_plugin_directory,
            cfx_add_web_plugin_path,
            cfx_api_hash,
            cfx_begin_tracing,
            cfx_clear_cross_origin_whitelist,
            cfx_clear_scheme_handler_factories,
            cfx_create_url,
            cfx_currently_on,
            cfx_do_message_loop_work,
            cfx_enable_highdpi_support,
            cfx_end_tracing,
            cfx_execute_process,
            cfx_force_web_plugin_shutdown,
            cfx_format_url_for_security_display,
            cfx_get_extensions_for_mime_type,
            cfx_get_geolocation,
            cfx_get_mime_type,
            cfx_get_path,
            cfx_get_xdisplay,
            cfx_initialize,
            cfx_is_web_plugin_unstable,
            cfx_launch_process,
            cfx_now_from_system_trace_time,
            cfx_parse_csscolor,
            cfx_parse_json,
            cfx_parse_jsonand_return_error,
            cfx_parse_url,
            cfx_post_delayed_task,
            cfx_post_task,
            cfx_quit_message_loop,
            cfx_refresh_web_plugins,
            cfx_register_extension,
            cfx_register_scheme_handler_factory,
            cfx_register_web_plugin_crash,
            cfx_remove_cross_origin_whitelist_entry,
            cfx_remove_web_plugin_path,
            cfx_run_message_loop,
            cfx_set_osmodal_loop,
            cfx_shutdown,
            cfx_unregister_internal_web_plugin,
            cfx_uridecode,
            cfx_uriencode,
            cfx_version_info,
            cfx_visit_web_plugin_info,
            cfx_write_json,
            cfx_app_ctor,
            cfx_app_get_gc_handle,
            cfx_app_set_managed_callback,
            cfx_auth_callback_cont,
            cfx_auth_callback_cancel,
            cfx_before_download_callback_cont,
            cfx_binary_value_create,
            cfx_binary_value_is_valid,
            cfx_binary_value_is_owned,
            cfx_binary_value_is_same,
            cfx_binary_value_is_equal,
            cfx_binary_value_copy,
            cfx_binary_value_get_size,
            cfx_binary_value_get_data,
            cfx_browser_get_host,
            cfx_browser_can_go_back,
            cfx_browser_go_back,
            cfx_browser_can_go_forward,
            cfx_browser_go_forward,
            cfx_browser_is_loading,
            cfx_browser_reload,
            cfx_browser_reload_ignore_cache,
            cfx_browser_stop_load,
            cfx_browser_get_identifier,
            cfx_browser_is_same,
            cfx_browser_is_popup,
            cfx_browser_has_document,
            cfx_browser_get_main_frame,
            cfx_browser_get_focused_frame,
            cfx_browser_get_frame_byident,
            cfx_browser_get_frame,
            cfx_browser_get_frame_count,
            cfx_browser_get_frame_identifiers,
            cfx_browser_get_frame_names,
            cfx_browser_send_process_message,
            cfx_browser_host_create_browser,
            cfx_browser_host_create_browser_sync,
            cfx_browser_host_get_browser,
            cfx_browser_host_close_browser,
            cfx_browser_host_set_focus,
            cfx_browser_host_set_window_visibility,
            cfx_browser_host_get_window_handle,
            cfx_browser_host_get_opener_window_handle,
            cfx_browser_host_get_client,
            cfx_browser_host_get_request_context,
            cfx_browser_host_get_zoom_level,
            cfx_browser_host_set_zoom_level,
            cfx_browser_host_run_file_dialog,
            cfx_browser_host_start_download,
            cfx_browser_host_print,
            cfx_browser_host_print_to_pdf,
            cfx_browser_host_find,
            cfx_browser_host_stop_finding,
            cfx_browser_host_show_dev_tools,
            cfx_browser_host_close_dev_tools,
            cfx_browser_host_get_navigation_entries,
            cfx_browser_host_set_mouse_cursor_change_disabled,
            cfx_browser_host_is_mouse_cursor_change_disabled,
            cfx_browser_host_replace_misspelling,
            cfx_browser_host_add_word_to_dictionary,
            cfx_browser_host_is_window_rendering_disabled,
            cfx_browser_host_was_resized,
            cfx_browser_host_was_hidden,
            cfx_browser_host_notify_screen_info_changed,
            cfx_browser_host_invalidate,
            cfx_browser_host_send_key_event,
            cfx_browser_host_send_mouse_click_event,
            cfx_browser_host_send_mouse_move_event,
            cfx_browser_host_send_mouse_wheel_event,
            cfx_browser_host_send_focus_event,
            cfx_browser_host_send_capture_lost_event,
            cfx_browser_host_notify_move_or_resize_started,
            cfx_browser_host_get_windowless_frame_rate,
            cfx_browser_host_set_windowless_frame_rate,
            cfx_browser_host_get_nstext_input_context,
            cfx_browser_host_handle_key_event_before_text_input_client,
            cfx_browser_host_handle_key_event_after_text_input_client,
            cfx_browser_host_drag_target_drag_enter,
            cfx_browser_host_drag_target_drag_over,
            cfx_browser_host_drag_target_drag_leave,
            cfx_browser_host_drag_target_drop,
            cfx_browser_host_drag_source_ended_at,
            cfx_browser_host_drag_source_system_drag_ended,
            cfx_browser_process_handler_ctor,
            cfx_browser_process_handler_get_gc_handle,
            cfx_browser_process_handler_set_managed_callback,
            cfx_browser_settings_ctor,
            cfx_browser_settings_dtor,
            cfx_browser_settings_set_windowless_frame_rate,
            cfx_browser_settings_get_windowless_frame_rate,
            cfx_browser_settings_set_standard_font_family,
            cfx_browser_settings_get_standard_font_family,
            cfx_browser_settings_set_fixed_font_family,
            cfx_browser_settings_get_fixed_font_family,
            cfx_browser_settings_set_serif_font_family,
            cfx_browser_settings_get_serif_font_family,
            cfx_browser_settings_set_sans_serif_font_family,
            cfx_browser_settings_get_sans_serif_font_family,
            cfx_browser_settings_set_cursive_font_family,
            cfx_browser_settings_get_cursive_font_family,
            cfx_browser_settings_set_fantasy_font_family,
            cfx_browser_settings_get_fantasy_font_family,
            cfx_browser_settings_set_default_font_size,
            cfx_browser_settings_get_default_font_size,
            cfx_browser_settings_set_default_fixed_font_size,
            cfx_browser_settings_get_default_fixed_font_size,
            cfx_browser_settings_set_minimum_font_size,
            cfx_browser_settings_get_minimum_font_size,
            cfx_browser_settings_set_minimum_logical_font_size,
            cfx_browser_settings_get_minimum_logical_font_size,
            cfx_browser_settings_set_default_encoding,
            cfx_browser_settings_get_default_encoding,
            cfx_browser_settings_set_remote_fonts,
            cfx_browser_settings_get_remote_fonts,
            cfx_browser_settings_set_javascript,
            cfx_browser_settings_get_javascript,
            cfx_browser_settings_set_javascript_open_windows,
            cfx_browser_settings_get_javascript_open_windows,
            cfx_browser_settings_set_javascript_close_windows,
            cfx_browser_settings_get_javascript_close_windows,
            cfx_browser_settings_set_javascript_access_clipboard,
            cfx_browser_settings_get_javascript_access_clipboard,
            cfx_browser_settings_set_javascript_dom_paste,
            cfx_browser_settings_get_javascript_dom_paste,
            cfx_browser_settings_set_caret_browsing,
            cfx_browser_settings_get_caret_browsing,
            cfx_browser_settings_set_plugins,
            cfx_browser_settings_get_plugins,
            cfx_browser_settings_set_universal_access_from_file_urls,
            cfx_browser_settings_get_universal_access_from_file_urls,
            cfx_browser_settings_set_file_access_from_file_urls,
            cfx_browser_settings_get_file_access_from_file_urls,
            cfx_browser_settings_set_web_security,
            cfx_browser_settings_get_web_security,
            cfx_browser_settings_set_image_loading,
            cfx_browser_settings_get_image_loading,
            cfx_browser_settings_set_image_shrink_standalone_to_fit,
            cfx_browser_settings_get_image_shrink_standalone_to_fit,
            cfx_browser_settings_set_text_area_resize,
            cfx_browser_settings_get_text_area_resize,
            cfx_browser_settings_set_tab_to_links,
            cfx_browser_settings_get_tab_to_links,
            cfx_browser_settings_set_local_storage,
            cfx_browser_settings_get_local_storage,
            cfx_browser_settings_set_databases,
            cfx_browser_settings_get_databases,
            cfx_browser_settings_set_application_cache,
            cfx_browser_settings_get_application_cache,
            cfx_browser_settings_set_webgl,
            cfx_browser_settings_get_webgl,
            cfx_browser_settings_set_background_color,
            cfx_browser_settings_get_background_color,
            cfx_browser_settings_set_accept_language_list,
            cfx_browser_settings_get_accept_language_list,
            cfx_callback_cont,
            cfx_callback_cancel,
            cfx_client_ctor,
            cfx_client_get_gc_handle,
            cfx_client_set_managed_callback,
            cfx_command_line_create,
            cfx_command_line_get_global,
            cfx_command_line_is_valid,
            cfx_command_line_is_read_only,
            cfx_command_line_copy,
            cfx_command_line_init_from_argv,
            cfx_command_line_init_from_string,
            cfx_command_line_reset,
            cfx_command_line_get_argv,
            cfx_command_line_get_command_line_string,
            cfx_command_line_get_program,
            cfx_command_line_set_program,
            cfx_command_line_has_switches,
            cfx_command_line_has_switch,
            cfx_command_line_get_switch_value,
            cfx_command_line_get_switches,
            cfx_command_line_append_switch,
            cfx_command_line_append_switch_with_value,
            cfx_command_line_has_arguments,
            cfx_command_line_get_arguments,
            cfx_command_line_append_argument,
            cfx_command_line_prepend_wrapper,
            cfx_completion_callback_ctor,
            cfx_completion_callback_get_gc_handle,
            cfx_completion_callback_set_managed_callback,
            cfx_context_menu_handler_ctor,
            cfx_context_menu_handler_get_gc_handle,
            cfx_context_menu_handler_set_managed_callback,
            cfx_context_menu_params_get_xcoord,
            cfx_context_menu_params_get_ycoord,
            cfx_context_menu_params_get_type_flags,
            cfx_context_menu_params_get_link_url,
            cfx_context_menu_params_get_unfiltered_link_url,
            cfx_context_menu_params_get_source_url,
            cfx_context_menu_params_has_image_contents,
            cfx_context_menu_params_get_page_url,
            cfx_context_menu_params_get_frame_url,
            cfx_context_menu_params_get_frame_charset,
            cfx_context_menu_params_get_media_type,
            cfx_context_menu_params_get_media_state_flags,
            cfx_context_menu_params_get_selection_text,
            cfx_context_menu_params_get_misspelled_word,
            cfx_context_menu_params_get_dictionary_suggestions,
            cfx_context_menu_params_is_editable,
            cfx_context_menu_params_is_spell_check_enabled,
            cfx_context_menu_params_get_edit_state_flags,
            cfx_context_menu_params_is_custom_menu,
            cfx_context_menu_params_is_pepper_menu,
            cfx_cookie_ctor,
            cfx_cookie_dtor,
            cfx_cookie_set_name,
            cfx_cookie_get_name,
            cfx_cookie_set_value,
            cfx_cookie_get_value,
            cfx_cookie_set_domain,
            cfx_cookie_get_domain,
            cfx_cookie_set_path,
            cfx_cookie_get_path,
            cfx_cookie_set_secure,
            cfx_cookie_get_secure,
            cfx_cookie_set_httponly,
            cfx_cookie_get_httponly,
            cfx_cookie_set_creation,
            cfx_cookie_get_creation,
            cfx_cookie_set_last_access,
            cfx_cookie_get_last_access,
            cfx_cookie_set_has_expires,
            cfx_cookie_get_has_expires,
            cfx_cookie_set_expires,
            cfx_cookie_get_expires,
            cfx_cookie_manager_get_global_manager,
            cfx_cookie_manager_create_manager,
            cfx_cookie_manager_set_supported_schemes,
            cfx_cookie_manager_visit_all_cookies,
            cfx_cookie_manager_visit_url_cookies,
            cfx_cookie_manager_set_cookie,
            cfx_cookie_manager_delete_cookies,
            cfx_cookie_manager_set_storage_path,
            cfx_cookie_manager_flush_store,
            cfx_cookie_visitor_ctor,
            cfx_cookie_visitor_get_gc_handle,
            cfx_cookie_visitor_set_managed_callback,
            cfx_cursor_info_ctor,
            cfx_cursor_info_dtor,
            cfx_cursor_info_set_hotspot,
            cfx_cursor_info_get_hotspot,
            cfx_cursor_info_set_image_scale_factor,
            cfx_cursor_info_get_image_scale_factor,
            cfx_cursor_info_set_buffer,
            cfx_cursor_info_get_buffer,
            cfx_delete_cookies_callback_ctor,
            cfx_delete_cookies_callback_get_gc_handle,
            cfx_delete_cookies_callback_set_managed_callback,
            cfx_dialog_handler_ctor,
            cfx_dialog_handler_get_gc_handle,
            cfx_dialog_handler_set_managed_callback,
            cfx_dictionary_value_create,
            cfx_dictionary_value_is_valid,
            cfx_dictionary_value_is_owned,
            cfx_dictionary_value_is_read_only,
            cfx_dictionary_value_is_same,
            cfx_dictionary_value_is_equal,
            cfx_dictionary_value_copy,
            cfx_dictionary_value_get_size,
            cfx_dictionary_value_clear,
            cfx_dictionary_value_has_key,
            cfx_dictionary_value_get_keys,
            cfx_dictionary_value_remove,
            cfx_dictionary_value_get_type,
            cfx_dictionary_value_get_value,
            cfx_dictionary_value_get_bool,
            cfx_dictionary_value_get_int,
            cfx_dictionary_value_get_double,
            cfx_dictionary_value_get_string,
            cfx_dictionary_value_get_binary,
            cfx_dictionary_value_get_dictionary,
            cfx_dictionary_value_get_list,
            cfx_dictionary_value_set_value,
            cfx_dictionary_value_set_null,
            cfx_dictionary_value_set_bool,
            cfx_dictionary_value_set_int,
            cfx_dictionary_value_set_double,
            cfx_dictionary_value_set_string,
            cfx_dictionary_value_set_binary,
            cfx_dictionary_value_set_dictionary,
            cfx_dictionary_value_set_list,
            cfx_display_handler_ctor,
            cfx_display_handler_get_gc_handle,
            cfx_display_handler_set_managed_callback,
            cfx_domdocument_get_type,
            cfx_domdocument_get_document,
            cfx_domdocument_get_body,
            cfx_domdocument_get_head,
            cfx_domdocument_get_title,
            cfx_domdocument_get_element_by_id,
            cfx_domdocument_get_focused_node,
            cfx_domdocument_has_selection,
            cfx_domdocument_get_selection_start_offset,
            cfx_domdocument_get_selection_end_offset,
            cfx_domdocument_get_selection_as_markup,
            cfx_domdocument_get_selection_as_text,
            cfx_domdocument_get_base_url,
            cfx_domdocument_get_complete_url,
            cfx_domnode_get_type,
            cfx_domnode_is_text,
            cfx_domnode_is_element,
            cfx_domnode_is_editable,
            cfx_domnode_is_form_control_element,
            cfx_domnode_get_form_control_element_type,
            cfx_domnode_is_same,
            cfx_domnode_get_name,
            cfx_domnode_get_value,
            cfx_domnode_set_value,
            cfx_domnode_get_as_markup,
            cfx_domnode_get_document,
            cfx_domnode_get_parent,
            cfx_domnode_get_previous_sibling,
            cfx_domnode_get_next_sibling,
            cfx_domnode_has_children,
            cfx_domnode_get_first_child,
            cfx_domnode_get_last_child,
            cfx_domnode_get_element_tag_name,
            cfx_domnode_has_element_attributes,
            cfx_domnode_has_element_attribute,
            cfx_domnode_get_element_attribute,
            cfx_domnode_get_element_attributes,
            cfx_domnode_set_element_attribute,
            cfx_domnode_get_element_inner_text,
            cfx_domvisitor_ctor,
            cfx_domvisitor_get_gc_handle,
            cfx_domvisitor_set_managed_callback,
            cfx_download_handler_ctor,
            cfx_download_handler_get_gc_handle,
            cfx_download_handler_set_managed_callback,
            cfx_download_item_is_valid,
            cfx_download_item_is_in_progress,
            cfx_download_item_is_complete,
            cfx_download_item_is_canceled,
            cfx_download_item_get_current_speed,
            cfx_download_item_get_percent_complete,
            cfx_download_item_get_total_bytes,
            cfx_download_item_get_received_bytes,
            cfx_download_item_get_start_time,
            cfx_download_item_get_end_time,
            cfx_download_item_get_full_path,
            cfx_download_item_get_id,
            cfx_download_item_get_url,
            cfx_download_item_get_original_url,
            cfx_download_item_get_suggested_file_name,
            cfx_download_item_get_content_disposition,
            cfx_download_item_get_mime_type,
            cfx_download_item_callback_cancel,
            cfx_download_item_callback_pause,
            cfx_download_item_callback_resume,
            cfx_drag_data_create,
            cfx_drag_data_clone,
            cfx_drag_data_is_read_only,
            cfx_drag_data_is_link,
            cfx_drag_data_is_fragment,
            cfx_drag_data_is_file,
            cfx_drag_data_get_link_url,
            cfx_drag_data_get_link_title,
            cfx_drag_data_get_link_metadata,
            cfx_drag_data_get_fragment_text,
            cfx_drag_data_get_fragment_html,
            cfx_drag_data_get_fragment_base_url,
            cfx_drag_data_get_file_name,
            cfx_drag_data_get_file_contents,
            cfx_drag_data_get_file_names,
            cfx_drag_data_set_link_url,
            cfx_drag_data_set_link_title,
            cfx_drag_data_set_link_metadata,
            cfx_drag_data_set_fragment_text,
            cfx_drag_data_set_fragment_html,
            cfx_drag_data_set_fragment_base_url,
            cfx_drag_data_reset_file_contents,
            cfx_drag_data_add_file,
            cfx_drag_handler_ctor,
            cfx_drag_handler_get_gc_handle,
            cfx_drag_handler_set_managed_callback,
            cfx_draggable_region_ctor,
            cfx_draggable_region_dtor,
            cfx_draggable_region_set_bounds,
            cfx_draggable_region_get_bounds,
            cfx_draggable_region_set_draggable,
            cfx_draggable_region_get_draggable,
            cfx_end_tracing_callback_ctor,
            cfx_end_tracing_callback_get_gc_handle,
            cfx_end_tracing_callback_set_managed_callback,
            cfx_file_dialog_callback_cont,
            cfx_file_dialog_callback_cancel,
            cfx_find_handler_ctor,
            cfx_find_handler_get_gc_handle,
            cfx_find_handler_set_managed_callback,
            cfx_focus_handler_ctor,
            cfx_focus_handler_get_gc_handle,
            cfx_focus_handler_set_managed_callback,
            cfx_frame_is_valid,
            cfx_frame_undo,
            cfx_frame_redo,
            cfx_frame_cut,
            cfx_frame_copy,
            cfx_frame_paste,
            cfx_frame_del,
            cfx_frame_select_all,
            cfx_frame_view_source,
            cfx_frame_get_source,
            cfx_frame_get_text,
            cfx_frame_load_request,
            cfx_frame_load_url,
            cfx_frame_load_string,
            cfx_frame_execute_java_script,
            cfx_frame_is_main,
            cfx_frame_is_focused,
            cfx_frame_get_name,
            cfx_frame_get_identifier,
            cfx_frame_get_parent,
            cfx_frame_get_url,
            cfx_frame_get_browser,
            cfx_frame_get_v8context,
            cfx_frame_visit_dom,
            cfx_geolocation_callback_cont,
            cfx_geolocation_handler_ctor,
            cfx_geolocation_handler_get_gc_handle,
            cfx_geolocation_handler_set_managed_callback,
            cfx_geoposition_ctor,
            cfx_geoposition_dtor,
            cfx_geoposition_set_latitude,
            cfx_geoposition_get_latitude,
            cfx_geoposition_set_longitude,
            cfx_geoposition_get_longitude,
            cfx_geoposition_set_altitude,
            cfx_geoposition_get_altitude,
            cfx_geoposition_set_accuracy,
            cfx_geoposition_get_accuracy,
            cfx_geoposition_set_altitude_accuracy,
            cfx_geoposition_get_altitude_accuracy,
            cfx_geoposition_set_heading,
            cfx_geoposition_get_heading,
            cfx_geoposition_set_speed,
            cfx_geoposition_get_speed,
            cfx_geoposition_set_timestamp,
            cfx_geoposition_get_timestamp,
            cfx_geoposition_set_error_code,
            cfx_geoposition_get_error_code,
            cfx_geoposition_set_error_message,
            cfx_geoposition_get_error_message,
            cfx_get_geolocation_callback_ctor,
            cfx_get_geolocation_callback_get_gc_handle,
            cfx_get_geolocation_callback_set_managed_callback,
            cfx_jsdialog_callback_cont,
            cfx_jsdialog_handler_ctor,
            cfx_jsdialog_handler_get_gc_handle,
            cfx_jsdialog_handler_set_managed_callback,
            cfx_key_event_ctor,
            cfx_key_event_dtor,
            cfx_key_event_set_type,
            cfx_key_event_get_type,
            cfx_key_event_set_modifiers,
            cfx_key_event_get_modifiers,
            cfx_key_event_set_windows_key_code,
            cfx_key_event_get_windows_key_code,
            cfx_key_event_set_native_key_code,
            cfx_key_event_get_native_key_code,
            cfx_key_event_set_is_system_key,
            cfx_key_event_get_is_system_key,
            cfx_key_event_set_character,
            cfx_key_event_get_character,
            cfx_key_event_set_unmodified_character,
            cfx_key_event_get_unmodified_character,
            cfx_key_event_set_focus_on_editable_field,
            cfx_key_event_get_focus_on_editable_field,
            cfx_keyboard_handler_ctor,
            cfx_keyboard_handler_get_gc_handle,
            cfx_keyboard_handler_set_managed_callback,
            cfx_life_span_handler_ctor,
            cfx_life_span_handler_get_gc_handle,
            cfx_life_span_handler_set_managed_callback,
            cfx_list_value_create,
            cfx_list_value_is_valid,
            cfx_list_value_is_owned,
            cfx_list_value_is_read_only,
            cfx_list_value_is_same,
            cfx_list_value_is_equal,
            cfx_list_value_copy,
            cfx_list_value_set_size,
            cfx_list_value_get_size,
            cfx_list_value_clear,
            cfx_list_value_remove,
            cfx_list_value_get_type,
            cfx_list_value_get_value,
            cfx_list_value_get_bool,
            cfx_list_value_get_int,
            cfx_list_value_get_double,
            cfx_list_value_get_string,
            cfx_list_value_get_binary,
            cfx_list_value_get_dictionary,
            cfx_list_value_get_list,
            cfx_list_value_set_value,
            cfx_list_value_set_null,
            cfx_list_value_set_bool,
            cfx_list_value_set_int,
            cfx_list_value_set_double,
            cfx_list_value_set_string,
            cfx_list_value_set_binary,
            cfx_list_value_set_dictionary,
            cfx_list_value_set_list,
            cfx_load_handler_ctor,
            cfx_load_handler_get_gc_handle,
            cfx_load_handler_set_managed_callback,
            cfx_main_args_linux_ctor,
            cfx_main_args_linux_dtor,
            cfx_main_args_linux_set_argc,
            cfx_main_args_linux_get_argc,
            cfx_main_args_linux_set_argv,
            cfx_main_args_linux_get_argv,
            cfx_main_args_windows_ctor,
            cfx_main_args_windows_dtor,
            cfx_main_args_windows_set_instance,
            cfx_main_args_windows_get_instance,
            cfx_menu_model_clear,
            cfx_menu_model_get_count,
            cfx_menu_model_add_separator,
            cfx_menu_model_add_item,
            cfx_menu_model_add_check_item,
            cfx_menu_model_add_radio_item,
            cfx_menu_model_add_sub_menu,
            cfx_menu_model_insert_separator_at,
            cfx_menu_model_insert_item_at,
            cfx_menu_model_insert_check_item_at,
            cfx_menu_model_insert_radio_item_at,
            cfx_menu_model_insert_sub_menu_at,
            cfx_menu_model_remove,
            cfx_menu_model_remove_at,
            cfx_menu_model_get_index_of,
            cfx_menu_model_get_command_id_at,
            cfx_menu_model_set_command_id_at,
            cfx_menu_model_get_label,
            cfx_menu_model_get_label_at,
            cfx_menu_model_set_label,
            cfx_menu_model_set_label_at,
            cfx_menu_model_get_type,
            cfx_menu_model_get_type_at,
            cfx_menu_model_get_group_id,
            cfx_menu_model_get_group_id_at,
            cfx_menu_model_set_group_id,
            cfx_menu_model_set_group_id_at,
            cfx_menu_model_get_sub_menu,
            cfx_menu_model_get_sub_menu_at,
            cfx_menu_model_is_visible,
            cfx_menu_model_is_visible_at,
            cfx_menu_model_set_visible,
            cfx_menu_model_set_visible_at,
            cfx_menu_model_is_enabled,
            cfx_menu_model_is_enabled_at,
            cfx_menu_model_set_enabled,
            cfx_menu_model_set_enabled_at,
            cfx_menu_model_is_checked,
            cfx_menu_model_is_checked_at,
            cfx_menu_model_set_checked,
            cfx_menu_model_set_checked_at,
            cfx_menu_model_has_accelerator,
            cfx_menu_model_has_accelerator_at,
            cfx_menu_model_set_accelerator,
            cfx_menu_model_set_accelerator_at,
            cfx_menu_model_remove_accelerator,
            cfx_menu_model_remove_accelerator_at,
            cfx_menu_model_get_accelerator,
            cfx_menu_model_get_accelerator_at,
            cfx_mouse_event_ctor,
            cfx_mouse_event_dtor,
            cfx_mouse_event_set_x,
            cfx_mouse_event_get_x,
            cfx_mouse_event_set_y,
            cfx_mouse_event_get_y,
            cfx_mouse_event_set_modifiers,
            cfx_mouse_event_get_modifiers,
            cfx_navigation_entry_is_valid,
            cfx_navigation_entry_get_url,
            cfx_navigation_entry_get_display_url,
            cfx_navigation_entry_get_original_url,
            cfx_navigation_entry_get_title,
            cfx_navigation_entry_get_transition_type,
            cfx_navigation_entry_has_post_data,
            cfx_navigation_entry_get_completion_time,
            cfx_navigation_entry_get_http_status_code,
            cfx_navigation_entry_visitor_ctor,
            cfx_navigation_entry_visitor_get_gc_handle,
            cfx_navigation_entry_visitor_set_managed_callback,
            cfx_page_range_ctor,
            cfx_page_range_dtor,
            cfx_page_range_set_from,
            cfx_page_range_get_from,
            cfx_page_range_set_to,
            cfx_page_range_get_to,
            cfx_pdf_print_callback_ctor,
            cfx_pdf_print_callback_get_gc_handle,
            cfx_pdf_print_callback_set_managed_callback,
            cfx_pdf_print_settings_ctor,
            cfx_pdf_print_settings_dtor,
            cfx_pdf_print_settings_set_header_footer_title,
            cfx_pdf_print_settings_get_header_footer_title,
            cfx_pdf_print_settings_set_header_footer_url,
            cfx_pdf_print_settings_get_header_footer_url,
            cfx_pdf_print_settings_set_page_width,
            cfx_pdf_print_settings_get_page_width,
            cfx_pdf_print_settings_set_page_height,
            cfx_pdf_print_settings_get_page_height,
            cfx_pdf_print_settings_set_margin_top,
            cfx_pdf_print_settings_get_margin_top,
            cfx_pdf_print_settings_set_margin_right,
            cfx_pdf_print_settings_get_margin_right,
            cfx_pdf_print_settings_set_margin_bottom,
            cfx_pdf_print_settings_get_margin_bottom,
            cfx_pdf_print_settings_set_margin_left,
            cfx_pdf_print_settings_get_margin_left,
            cfx_pdf_print_settings_set_margin_type,
            cfx_pdf_print_settings_get_margin_type,
            cfx_pdf_print_settings_set_header_footer_enabled,
            cfx_pdf_print_settings_get_header_footer_enabled,
            cfx_pdf_print_settings_set_selection_only,
            cfx_pdf_print_settings_get_selection_only,
            cfx_pdf_print_settings_set_landscape,
            cfx_pdf_print_settings_get_landscape,
            cfx_pdf_print_settings_set_backgrounds_enabled,
            cfx_pdf_print_settings_get_backgrounds_enabled,
            cfx_point_ctor,
            cfx_point_dtor,
            cfx_point_set_x,
            cfx_point_get_x,
            cfx_point_set_y,
            cfx_point_get_y,
            cfx_popup_features_ctor,
            cfx_popup_features_dtor,
            cfx_popup_features_set_x,
            cfx_popup_features_get_x,
            cfx_popup_features_set_xSet,
            cfx_popup_features_get_xSet,
            cfx_popup_features_set_y,
            cfx_popup_features_get_y,
            cfx_popup_features_set_ySet,
            cfx_popup_features_get_ySet,
            cfx_popup_features_set_width,
            cfx_popup_features_get_width,
            cfx_popup_features_set_widthSet,
            cfx_popup_features_get_widthSet,
            cfx_popup_features_set_height,
            cfx_popup_features_get_height,
            cfx_popup_features_set_heightSet,
            cfx_popup_features_get_heightSet,
            cfx_popup_features_set_menuBarVisible,
            cfx_popup_features_get_menuBarVisible,
            cfx_popup_features_set_statusBarVisible,
            cfx_popup_features_get_statusBarVisible,
            cfx_popup_features_set_toolBarVisible,
            cfx_popup_features_get_toolBarVisible,
            cfx_popup_features_set_locationBarVisible,
            cfx_popup_features_get_locationBarVisible,
            cfx_popup_features_set_scrollbarsVisible,
            cfx_popup_features_get_scrollbarsVisible,
            cfx_popup_features_set_resizable,
            cfx_popup_features_get_resizable,
            cfx_popup_features_set_fullscreen,
            cfx_popup_features_get_fullscreen,
            cfx_popup_features_set_dialog,
            cfx_popup_features_get_dialog,
            cfx_popup_features_set_additionalFeatures,
            cfx_popup_features_get_additionalFeatures,
            cfx_post_data_create,
            cfx_post_data_is_read_only,
            cfx_post_data_has_excluded_elements,
            cfx_post_data_get_element_count,
            cfx_post_data_get_elements,
            cfx_post_data_remove_element,
            cfx_post_data_add_element,
            cfx_post_data_remove_elements,
            cfx_post_data_element_create,
            cfx_post_data_element_is_read_only,
            cfx_post_data_element_set_to_empty,
            cfx_post_data_element_set_to_file,
            cfx_post_data_element_set_to_bytes,
            cfx_post_data_element_get_type,
            cfx_post_data_element_get_file,
            cfx_post_data_element_get_bytes_count,
            cfx_post_data_element_get_bytes,
            cfx_print_dialog_callback_cont,
            cfx_print_dialog_callback_cancel,
            cfx_print_handler_ctor,
            cfx_print_handler_get_gc_handle,
            cfx_print_handler_set_managed_callback,
            cfx_print_job_callback_cont,
            cfx_print_settings_create,
            cfx_print_settings_is_valid,
            cfx_print_settings_is_read_only,
            cfx_print_settings_copy,
            cfx_print_settings_set_orientation,
            cfx_print_settings_is_landscape,
            cfx_print_settings_set_printer_printable_area,
            cfx_print_settings_set_device_name,
            cfx_print_settings_get_device_name,
            cfx_print_settings_set_dpi,
            cfx_print_settings_get_dpi,
            cfx_print_settings_set_page_ranges,
            cfx_print_settings_get_page_ranges_count,
            cfx_print_settings_get_page_ranges,
            cfx_print_settings_set_selection_only,
            cfx_print_settings_is_selection_only,
            cfx_print_settings_set_collate,
            cfx_print_settings_will_collate,
            cfx_print_settings_set_color_model,
            cfx_print_settings_get_color_model,
            cfx_print_settings_set_copies,
            cfx_print_settings_get_copies,
            cfx_print_settings_set_duplex_mode,
            cfx_print_settings_get_duplex_mode,
            cfx_process_message_create,
            cfx_process_message_is_valid,
            cfx_process_message_is_read_only,
            cfx_process_message_copy,
            cfx_process_message_get_name,
            cfx_process_message_get_argument_list,
            cfx_read_handler_ctor,
            cfx_read_handler_get_gc_handle,
            cfx_read_handler_set_managed_callback,
            cfx_rect_ctor,
            cfx_rect_dtor,
            cfx_rect_set_x,
            cfx_rect_get_x,
            cfx_rect_set_y,
            cfx_rect_get_y,
            cfx_rect_set_width,
            cfx_rect_get_width,
            cfx_rect_set_height,
            cfx_rect_get_height,
            cfx_render_handler_ctor,
            cfx_render_handler_get_gc_handle,
            cfx_render_handler_set_managed_callback,
            cfx_render_process_handler_ctor,
            cfx_render_process_handler_get_gc_handle,
            cfx_render_process_handler_set_managed_callback,
            cfx_request_create,
            cfx_request_is_read_only,
            cfx_request_get_url,
            cfx_request_set_url,
            cfx_request_get_method,
            cfx_request_set_method,
            cfx_request_set_referrer,
            cfx_request_get_referrer_url,
            cfx_request_get_referrer_policy,
            cfx_request_get_post_data,
            cfx_request_set_post_data,
            cfx_request_get_header_map,
            cfx_request_set_header_map,
            cfx_request_set,
            cfx_request_get_flags,
            cfx_request_set_flags,
            cfx_request_get_first_party_for_cookies,
            cfx_request_set_first_party_for_cookies,
            cfx_request_get_resource_type,
            cfx_request_get_transition_type,
            cfx_request_get_identifier,
            cfx_request_callback_cont,
            cfx_request_callback_cancel,
            cfx_request_context_get_global_context,
            cfx_request_context_create_context,
            cfx_request_context_is_same,
            cfx_request_context_is_sharing_with,
            cfx_request_context_is_global,
            cfx_request_context_get_handler,
            cfx_request_context_get_cache_path,
            cfx_request_context_get_default_cookie_manager,
            cfx_request_context_register_scheme_handler_factory,
            cfx_request_context_clear_scheme_handler_factories,
            cfx_request_context_purge_plugin_list_cache,
            cfx_request_context_has_preference,
            cfx_request_context_get_preference,
            cfx_request_context_get_all_preferences,
            cfx_request_context_can_set_preference,
            cfx_request_context_set_preference,
            cfx_request_context_clear_certificate_exceptions,
            cfx_request_context_close_all_connections,
            cfx_request_context_resolve_host,
            cfx_request_context_resolve_host_cached,
            cfx_request_context_handler_ctor,
            cfx_request_context_handler_get_gc_handle,
            cfx_request_context_handler_set_managed_callback,
            cfx_request_context_settings_ctor,
            cfx_request_context_settings_dtor,
            cfx_request_context_settings_set_cache_path,
            cfx_request_context_settings_get_cache_path,
            cfx_request_context_settings_set_persist_session_cookies,
            cfx_request_context_settings_get_persist_session_cookies,
            cfx_request_context_settings_set_persist_user_preferences,
            cfx_request_context_settings_get_persist_user_preferences,
            cfx_request_context_settings_set_ignore_certificate_errors,
            cfx_request_context_settings_get_ignore_certificate_errors,
            cfx_request_context_settings_set_accept_language_list,
            cfx_request_context_settings_get_accept_language_list,
            cfx_request_handler_ctor,
            cfx_request_handler_get_gc_handle,
            cfx_request_handler_set_managed_callback,
            cfx_resolve_callback_ctor,
            cfx_resolve_callback_get_gc_handle,
            cfx_resolve_callback_set_managed_callback,
            cfx_resource_bundle_get_global,
            cfx_resource_bundle_get_localized_string,
            cfx_resource_bundle_get_data_resource,
            cfx_resource_bundle_get_data_resource_for_scale,
            cfx_resource_bundle_handler_ctor,
            cfx_resource_bundle_handler_get_gc_handle,
            cfx_resource_bundle_handler_set_managed_callback,
            cfx_resource_handler_ctor,
            cfx_resource_handler_get_gc_handle,
            cfx_resource_handler_set_managed_callback,
            cfx_response_create,
            cfx_response_is_read_only,
            cfx_response_get_status,
            cfx_response_set_status,
            cfx_response_get_status_text,
            cfx_response_set_status_text,
            cfx_response_get_mime_type,
            cfx_response_set_mime_type,
            cfx_response_get_header,
            cfx_response_get_header_map,
            cfx_response_set_header_map,
            cfx_response_filter_ctor,
            cfx_response_filter_get_gc_handle,
            cfx_response_filter_set_managed_callback,
            cfx_run_context_menu_callback_cont,
            cfx_run_context_menu_callback_cancel,
            cfx_run_file_dialog_callback_ctor,
            cfx_run_file_dialog_callback_get_gc_handle,
            cfx_run_file_dialog_callback_set_managed_callback,
            cfx_scheme_handler_factory_ctor,
            cfx_scheme_handler_factory_get_gc_handle,
            cfx_scheme_handler_factory_set_managed_callback,
            cfx_scheme_registrar_add_custom_scheme,
            cfx_screen_info_ctor,
            cfx_screen_info_dtor,
            cfx_screen_info_set_device_scale_factor,
            cfx_screen_info_get_device_scale_factor,
            cfx_screen_info_set_depth,
            cfx_screen_info_get_depth,
            cfx_screen_info_set_depth_per_component,
            cfx_screen_info_get_depth_per_component,
            cfx_screen_info_set_is_monochrome,
            cfx_screen_info_get_is_monochrome,
            cfx_screen_info_set_rect,
            cfx_screen_info_get_rect,
            cfx_screen_info_set_available_rect,
            cfx_screen_info_get_available_rect,
            cfx_set_cookie_callback_ctor,
            cfx_set_cookie_callback_get_gc_handle,
            cfx_set_cookie_callback_set_managed_callback,
            cfx_settings_ctor,
            cfx_settings_dtor,
            cfx_settings_set_single_process,
            cfx_settings_get_single_process,
            cfx_settings_set_no_sandbox,
            cfx_settings_get_no_sandbox,
            cfx_settings_set_browser_subprocess_path,
            cfx_settings_get_browser_subprocess_path,
            cfx_settings_set_multi_threaded_message_loop,
            cfx_settings_get_multi_threaded_message_loop,
            cfx_settings_set_windowless_rendering_enabled,
            cfx_settings_get_windowless_rendering_enabled,
            cfx_settings_set_command_line_args_disabled,
            cfx_settings_get_command_line_args_disabled,
            cfx_settings_set_cache_path,
            cfx_settings_get_cache_path,
            cfx_settings_set_user_data_path,
            cfx_settings_get_user_data_path,
            cfx_settings_set_persist_session_cookies,
            cfx_settings_get_persist_session_cookies,
            cfx_settings_set_persist_user_preferences,
            cfx_settings_get_persist_user_preferences,
            cfx_settings_set_user_agent,
            cfx_settings_get_user_agent,
            cfx_settings_set_product_version,
            cfx_settings_get_product_version,
            cfx_settings_set_locale,
            cfx_settings_get_locale,
            cfx_settings_set_log_file,
            cfx_settings_get_log_file,
            cfx_settings_set_log_severity,
            cfx_settings_get_log_severity,
            cfx_settings_set_javascript_flags,
            cfx_settings_get_javascript_flags,
            cfx_settings_set_resources_dir_path,
            cfx_settings_get_resources_dir_path,
            cfx_settings_set_locales_dir_path,
            cfx_settings_get_locales_dir_path,
            cfx_settings_set_pack_loading_disabled,
            cfx_settings_get_pack_loading_disabled,
            cfx_settings_set_remote_debugging_port,
            cfx_settings_get_remote_debugging_port,
            cfx_settings_set_uncaught_exception_stack_size,
            cfx_settings_get_uncaught_exception_stack_size,
            cfx_settings_set_context_safety_implementation,
            cfx_settings_get_context_safety_implementation,
            cfx_settings_set_ignore_certificate_errors,
            cfx_settings_get_ignore_certificate_errors,
            cfx_settings_set_background_color,
            cfx_settings_get_background_color,
            cfx_settings_set_accept_language_list,
            cfx_settings_get_accept_language_list,
            cfx_size_ctor,
            cfx_size_dtor,
            cfx_size_set_width,
            cfx_size_get_width,
            cfx_size_set_height,
            cfx_size_get_height,
            cfx_sslcert_principal_get_display_name,
            cfx_sslcert_principal_get_common_name,
            cfx_sslcert_principal_get_locality_name,
            cfx_sslcert_principal_get_state_or_province_name,
            cfx_sslcert_principal_get_country_name,
            cfx_sslcert_principal_get_street_addresses,
            cfx_sslcert_principal_get_organization_names,
            cfx_sslcert_principal_get_organization_unit_names,
            cfx_sslcert_principal_get_domain_components,
            cfx_sslinfo_get_cert_status,
            cfx_sslinfo_is_cert_status_error,
            cfx_sslinfo_is_cert_status_minor_error,
            cfx_sslinfo_get_subject,
            cfx_sslinfo_get_issuer,
            cfx_sslinfo_get_serial_number,
            cfx_sslinfo_get_valid_start,
            cfx_sslinfo_get_valid_expiry,
            cfx_sslinfo_get_derencoded,
            cfx_sslinfo_get_pemencoded,
            cfx_sslinfo_get_issuer_chain_size,
            cfx_sslinfo_get_derencoded_issuer_chain,
            cfx_sslinfo_get_pemencoded_issuer_chain,
            cfx_stream_reader_create_for_file,
            cfx_stream_reader_create_for_data,
            cfx_stream_reader_create_for_handler,
            cfx_stream_reader_read,
            cfx_stream_reader_seek,
            cfx_stream_reader_tell,
            cfx_stream_reader_eof,
            cfx_stream_reader_may_block,
            cfx_stream_writer_create_for_file,
            cfx_stream_writer_create_for_handler,
            cfx_stream_writer_write,
            cfx_stream_writer_seek,
            cfx_stream_writer_tell,
            cfx_stream_writer_flush,
            cfx_stream_writer_may_block,
            cfx_string_visitor_ctor,
            cfx_string_visitor_get_gc_handle,
            cfx_string_visitor_set_managed_callback,
            cfx_task_ctor,
            cfx_task_get_gc_handle,
            cfx_task_set_managed_callback,
            cfx_task_runner_get_for_current_thread,
            cfx_task_runner_get_for_thread,
            cfx_task_runner_is_same,
            cfx_task_runner_belongs_to_current_thread,
            cfx_task_runner_belongs_to_thread,
            cfx_task_runner_post_task,
            cfx_task_runner_post_delayed_task,
            cfx_time_ctor,
            cfx_time_dtor,
            cfx_time_set_year,
            cfx_time_get_year,
            cfx_time_set_month,
            cfx_time_get_month,
            cfx_time_set_day_of_week,
            cfx_time_get_day_of_week,
            cfx_time_set_day_of_month,
            cfx_time_get_day_of_month,
            cfx_time_set_hour,
            cfx_time_get_hour,
            cfx_time_set_minute,
            cfx_time_get_minute,
            cfx_time_set_second,
            cfx_time_get_second,
            cfx_time_set_millisecond,
            cfx_time_get_millisecond,
            cfx_urlparts_ctor,
            cfx_urlparts_dtor,
            cfx_urlparts_set_spec,
            cfx_urlparts_get_spec,
            cfx_urlparts_set_scheme,
            cfx_urlparts_get_scheme,
            cfx_urlparts_set_username,
            cfx_urlparts_get_username,
            cfx_urlparts_set_password,
            cfx_urlparts_get_password,
            cfx_urlparts_set_host,
            cfx_urlparts_get_host,
            cfx_urlparts_set_port,
            cfx_urlparts_get_port,
            cfx_urlparts_set_origin,
            cfx_urlparts_get_origin,
            cfx_urlparts_set_path,
            cfx_urlparts_get_path,
            cfx_urlparts_set_query,
            cfx_urlparts_get_query,
            cfx_urlrequest_create,
            cfx_urlrequest_get_request,
            cfx_urlrequest_get_client,
            cfx_urlrequest_get_request_status,
            cfx_urlrequest_get_request_error,
            cfx_urlrequest_get_response,
            cfx_urlrequest_cancel,
            cfx_urlrequest_client_ctor,
            cfx_urlrequest_client_get_gc_handle,
            cfx_urlrequest_client_set_managed_callback,
            cfx_v8accessor_ctor,
            cfx_v8accessor_get_gc_handle,
            cfx_v8accessor_set_managed_callback,
            cfx_v8context_get_current_context,
            cfx_v8context_get_entered_context,
            cfx_v8context_in_context,
            cfx_v8context_get_task_runner,
            cfx_v8context_is_valid,
            cfx_v8context_get_browser,
            cfx_v8context_get_frame,
            cfx_v8context_get_global,
            cfx_v8context_enter,
            cfx_v8context_exit,
            cfx_v8context_is_same,
            cfx_v8context_eval,
            cfx_v8exception_get_message,
            cfx_v8exception_get_source_line,
            cfx_v8exception_get_script_resource_name,
            cfx_v8exception_get_line_number,
            cfx_v8exception_get_start_position,
            cfx_v8exception_get_end_position,
            cfx_v8exception_get_start_column,
            cfx_v8exception_get_end_column,
            cfx_v8handler_ctor,
            cfx_v8handler_get_gc_handle,
            cfx_v8handler_set_managed_callback,
            cfx_v8stack_frame_is_valid,
            cfx_v8stack_frame_get_script_name,
            cfx_v8stack_frame_get_script_name_or_source_url,
            cfx_v8stack_frame_get_function_name,
            cfx_v8stack_frame_get_line_number,
            cfx_v8stack_frame_get_column,
            cfx_v8stack_frame_is_eval,
            cfx_v8stack_frame_is_constructor,
            cfx_v8stack_trace_get_current,
            cfx_v8stack_trace_is_valid,
            cfx_v8stack_trace_get_frame_count,
            cfx_v8stack_trace_get_frame,
            cfx_v8value_create_undefined,
            cfx_v8value_create_null,
            cfx_v8value_create_bool,
            cfx_v8value_create_int,
            cfx_v8value_create_uint,
            cfx_v8value_create_double,
            cfx_v8value_create_date,
            cfx_v8value_create_string,
            cfx_v8value_create_object,
            cfx_v8value_create_array,
            cfx_v8value_create_function,
            cfx_v8value_is_valid,
            cfx_v8value_is_undefined,
            cfx_v8value_is_null,
            cfx_v8value_is_bool,
            cfx_v8value_is_int,
            cfx_v8value_is_uint,
            cfx_v8value_is_double,
            cfx_v8value_is_date,
            cfx_v8value_is_string,
            cfx_v8value_is_object,
            cfx_v8value_is_array,
            cfx_v8value_is_function,
            cfx_v8value_is_same,
            cfx_v8value_get_bool_value,
            cfx_v8value_get_int_value,
            cfx_v8value_get_uint_value,
            cfx_v8value_get_double_value,
            cfx_v8value_get_date_value,
            cfx_v8value_get_string_value,
            cfx_v8value_is_user_created,
            cfx_v8value_has_exception,
            cfx_v8value_get_exception,
            cfx_v8value_clear_exception,
            cfx_v8value_will_rethrow_exceptions,
            cfx_v8value_set_rethrow_exceptions,
            cfx_v8value_has_value_bykey,
            cfx_v8value_has_value_byindex,
            cfx_v8value_delete_value_bykey,
            cfx_v8value_delete_value_byindex,
            cfx_v8value_get_value_bykey,
            cfx_v8value_get_value_byindex,
            cfx_v8value_set_value_bykey,
            cfx_v8value_set_value_byindex,
            cfx_v8value_set_value_byaccessor,
            cfx_v8value_get_keys,
            cfx_v8value_set_user_data,
            cfx_v8value_get_user_data,
            cfx_v8value_get_externally_allocated_memory,
            cfx_v8value_adjust_externally_allocated_memory,
            cfx_v8value_get_array_length,
            cfx_v8value_get_function_name,
            cfx_v8value_get_function_handler,
            cfx_v8value_execute_function,
            cfx_v8value_execute_function_with_context,
            cfx_value_create,
            cfx_value_is_valid,
            cfx_value_is_owned,
            cfx_value_is_read_only,
            cfx_value_is_same,
            cfx_value_is_equal,
            cfx_value_copy,
            cfx_value_get_type,
            cfx_value_get_bool,
            cfx_value_get_int,
            cfx_value_get_double,
            cfx_value_get_string,
            cfx_value_get_binary,
            cfx_value_get_dictionary,
            cfx_value_get_list,
            cfx_value_set_null,
            cfx_value_set_bool,
            cfx_value_set_int,
            cfx_value_set_double,
            cfx_value_set_string,
            cfx_value_set_binary,
            cfx_value_set_dictionary,
            cfx_value_set_list,
            cfx_web_plugin_info_get_name,
            cfx_web_plugin_info_get_path,
            cfx_web_plugin_info_get_version,
            cfx_web_plugin_info_get_description,
            cfx_web_plugin_info_visitor_ctor,
            cfx_web_plugin_info_visitor_get_gc_handle,
            cfx_web_plugin_info_visitor_set_managed_callback,
            cfx_web_plugin_unstable_callback_ctor,
            cfx_web_plugin_unstable_callback_get_gc_handle,
            cfx_web_plugin_unstable_callback_set_managed_callback,
            cfx_window_info_linux_ctor,
            cfx_window_info_linux_dtor,
            cfx_window_info_linux_set_x,
            cfx_window_info_linux_get_x,
            cfx_window_info_linux_set_y,
            cfx_window_info_linux_get_y,
            cfx_window_info_linux_set_width,
            cfx_window_info_linux_get_width,
            cfx_window_info_linux_set_height,
            cfx_window_info_linux_get_height,
            cfx_window_info_linux_set_parent_window,
            cfx_window_info_linux_get_parent_window,
            cfx_window_info_linux_set_windowless_rendering_enabled,
            cfx_window_info_linux_get_windowless_rendering_enabled,
            cfx_window_info_linux_set_transparent_painting_enabled,
            cfx_window_info_linux_get_transparent_painting_enabled,
            cfx_window_info_linux_set_window,
            cfx_window_info_linux_get_window,
            cfx_window_info_windows_ctor,
            cfx_window_info_windows_dtor,
            cfx_window_info_windows_set_ex_style,
            cfx_window_info_windows_get_ex_style,
            cfx_window_info_windows_set_window_name,
            cfx_window_info_windows_get_window_name,
            cfx_window_info_windows_set_style,
            cfx_window_info_windows_get_style,
            cfx_window_info_windows_set_x,
            cfx_window_info_windows_get_x,
            cfx_window_info_windows_set_y,
            cfx_window_info_windows_get_y,
            cfx_window_info_windows_set_width,
            cfx_window_info_windows_get_width,
            cfx_window_info_windows_set_height,
            cfx_window_info_windows_get_height,
            cfx_window_info_windows_set_parent_window,
            cfx_window_info_windows_get_parent_window,
            cfx_window_info_windows_set_menu,
            cfx_window_info_windows_get_menu,
            cfx_window_info_windows_set_windowless_rendering_enabled,
            cfx_window_info_windows_get_windowless_rendering_enabled,
            cfx_window_info_windows_set_transparent_painting_enabled,
            cfx_window_info_windows_get_transparent_painting_enabled,
            cfx_window_info_windows_set_window,
            cfx_window_info_windows_get_window,
            cfx_write_handler_ctor,
            cfx_write_handler_get_gc_handle,
            cfx_write_handler_set_managed_callback,
            cfx_xml_reader_create,
            cfx_xml_reader_move_to_next_node,
            cfx_xml_reader_close,
            cfx_xml_reader_has_error,
            cfx_xml_reader_get_error,
            cfx_xml_reader_get_type,
            cfx_xml_reader_get_depth,
            cfx_xml_reader_get_local_name,
            cfx_xml_reader_get_prefix,
            cfx_xml_reader_get_qualified_name,
            cfx_xml_reader_get_namespace_uri,
            cfx_xml_reader_get_base_uri,
            cfx_xml_reader_get_xml_lang,
            cfx_xml_reader_is_empty_element,
            cfx_xml_reader_has_value,
            cfx_xml_reader_get_value,
            cfx_xml_reader_has_attributes,
            cfx_xml_reader_get_attribute_count,
            cfx_xml_reader_get_attribute_byindex,
            cfx_xml_reader_get_attribute_byqname,
            cfx_xml_reader_get_attribute_bylname,
            cfx_xml_reader_get_inner_xml,
            cfx_xml_reader_get_outer_xml,
            cfx_xml_reader_get_line_number,
            cfx_xml_reader_move_to_attribute_byindex,
            cfx_xml_reader_move_to_attribute_byqname,
            cfx_xml_reader_move_to_attribute_bylname,
            cfx_xml_reader_move_to_first_attribute,
            cfx_xml_reader_move_to_next_attribute,
            cfx_xml_reader_move_to_carrying_element,
            cfx_zip_reader_create,
            cfx_zip_reader_move_to_first_file,
            cfx_zip_reader_move_to_next_file,
            cfx_zip_reader_move_to_file,
            cfx_zip_reader_close,
            cfx_zip_reader_get_file_name,
            cfx_zip_reader_get_file_size,
            cfx_zip_reader_get_file_last_modified,
            cfx_zip_reader_open_file,
            cfx_zip_reader_close_file,
            cfx_zip_reader_read_file,
            cfx_zip_reader_tell,
            cfx_zip_reader_eof,
            cfx_string_list_alloc,
            cfx_string_list_size,
            cfx_string_list_value,
            cfx_string_list_append,
            cfx_string_list_clear,
            cfx_string_list_free,
            cfx_string_list_copy,
            cfx_string_map_alloc,
            cfx_string_map_size,
            cfx_string_map_find,
            cfx_string_map_key,
            cfx_string_map_value,
            cfx_string_map_append,
            cfx_string_map_clear,
            cfx_string_map_free,
            cfx_string_multimap_alloc,
            cfx_string_multimap_size,
            cfx_string_multimap_find_count,
            cfx_string_multimap_enumerate,
            cfx_string_multimap_key,
            cfx_string_multimap_value,
            cfx_string_multimap_append,
            cfx_string_multimap_clear,
            cfx_string_multimap_free,
        }

        internal static void LoadCfxRuntimeApi() {
            CfxApi.cfx_add_cross_origin_whitelist_entry = (CfxApi.cfx_add_cross_origin_whitelist_entry_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_add_cross_origin_whitelist_entry, typeof(CfxApi.cfx_add_cross_origin_whitelist_entry_delegate));
            CfxApi.cfx_add_web_plugin_directory = (CfxApi.cfx_add_web_plugin_directory_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_add_web_plugin_directory, typeof(CfxApi.cfx_add_web_plugin_directory_delegate));
            CfxApi.cfx_add_web_plugin_path = (CfxApi.cfx_add_web_plugin_path_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_add_web_plugin_path, typeof(CfxApi.cfx_add_web_plugin_path_delegate));
            CfxApi.cfx_api_hash = (CfxApi.cfx_api_hash_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_api_hash, typeof(CfxApi.cfx_api_hash_delegate));
            CfxApi.cfx_begin_tracing = (CfxApi.cfx_begin_tracing_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_begin_tracing, typeof(CfxApi.cfx_begin_tracing_delegate));
            CfxApi.cfx_clear_cross_origin_whitelist = (CfxApi.cfx_clear_cross_origin_whitelist_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_clear_cross_origin_whitelist, typeof(CfxApi.cfx_clear_cross_origin_whitelist_delegate));
            CfxApi.cfx_clear_scheme_handler_factories = (CfxApi.cfx_clear_scheme_handler_factories_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_clear_scheme_handler_factories, typeof(CfxApi.cfx_clear_scheme_handler_factories_delegate));
            CfxApi.cfx_create_url = (CfxApi.cfx_create_url_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_create_url, typeof(CfxApi.cfx_create_url_delegate));
            CfxApi.cfx_currently_on = (CfxApi.cfx_currently_on_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_currently_on, typeof(CfxApi.cfx_currently_on_delegate));
            CfxApi.cfx_do_message_loop_work = (CfxApi.cfx_do_message_loop_work_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_do_message_loop_work, typeof(CfxApi.cfx_do_message_loop_work_delegate));
            CfxApi.cfx_enable_highdpi_support = (CfxApi.cfx_enable_highdpi_support_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_enable_highdpi_support, typeof(CfxApi.cfx_enable_highdpi_support_delegate));
            CfxApi.cfx_end_tracing = (CfxApi.cfx_end_tracing_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_end_tracing, typeof(CfxApi.cfx_end_tracing_delegate));
            CfxApi.cfx_execute_process = (CfxApi.cfx_execute_process_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_execute_process, typeof(CfxApi.cfx_execute_process_delegate));
            CfxApi.cfx_force_web_plugin_shutdown = (CfxApi.cfx_force_web_plugin_shutdown_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_force_web_plugin_shutdown, typeof(CfxApi.cfx_force_web_plugin_shutdown_delegate));
            CfxApi.cfx_format_url_for_security_display = (CfxApi.cfx_format_url_for_security_display_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_format_url_for_security_display, typeof(CfxApi.cfx_format_url_for_security_display_delegate));
            CfxApi.cfx_get_extensions_for_mime_type = (CfxApi.cfx_get_extensions_for_mime_type_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_get_extensions_for_mime_type, typeof(CfxApi.cfx_get_extensions_for_mime_type_delegate));
            CfxApi.cfx_get_geolocation = (CfxApi.cfx_get_geolocation_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_get_geolocation, typeof(CfxApi.cfx_get_geolocation_delegate));
            CfxApi.cfx_get_mime_type = (CfxApi.cfx_get_mime_type_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_get_mime_type, typeof(CfxApi.cfx_get_mime_type_delegate));
            CfxApi.cfx_get_path = (CfxApi.cfx_get_path_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_get_path, typeof(CfxApi.cfx_get_path_delegate));
            if(CfxApi.PlatformOS == CfxPlatformOS.Linux) {
                CfxApi.cfx_get_xdisplay = (CfxApi.cfx_get_xdisplay_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_get_xdisplay, typeof(CfxApi.cfx_get_xdisplay_delegate));
            }
            CfxApi.cfx_initialize = (CfxApi.cfx_initialize_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_initialize, typeof(CfxApi.cfx_initialize_delegate));
            CfxApi.cfx_is_web_plugin_unstable = (CfxApi.cfx_is_web_plugin_unstable_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_is_web_plugin_unstable, typeof(CfxApi.cfx_is_web_plugin_unstable_delegate));
            CfxApi.cfx_launch_process = (CfxApi.cfx_launch_process_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_launch_process, typeof(CfxApi.cfx_launch_process_delegate));
            CfxApi.cfx_now_from_system_trace_time = (CfxApi.cfx_now_from_system_trace_time_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_now_from_system_trace_time, typeof(CfxApi.cfx_now_from_system_trace_time_delegate));
            CfxApi.cfx_parse_csscolor = (CfxApi.cfx_parse_csscolor_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_parse_csscolor, typeof(CfxApi.cfx_parse_csscolor_delegate));
            CfxApi.cfx_parse_json = (CfxApi.cfx_parse_json_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_parse_json, typeof(CfxApi.cfx_parse_json_delegate));
            CfxApi.cfx_parse_jsonand_return_error = (CfxApi.cfx_parse_jsonand_return_error_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_parse_jsonand_return_error, typeof(CfxApi.cfx_parse_jsonand_return_error_delegate));
            CfxApi.cfx_parse_url = (CfxApi.cfx_parse_url_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_parse_url, typeof(CfxApi.cfx_parse_url_delegate));
            CfxApi.cfx_post_delayed_task = (CfxApi.cfx_post_delayed_task_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_post_delayed_task, typeof(CfxApi.cfx_post_delayed_task_delegate));
            CfxApi.cfx_post_task = (CfxApi.cfx_post_task_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_post_task, typeof(CfxApi.cfx_post_task_delegate));
            CfxApi.cfx_quit_message_loop = (CfxApi.cfx_quit_message_loop_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_quit_message_loop, typeof(CfxApi.cfx_quit_message_loop_delegate));
            CfxApi.cfx_refresh_web_plugins = (CfxApi.cfx_refresh_web_plugins_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_refresh_web_plugins, typeof(CfxApi.cfx_refresh_web_plugins_delegate));
            CfxApi.cfx_register_extension = (CfxApi.cfx_register_extension_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_register_extension, typeof(CfxApi.cfx_register_extension_delegate));
            CfxApi.cfx_register_scheme_handler_factory = (CfxApi.cfx_register_scheme_handler_factory_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_register_scheme_handler_factory, typeof(CfxApi.cfx_register_scheme_handler_factory_delegate));
            CfxApi.cfx_register_web_plugin_crash = (CfxApi.cfx_register_web_plugin_crash_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_register_web_plugin_crash, typeof(CfxApi.cfx_register_web_plugin_crash_delegate));
            CfxApi.cfx_remove_cross_origin_whitelist_entry = (CfxApi.cfx_remove_cross_origin_whitelist_entry_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_remove_cross_origin_whitelist_entry, typeof(CfxApi.cfx_remove_cross_origin_whitelist_entry_delegate));
            CfxApi.cfx_remove_web_plugin_path = (CfxApi.cfx_remove_web_plugin_path_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_remove_web_plugin_path, typeof(CfxApi.cfx_remove_web_plugin_path_delegate));
            CfxApi.cfx_run_message_loop = (CfxApi.cfx_run_message_loop_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_run_message_loop, typeof(CfxApi.cfx_run_message_loop_delegate));
            CfxApi.cfx_set_osmodal_loop = (CfxApi.cfx_set_osmodal_loop_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_set_osmodal_loop, typeof(CfxApi.cfx_set_osmodal_loop_delegate));
            CfxApi.cfx_shutdown = (CfxApi.cfx_shutdown_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_shutdown, typeof(CfxApi.cfx_shutdown_delegate));
            CfxApi.cfx_unregister_internal_web_plugin = (CfxApi.cfx_unregister_internal_web_plugin_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_unregister_internal_web_plugin, typeof(CfxApi.cfx_unregister_internal_web_plugin_delegate));
            CfxApi.cfx_uridecode = (CfxApi.cfx_uridecode_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_uridecode, typeof(CfxApi.cfx_uridecode_delegate));
            CfxApi.cfx_uriencode = (CfxApi.cfx_uriencode_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_uriencode, typeof(CfxApi.cfx_uriencode_delegate));
            CfxApi.cfx_version_info = (CfxApi.cfx_version_info_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_version_info, typeof(CfxApi.cfx_version_info_delegate));
            CfxApi.cfx_visit_web_plugin_info = (CfxApi.cfx_visit_web_plugin_info_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_visit_web_plugin_info, typeof(CfxApi.cfx_visit_web_plugin_info_delegate));
            CfxApi.cfx_write_json = (CfxApi.cfx_write_json_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_write_json, typeof(CfxApi.cfx_write_json_delegate));
        }

        internal static void LoadStringCollectionApi() {
            CfxApi.Probe();
            CfxApi.cfx_string_list_alloc = (CfxApi.cfx_string_list_alloc_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_string_list_alloc, typeof(CfxApi.cfx_string_list_alloc_delegate));
            CfxApi.cfx_string_list_size = (CfxApi.cfx_string_list_size_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_string_list_size, typeof(CfxApi.cfx_string_list_size_delegate));
            CfxApi.cfx_string_list_value = (CfxApi.cfx_string_list_value_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_string_list_value, typeof(CfxApi.cfx_string_list_value_delegate));
            CfxApi.cfx_string_list_append = (CfxApi.cfx_string_list_append_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_string_list_append, typeof(CfxApi.cfx_string_list_append_delegate));
            CfxApi.cfx_string_list_clear = (CfxApi.cfx_string_list_clear_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_string_list_clear, typeof(CfxApi.cfx_string_list_clear_delegate));
            CfxApi.cfx_string_list_free = (CfxApi.cfx_string_list_free_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_string_list_free, typeof(CfxApi.cfx_string_list_free_delegate));
            CfxApi.cfx_string_list_copy = (CfxApi.cfx_string_list_copy_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_string_list_copy, typeof(CfxApi.cfx_string_list_copy_delegate));
            CfxApi.cfx_string_map_alloc = (CfxApi.cfx_string_map_alloc_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_string_map_alloc, typeof(CfxApi.cfx_string_map_alloc_delegate));
            CfxApi.cfx_string_map_size = (CfxApi.cfx_string_map_size_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_string_map_size, typeof(CfxApi.cfx_string_map_size_delegate));
            CfxApi.cfx_string_map_find = (CfxApi.cfx_string_map_find_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_string_map_find, typeof(CfxApi.cfx_string_map_find_delegate));
            CfxApi.cfx_string_map_key = (CfxApi.cfx_string_map_key_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_string_map_key, typeof(CfxApi.cfx_string_map_key_delegate));
            CfxApi.cfx_string_map_value = (CfxApi.cfx_string_map_value_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_string_map_value, typeof(CfxApi.cfx_string_map_value_delegate));
            CfxApi.cfx_string_map_append = (CfxApi.cfx_string_map_append_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_string_map_append, typeof(CfxApi.cfx_string_map_append_delegate));
            CfxApi.cfx_string_map_clear = (CfxApi.cfx_string_map_clear_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_string_map_clear, typeof(CfxApi.cfx_string_map_clear_delegate));
            CfxApi.cfx_string_map_free = (CfxApi.cfx_string_map_free_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_string_map_free, typeof(CfxApi.cfx_string_map_free_delegate));
            CfxApi.cfx_string_multimap_alloc = (CfxApi.cfx_string_multimap_alloc_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_string_multimap_alloc, typeof(CfxApi.cfx_string_multimap_alloc_delegate));
            CfxApi.cfx_string_multimap_size = (CfxApi.cfx_string_multimap_size_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_string_multimap_size, typeof(CfxApi.cfx_string_multimap_size_delegate));
            CfxApi.cfx_string_multimap_find_count = (CfxApi.cfx_string_multimap_find_count_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_string_multimap_find_count, typeof(CfxApi.cfx_string_multimap_find_count_delegate));
            CfxApi.cfx_string_multimap_enumerate = (CfxApi.cfx_string_multimap_enumerate_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_string_multimap_enumerate, typeof(CfxApi.cfx_string_multimap_enumerate_delegate));
            CfxApi.cfx_string_multimap_key = (CfxApi.cfx_string_multimap_key_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_string_multimap_key, typeof(CfxApi.cfx_string_multimap_key_delegate));
            CfxApi.cfx_string_multimap_value = (CfxApi.cfx_string_multimap_value_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_string_multimap_value, typeof(CfxApi.cfx_string_multimap_value_delegate));
            CfxApi.cfx_string_multimap_append = (CfxApi.cfx_string_multimap_append_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_string_multimap_append, typeof(CfxApi.cfx_string_multimap_append_delegate));
            CfxApi.cfx_string_multimap_clear = (CfxApi.cfx_string_multimap_clear_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_string_multimap_clear, typeof(CfxApi.cfx_string_multimap_clear_delegate));
            CfxApi.cfx_string_multimap_free = (CfxApi.cfx_string_multimap_free_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_string_multimap_free, typeof(CfxApi.cfx_string_multimap_free_delegate));
        }

        private static bool CfxAppApiLoaded;
        internal static void LoadCfxAppApi() {
            if(CfxAppApiLoaded) return;
            CfxAppApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_app_ctor = (CfxApi.cfx_ctor_with_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_app_ctor, typeof(CfxApi.cfx_ctor_with_gc_handle_delegate));
            CfxApi.cfx_app_get_gc_handle = (CfxApi.cfx_get_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_app_get_gc_handle, typeof(CfxApi.cfx_get_gc_handle_delegate));
            CfxApi.cfx_app_set_managed_callback = (CfxApi.cfx_set_callback_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_app_set_managed_callback, typeof(CfxApi.cfx_set_callback_delegate));
        }

        private static bool CfxAuthCallbackApiLoaded;
        internal static void LoadCfxAuthCallbackApi() {
            if(CfxAuthCallbackApiLoaded) return;
            CfxAuthCallbackApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_auth_callback_cont = (CfxApi.cfx_auth_callback_cont_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_auth_callback_cont, typeof(CfxApi.cfx_auth_callback_cont_delegate));
            CfxApi.cfx_auth_callback_cancel = (CfxApi.cfx_auth_callback_cancel_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_auth_callback_cancel, typeof(CfxApi.cfx_auth_callback_cancel_delegate));
        }

        private static bool CfxBeforeDownloadCallbackApiLoaded;
        internal static void LoadCfxBeforeDownloadCallbackApi() {
            if(CfxBeforeDownloadCallbackApiLoaded) return;
            CfxBeforeDownloadCallbackApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_before_download_callback_cont = (CfxApi.cfx_before_download_callback_cont_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_before_download_callback_cont, typeof(CfxApi.cfx_before_download_callback_cont_delegate));
        }

        private static bool CfxBinaryValueApiLoaded;
        internal static void LoadCfxBinaryValueApi() {
            if(CfxBinaryValueApiLoaded) return;
            CfxBinaryValueApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_binary_value_create = (CfxApi.cfx_binary_value_create_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_binary_value_create, typeof(CfxApi.cfx_binary_value_create_delegate));
            CfxApi.cfx_binary_value_is_valid = (CfxApi.cfx_binary_value_is_valid_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_binary_value_is_valid, typeof(CfxApi.cfx_binary_value_is_valid_delegate));
            CfxApi.cfx_binary_value_is_owned = (CfxApi.cfx_binary_value_is_owned_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_binary_value_is_owned, typeof(CfxApi.cfx_binary_value_is_owned_delegate));
            CfxApi.cfx_binary_value_is_same = (CfxApi.cfx_binary_value_is_same_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_binary_value_is_same, typeof(CfxApi.cfx_binary_value_is_same_delegate));
            CfxApi.cfx_binary_value_is_equal = (CfxApi.cfx_binary_value_is_equal_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_binary_value_is_equal, typeof(CfxApi.cfx_binary_value_is_equal_delegate));
            CfxApi.cfx_binary_value_copy = (CfxApi.cfx_binary_value_copy_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_binary_value_copy, typeof(CfxApi.cfx_binary_value_copy_delegate));
            CfxApi.cfx_binary_value_get_size = (CfxApi.cfx_binary_value_get_size_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_binary_value_get_size, typeof(CfxApi.cfx_binary_value_get_size_delegate));
            CfxApi.cfx_binary_value_get_data = (CfxApi.cfx_binary_value_get_data_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_binary_value_get_data, typeof(CfxApi.cfx_binary_value_get_data_delegate));
        }

        private static bool CfxBrowserApiLoaded;
        internal static void LoadCfxBrowserApi() {
            if(CfxBrowserApiLoaded) return;
            CfxBrowserApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_browser_get_host = (CfxApi.cfx_browser_get_host_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_get_host, typeof(CfxApi.cfx_browser_get_host_delegate));
            CfxApi.cfx_browser_can_go_back = (CfxApi.cfx_browser_can_go_back_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_can_go_back, typeof(CfxApi.cfx_browser_can_go_back_delegate));
            CfxApi.cfx_browser_go_back = (CfxApi.cfx_browser_go_back_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_go_back, typeof(CfxApi.cfx_browser_go_back_delegate));
            CfxApi.cfx_browser_can_go_forward = (CfxApi.cfx_browser_can_go_forward_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_can_go_forward, typeof(CfxApi.cfx_browser_can_go_forward_delegate));
            CfxApi.cfx_browser_go_forward = (CfxApi.cfx_browser_go_forward_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_go_forward, typeof(CfxApi.cfx_browser_go_forward_delegate));
            CfxApi.cfx_browser_is_loading = (CfxApi.cfx_browser_is_loading_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_is_loading, typeof(CfxApi.cfx_browser_is_loading_delegate));
            CfxApi.cfx_browser_reload = (CfxApi.cfx_browser_reload_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_reload, typeof(CfxApi.cfx_browser_reload_delegate));
            CfxApi.cfx_browser_reload_ignore_cache = (CfxApi.cfx_browser_reload_ignore_cache_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_reload_ignore_cache, typeof(CfxApi.cfx_browser_reload_ignore_cache_delegate));
            CfxApi.cfx_browser_stop_load = (CfxApi.cfx_browser_stop_load_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_stop_load, typeof(CfxApi.cfx_browser_stop_load_delegate));
            CfxApi.cfx_browser_get_identifier = (CfxApi.cfx_browser_get_identifier_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_get_identifier, typeof(CfxApi.cfx_browser_get_identifier_delegate));
            CfxApi.cfx_browser_is_same = (CfxApi.cfx_browser_is_same_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_is_same, typeof(CfxApi.cfx_browser_is_same_delegate));
            CfxApi.cfx_browser_is_popup = (CfxApi.cfx_browser_is_popup_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_is_popup, typeof(CfxApi.cfx_browser_is_popup_delegate));
            CfxApi.cfx_browser_has_document = (CfxApi.cfx_browser_has_document_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_has_document, typeof(CfxApi.cfx_browser_has_document_delegate));
            CfxApi.cfx_browser_get_main_frame = (CfxApi.cfx_browser_get_main_frame_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_get_main_frame, typeof(CfxApi.cfx_browser_get_main_frame_delegate));
            CfxApi.cfx_browser_get_focused_frame = (CfxApi.cfx_browser_get_focused_frame_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_get_focused_frame, typeof(CfxApi.cfx_browser_get_focused_frame_delegate));
            CfxApi.cfx_browser_get_frame_byident = (CfxApi.cfx_browser_get_frame_byident_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_get_frame_byident, typeof(CfxApi.cfx_browser_get_frame_byident_delegate));
            CfxApi.cfx_browser_get_frame = (CfxApi.cfx_browser_get_frame_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_get_frame, typeof(CfxApi.cfx_browser_get_frame_delegate));
            CfxApi.cfx_browser_get_frame_count = (CfxApi.cfx_browser_get_frame_count_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_get_frame_count, typeof(CfxApi.cfx_browser_get_frame_count_delegate));
            CfxApi.cfx_browser_get_frame_identifiers = (CfxApi.cfx_browser_get_frame_identifiers_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_get_frame_identifiers, typeof(CfxApi.cfx_browser_get_frame_identifiers_delegate));
            CfxApi.cfx_browser_get_frame_names = (CfxApi.cfx_browser_get_frame_names_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_get_frame_names, typeof(CfxApi.cfx_browser_get_frame_names_delegate));
            CfxApi.cfx_browser_send_process_message = (CfxApi.cfx_browser_send_process_message_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_send_process_message, typeof(CfxApi.cfx_browser_send_process_message_delegate));
        }

        private static bool CfxBrowserHostApiLoaded;
        internal static void LoadCfxBrowserHostApi() {
            if(CfxBrowserHostApiLoaded) return;
            CfxBrowserHostApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_browser_host_create_browser = (CfxApi.cfx_browser_host_create_browser_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_host_create_browser, typeof(CfxApi.cfx_browser_host_create_browser_delegate));
            CfxApi.cfx_browser_host_create_browser_sync = (CfxApi.cfx_browser_host_create_browser_sync_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_host_create_browser_sync, typeof(CfxApi.cfx_browser_host_create_browser_sync_delegate));
            CfxApi.cfx_browser_host_get_browser = (CfxApi.cfx_browser_host_get_browser_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_host_get_browser, typeof(CfxApi.cfx_browser_host_get_browser_delegate));
            CfxApi.cfx_browser_host_close_browser = (CfxApi.cfx_browser_host_close_browser_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_host_close_browser, typeof(CfxApi.cfx_browser_host_close_browser_delegate));
            CfxApi.cfx_browser_host_set_focus = (CfxApi.cfx_browser_host_set_focus_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_host_set_focus, typeof(CfxApi.cfx_browser_host_set_focus_delegate));
            CfxApi.cfx_browser_host_set_window_visibility = (CfxApi.cfx_browser_host_set_window_visibility_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_host_set_window_visibility, typeof(CfxApi.cfx_browser_host_set_window_visibility_delegate));
            CfxApi.cfx_browser_host_get_window_handle = (CfxApi.cfx_browser_host_get_window_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_host_get_window_handle, typeof(CfxApi.cfx_browser_host_get_window_handle_delegate));
            CfxApi.cfx_browser_host_get_opener_window_handle = (CfxApi.cfx_browser_host_get_opener_window_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_host_get_opener_window_handle, typeof(CfxApi.cfx_browser_host_get_opener_window_handle_delegate));
            CfxApi.cfx_browser_host_get_client = (CfxApi.cfx_browser_host_get_client_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_host_get_client, typeof(CfxApi.cfx_browser_host_get_client_delegate));
            CfxApi.cfx_browser_host_get_request_context = (CfxApi.cfx_browser_host_get_request_context_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_host_get_request_context, typeof(CfxApi.cfx_browser_host_get_request_context_delegate));
            CfxApi.cfx_browser_host_get_zoom_level = (CfxApi.cfx_browser_host_get_zoom_level_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_host_get_zoom_level, typeof(CfxApi.cfx_browser_host_get_zoom_level_delegate));
            CfxApi.cfx_browser_host_set_zoom_level = (CfxApi.cfx_browser_host_set_zoom_level_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_host_set_zoom_level, typeof(CfxApi.cfx_browser_host_set_zoom_level_delegate));
            CfxApi.cfx_browser_host_run_file_dialog = (CfxApi.cfx_browser_host_run_file_dialog_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_host_run_file_dialog, typeof(CfxApi.cfx_browser_host_run_file_dialog_delegate));
            CfxApi.cfx_browser_host_start_download = (CfxApi.cfx_browser_host_start_download_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_host_start_download, typeof(CfxApi.cfx_browser_host_start_download_delegate));
            CfxApi.cfx_browser_host_print = (CfxApi.cfx_browser_host_print_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_host_print, typeof(CfxApi.cfx_browser_host_print_delegate));
            CfxApi.cfx_browser_host_print_to_pdf = (CfxApi.cfx_browser_host_print_to_pdf_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_host_print_to_pdf, typeof(CfxApi.cfx_browser_host_print_to_pdf_delegate));
            CfxApi.cfx_browser_host_find = (CfxApi.cfx_browser_host_find_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_host_find, typeof(CfxApi.cfx_browser_host_find_delegate));
            CfxApi.cfx_browser_host_stop_finding = (CfxApi.cfx_browser_host_stop_finding_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_host_stop_finding, typeof(CfxApi.cfx_browser_host_stop_finding_delegate));
            CfxApi.cfx_browser_host_show_dev_tools = (CfxApi.cfx_browser_host_show_dev_tools_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_host_show_dev_tools, typeof(CfxApi.cfx_browser_host_show_dev_tools_delegate));
            CfxApi.cfx_browser_host_close_dev_tools = (CfxApi.cfx_browser_host_close_dev_tools_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_host_close_dev_tools, typeof(CfxApi.cfx_browser_host_close_dev_tools_delegate));
            CfxApi.cfx_browser_host_get_navigation_entries = (CfxApi.cfx_browser_host_get_navigation_entries_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_host_get_navigation_entries, typeof(CfxApi.cfx_browser_host_get_navigation_entries_delegate));
            CfxApi.cfx_browser_host_set_mouse_cursor_change_disabled = (CfxApi.cfx_browser_host_set_mouse_cursor_change_disabled_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_host_set_mouse_cursor_change_disabled, typeof(CfxApi.cfx_browser_host_set_mouse_cursor_change_disabled_delegate));
            CfxApi.cfx_browser_host_is_mouse_cursor_change_disabled = (CfxApi.cfx_browser_host_is_mouse_cursor_change_disabled_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_host_is_mouse_cursor_change_disabled, typeof(CfxApi.cfx_browser_host_is_mouse_cursor_change_disabled_delegate));
            CfxApi.cfx_browser_host_replace_misspelling = (CfxApi.cfx_browser_host_replace_misspelling_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_host_replace_misspelling, typeof(CfxApi.cfx_browser_host_replace_misspelling_delegate));
            CfxApi.cfx_browser_host_add_word_to_dictionary = (CfxApi.cfx_browser_host_add_word_to_dictionary_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_host_add_word_to_dictionary, typeof(CfxApi.cfx_browser_host_add_word_to_dictionary_delegate));
            CfxApi.cfx_browser_host_is_window_rendering_disabled = (CfxApi.cfx_browser_host_is_window_rendering_disabled_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_host_is_window_rendering_disabled, typeof(CfxApi.cfx_browser_host_is_window_rendering_disabled_delegate));
            CfxApi.cfx_browser_host_was_resized = (CfxApi.cfx_browser_host_was_resized_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_host_was_resized, typeof(CfxApi.cfx_browser_host_was_resized_delegate));
            CfxApi.cfx_browser_host_was_hidden = (CfxApi.cfx_browser_host_was_hidden_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_host_was_hidden, typeof(CfxApi.cfx_browser_host_was_hidden_delegate));
            CfxApi.cfx_browser_host_notify_screen_info_changed = (CfxApi.cfx_browser_host_notify_screen_info_changed_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_host_notify_screen_info_changed, typeof(CfxApi.cfx_browser_host_notify_screen_info_changed_delegate));
            CfxApi.cfx_browser_host_invalidate = (CfxApi.cfx_browser_host_invalidate_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_host_invalidate, typeof(CfxApi.cfx_browser_host_invalidate_delegate));
            CfxApi.cfx_browser_host_send_key_event = (CfxApi.cfx_browser_host_send_key_event_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_host_send_key_event, typeof(CfxApi.cfx_browser_host_send_key_event_delegate));
            CfxApi.cfx_browser_host_send_mouse_click_event = (CfxApi.cfx_browser_host_send_mouse_click_event_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_host_send_mouse_click_event, typeof(CfxApi.cfx_browser_host_send_mouse_click_event_delegate));
            CfxApi.cfx_browser_host_send_mouse_move_event = (CfxApi.cfx_browser_host_send_mouse_move_event_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_host_send_mouse_move_event, typeof(CfxApi.cfx_browser_host_send_mouse_move_event_delegate));
            CfxApi.cfx_browser_host_send_mouse_wheel_event = (CfxApi.cfx_browser_host_send_mouse_wheel_event_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_host_send_mouse_wheel_event, typeof(CfxApi.cfx_browser_host_send_mouse_wheel_event_delegate));
            CfxApi.cfx_browser_host_send_focus_event = (CfxApi.cfx_browser_host_send_focus_event_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_host_send_focus_event, typeof(CfxApi.cfx_browser_host_send_focus_event_delegate));
            CfxApi.cfx_browser_host_send_capture_lost_event = (CfxApi.cfx_browser_host_send_capture_lost_event_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_host_send_capture_lost_event, typeof(CfxApi.cfx_browser_host_send_capture_lost_event_delegate));
            CfxApi.cfx_browser_host_notify_move_or_resize_started = (CfxApi.cfx_browser_host_notify_move_or_resize_started_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_host_notify_move_or_resize_started, typeof(CfxApi.cfx_browser_host_notify_move_or_resize_started_delegate));
            CfxApi.cfx_browser_host_get_windowless_frame_rate = (CfxApi.cfx_browser_host_get_windowless_frame_rate_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_host_get_windowless_frame_rate, typeof(CfxApi.cfx_browser_host_get_windowless_frame_rate_delegate));
            CfxApi.cfx_browser_host_set_windowless_frame_rate = (CfxApi.cfx_browser_host_set_windowless_frame_rate_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_host_set_windowless_frame_rate, typeof(CfxApi.cfx_browser_host_set_windowless_frame_rate_delegate));
            CfxApi.cfx_browser_host_get_nstext_input_context = (CfxApi.cfx_browser_host_get_nstext_input_context_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_host_get_nstext_input_context, typeof(CfxApi.cfx_browser_host_get_nstext_input_context_delegate));
            CfxApi.cfx_browser_host_handle_key_event_before_text_input_client = (CfxApi.cfx_browser_host_handle_key_event_before_text_input_client_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_host_handle_key_event_before_text_input_client, typeof(CfxApi.cfx_browser_host_handle_key_event_before_text_input_client_delegate));
            CfxApi.cfx_browser_host_handle_key_event_after_text_input_client = (CfxApi.cfx_browser_host_handle_key_event_after_text_input_client_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_host_handle_key_event_after_text_input_client, typeof(CfxApi.cfx_browser_host_handle_key_event_after_text_input_client_delegate));
            CfxApi.cfx_browser_host_drag_target_drag_enter = (CfxApi.cfx_browser_host_drag_target_drag_enter_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_host_drag_target_drag_enter, typeof(CfxApi.cfx_browser_host_drag_target_drag_enter_delegate));
            CfxApi.cfx_browser_host_drag_target_drag_over = (CfxApi.cfx_browser_host_drag_target_drag_over_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_host_drag_target_drag_over, typeof(CfxApi.cfx_browser_host_drag_target_drag_over_delegate));
            CfxApi.cfx_browser_host_drag_target_drag_leave = (CfxApi.cfx_browser_host_drag_target_drag_leave_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_host_drag_target_drag_leave, typeof(CfxApi.cfx_browser_host_drag_target_drag_leave_delegate));
            CfxApi.cfx_browser_host_drag_target_drop = (CfxApi.cfx_browser_host_drag_target_drop_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_host_drag_target_drop, typeof(CfxApi.cfx_browser_host_drag_target_drop_delegate));
            CfxApi.cfx_browser_host_drag_source_ended_at = (CfxApi.cfx_browser_host_drag_source_ended_at_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_host_drag_source_ended_at, typeof(CfxApi.cfx_browser_host_drag_source_ended_at_delegate));
            CfxApi.cfx_browser_host_drag_source_system_drag_ended = (CfxApi.cfx_browser_host_drag_source_system_drag_ended_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_host_drag_source_system_drag_ended, typeof(CfxApi.cfx_browser_host_drag_source_system_drag_ended_delegate));
        }

        private static bool CfxBrowserProcessHandlerApiLoaded;
        internal static void LoadCfxBrowserProcessHandlerApi() {
            if(CfxBrowserProcessHandlerApiLoaded) return;
            CfxBrowserProcessHandlerApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_browser_process_handler_ctor = (CfxApi.cfx_ctor_with_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_process_handler_ctor, typeof(CfxApi.cfx_ctor_with_gc_handle_delegate));
            CfxApi.cfx_browser_process_handler_get_gc_handle = (CfxApi.cfx_get_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_process_handler_get_gc_handle, typeof(CfxApi.cfx_get_gc_handle_delegate));
            CfxApi.cfx_browser_process_handler_set_managed_callback = (CfxApi.cfx_set_callback_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_process_handler_set_managed_callback, typeof(CfxApi.cfx_set_callback_delegate));
        }

        private static bool CfxBrowserSettingsApiLoaded;
        internal static void LoadCfxBrowserSettingsApi() {
            if(CfxBrowserSettingsApiLoaded) return;
            CfxBrowserSettingsApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_browser_settings_ctor = (CfxApi.cfx_ctor_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_ctor, typeof(CfxApi.cfx_ctor_delegate));
            CfxApi.cfx_browser_settings_dtor = (CfxApi.cfx_dtor_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_dtor, typeof(CfxApi.cfx_dtor_delegate));
            CfxApi.cfx_browser_settings_set_windowless_frame_rate = (CfxApi.cfx_browser_settings_set_windowless_frame_rate_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_set_windowless_frame_rate, typeof(CfxApi.cfx_browser_settings_set_windowless_frame_rate_delegate));
            CfxApi.cfx_browser_settings_get_windowless_frame_rate = (CfxApi.cfx_browser_settings_get_windowless_frame_rate_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_get_windowless_frame_rate, typeof(CfxApi.cfx_browser_settings_get_windowless_frame_rate_delegate));
            CfxApi.cfx_browser_settings_set_standard_font_family = (CfxApi.cfx_browser_settings_set_standard_font_family_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_set_standard_font_family, typeof(CfxApi.cfx_browser_settings_set_standard_font_family_delegate));
            CfxApi.cfx_browser_settings_get_standard_font_family = (CfxApi.cfx_browser_settings_get_standard_font_family_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_get_standard_font_family, typeof(CfxApi.cfx_browser_settings_get_standard_font_family_delegate));
            CfxApi.cfx_browser_settings_set_fixed_font_family = (CfxApi.cfx_browser_settings_set_fixed_font_family_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_set_fixed_font_family, typeof(CfxApi.cfx_browser_settings_set_fixed_font_family_delegate));
            CfxApi.cfx_browser_settings_get_fixed_font_family = (CfxApi.cfx_browser_settings_get_fixed_font_family_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_get_fixed_font_family, typeof(CfxApi.cfx_browser_settings_get_fixed_font_family_delegate));
            CfxApi.cfx_browser_settings_set_serif_font_family = (CfxApi.cfx_browser_settings_set_serif_font_family_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_set_serif_font_family, typeof(CfxApi.cfx_browser_settings_set_serif_font_family_delegate));
            CfxApi.cfx_browser_settings_get_serif_font_family = (CfxApi.cfx_browser_settings_get_serif_font_family_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_get_serif_font_family, typeof(CfxApi.cfx_browser_settings_get_serif_font_family_delegate));
            CfxApi.cfx_browser_settings_set_sans_serif_font_family = (CfxApi.cfx_browser_settings_set_sans_serif_font_family_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_set_sans_serif_font_family, typeof(CfxApi.cfx_browser_settings_set_sans_serif_font_family_delegate));
            CfxApi.cfx_browser_settings_get_sans_serif_font_family = (CfxApi.cfx_browser_settings_get_sans_serif_font_family_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_get_sans_serif_font_family, typeof(CfxApi.cfx_browser_settings_get_sans_serif_font_family_delegate));
            CfxApi.cfx_browser_settings_set_cursive_font_family = (CfxApi.cfx_browser_settings_set_cursive_font_family_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_set_cursive_font_family, typeof(CfxApi.cfx_browser_settings_set_cursive_font_family_delegate));
            CfxApi.cfx_browser_settings_get_cursive_font_family = (CfxApi.cfx_browser_settings_get_cursive_font_family_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_get_cursive_font_family, typeof(CfxApi.cfx_browser_settings_get_cursive_font_family_delegate));
            CfxApi.cfx_browser_settings_set_fantasy_font_family = (CfxApi.cfx_browser_settings_set_fantasy_font_family_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_set_fantasy_font_family, typeof(CfxApi.cfx_browser_settings_set_fantasy_font_family_delegate));
            CfxApi.cfx_browser_settings_get_fantasy_font_family = (CfxApi.cfx_browser_settings_get_fantasy_font_family_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_get_fantasy_font_family, typeof(CfxApi.cfx_browser_settings_get_fantasy_font_family_delegate));
            CfxApi.cfx_browser_settings_set_default_font_size = (CfxApi.cfx_browser_settings_set_default_font_size_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_set_default_font_size, typeof(CfxApi.cfx_browser_settings_set_default_font_size_delegate));
            CfxApi.cfx_browser_settings_get_default_font_size = (CfxApi.cfx_browser_settings_get_default_font_size_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_get_default_font_size, typeof(CfxApi.cfx_browser_settings_get_default_font_size_delegate));
            CfxApi.cfx_browser_settings_set_default_fixed_font_size = (CfxApi.cfx_browser_settings_set_default_fixed_font_size_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_set_default_fixed_font_size, typeof(CfxApi.cfx_browser_settings_set_default_fixed_font_size_delegate));
            CfxApi.cfx_browser_settings_get_default_fixed_font_size = (CfxApi.cfx_browser_settings_get_default_fixed_font_size_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_get_default_fixed_font_size, typeof(CfxApi.cfx_browser_settings_get_default_fixed_font_size_delegate));
            CfxApi.cfx_browser_settings_set_minimum_font_size = (CfxApi.cfx_browser_settings_set_minimum_font_size_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_set_minimum_font_size, typeof(CfxApi.cfx_browser_settings_set_minimum_font_size_delegate));
            CfxApi.cfx_browser_settings_get_minimum_font_size = (CfxApi.cfx_browser_settings_get_minimum_font_size_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_get_minimum_font_size, typeof(CfxApi.cfx_browser_settings_get_minimum_font_size_delegate));
            CfxApi.cfx_browser_settings_set_minimum_logical_font_size = (CfxApi.cfx_browser_settings_set_minimum_logical_font_size_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_set_minimum_logical_font_size, typeof(CfxApi.cfx_browser_settings_set_minimum_logical_font_size_delegate));
            CfxApi.cfx_browser_settings_get_minimum_logical_font_size = (CfxApi.cfx_browser_settings_get_minimum_logical_font_size_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_get_minimum_logical_font_size, typeof(CfxApi.cfx_browser_settings_get_minimum_logical_font_size_delegate));
            CfxApi.cfx_browser_settings_set_default_encoding = (CfxApi.cfx_browser_settings_set_default_encoding_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_set_default_encoding, typeof(CfxApi.cfx_browser_settings_set_default_encoding_delegate));
            CfxApi.cfx_browser_settings_get_default_encoding = (CfxApi.cfx_browser_settings_get_default_encoding_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_get_default_encoding, typeof(CfxApi.cfx_browser_settings_get_default_encoding_delegate));
            CfxApi.cfx_browser_settings_set_remote_fonts = (CfxApi.cfx_browser_settings_set_remote_fonts_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_set_remote_fonts, typeof(CfxApi.cfx_browser_settings_set_remote_fonts_delegate));
            CfxApi.cfx_browser_settings_get_remote_fonts = (CfxApi.cfx_browser_settings_get_remote_fonts_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_get_remote_fonts, typeof(CfxApi.cfx_browser_settings_get_remote_fonts_delegate));
            CfxApi.cfx_browser_settings_set_javascript = (CfxApi.cfx_browser_settings_set_javascript_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_set_javascript, typeof(CfxApi.cfx_browser_settings_set_javascript_delegate));
            CfxApi.cfx_browser_settings_get_javascript = (CfxApi.cfx_browser_settings_get_javascript_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_get_javascript, typeof(CfxApi.cfx_browser_settings_get_javascript_delegate));
            CfxApi.cfx_browser_settings_set_javascript_open_windows = (CfxApi.cfx_browser_settings_set_javascript_open_windows_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_set_javascript_open_windows, typeof(CfxApi.cfx_browser_settings_set_javascript_open_windows_delegate));
            CfxApi.cfx_browser_settings_get_javascript_open_windows = (CfxApi.cfx_browser_settings_get_javascript_open_windows_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_get_javascript_open_windows, typeof(CfxApi.cfx_browser_settings_get_javascript_open_windows_delegate));
            CfxApi.cfx_browser_settings_set_javascript_close_windows = (CfxApi.cfx_browser_settings_set_javascript_close_windows_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_set_javascript_close_windows, typeof(CfxApi.cfx_browser_settings_set_javascript_close_windows_delegate));
            CfxApi.cfx_browser_settings_get_javascript_close_windows = (CfxApi.cfx_browser_settings_get_javascript_close_windows_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_get_javascript_close_windows, typeof(CfxApi.cfx_browser_settings_get_javascript_close_windows_delegate));
            CfxApi.cfx_browser_settings_set_javascript_access_clipboard = (CfxApi.cfx_browser_settings_set_javascript_access_clipboard_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_set_javascript_access_clipboard, typeof(CfxApi.cfx_browser_settings_set_javascript_access_clipboard_delegate));
            CfxApi.cfx_browser_settings_get_javascript_access_clipboard = (CfxApi.cfx_browser_settings_get_javascript_access_clipboard_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_get_javascript_access_clipboard, typeof(CfxApi.cfx_browser_settings_get_javascript_access_clipboard_delegate));
            CfxApi.cfx_browser_settings_set_javascript_dom_paste = (CfxApi.cfx_browser_settings_set_javascript_dom_paste_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_set_javascript_dom_paste, typeof(CfxApi.cfx_browser_settings_set_javascript_dom_paste_delegate));
            CfxApi.cfx_browser_settings_get_javascript_dom_paste = (CfxApi.cfx_browser_settings_get_javascript_dom_paste_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_get_javascript_dom_paste, typeof(CfxApi.cfx_browser_settings_get_javascript_dom_paste_delegate));
            CfxApi.cfx_browser_settings_set_caret_browsing = (CfxApi.cfx_browser_settings_set_caret_browsing_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_set_caret_browsing, typeof(CfxApi.cfx_browser_settings_set_caret_browsing_delegate));
            CfxApi.cfx_browser_settings_get_caret_browsing = (CfxApi.cfx_browser_settings_get_caret_browsing_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_get_caret_browsing, typeof(CfxApi.cfx_browser_settings_get_caret_browsing_delegate));
            CfxApi.cfx_browser_settings_set_plugins = (CfxApi.cfx_browser_settings_set_plugins_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_set_plugins, typeof(CfxApi.cfx_browser_settings_set_plugins_delegate));
            CfxApi.cfx_browser_settings_get_plugins = (CfxApi.cfx_browser_settings_get_plugins_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_get_plugins, typeof(CfxApi.cfx_browser_settings_get_plugins_delegate));
            CfxApi.cfx_browser_settings_set_universal_access_from_file_urls = (CfxApi.cfx_browser_settings_set_universal_access_from_file_urls_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_set_universal_access_from_file_urls, typeof(CfxApi.cfx_browser_settings_set_universal_access_from_file_urls_delegate));
            CfxApi.cfx_browser_settings_get_universal_access_from_file_urls = (CfxApi.cfx_browser_settings_get_universal_access_from_file_urls_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_get_universal_access_from_file_urls, typeof(CfxApi.cfx_browser_settings_get_universal_access_from_file_urls_delegate));
            CfxApi.cfx_browser_settings_set_file_access_from_file_urls = (CfxApi.cfx_browser_settings_set_file_access_from_file_urls_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_set_file_access_from_file_urls, typeof(CfxApi.cfx_browser_settings_set_file_access_from_file_urls_delegate));
            CfxApi.cfx_browser_settings_get_file_access_from_file_urls = (CfxApi.cfx_browser_settings_get_file_access_from_file_urls_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_get_file_access_from_file_urls, typeof(CfxApi.cfx_browser_settings_get_file_access_from_file_urls_delegate));
            CfxApi.cfx_browser_settings_set_web_security = (CfxApi.cfx_browser_settings_set_web_security_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_set_web_security, typeof(CfxApi.cfx_browser_settings_set_web_security_delegate));
            CfxApi.cfx_browser_settings_get_web_security = (CfxApi.cfx_browser_settings_get_web_security_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_get_web_security, typeof(CfxApi.cfx_browser_settings_get_web_security_delegate));
            CfxApi.cfx_browser_settings_set_image_loading = (CfxApi.cfx_browser_settings_set_image_loading_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_set_image_loading, typeof(CfxApi.cfx_browser_settings_set_image_loading_delegate));
            CfxApi.cfx_browser_settings_get_image_loading = (CfxApi.cfx_browser_settings_get_image_loading_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_get_image_loading, typeof(CfxApi.cfx_browser_settings_get_image_loading_delegate));
            CfxApi.cfx_browser_settings_set_image_shrink_standalone_to_fit = (CfxApi.cfx_browser_settings_set_image_shrink_standalone_to_fit_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_set_image_shrink_standalone_to_fit, typeof(CfxApi.cfx_browser_settings_set_image_shrink_standalone_to_fit_delegate));
            CfxApi.cfx_browser_settings_get_image_shrink_standalone_to_fit = (CfxApi.cfx_browser_settings_get_image_shrink_standalone_to_fit_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_get_image_shrink_standalone_to_fit, typeof(CfxApi.cfx_browser_settings_get_image_shrink_standalone_to_fit_delegate));
            CfxApi.cfx_browser_settings_set_text_area_resize = (CfxApi.cfx_browser_settings_set_text_area_resize_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_set_text_area_resize, typeof(CfxApi.cfx_browser_settings_set_text_area_resize_delegate));
            CfxApi.cfx_browser_settings_get_text_area_resize = (CfxApi.cfx_browser_settings_get_text_area_resize_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_get_text_area_resize, typeof(CfxApi.cfx_browser_settings_get_text_area_resize_delegate));
            CfxApi.cfx_browser_settings_set_tab_to_links = (CfxApi.cfx_browser_settings_set_tab_to_links_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_set_tab_to_links, typeof(CfxApi.cfx_browser_settings_set_tab_to_links_delegate));
            CfxApi.cfx_browser_settings_get_tab_to_links = (CfxApi.cfx_browser_settings_get_tab_to_links_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_get_tab_to_links, typeof(CfxApi.cfx_browser_settings_get_tab_to_links_delegate));
            CfxApi.cfx_browser_settings_set_local_storage = (CfxApi.cfx_browser_settings_set_local_storage_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_set_local_storage, typeof(CfxApi.cfx_browser_settings_set_local_storage_delegate));
            CfxApi.cfx_browser_settings_get_local_storage = (CfxApi.cfx_browser_settings_get_local_storage_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_get_local_storage, typeof(CfxApi.cfx_browser_settings_get_local_storage_delegate));
            CfxApi.cfx_browser_settings_set_databases = (CfxApi.cfx_browser_settings_set_databases_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_set_databases, typeof(CfxApi.cfx_browser_settings_set_databases_delegate));
            CfxApi.cfx_browser_settings_get_databases = (CfxApi.cfx_browser_settings_get_databases_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_get_databases, typeof(CfxApi.cfx_browser_settings_get_databases_delegate));
            CfxApi.cfx_browser_settings_set_application_cache = (CfxApi.cfx_browser_settings_set_application_cache_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_set_application_cache, typeof(CfxApi.cfx_browser_settings_set_application_cache_delegate));
            CfxApi.cfx_browser_settings_get_application_cache = (CfxApi.cfx_browser_settings_get_application_cache_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_get_application_cache, typeof(CfxApi.cfx_browser_settings_get_application_cache_delegate));
            CfxApi.cfx_browser_settings_set_webgl = (CfxApi.cfx_browser_settings_set_webgl_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_set_webgl, typeof(CfxApi.cfx_browser_settings_set_webgl_delegate));
            CfxApi.cfx_browser_settings_get_webgl = (CfxApi.cfx_browser_settings_get_webgl_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_get_webgl, typeof(CfxApi.cfx_browser_settings_get_webgl_delegate));
            CfxApi.cfx_browser_settings_set_background_color = (CfxApi.cfx_browser_settings_set_background_color_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_set_background_color, typeof(CfxApi.cfx_browser_settings_set_background_color_delegate));
            CfxApi.cfx_browser_settings_get_background_color = (CfxApi.cfx_browser_settings_get_background_color_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_get_background_color, typeof(CfxApi.cfx_browser_settings_get_background_color_delegate));
            CfxApi.cfx_browser_settings_set_accept_language_list = (CfxApi.cfx_browser_settings_set_accept_language_list_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_set_accept_language_list, typeof(CfxApi.cfx_browser_settings_set_accept_language_list_delegate));
            CfxApi.cfx_browser_settings_get_accept_language_list = (CfxApi.cfx_browser_settings_get_accept_language_list_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_get_accept_language_list, typeof(CfxApi.cfx_browser_settings_get_accept_language_list_delegate));
        }

        private static bool CfxCallbackApiLoaded;
        internal static void LoadCfxCallbackApi() {
            if(CfxCallbackApiLoaded) return;
            CfxCallbackApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_callback_cont = (CfxApi.cfx_callback_cont_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_callback_cont, typeof(CfxApi.cfx_callback_cont_delegate));
            CfxApi.cfx_callback_cancel = (CfxApi.cfx_callback_cancel_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_callback_cancel, typeof(CfxApi.cfx_callback_cancel_delegate));
        }

        private static bool CfxClientApiLoaded;
        internal static void LoadCfxClientApi() {
            if(CfxClientApiLoaded) return;
            CfxClientApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_client_ctor = (CfxApi.cfx_ctor_with_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_client_ctor, typeof(CfxApi.cfx_ctor_with_gc_handle_delegate));
            CfxApi.cfx_client_get_gc_handle = (CfxApi.cfx_get_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_client_get_gc_handle, typeof(CfxApi.cfx_get_gc_handle_delegate));
            CfxApi.cfx_client_set_managed_callback = (CfxApi.cfx_set_callback_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_client_set_managed_callback, typeof(CfxApi.cfx_set_callback_delegate));
        }

        private static bool CfxCommandLineApiLoaded;
        internal static void LoadCfxCommandLineApi() {
            if(CfxCommandLineApiLoaded) return;
            CfxCommandLineApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_command_line_create = (CfxApi.cfx_command_line_create_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_command_line_create, typeof(CfxApi.cfx_command_line_create_delegate));
            CfxApi.cfx_command_line_get_global = (CfxApi.cfx_command_line_get_global_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_command_line_get_global, typeof(CfxApi.cfx_command_line_get_global_delegate));
            CfxApi.cfx_command_line_is_valid = (CfxApi.cfx_command_line_is_valid_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_command_line_is_valid, typeof(CfxApi.cfx_command_line_is_valid_delegate));
            CfxApi.cfx_command_line_is_read_only = (CfxApi.cfx_command_line_is_read_only_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_command_line_is_read_only, typeof(CfxApi.cfx_command_line_is_read_only_delegate));
            CfxApi.cfx_command_line_copy = (CfxApi.cfx_command_line_copy_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_command_line_copy, typeof(CfxApi.cfx_command_line_copy_delegate));
            CfxApi.cfx_command_line_init_from_argv = (CfxApi.cfx_command_line_init_from_argv_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_command_line_init_from_argv, typeof(CfxApi.cfx_command_line_init_from_argv_delegate));
            CfxApi.cfx_command_line_init_from_string = (CfxApi.cfx_command_line_init_from_string_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_command_line_init_from_string, typeof(CfxApi.cfx_command_line_init_from_string_delegate));
            CfxApi.cfx_command_line_reset = (CfxApi.cfx_command_line_reset_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_command_line_reset, typeof(CfxApi.cfx_command_line_reset_delegate));
            CfxApi.cfx_command_line_get_argv = (CfxApi.cfx_command_line_get_argv_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_command_line_get_argv, typeof(CfxApi.cfx_command_line_get_argv_delegate));
            CfxApi.cfx_command_line_get_command_line_string = (CfxApi.cfx_command_line_get_command_line_string_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_command_line_get_command_line_string, typeof(CfxApi.cfx_command_line_get_command_line_string_delegate));
            CfxApi.cfx_command_line_get_program = (CfxApi.cfx_command_line_get_program_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_command_line_get_program, typeof(CfxApi.cfx_command_line_get_program_delegate));
            CfxApi.cfx_command_line_set_program = (CfxApi.cfx_command_line_set_program_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_command_line_set_program, typeof(CfxApi.cfx_command_line_set_program_delegate));
            CfxApi.cfx_command_line_has_switches = (CfxApi.cfx_command_line_has_switches_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_command_line_has_switches, typeof(CfxApi.cfx_command_line_has_switches_delegate));
            CfxApi.cfx_command_line_has_switch = (CfxApi.cfx_command_line_has_switch_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_command_line_has_switch, typeof(CfxApi.cfx_command_line_has_switch_delegate));
            CfxApi.cfx_command_line_get_switch_value = (CfxApi.cfx_command_line_get_switch_value_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_command_line_get_switch_value, typeof(CfxApi.cfx_command_line_get_switch_value_delegate));
            CfxApi.cfx_command_line_get_switches = (CfxApi.cfx_command_line_get_switches_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_command_line_get_switches, typeof(CfxApi.cfx_command_line_get_switches_delegate));
            CfxApi.cfx_command_line_append_switch = (CfxApi.cfx_command_line_append_switch_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_command_line_append_switch, typeof(CfxApi.cfx_command_line_append_switch_delegate));
            CfxApi.cfx_command_line_append_switch_with_value = (CfxApi.cfx_command_line_append_switch_with_value_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_command_line_append_switch_with_value, typeof(CfxApi.cfx_command_line_append_switch_with_value_delegate));
            CfxApi.cfx_command_line_has_arguments = (CfxApi.cfx_command_line_has_arguments_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_command_line_has_arguments, typeof(CfxApi.cfx_command_line_has_arguments_delegate));
            CfxApi.cfx_command_line_get_arguments = (CfxApi.cfx_command_line_get_arguments_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_command_line_get_arguments, typeof(CfxApi.cfx_command_line_get_arguments_delegate));
            CfxApi.cfx_command_line_append_argument = (CfxApi.cfx_command_line_append_argument_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_command_line_append_argument, typeof(CfxApi.cfx_command_line_append_argument_delegate));
            CfxApi.cfx_command_line_prepend_wrapper = (CfxApi.cfx_command_line_prepend_wrapper_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_command_line_prepend_wrapper, typeof(CfxApi.cfx_command_line_prepend_wrapper_delegate));
        }

        private static bool CfxCompletionCallbackApiLoaded;
        internal static void LoadCfxCompletionCallbackApi() {
            if(CfxCompletionCallbackApiLoaded) return;
            CfxCompletionCallbackApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_completion_callback_ctor = (CfxApi.cfx_ctor_with_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_completion_callback_ctor, typeof(CfxApi.cfx_ctor_with_gc_handle_delegate));
            CfxApi.cfx_completion_callback_get_gc_handle = (CfxApi.cfx_get_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_completion_callback_get_gc_handle, typeof(CfxApi.cfx_get_gc_handle_delegate));
            CfxApi.cfx_completion_callback_set_managed_callback = (CfxApi.cfx_set_callback_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_completion_callback_set_managed_callback, typeof(CfxApi.cfx_set_callback_delegate));
        }

        private static bool CfxContextMenuHandlerApiLoaded;
        internal static void LoadCfxContextMenuHandlerApi() {
            if(CfxContextMenuHandlerApiLoaded) return;
            CfxContextMenuHandlerApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_context_menu_handler_ctor = (CfxApi.cfx_ctor_with_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_context_menu_handler_ctor, typeof(CfxApi.cfx_ctor_with_gc_handle_delegate));
            CfxApi.cfx_context_menu_handler_get_gc_handle = (CfxApi.cfx_get_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_context_menu_handler_get_gc_handle, typeof(CfxApi.cfx_get_gc_handle_delegate));
            CfxApi.cfx_context_menu_handler_set_managed_callback = (CfxApi.cfx_set_callback_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_context_menu_handler_set_managed_callback, typeof(CfxApi.cfx_set_callback_delegate));
        }

        private static bool CfxContextMenuParamsApiLoaded;
        internal static void LoadCfxContextMenuParamsApi() {
            if(CfxContextMenuParamsApiLoaded) return;
            CfxContextMenuParamsApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_context_menu_params_get_xcoord = (CfxApi.cfx_context_menu_params_get_xcoord_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_context_menu_params_get_xcoord, typeof(CfxApi.cfx_context_menu_params_get_xcoord_delegate));
            CfxApi.cfx_context_menu_params_get_ycoord = (CfxApi.cfx_context_menu_params_get_ycoord_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_context_menu_params_get_ycoord, typeof(CfxApi.cfx_context_menu_params_get_ycoord_delegate));
            CfxApi.cfx_context_menu_params_get_type_flags = (CfxApi.cfx_context_menu_params_get_type_flags_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_context_menu_params_get_type_flags, typeof(CfxApi.cfx_context_menu_params_get_type_flags_delegate));
            CfxApi.cfx_context_menu_params_get_link_url = (CfxApi.cfx_context_menu_params_get_link_url_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_context_menu_params_get_link_url, typeof(CfxApi.cfx_context_menu_params_get_link_url_delegate));
            CfxApi.cfx_context_menu_params_get_unfiltered_link_url = (CfxApi.cfx_context_menu_params_get_unfiltered_link_url_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_context_menu_params_get_unfiltered_link_url, typeof(CfxApi.cfx_context_menu_params_get_unfiltered_link_url_delegate));
            CfxApi.cfx_context_menu_params_get_source_url = (CfxApi.cfx_context_menu_params_get_source_url_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_context_menu_params_get_source_url, typeof(CfxApi.cfx_context_menu_params_get_source_url_delegate));
            CfxApi.cfx_context_menu_params_has_image_contents = (CfxApi.cfx_context_menu_params_has_image_contents_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_context_menu_params_has_image_contents, typeof(CfxApi.cfx_context_menu_params_has_image_contents_delegate));
            CfxApi.cfx_context_menu_params_get_page_url = (CfxApi.cfx_context_menu_params_get_page_url_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_context_menu_params_get_page_url, typeof(CfxApi.cfx_context_menu_params_get_page_url_delegate));
            CfxApi.cfx_context_menu_params_get_frame_url = (CfxApi.cfx_context_menu_params_get_frame_url_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_context_menu_params_get_frame_url, typeof(CfxApi.cfx_context_menu_params_get_frame_url_delegate));
            CfxApi.cfx_context_menu_params_get_frame_charset = (CfxApi.cfx_context_menu_params_get_frame_charset_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_context_menu_params_get_frame_charset, typeof(CfxApi.cfx_context_menu_params_get_frame_charset_delegate));
            CfxApi.cfx_context_menu_params_get_media_type = (CfxApi.cfx_context_menu_params_get_media_type_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_context_menu_params_get_media_type, typeof(CfxApi.cfx_context_menu_params_get_media_type_delegate));
            CfxApi.cfx_context_menu_params_get_media_state_flags = (CfxApi.cfx_context_menu_params_get_media_state_flags_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_context_menu_params_get_media_state_flags, typeof(CfxApi.cfx_context_menu_params_get_media_state_flags_delegate));
            CfxApi.cfx_context_menu_params_get_selection_text = (CfxApi.cfx_context_menu_params_get_selection_text_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_context_menu_params_get_selection_text, typeof(CfxApi.cfx_context_menu_params_get_selection_text_delegate));
            CfxApi.cfx_context_menu_params_get_misspelled_word = (CfxApi.cfx_context_menu_params_get_misspelled_word_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_context_menu_params_get_misspelled_word, typeof(CfxApi.cfx_context_menu_params_get_misspelled_word_delegate));
            CfxApi.cfx_context_menu_params_get_dictionary_suggestions = (CfxApi.cfx_context_menu_params_get_dictionary_suggestions_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_context_menu_params_get_dictionary_suggestions, typeof(CfxApi.cfx_context_menu_params_get_dictionary_suggestions_delegate));
            CfxApi.cfx_context_menu_params_is_editable = (CfxApi.cfx_context_menu_params_is_editable_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_context_menu_params_is_editable, typeof(CfxApi.cfx_context_menu_params_is_editable_delegate));
            CfxApi.cfx_context_menu_params_is_spell_check_enabled = (CfxApi.cfx_context_menu_params_is_spell_check_enabled_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_context_menu_params_is_spell_check_enabled, typeof(CfxApi.cfx_context_menu_params_is_spell_check_enabled_delegate));
            CfxApi.cfx_context_menu_params_get_edit_state_flags = (CfxApi.cfx_context_menu_params_get_edit_state_flags_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_context_menu_params_get_edit_state_flags, typeof(CfxApi.cfx_context_menu_params_get_edit_state_flags_delegate));
            CfxApi.cfx_context_menu_params_is_custom_menu = (CfxApi.cfx_context_menu_params_is_custom_menu_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_context_menu_params_is_custom_menu, typeof(CfxApi.cfx_context_menu_params_is_custom_menu_delegate));
            CfxApi.cfx_context_menu_params_is_pepper_menu = (CfxApi.cfx_context_menu_params_is_pepper_menu_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_context_menu_params_is_pepper_menu, typeof(CfxApi.cfx_context_menu_params_is_pepper_menu_delegate));
        }

        private static bool CfxCookieApiLoaded;
        internal static void LoadCfxCookieApi() {
            if(CfxCookieApiLoaded) return;
            CfxCookieApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_cookie_ctor = (CfxApi.cfx_ctor_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_cookie_ctor, typeof(CfxApi.cfx_ctor_delegate));
            CfxApi.cfx_cookie_dtor = (CfxApi.cfx_dtor_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_cookie_dtor, typeof(CfxApi.cfx_dtor_delegate));
            CfxApi.cfx_cookie_set_name = (CfxApi.cfx_cookie_set_name_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_cookie_set_name, typeof(CfxApi.cfx_cookie_set_name_delegate));
            CfxApi.cfx_cookie_get_name = (CfxApi.cfx_cookie_get_name_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_cookie_get_name, typeof(CfxApi.cfx_cookie_get_name_delegate));
            CfxApi.cfx_cookie_set_value = (CfxApi.cfx_cookie_set_value_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_cookie_set_value, typeof(CfxApi.cfx_cookie_set_value_delegate));
            CfxApi.cfx_cookie_get_value = (CfxApi.cfx_cookie_get_value_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_cookie_get_value, typeof(CfxApi.cfx_cookie_get_value_delegate));
            CfxApi.cfx_cookie_set_domain = (CfxApi.cfx_cookie_set_domain_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_cookie_set_domain, typeof(CfxApi.cfx_cookie_set_domain_delegate));
            CfxApi.cfx_cookie_get_domain = (CfxApi.cfx_cookie_get_domain_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_cookie_get_domain, typeof(CfxApi.cfx_cookie_get_domain_delegate));
            CfxApi.cfx_cookie_set_path = (CfxApi.cfx_cookie_set_path_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_cookie_set_path, typeof(CfxApi.cfx_cookie_set_path_delegate));
            CfxApi.cfx_cookie_get_path = (CfxApi.cfx_cookie_get_path_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_cookie_get_path, typeof(CfxApi.cfx_cookie_get_path_delegate));
            CfxApi.cfx_cookie_set_secure = (CfxApi.cfx_cookie_set_secure_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_cookie_set_secure, typeof(CfxApi.cfx_cookie_set_secure_delegate));
            CfxApi.cfx_cookie_get_secure = (CfxApi.cfx_cookie_get_secure_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_cookie_get_secure, typeof(CfxApi.cfx_cookie_get_secure_delegate));
            CfxApi.cfx_cookie_set_httponly = (CfxApi.cfx_cookie_set_httponly_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_cookie_set_httponly, typeof(CfxApi.cfx_cookie_set_httponly_delegate));
            CfxApi.cfx_cookie_get_httponly = (CfxApi.cfx_cookie_get_httponly_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_cookie_get_httponly, typeof(CfxApi.cfx_cookie_get_httponly_delegate));
            CfxApi.cfx_cookie_set_creation = (CfxApi.cfx_cookie_set_creation_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_cookie_set_creation, typeof(CfxApi.cfx_cookie_set_creation_delegate));
            CfxApi.cfx_cookie_get_creation = (CfxApi.cfx_cookie_get_creation_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_cookie_get_creation, typeof(CfxApi.cfx_cookie_get_creation_delegate));
            CfxApi.cfx_cookie_set_last_access = (CfxApi.cfx_cookie_set_last_access_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_cookie_set_last_access, typeof(CfxApi.cfx_cookie_set_last_access_delegate));
            CfxApi.cfx_cookie_get_last_access = (CfxApi.cfx_cookie_get_last_access_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_cookie_get_last_access, typeof(CfxApi.cfx_cookie_get_last_access_delegate));
            CfxApi.cfx_cookie_set_has_expires = (CfxApi.cfx_cookie_set_has_expires_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_cookie_set_has_expires, typeof(CfxApi.cfx_cookie_set_has_expires_delegate));
            CfxApi.cfx_cookie_get_has_expires = (CfxApi.cfx_cookie_get_has_expires_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_cookie_get_has_expires, typeof(CfxApi.cfx_cookie_get_has_expires_delegate));
            CfxApi.cfx_cookie_set_expires = (CfxApi.cfx_cookie_set_expires_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_cookie_set_expires, typeof(CfxApi.cfx_cookie_set_expires_delegate));
            CfxApi.cfx_cookie_get_expires = (CfxApi.cfx_cookie_get_expires_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_cookie_get_expires, typeof(CfxApi.cfx_cookie_get_expires_delegate));
        }

        private static bool CfxCookieManagerApiLoaded;
        internal static void LoadCfxCookieManagerApi() {
            if(CfxCookieManagerApiLoaded) return;
            CfxCookieManagerApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_cookie_manager_get_global_manager = (CfxApi.cfx_cookie_manager_get_global_manager_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_cookie_manager_get_global_manager, typeof(CfxApi.cfx_cookie_manager_get_global_manager_delegate));
            CfxApi.cfx_cookie_manager_create_manager = (CfxApi.cfx_cookie_manager_create_manager_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_cookie_manager_create_manager, typeof(CfxApi.cfx_cookie_manager_create_manager_delegate));
            CfxApi.cfx_cookie_manager_set_supported_schemes = (CfxApi.cfx_cookie_manager_set_supported_schemes_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_cookie_manager_set_supported_schemes, typeof(CfxApi.cfx_cookie_manager_set_supported_schemes_delegate));
            CfxApi.cfx_cookie_manager_visit_all_cookies = (CfxApi.cfx_cookie_manager_visit_all_cookies_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_cookie_manager_visit_all_cookies, typeof(CfxApi.cfx_cookie_manager_visit_all_cookies_delegate));
            CfxApi.cfx_cookie_manager_visit_url_cookies = (CfxApi.cfx_cookie_manager_visit_url_cookies_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_cookie_manager_visit_url_cookies, typeof(CfxApi.cfx_cookie_manager_visit_url_cookies_delegate));
            CfxApi.cfx_cookie_manager_set_cookie = (CfxApi.cfx_cookie_manager_set_cookie_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_cookie_manager_set_cookie, typeof(CfxApi.cfx_cookie_manager_set_cookie_delegate));
            CfxApi.cfx_cookie_manager_delete_cookies = (CfxApi.cfx_cookie_manager_delete_cookies_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_cookie_manager_delete_cookies, typeof(CfxApi.cfx_cookie_manager_delete_cookies_delegate));
            CfxApi.cfx_cookie_manager_set_storage_path = (CfxApi.cfx_cookie_manager_set_storage_path_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_cookie_manager_set_storage_path, typeof(CfxApi.cfx_cookie_manager_set_storage_path_delegate));
            CfxApi.cfx_cookie_manager_flush_store = (CfxApi.cfx_cookie_manager_flush_store_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_cookie_manager_flush_store, typeof(CfxApi.cfx_cookie_manager_flush_store_delegate));
        }

        private static bool CfxCookieVisitorApiLoaded;
        internal static void LoadCfxCookieVisitorApi() {
            if(CfxCookieVisitorApiLoaded) return;
            CfxCookieVisitorApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_cookie_visitor_ctor = (CfxApi.cfx_ctor_with_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_cookie_visitor_ctor, typeof(CfxApi.cfx_ctor_with_gc_handle_delegate));
            CfxApi.cfx_cookie_visitor_get_gc_handle = (CfxApi.cfx_get_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_cookie_visitor_get_gc_handle, typeof(CfxApi.cfx_get_gc_handle_delegate));
            CfxApi.cfx_cookie_visitor_set_managed_callback = (CfxApi.cfx_set_callback_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_cookie_visitor_set_managed_callback, typeof(CfxApi.cfx_set_callback_delegate));
        }

        private static bool CfxCursorInfoApiLoaded;
        internal static void LoadCfxCursorInfoApi() {
            if(CfxCursorInfoApiLoaded) return;
            CfxCursorInfoApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_cursor_info_ctor = (CfxApi.cfx_ctor_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_cursor_info_ctor, typeof(CfxApi.cfx_ctor_delegate));
            CfxApi.cfx_cursor_info_dtor = (CfxApi.cfx_dtor_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_cursor_info_dtor, typeof(CfxApi.cfx_dtor_delegate));
            CfxApi.cfx_cursor_info_set_hotspot = (CfxApi.cfx_cursor_info_set_hotspot_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_cursor_info_set_hotspot, typeof(CfxApi.cfx_cursor_info_set_hotspot_delegate));
            CfxApi.cfx_cursor_info_get_hotspot = (CfxApi.cfx_cursor_info_get_hotspot_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_cursor_info_get_hotspot, typeof(CfxApi.cfx_cursor_info_get_hotspot_delegate));
            CfxApi.cfx_cursor_info_set_image_scale_factor = (CfxApi.cfx_cursor_info_set_image_scale_factor_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_cursor_info_set_image_scale_factor, typeof(CfxApi.cfx_cursor_info_set_image_scale_factor_delegate));
            CfxApi.cfx_cursor_info_get_image_scale_factor = (CfxApi.cfx_cursor_info_get_image_scale_factor_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_cursor_info_get_image_scale_factor, typeof(CfxApi.cfx_cursor_info_get_image_scale_factor_delegate));
            CfxApi.cfx_cursor_info_set_buffer = (CfxApi.cfx_cursor_info_set_buffer_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_cursor_info_set_buffer, typeof(CfxApi.cfx_cursor_info_set_buffer_delegate));
            CfxApi.cfx_cursor_info_get_buffer = (CfxApi.cfx_cursor_info_get_buffer_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_cursor_info_get_buffer, typeof(CfxApi.cfx_cursor_info_get_buffer_delegate));
        }

        private static bool CfxDeleteCookiesCallbackApiLoaded;
        internal static void LoadCfxDeleteCookiesCallbackApi() {
            if(CfxDeleteCookiesCallbackApiLoaded) return;
            CfxDeleteCookiesCallbackApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_delete_cookies_callback_ctor = (CfxApi.cfx_ctor_with_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_delete_cookies_callback_ctor, typeof(CfxApi.cfx_ctor_with_gc_handle_delegate));
            CfxApi.cfx_delete_cookies_callback_get_gc_handle = (CfxApi.cfx_get_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_delete_cookies_callback_get_gc_handle, typeof(CfxApi.cfx_get_gc_handle_delegate));
            CfxApi.cfx_delete_cookies_callback_set_managed_callback = (CfxApi.cfx_set_callback_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_delete_cookies_callback_set_managed_callback, typeof(CfxApi.cfx_set_callback_delegate));
        }

        private static bool CfxDialogHandlerApiLoaded;
        internal static void LoadCfxDialogHandlerApi() {
            if(CfxDialogHandlerApiLoaded) return;
            CfxDialogHandlerApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_dialog_handler_ctor = (CfxApi.cfx_ctor_with_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_dialog_handler_ctor, typeof(CfxApi.cfx_ctor_with_gc_handle_delegate));
            CfxApi.cfx_dialog_handler_get_gc_handle = (CfxApi.cfx_get_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_dialog_handler_get_gc_handle, typeof(CfxApi.cfx_get_gc_handle_delegate));
            CfxApi.cfx_dialog_handler_set_managed_callback = (CfxApi.cfx_set_callback_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_dialog_handler_set_managed_callback, typeof(CfxApi.cfx_set_callback_delegate));
        }

        private static bool CfxDictionaryValueApiLoaded;
        internal static void LoadCfxDictionaryValueApi() {
            if(CfxDictionaryValueApiLoaded) return;
            CfxDictionaryValueApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_dictionary_value_create = (CfxApi.cfx_dictionary_value_create_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_dictionary_value_create, typeof(CfxApi.cfx_dictionary_value_create_delegate));
            CfxApi.cfx_dictionary_value_is_valid = (CfxApi.cfx_dictionary_value_is_valid_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_dictionary_value_is_valid, typeof(CfxApi.cfx_dictionary_value_is_valid_delegate));
            CfxApi.cfx_dictionary_value_is_owned = (CfxApi.cfx_dictionary_value_is_owned_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_dictionary_value_is_owned, typeof(CfxApi.cfx_dictionary_value_is_owned_delegate));
            CfxApi.cfx_dictionary_value_is_read_only = (CfxApi.cfx_dictionary_value_is_read_only_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_dictionary_value_is_read_only, typeof(CfxApi.cfx_dictionary_value_is_read_only_delegate));
            CfxApi.cfx_dictionary_value_is_same = (CfxApi.cfx_dictionary_value_is_same_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_dictionary_value_is_same, typeof(CfxApi.cfx_dictionary_value_is_same_delegate));
            CfxApi.cfx_dictionary_value_is_equal = (CfxApi.cfx_dictionary_value_is_equal_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_dictionary_value_is_equal, typeof(CfxApi.cfx_dictionary_value_is_equal_delegate));
            CfxApi.cfx_dictionary_value_copy = (CfxApi.cfx_dictionary_value_copy_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_dictionary_value_copy, typeof(CfxApi.cfx_dictionary_value_copy_delegate));
            CfxApi.cfx_dictionary_value_get_size = (CfxApi.cfx_dictionary_value_get_size_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_dictionary_value_get_size, typeof(CfxApi.cfx_dictionary_value_get_size_delegate));
            CfxApi.cfx_dictionary_value_clear = (CfxApi.cfx_dictionary_value_clear_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_dictionary_value_clear, typeof(CfxApi.cfx_dictionary_value_clear_delegate));
            CfxApi.cfx_dictionary_value_has_key = (CfxApi.cfx_dictionary_value_has_key_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_dictionary_value_has_key, typeof(CfxApi.cfx_dictionary_value_has_key_delegate));
            CfxApi.cfx_dictionary_value_get_keys = (CfxApi.cfx_dictionary_value_get_keys_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_dictionary_value_get_keys, typeof(CfxApi.cfx_dictionary_value_get_keys_delegate));
            CfxApi.cfx_dictionary_value_remove = (CfxApi.cfx_dictionary_value_remove_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_dictionary_value_remove, typeof(CfxApi.cfx_dictionary_value_remove_delegate));
            CfxApi.cfx_dictionary_value_get_type = (CfxApi.cfx_dictionary_value_get_type_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_dictionary_value_get_type, typeof(CfxApi.cfx_dictionary_value_get_type_delegate));
            CfxApi.cfx_dictionary_value_get_value = (CfxApi.cfx_dictionary_value_get_value_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_dictionary_value_get_value, typeof(CfxApi.cfx_dictionary_value_get_value_delegate));
            CfxApi.cfx_dictionary_value_get_bool = (CfxApi.cfx_dictionary_value_get_bool_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_dictionary_value_get_bool, typeof(CfxApi.cfx_dictionary_value_get_bool_delegate));
            CfxApi.cfx_dictionary_value_get_int = (CfxApi.cfx_dictionary_value_get_int_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_dictionary_value_get_int, typeof(CfxApi.cfx_dictionary_value_get_int_delegate));
            CfxApi.cfx_dictionary_value_get_double = (CfxApi.cfx_dictionary_value_get_double_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_dictionary_value_get_double, typeof(CfxApi.cfx_dictionary_value_get_double_delegate));
            CfxApi.cfx_dictionary_value_get_string = (CfxApi.cfx_dictionary_value_get_string_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_dictionary_value_get_string, typeof(CfxApi.cfx_dictionary_value_get_string_delegate));
            CfxApi.cfx_dictionary_value_get_binary = (CfxApi.cfx_dictionary_value_get_binary_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_dictionary_value_get_binary, typeof(CfxApi.cfx_dictionary_value_get_binary_delegate));
            CfxApi.cfx_dictionary_value_get_dictionary = (CfxApi.cfx_dictionary_value_get_dictionary_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_dictionary_value_get_dictionary, typeof(CfxApi.cfx_dictionary_value_get_dictionary_delegate));
            CfxApi.cfx_dictionary_value_get_list = (CfxApi.cfx_dictionary_value_get_list_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_dictionary_value_get_list, typeof(CfxApi.cfx_dictionary_value_get_list_delegate));
            CfxApi.cfx_dictionary_value_set_value = (CfxApi.cfx_dictionary_value_set_value_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_dictionary_value_set_value, typeof(CfxApi.cfx_dictionary_value_set_value_delegate));
            CfxApi.cfx_dictionary_value_set_null = (CfxApi.cfx_dictionary_value_set_null_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_dictionary_value_set_null, typeof(CfxApi.cfx_dictionary_value_set_null_delegate));
            CfxApi.cfx_dictionary_value_set_bool = (CfxApi.cfx_dictionary_value_set_bool_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_dictionary_value_set_bool, typeof(CfxApi.cfx_dictionary_value_set_bool_delegate));
            CfxApi.cfx_dictionary_value_set_int = (CfxApi.cfx_dictionary_value_set_int_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_dictionary_value_set_int, typeof(CfxApi.cfx_dictionary_value_set_int_delegate));
            CfxApi.cfx_dictionary_value_set_double = (CfxApi.cfx_dictionary_value_set_double_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_dictionary_value_set_double, typeof(CfxApi.cfx_dictionary_value_set_double_delegate));
            CfxApi.cfx_dictionary_value_set_string = (CfxApi.cfx_dictionary_value_set_string_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_dictionary_value_set_string, typeof(CfxApi.cfx_dictionary_value_set_string_delegate));
            CfxApi.cfx_dictionary_value_set_binary = (CfxApi.cfx_dictionary_value_set_binary_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_dictionary_value_set_binary, typeof(CfxApi.cfx_dictionary_value_set_binary_delegate));
            CfxApi.cfx_dictionary_value_set_dictionary = (CfxApi.cfx_dictionary_value_set_dictionary_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_dictionary_value_set_dictionary, typeof(CfxApi.cfx_dictionary_value_set_dictionary_delegate));
            CfxApi.cfx_dictionary_value_set_list = (CfxApi.cfx_dictionary_value_set_list_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_dictionary_value_set_list, typeof(CfxApi.cfx_dictionary_value_set_list_delegate));
        }

        private static bool CfxDisplayHandlerApiLoaded;
        internal static void LoadCfxDisplayHandlerApi() {
            if(CfxDisplayHandlerApiLoaded) return;
            CfxDisplayHandlerApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_display_handler_ctor = (CfxApi.cfx_ctor_with_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_display_handler_ctor, typeof(CfxApi.cfx_ctor_with_gc_handle_delegate));
            CfxApi.cfx_display_handler_get_gc_handle = (CfxApi.cfx_get_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_display_handler_get_gc_handle, typeof(CfxApi.cfx_get_gc_handle_delegate));
            CfxApi.cfx_display_handler_set_managed_callback = (CfxApi.cfx_set_callback_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_display_handler_set_managed_callback, typeof(CfxApi.cfx_set_callback_delegate));
        }

        private static bool CfxDomDocumentApiLoaded;
        internal static void LoadCfxDomDocumentApi() {
            if(CfxDomDocumentApiLoaded) return;
            CfxDomDocumentApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_domdocument_get_type = (CfxApi.cfx_domdocument_get_type_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_domdocument_get_type, typeof(CfxApi.cfx_domdocument_get_type_delegate));
            CfxApi.cfx_domdocument_get_document = (CfxApi.cfx_domdocument_get_document_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_domdocument_get_document, typeof(CfxApi.cfx_domdocument_get_document_delegate));
            CfxApi.cfx_domdocument_get_body = (CfxApi.cfx_domdocument_get_body_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_domdocument_get_body, typeof(CfxApi.cfx_domdocument_get_body_delegate));
            CfxApi.cfx_domdocument_get_head = (CfxApi.cfx_domdocument_get_head_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_domdocument_get_head, typeof(CfxApi.cfx_domdocument_get_head_delegate));
            CfxApi.cfx_domdocument_get_title = (CfxApi.cfx_domdocument_get_title_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_domdocument_get_title, typeof(CfxApi.cfx_domdocument_get_title_delegate));
            CfxApi.cfx_domdocument_get_element_by_id = (CfxApi.cfx_domdocument_get_element_by_id_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_domdocument_get_element_by_id, typeof(CfxApi.cfx_domdocument_get_element_by_id_delegate));
            CfxApi.cfx_domdocument_get_focused_node = (CfxApi.cfx_domdocument_get_focused_node_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_domdocument_get_focused_node, typeof(CfxApi.cfx_domdocument_get_focused_node_delegate));
            CfxApi.cfx_domdocument_has_selection = (CfxApi.cfx_domdocument_has_selection_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_domdocument_has_selection, typeof(CfxApi.cfx_domdocument_has_selection_delegate));
            CfxApi.cfx_domdocument_get_selection_start_offset = (CfxApi.cfx_domdocument_get_selection_start_offset_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_domdocument_get_selection_start_offset, typeof(CfxApi.cfx_domdocument_get_selection_start_offset_delegate));
            CfxApi.cfx_domdocument_get_selection_end_offset = (CfxApi.cfx_domdocument_get_selection_end_offset_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_domdocument_get_selection_end_offset, typeof(CfxApi.cfx_domdocument_get_selection_end_offset_delegate));
            CfxApi.cfx_domdocument_get_selection_as_markup = (CfxApi.cfx_domdocument_get_selection_as_markup_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_domdocument_get_selection_as_markup, typeof(CfxApi.cfx_domdocument_get_selection_as_markup_delegate));
            CfxApi.cfx_domdocument_get_selection_as_text = (CfxApi.cfx_domdocument_get_selection_as_text_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_domdocument_get_selection_as_text, typeof(CfxApi.cfx_domdocument_get_selection_as_text_delegate));
            CfxApi.cfx_domdocument_get_base_url = (CfxApi.cfx_domdocument_get_base_url_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_domdocument_get_base_url, typeof(CfxApi.cfx_domdocument_get_base_url_delegate));
            CfxApi.cfx_domdocument_get_complete_url = (CfxApi.cfx_domdocument_get_complete_url_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_domdocument_get_complete_url, typeof(CfxApi.cfx_domdocument_get_complete_url_delegate));
        }

        private static bool CfxDomNodeApiLoaded;
        internal static void LoadCfxDomNodeApi() {
            if(CfxDomNodeApiLoaded) return;
            CfxDomNodeApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_domnode_get_type = (CfxApi.cfx_domnode_get_type_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_domnode_get_type, typeof(CfxApi.cfx_domnode_get_type_delegate));
            CfxApi.cfx_domnode_is_text = (CfxApi.cfx_domnode_is_text_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_domnode_is_text, typeof(CfxApi.cfx_domnode_is_text_delegate));
            CfxApi.cfx_domnode_is_element = (CfxApi.cfx_domnode_is_element_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_domnode_is_element, typeof(CfxApi.cfx_domnode_is_element_delegate));
            CfxApi.cfx_domnode_is_editable = (CfxApi.cfx_domnode_is_editable_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_domnode_is_editable, typeof(CfxApi.cfx_domnode_is_editable_delegate));
            CfxApi.cfx_domnode_is_form_control_element = (CfxApi.cfx_domnode_is_form_control_element_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_domnode_is_form_control_element, typeof(CfxApi.cfx_domnode_is_form_control_element_delegate));
            CfxApi.cfx_domnode_get_form_control_element_type = (CfxApi.cfx_domnode_get_form_control_element_type_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_domnode_get_form_control_element_type, typeof(CfxApi.cfx_domnode_get_form_control_element_type_delegate));
            CfxApi.cfx_domnode_is_same = (CfxApi.cfx_domnode_is_same_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_domnode_is_same, typeof(CfxApi.cfx_domnode_is_same_delegate));
            CfxApi.cfx_domnode_get_name = (CfxApi.cfx_domnode_get_name_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_domnode_get_name, typeof(CfxApi.cfx_domnode_get_name_delegate));
            CfxApi.cfx_domnode_get_value = (CfxApi.cfx_domnode_get_value_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_domnode_get_value, typeof(CfxApi.cfx_domnode_get_value_delegate));
            CfxApi.cfx_domnode_set_value = (CfxApi.cfx_domnode_set_value_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_domnode_set_value, typeof(CfxApi.cfx_domnode_set_value_delegate));
            CfxApi.cfx_domnode_get_as_markup = (CfxApi.cfx_domnode_get_as_markup_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_domnode_get_as_markup, typeof(CfxApi.cfx_domnode_get_as_markup_delegate));
            CfxApi.cfx_domnode_get_document = (CfxApi.cfx_domnode_get_document_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_domnode_get_document, typeof(CfxApi.cfx_domnode_get_document_delegate));
            CfxApi.cfx_domnode_get_parent = (CfxApi.cfx_domnode_get_parent_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_domnode_get_parent, typeof(CfxApi.cfx_domnode_get_parent_delegate));
            CfxApi.cfx_domnode_get_previous_sibling = (CfxApi.cfx_domnode_get_previous_sibling_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_domnode_get_previous_sibling, typeof(CfxApi.cfx_domnode_get_previous_sibling_delegate));
            CfxApi.cfx_domnode_get_next_sibling = (CfxApi.cfx_domnode_get_next_sibling_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_domnode_get_next_sibling, typeof(CfxApi.cfx_domnode_get_next_sibling_delegate));
            CfxApi.cfx_domnode_has_children = (CfxApi.cfx_domnode_has_children_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_domnode_has_children, typeof(CfxApi.cfx_domnode_has_children_delegate));
            CfxApi.cfx_domnode_get_first_child = (CfxApi.cfx_domnode_get_first_child_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_domnode_get_first_child, typeof(CfxApi.cfx_domnode_get_first_child_delegate));
            CfxApi.cfx_domnode_get_last_child = (CfxApi.cfx_domnode_get_last_child_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_domnode_get_last_child, typeof(CfxApi.cfx_domnode_get_last_child_delegate));
            CfxApi.cfx_domnode_get_element_tag_name = (CfxApi.cfx_domnode_get_element_tag_name_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_domnode_get_element_tag_name, typeof(CfxApi.cfx_domnode_get_element_tag_name_delegate));
            CfxApi.cfx_domnode_has_element_attributes = (CfxApi.cfx_domnode_has_element_attributes_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_domnode_has_element_attributes, typeof(CfxApi.cfx_domnode_has_element_attributes_delegate));
            CfxApi.cfx_domnode_has_element_attribute = (CfxApi.cfx_domnode_has_element_attribute_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_domnode_has_element_attribute, typeof(CfxApi.cfx_domnode_has_element_attribute_delegate));
            CfxApi.cfx_domnode_get_element_attribute = (CfxApi.cfx_domnode_get_element_attribute_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_domnode_get_element_attribute, typeof(CfxApi.cfx_domnode_get_element_attribute_delegate));
            CfxApi.cfx_domnode_get_element_attributes = (CfxApi.cfx_domnode_get_element_attributes_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_domnode_get_element_attributes, typeof(CfxApi.cfx_domnode_get_element_attributes_delegate));
            CfxApi.cfx_domnode_set_element_attribute = (CfxApi.cfx_domnode_set_element_attribute_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_domnode_set_element_attribute, typeof(CfxApi.cfx_domnode_set_element_attribute_delegate));
            CfxApi.cfx_domnode_get_element_inner_text = (CfxApi.cfx_domnode_get_element_inner_text_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_domnode_get_element_inner_text, typeof(CfxApi.cfx_domnode_get_element_inner_text_delegate));
        }

        private static bool CfxDomVisitorApiLoaded;
        internal static void LoadCfxDomVisitorApi() {
            if(CfxDomVisitorApiLoaded) return;
            CfxDomVisitorApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_domvisitor_ctor = (CfxApi.cfx_ctor_with_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_domvisitor_ctor, typeof(CfxApi.cfx_ctor_with_gc_handle_delegate));
            CfxApi.cfx_domvisitor_get_gc_handle = (CfxApi.cfx_get_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_domvisitor_get_gc_handle, typeof(CfxApi.cfx_get_gc_handle_delegate));
            CfxApi.cfx_domvisitor_set_managed_callback = (CfxApi.cfx_set_callback_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_domvisitor_set_managed_callback, typeof(CfxApi.cfx_set_callback_delegate));
        }

        private static bool CfxDownloadHandlerApiLoaded;
        internal static void LoadCfxDownloadHandlerApi() {
            if(CfxDownloadHandlerApiLoaded) return;
            CfxDownloadHandlerApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_download_handler_ctor = (CfxApi.cfx_ctor_with_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_download_handler_ctor, typeof(CfxApi.cfx_ctor_with_gc_handle_delegate));
            CfxApi.cfx_download_handler_get_gc_handle = (CfxApi.cfx_get_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_download_handler_get_gc_handle, typeof(CfxApi.cfx_get_gc_handle_delegate));
            CfxApi.cfx_download_handler_set_managed_callback = (CfxApi.cfx_set_callback_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_download_handler_set_managed_callback, typeof(CfxApi.cfx_set_callback_delegate));
        }

        private static bool CfxDownloadItemApiLoaded;
        internal static void LoadCfxDownloadItemApi() {
            if(CfxDownloadItemApiLoaded) return;
            CfxDownloadItemApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_download_item_is_valid = (CfxApi.cfx_download_item_is_valid_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_download_item_is_valid, typeof(CfxApi.cfx_download_item_is_valid_delegate));
            CfxApi.cfx_download_item_is_in_progress = (CfxApi.cfx_download_item_is_in_progress_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_download_item_is_in_progress, typeof(CfxApi.cfx_download_item_is_in_progress_delegate));
            CfxApi.cfx_download_item_is_complete = (CfxApi.cfx_download_item_is_complete_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_download_item_is_complete, typeof(CfxApi.cfx_download_item_is_complete_delegate));
            CfxApi.cfx_download_item_is_canceled = (CfxApi.cfx_download_item_is_canceled_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_download_item_is_canceled, typeof(CfxApi.cfx_download_item_is_canceled_delegate));
            CfxApi.cfx_download_item_get_current_speed = (CfxApi.cfx_download_item_get_current_speed_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_download_item_get_current_speed, typeof(CfxApi.cfx_download_item_get_current_speed_delegate));
            CfxApi.cfx_download_item_get_percent_complete = (CfxApi.cfx_download_item_get_percent_complete_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_download_item_get_percent_complete, typeof(CfxApi.cfx_download_item_get_percent_complete_delegate));
            CfxApi.cfx_download_item_get_total_bytes = (CfxApi.cfx_download_item_get_total_bytes_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_download_item_get_total_bytes, typeof(CfxApi.cfx_download_item_get_total_bytes_delegate));
            CfxApi.cfx_download_item_get_received_bytes = (CfxApi.cfx_download_item_get_received_bytes_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_download_item_get_received_bytes, typeof(CfxApi.cfx_download_item_get_received_bytes_delegate));
            CfxApi.cfx_download_item_get_start_time = (CfxApi.cfx_download_item_get_start_time_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_download_item_get_start_time, typeof(CfxApi.cfx_download_item_get_start_time_delegate));
            CfxApi.cfx_download_item_get_end_time = (CfxApi.cfx_download_item_get_end_time_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_download_item_get_end_time, typeof(CfxApi.cfx_download_item_get_end_time_delegate));
            CfxApi.cfx_download_item_get_full_path = (CfxApi.cfx_download_item_get_full_path_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_download_item_get_full_path, typeof(CfxApi.cfx_download_item_get_full_path_delegate));
            CfxApi.cfx_download_item_get_id = (CfxApi.cfx_download_item_get_id_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_download_item_get_id, typeof(CfxApi.cfx_download_item_get_id_delegate));
            CfxApi.cfx_download_item_get_url = (CfxApi.cfx_download_item_get_url_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_download_item_get_url, typeof(CfxApi.cfx_download_item_get_url_delegate));
            CfxApi.cfx_download_item_get_original_url = (CfxApi.cfx_download_item_get_original_url_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_download_item_get_original_url, typeof(CfxApi.cfx_download_item_get_original_url_delegate));
            CfxApi.cfx_download_item_get_suggested_file_name = (CfxApi.cfx_download_item_get_suggested_file_name_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_download_item_get_suggested_file_name, typeof(CfxApi.cfx_download_item_get_suggested_file_name_delegate));
            CfxApi.cfx_download_item_get_content_disposition = (CfxApi.cfx_download_item_get_content_disposition_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_download_item_get_content_disposition, typeof(CfxApi.cfx_download_item_get_content_disposition_delegate));
            CfxApi.cfx_download_item_get_mime_type = (CfxApi.cfx_download_item_get_mime_type_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_download_item_get_mime_type, typeof(CfxApi.cfx_download_item_get_mime_type_delegate));
        }

        private static bool CfxDownloadItemCallbackApiLoaded;
        internal static void LoadCfxDownloadItemCallbackApi() {
            if(CfxDownloadItemCallbackApiLoaded) return;
            CfxDownloadItemCallbackApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_download_item_callback_cancel = (CfxApi.cfx_download_item_callback_cancel_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_download_item_callback_cancel, typeof(CfxApi.cfx_download_item_callback_cancel_delegate));
            CfxApi.cfx_download_item_callback_pause = (CfxApi.cfx_download_item_callback_pause_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_download_item_callback_pause, typeof(CfxApi.cfx_download_item_callback_pause_delegate));
            CfxApi.cfx_download_item_callback_resume = (CfxApi.cfx_download_item_callback_resume_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_download_item_callback_resume, typeof(CfxApi.cfx_download_item_callback_resume_delegate));
        }

        private static bool CfxDragDataApiLoaded;
        internal static void LoadCfxDragDataApi() {
            if(CfxDragDataApiLoaded) return;
            CfxDragDataApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_drag_data_create = (CfxApi.cfx_drag_data_create_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_drag_data_create, typeof(CfxApi.cfx_drag_data_create_delegate));
            CfxApi.cfx_drag_data_clone = (CfxApi.cfx_drag_data_clone_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_drag_data_clone, typeof(CfxApi.cfx_drag_data_clone_delegate));
            CfxApi.cfx_drag_data_is_read_only = (CfxApi.cfx_drag_data_is_read_only_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_drag_data_is_read_only, typeof(CfxApi.cfx_drag_data_is_read_only_delegate));
            CfxApi.cfx_drag_data_is_link = (CfxApi.cfx_drag_data_is_link_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_drag_data_is_link, typeof(CfxApi.cfx_drag_data_is_link_delegate));
            CfxApi.cfx_drag_data_is_fragment = (CfxApi.cfx_drag_data_is_fragment_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_drag_data_is_fragment, typeof(CfxApi.cfx_drag_data_is_fragment_delegate));
            CfxApi.cfx_drag_data_is_file = (CfxApi.cfx_drag_data_is_file_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_drag_data_is_file, typeof(CfxApi.cfx_drag_data_is_file_delegate));
            CfxApi.cfx_drag_data_get_link_url = (CfxApi.cfx_drag_data_get_link_url_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_drag_data_get_link_url, typeof(CfxApi.cfx_drag_data_get_link_url_delegate));
            CfxApi.cfx_drag_data_get_link_title = (CfxApi.cfx_drag_data_get_link_title_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_drag_data_get_link_title, typeof(CfxApi.cfx_drag_data_get_link_title_delegate));
            CfxApi.cfx_drag_data_get_link_metadata = (CfxApi.cfx_drag_data_get_link_metadata_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_drag_data_get_link_metadata, typeof(CfxApi.cfx_drag_data_get_link_metadata_delegate));
            CfxApi.cfx_drag_data_get_fragment_text = (CfxApi.cfx_drag_data_get_fragment_text_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_drag_data_get_fragment_text, typeof(CfxApi.cfx_drag_data_get_fragment_text_delegate));
            CfxApi.cfx_drag_data_get_fragment_html = (CfxApi.cfx_drag_data_get_fragment_html_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_drag_data_get_fragment_html, typeof(CfxApi.cfx_drag_data_get_fragment_html_delegate));
            CfxApi.cfx_drag_data_get_fragment_base_url = (CfxApi.cfx_drag_data_get_fragment_base_url_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_drag_data_get_fragment_base_url, typeof(CfxApi.cfx_drag_data_get_fragment_base_url_delegate));
            CfxApi.cfx_drag_data_get_file_name = (CfxApi.cfx_drag_data_get_file_name_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_drag_data_get_file_name, typeof(CfxApi.cfx_drag_data_get_file_name_delegate));
            CfxApi.cfx_drag_data_get_file_contents = (CfxApi.cfx_drag_data_get_file_contents_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_drag_data_get_file_contents, typeof(CfxApi.cfx_drag_data_get_file_contents_delegate));
            CfxApi.cfx_drag_data_get_file_names = (CfxApi.cfx_drag_data_get_file_names_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_drag_data_get_file_names, typeof(CfxApi.cfx_drag_data_get_file_names_delegate));
            CfxApi.cfx_drag_data_set_link_url = (CfxApi.cfx_drag_data_set_link_url_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_drag_data_set_link_url, typeof(CfxApi.cfx_drag_data_set_link_url_delegate));
            CfxApi.cfx_drag_data_set_link_title = (CfxApi.cfx_drag_data_set_link_title_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_drag_data_set_link_title, typeof(CfxApi.cfx_drag_data_set_link_title_delegate));
            CfxApi.cfx_drag_data_set_link_metadata = (CfxApi.cfx_drag_data_set_link_metadata_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_drag_data_set_link_metadata, typeof(CfxApi.cfx_drag_data_set_link_metadata_delegate));
            CfxApi.cfx_drag_data_set_fragment_text = (CfxApi.cfx_drag_data_set_fragment_text_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_drag_data_set_fragment_text, typeof(CfxApi.cfx_drag_data_set_fragment_text_delegate));
            CfxApi.cfx_drag_data_set_fragment_html = (CfxApi.cfx_drag_data_set_fragment_html_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_drag_data_set_fragment_html, typeof(CfxApi.cfx_drag_data_set_fragment_html_delegate));
            CfxApi.cfx_drag_data_set_fragment_base_url = (CfxApi.cfx_drag_data_set_fragment_base_url_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_drag_data_set_fragment_base_url, typeof(CfxApi.cfx_drag_data_set_fragment_base_url_delegate));
            CfxApi.cfx_drag_data_reset_file_contents = (CfxApi.cfx_drag_data_reset_file_contents_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_drag_data_reset_file_contents, typeof(CfxApi.cfx_drag_data_reset_file_contents_delegate));
            CfxApi.cfx_drag_data_add_file = (CfxApi.cfx_drag_data_add_file_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_drag_data_add_file, typeof(CfxApi.cfx_drag_data_add_file_delegate));
        }

        private static bool CfxDragHandlerApiLoaded;
        internal static void LoadCfxDragHandlerApi() {
            if(CfxDragHandlerApiLoaded) return;
            CfxDragHandlerApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_drag_handler_ctor = (CfxApi.cfx_ctor_with_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_drag_handler_ctor, typeof(CfxApi.cfx_ctor_with_gc_handle_delegate));
            CfxApi.cfx_drag_handler_get_gc_handle = (CfxApi.cfx_get_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_drag_handler_get_gc_handle, typeof(CfxApi.cfx_get_gc_handle_delegate));
            CfxApi.cfx_drag_handler_set_managed_callback = (CfxApi.cfx_set_callback_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_drag_handler_set_managed_callback, typeof(CfxApi.cfx_set_callback_delegate));
        }

        private static bool CfxDraggableRegionApiLoaded;
        internal static void LoadCfxDraggableRegionApi() {
            if(CfxDraggableRegionApiLoaded) return;
            CfxDraggableRegionApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_draggable_region_ctor = (CfxApi.cfx_ctor_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_draggable_region_ctor, typeof(CfxApi.cfx_ctor_delegate));
            CfxApi.cfx_draggable_region_dtor = (CfxApi.cfx_dtor_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_draggable_region_dtor, typeof(CfxApi.cfx_dtor_delegate));
            CfxApi.cfx_draggable_region_set_bounds = (CfxApi.cfx_draggable_region_set_bounds_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_draggable_region_set_bounds, typeof(CfxApi.cfx_draggable_region_set_bounds_delegate));
            CfxApi.cfx_draggable_region_get_bounds = (CfxApi.cfx_draggable_region_get_bounds_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_draggable_region_get_bounds, typeof(CfxApi.cfx_draggable_region_get_bounds_delegate));
            CfxApi.cfx_draggable_region_set_draggable = (CfxApi.cfx_draggable_region_set_draggable_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_draggable_region_set_draggable, typeof(CfxApi.cfx_draggable_region_set_draggable_delegate));
            CfxApi.cfx_draggable_region_get_draggable = (CfxApi.cfx_draggable_region_get_draggable_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_draggable_region_get_draggable, typeof(CfxApi.cfx_draggable_region_get_draggable_delegate));
        }

        private static bool CfxEndTracingCallbackApiLoaded;
        internal static void LoadCfxEndTracingCallbackApi() {
            if(CfxEndTracingCallbackApiLoaded) return;
            CfxEndTracingCallbackApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_end_tracing_callback_ctor = (CfxApi.cfx_ctor_with_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_end_tracing_callback_ctor, typeof(CfxApi.cfx_ctor_with_gc_handle_delegate));
            CfxApi.cfx_end_tracing_callback_get_gc_handle = (CfxApi.cfx_get_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_end_tracing_callback_get_gc_handle, typeof(CfxApi.cfx_get_gc_handle_delegate));
            CfxApi.cfx_end_tracing_callback_set_managed_callback = (CfxApi.cfx_set_callback_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_end_tracing_callback_set_managed_callback, typeof(CfxApi.cfx_set_callback_delegate));
        }

        private static bool CfxFileDialogCallbackApiLoaded;
        internal static void LoadCfxFileDialogCallbackApi() {
            if(CfxFileDialogCallbackApiLoaded) return;
            CfxFileDialogCallbackApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_file_dialog_callback_cont = (CfxApi.cfx_file_dialog_callback_cont_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_file_dialog_callback_cont, typeof(CfxApi.cfx_file_dialog_callback_cont_delegate));
            CfxApi.cfx_file_dialog_callback_cancel = (CfxApi.cfx_file_dialog_callback_cancel_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_file_dialog_callback_cancel, typeof(CfxApi.cfx_file_dialog_callback_cancel_delegate));
        }

        private static bool CfxFindHandlerApiLoaded;
        internal static void LoadCfxFindHandlerApi() {
            if(CfxFindHandlerApiLoaded) return;
            CfxFindHandlerApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_find_handler_ctor = (CfxApi.cfx_ctor_with_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_find_handler_ctor, typeof(CfxApi.cfx_ctor_with_gc_handle_delegate));
            CfxApi.cfx_find_handler_get_gc_handle = (CfxApi.cfx_get_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_find_handler_get_gc_handle, typeof(CfxApi.cfx_get_gc_handle_delegate));
            CfxApi.cfx_find_handler_set_managed_callback = (CfxApi.cfx_set_callback_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_find_handler_set_managed_callback, typeof(CfxApi.cfx_set_callback_delegate));
        }

        private static bool CfxFocusHandlerApiLoaded;
        internal static void LoadCfxFocusHandlerApi() {
            if(CfxFocusHandlerApiLoaded) return;
            CfxFocusHandlerApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_focus_handler_ctor = (CfxApi.cfx_ctor_with_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_focus_handler_ctor, typeof(CfxApi.cfx_ctor_with_gc_handle_delegate));
            CfxApi.cfx_focus_handler_get_gc_handle = (CfxApi.cfx_get_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_focus_handler_get_gc_handle, typeof(CfxApi.cfx_get_gc_handle_delegate));
            CfxApi.cfx_focus_handler_set_managed_callback = (CfxApi.cfx_set_callback_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_focus_handler_set_managed_callback, typeof(CfxApi.cfx_set_callback_delegate));
        }

        private static bool CfxFrameApiLoaded;
        internal static void LoadCfxFrameApi() {
            if(CfxFrameApiLoaded) return;
            CfxFrameApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_frame_is_valid = (CfxApi.cfx_frame_is_valid_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_frame_is_valid, typeof(CfxApi.cfx_frame_is_valid_delegate));
            CfxApi.cfx_frame_undo = (CfxApi.cfx_frame_undo_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_frame_undo, typeof(CfxApi.cfx_frame_undo_delegate));
            CfxApi.cfx_frame_redo = (CfxApi.cfx_frame_redo_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_frame_redo, typeof(CfxApi.cfx_frame_redo_delegate));
            CfxApi.cfx_frame_cut = (CfxApi.cfx_frame_cut_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_frame_cut, typeof(CfxApi.cfx_frame_cut_delegate));
            CfxApi.cfx_frame_copy = (CfxApi.cfx_frame_copy_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_frame_copy, typeof(CfxApi.cfx_frame_copy_delegate));
            CfxApi.cfx_frame_paste = (CfxApi.cfx_frame_paste_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_frame_paste, typeof(CfxApi.cfx_frame_paste_delegate));
            CfxApi.cfx_frame_del = (CfxApi.cfx_frame_del_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_frame_del, typeof(CfxApi.cfx_frame_del_delegate));
            CfxApi.cfx_frame_select_all = (CfxApi.cfx_frame_select_all_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_frame_select_all, typeof(CfxApi.cfx_frame_select_all_delegate));
            CfxApi.cfx_frame_view_source = (CfxApi.cfx_frame_view_source_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_frame_view_source, typeof(CfxApi.cfx_frame_view_source_delegate));
            CfxApi.cfx_frame_get_source = (CfxApi.cfx_frame_get_source_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_frame_get_source, typeof(CfxApi.cfx_frame_get_source_delegate));
            CfxApi.cfx_frame_get_text = (CfxApi.cfx_frame_get_text_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_frame_get_text, typeof(CfxApi.cfx_frame_get_text_delegate));
            CfxApi.cfx_frame_load_request = (CfxApi.cfx_frame_load_request_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_frame_load_request, typeof(CfxApi.cfx_frame_load_request_delegate));
            CfxApi.cfx_frame_load_url = (CfxApi.cfx_frame_load_url_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_frame_load_url, typeof(CfxApi.cfx_frame_load_url_delegate));
            CfxApi.cfx_frame_load_string = (CfxApi.cfx_frame_load_string_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_frame_load_string, typeof(CfxApi.cfx_frame_load_string_delegate));
            CfxApi.cfx_frame_execute_java_script = (CfxApi.cfx_frame_execute_java_script_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_frame_execute_java_script, typeof(CfxApi.cfx_frame_execute_java_script_delegate));
            CfxApi.cfx_frame_is_main = (CfxApi.cfx_frame_is_main_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_frame_is_main, typeof(CfxApi.cfx_frame_is_main_delegate));
            CfxApi.cfx_frame_is_focused = (CfxApi.cfx_frame_is_focused_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_frame_is_focused, typeof(CfxApi.cfx_frame_is_focused_delegate));
            CfxApi.cfx_frame_get_name = (CfxApi.cfx_frame_get_name_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_frame_get_name, typeof(CfxApi.cfx_frame_get_name_delegate));
            CfxApi.cfx_frame_get_identifier = (CfxApi.cfx_frame_get_identifier_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_frame_get_identifier, typeof(CfxApi.cfx_frame_get_identifier_delegate));
            CfxApi.cfx_frame_get_parent = (CfxApi.cfx_frame_get_parent_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_frame_get_parent, typeof(CfxApi.cfx_frame_get_parent_delegate));
            CfxApi.cfx_frame_get_url = (CfxApi.cfx_frame_get_url_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_frame_get_url, typeof(CfxApi.cfx_frame_get_url_delegate));
            CfxApi.cfx_frame_get_browser = (CfxApi.cfx_frame_get_browser_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_frame_get_browser, typeof(CfxApi.cfx_frame_get_browser_delegate));
            CfxApi.cfx_frame_get_v8context = (CfxApi.cfx_frame_get_v8context_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_frame_get_v8context, typeof(CfxApi.cfx_frame_get_v8context_delegate));
            CfxApi.cfx_frame_visit_dom = (CfxApi.cfx_frame_visit_dom_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_frame_visit_dom, typeof(CfxApi.cfx_frame_visit_dom_delegate));
        }

        private static bool CfxGeolocationCallbackApiLoaded;
        internal static void LoadCfxGeolocationCallbackApi() {
            if(CfxGeolocationCallbackApiLoaded) return;
            CfxGeolocationCallbackApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_geolocation_callback_cont = (CfxApi.cfx_geolocation_callback_cont_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_geolocation_callback_cont, typeof(CfxApi.cfx_geolocation_callback_cont_delegate));
        }

        private static bool CfxGeolocationHandlerApiLoaded;
        internal static void LoadCfxGeolocationHandlerApi() {
            if(CfxGeolocationHandlerApiLoaded) return;
            CfxGeolocationHandlerApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_geolocation_handler_ctor = (CfxApi.cfx_ctor_with_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_geolocation_handler_ctor, typeof(CfxApi.cfx_ctor_with_gc_handle_delegate));
            CfxApi.cfx_geolocation_handler_get_gc_handle = (CfxApi.cfx_get_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_geolocation_handler_get_gc_handle, typeof(CfxApi.cfx_get_gc_handle_delegate));
            CfxApi.cfx_geolocation_handler_set_managed_callback = (CfxApi.cfx_set_callback_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_geolocation_handler_set_managed_callback, typeof(CfxApi.cfx_set_callback_delegate));
        }

        private static bool CfxGeopositionApiLoaded;
        internal static void LoadCfxGeopositionApi() {
            if(CfxGeopositionApiLoaded) return;
            CfxGeopositionApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_geoposition_ctor = (CfxApi.cfx_ctor_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_geoposition_ctor, typeof(CfxApi.cfx_ctor_delegate));
            CfxApi.cfx_geoposition_dtor = (CfxApi.cfx_dtor_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_geoposition_dtor, typeof(CfxApi.cfx_dtor_delegate));
            CfxApi.cfx_geoposition_set_latitude = (CfxApi.cfx_geoposition_set_latitude_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_geoposition_set_latitude, typeof(CfxApi.cfx_geoposition_set_latitude_delegate));
            CfxApi.cfx_geoposition_get_latitude = (CfxApi.cfx_geoposition_get_latitude_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_geoposition_get_latitude, typeof(CfxApi.cfx_geoposition_get_latitude_delegate));
            CfxApi.cfx_geoposition_set_longitude = (CfxApi.cfx_geoposition_set_longitude_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_geoposition_set_longitude, typeof(CfxApi.cfx_geoposition_set_longitude_delegate));
            CfxApi.cfx_geoposition_get_longitude = (CfxApi.cfx_geoposition_get_longitude_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_geoposition_get_longitude, typeof(CfxApi.cfx_geoposition_get_longitude_delegate));
            CfxApi.cfx_geoposition_set_altitude = (CfxApi.cfx_geoposition_set_altitude_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_geoposition_set_altitude, typeof(CfxApi.cfx_geoposition_set_altitude_delegate));
            CfxApi.cfx_geoposition_get_altitude = (CfxApi.cfx_geoposition_get_altitude_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_geoposition_get_altitude, typeof(CfxApi.cfx_geoposition_get_altitude_delegate));
            CfxApi.cfx_geoposition_set_accuracy = (CfxApi.cfx_geoposition_set_accuracy_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_geoposition_set_accuracy, typeof(CfxApi.cfx_geoposition_set_accuracy_delegate));
            CfxApi.cfx_geoposition_get_accuracy = (CfxApi.cfx_geoposition_get_accuracy_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_geoposition_get_accuracy, typeof(CfxApi.cfx_geoposition_get_accuracy_delegate));
            CfxApi.cfx_geoposition_set_altitude_accuracy = (CfxApi.cfx_geoposition_set_altitude_accuracy_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_geoposition_set_altitude_accuracy, typeof(CfxApi.cfx_geoposition_set_altitude_accuracy_delegate));
            CfxApi.cfx_geoposition_get_altitude_accuracy = (CfxApi.cfx_geoposition_get_altitude_accuracy_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_geoposition_get_altitude_accuracy, typeof(CfxApi.cfx_geoposition_get_altitude_accuracy_delegate));
            CfxApi.cfx_geoposition_set_heading = (CfxApi.cfx_geoposition_set_heading_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_geoposition_set_heading, typeof(CfxApi.cfx_geoposition_set_heading_delegate));
            CfxApi.cfx_geoposition_get_heading = (CfxApi.cfx_geoposition_get_heading_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_geoposition_get_heading, typeof(CfxApi.cfx_geoposition_get_heading_delegate));
            CfxApi.cfx_geoposition_set_speed = (CfxApi.cfx_geoposition_set_speed_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_geoposition_set_speed, typeof(CfxApi.cfx_geoposition_set_speed_delegate));
            CfxApi.cfx_geoposition_get_speed = (CfxApi.cfx_geoposition_get_speed_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_geoposition_get_speed, typeof(CfxApi.cfx_geoposition_get_speed_delegate));
            CfxApi.cfx_geoposition_set_timestamp = (CfxApi.cfx_geoposition_set_timestamp_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_geoposition_set_timestamp, typeof(CfxApi.cfx_geoposition_set_timestamp_delegate));
            CfxApi.cfx_geoposition_get_timestamp = (CfxApi.cfx_geoposition_get_timestamp_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_geoposition_get_timestamp, typeof(CfxApi.cfx_geoposition_get_timestamp_delegate));
            CfxApi.cfx_geoposition_set_error_code = (CfxApi.cfx_geoposition_set_error_code_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_geoposition_set_error_code, typeof(CfxApi.cfx_geoposition_set_error_code_delegate));
            CfxApi.cfx_geoposition_get_error_code = (CfxApi.cfx_geoposition_get_error_code_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_geoposition_get_error_code, typeof(CfxApi.cfx_geoposition_get_error_code_delegate));
            CfxApi.cfx_geoposition_set_error_message = (CfxApi.cfx_geoposition_set_error_message_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_geoposition_set_error_message, typeof(CfxApi.cfx_geoposition_set_error_message_delegate));
            CfxApi.cfx_geoposition_get_error_message = (CfxApi.cfx_geoposition_get_error_message_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_geoposition_get_error_message, typeof(CfxApi.cfx_geoposition_get_error_message_delegate));
        }

        private static bool CfxGetGeolocationCallbackApiLoaded;
        internal static void LoadCfxGetGeolocationCallbackApi() {
            if(CfxGetGeolocationCallbackApiLoaded) return;
            CfxGetGeolocationCallbackApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_get_geolocation_callback_ctor = (CfxApi.cfx_ctor_with_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_get_geolocation_callback_ctor, typeof(CfxApi.cfx_ctor_with_gc_handle_delegate));
            CfxApi.cfx_get_geolocation_callback_get_gc_handle = (CfxApi.cfx_get_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_get_geolocation_callback_get_gc_handle, typeof(CfxApi.cfx_get_gc_handle_delegate));
            CfxApi.cfx_get_geolocation_callback_set_managed_callback = (CfxApi.cfx_set_callback_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_get_geolocation_callback_set_managed_callback, typeof(CfxApi.cfx_set_callback_delegate));
        }

        private static bool CfxJsDialogCallbackApiLoaded;
        internal static void LoadCfxJsDialogCallbackApi() {
            if(CfxJsDialogCallbackApiLoaded) return;
            CfxJsDialogCallbackApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_jsdialog_callback_cont = (CfxApi.cfx_jsdialog_callback_cont_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_jsdialog_callback_cont, typeof(CfxApi.cfx_jsdialog_callback_cont_delegate));
        }

        private static bool CfxJsDialogHandlerApiLoaded;
        internal static void LoadCfxJsDialogHandlerApi() {
            if(CfxJsDialogHandlerApiLoaded) return;
            CfxJsDialogHandlerApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_jsdialog_handler_ctor = (CfxApi.cfx_ctor_with_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_jsdialog_handler_ctor, typeof(CfxApi.cfx_ctor_with_gc_handle_delegate));
            CfxApi.cfx_jsdialog_handler_get_gc_handle = (CfxApi.cfx_get_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_jsdialog_handler_get_gc_handle, typeof(CfxApi.cfx_get_gc_handle_delegate));
            CfxApi.cfx_jsdialog_handler_set_managed_callback = (CfxApi.cfx_set_callback_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_jsdialog_handler_set_managed_callback, typeof(CfxApi.cfx_set_callback_delegate));
        }

        private static bool CfxKeyEventApiLoaded;
        internal static void LoadCfxKeyEventApi() {
            if(CfxKeyEventApiLoaded) return;
            CfxKeyEventApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_key_event_ctor = (CfxApi.cfx_ctor_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_key_event_ctor, typeof(CfxApi.cfx_ctor_delegate));
            CfxApi.cfx_key_event_dtor = (CfxApi.cfx_dtor_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_key_event_dtor, typeof(CfxApi.cfx_dtor_delegate));
            CfxApi.cfx_key_event_set_type = (CfxApi.cfx_key_event_set_type_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_key_event_set_type, typeof(CfxApi.cfx_key_event_set_type_delegate));
            CfxApi.cfx_key_event_get_type = (CfxApi.cfx_key_event_get_type_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_key_event_get_type, typeof(CfxApi.cfx_key_event_get_type_delegate));
            CfxApi.cfx_key_event_set_modifiers = (CfxApi.cfx_key_event_set_modifiers_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_key_event_set_modifiers, typeof(CfxApi.cfx_key_event_set_modifiers_delegate));
            CfxApi.cfx_key_event_get_modifiers = (CfxApi.cfx_key_event_get_modifiers_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_key_event_get_modifiers, typeof(CfxApi.cfx_key_event_get_modifiers_delegate));
            CfxApi.cfx_key_event_set_windows_key_code = (CfxApi.cfx_key_event_set_windows_key_code_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_key_event_set_windows_key_code, typeof(CfxApi.cfx_key_event_set_windows_key_code_delegate));
            CfxApi.cfx_key_event_get_windows_key_code = (CfxApi.cfx_key_event_get_windows_key_code_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_key_event_get_windows_key_code, typeof(CfxApi.cfx_key_event_get_windows_key_code_delegate));
            CfxApi.cfx_key_event_set_native_key_code = (CfxApi.cfx_key_event_set_native_key_code_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_key_event_set_native_key_code, typeof(CfxApi.cfx_key_event_set_native_key_code_delegate));
            CfxApi.cfx_key_event_get_native_key_code = (CfxApi.cfx_key_event_get_native_key_code_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_key_event_get_native_key_code, typeof(CfxApi.cfx_key_event_get_native_key_code_delegate));
            CfxApi.cfx_key_event_set_is_system_key = (CfxApi.cfx_key_event_set_is_system_key_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_key_event_set_is_system_key, typeof(CfxApi.cfx_key_event_set_is_system_key_delegate));
            CfxApi.cfx_key_event_get_is_system_key = (CfxApi.cfx_key_event_get_is_system_key_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_key_event_get_is_system_key, typeof(CfxApi.cfx_key_event_get_is_system_key_delegate));
            CfxApi.cfx_key_event_set_character = (CfxApi.cfx_key_event_set_character_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_key_event_set_character, typeof(CfxApi.cfx_key_event_set_character_delegate));
            CfxApi.cfx_key_event_get_character = (CfxApi.cfx_key_event_get_character_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_key_event_get_character, typeof(CfxApi.cfx_key_event_get_character_delegate));
            CfxApi.cfx_key_event_set_unmodified_character = (CfxApi.cfx_key_event_set_unmodified_character_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_key_event_set_unmodified_character, typeof(CfxApi.cfx_key_event_set_unmodified_character_delegate));
            CfxApi.cfx_key_event_get_unmodified_character = (CfxApi.cfx_key_event_get_unmodified_character_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_key_event_get_unmodified_character, typeof(CfxApi.cfx_key_event_get_unmodified_character_delegate));
            CfxApi.cfx_key_event_set_focus_on_editable_field = (CfxApi.cfx_key_event_set_focus_on_editable_field_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_key_event_set_focus_on_editable_field, typeof(CfxApi.cfx_key_event_set_focus_on_editable_field_delegate));
            CfxApi.cfx_key_event_get_focus_on_editable_field = (CfxApi.cfx_key_event_get_focus_on_editable_field_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_key_event_get_focus_on_editable_field, typeof(CfxApi.cfx_key_event_get_focus_on_editable_field_delegate));
        }

        private static bool CfxKeyboardHandlerApiLoaded;
        internal static void LoadCfxKeyboardHandlerApi() {
            if(CfxKeyboardHandlerApiLoaded) return;
            CfxKeyboardHandlerApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_keyboard_handler_ctor = (CfxApi.cfx_ctor_with_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_keyboard_handler_ctor, typeof(CfxApi.cfx_ctor_with_gc_handle_delegate));
            CfxApi.cfx_keyboard_handler_get_gc_handle = (CfxApi.cfx_get_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_keyboard_handler_get_gc_handle, typeof(CfxApi.cfx_get_gc_handle_delegate));
            CfxApi.cfx_keyboard_handler_set_managed_callback = (CfxApi.cfx_set_callback_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_keyboard_handler_set_managed_callback, typeof(CfxApi.cfx_set_callback_delegate));
        }

        private static bool CfxLifeSpanHandlerApiLoaded;
        internal static void LoadCfxLifeSpanHandlerApi() {
            if(CfxLifeSpanHandlerApiLoaded) return;
            CfxLifeSpanHandlerApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_life_span_handler_ctor = (CfxApi.cfx_ctor_with_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_life_span_handler_ctor, typeof(CfxApi.cfx_ctor_with_gc_handle_delegate));
            CfxApi.cfx_life_span_handler_get_gc_handle = (CfxApi.cfx_get_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_life_span_handler_get_gc_handle, typeof(CfxApi.cfx_get_gc_handle_delegate));
            CfxApi.cfx_life_span_handler_set_managed_callback = (CfxApi.cfx_set_callback_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_life_span_handler_set_managed_callback, typeof(CfxApi.cfx_set_callback_delegate));
        }

        private static bool CfxListValueApiLoaded;
        internal static void LoadCfxListValueApi() {
            if(CfxListValueApiLoaded) return;
            CfxListValueApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_list_value_create = (CfxApi.cfx_list_value_create_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_list_value_create, typeof(CfxApi.cfx_list_value_create_delegate));
            CfxApi.cfx_list_value_is_valid = (CfxApi.cfx_list_value_is_valid_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_list_value_is_valid, typeof(CfxApi.cfx_list_value_is_valid_delegate));
            CfxApi.cfx_list_value_is_owned = (CfxApi.cfx_list_value_is_owned_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_list_value_is_owned, typeof(CfxApi.cfx_list_value_is_owned_delegate));
            CfxApi.cfx_list_value_is_read_only = (CfxApi.cfx_list_value_is_read_only_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_list_value_is_read_only, typeof(CfxApi.cfx_list_value_is_read_only_delegate));
            CfxApi.cfx_list_value_is_same = (CfxApi.cfx_list_value_is_same_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_list_value_is_same, typeof(CfxApi.cfx_list_value_is_same_delegate));
            CfxApi.cfx_list_value_is_equal = (CfxApi.cfx_list_value_is_equal_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_list_value_is_equal, typeof(CfxApi.cfx_list_value_is_equal_delegate));
            CfxApi.cfx_list_value_copy = (CfxApi.cfx_list_value_copy_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_list_value_copy, typeof(CfxApi.cfx_list_value_copy_delegate));
            CfxApi.cfx_list_value_set_size = (CfxApi.cfx_list_value_set_size_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_list_value_set_size, typeof(CfxApi.cfx_list_value_set_size_delegate));
            CfxApi.cfx_list_value_get_size = (CfxApi.cfx_list_value_get_size_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_list_value_get_size, typeof(CfxApi.cfx_list_value_get_size_delegate));
            CfxApi.cfx_list_value_clear = (CfxApi.cfx_list_value_clear_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_list_value_clear, typeof(CfxApi.cfx_list_value_clear_delegate));
            CfxApi.cfx_list_value_remove = (CfxApi.cfx_list_value_remove_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_list_value_remove, typeof(CfxApi.cfx_list_value_remove_delegate));
            CfxApi.cfx_list_value_get_type = (CfxApi.cfx_list_value_get_type_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_list_value_get_type, typeof(CfxApi.cfx_list_value_get_type_delegate));
            CfxApi.cfx_list_value_get_value = (CfxApi.cfx_list_value_get_value_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_list_value_get_value, typeof(CfxApi.cfx_list_value_get_value_delegate));
            CfxApi.cfx_list_value_get_bool = (CfxApi.cfx_list_value_get_bool_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_list_value_get_bool, typeof(CfxApi.cfx_list_value_get_bool_delegate));
            CfxApi.cfx_list_value_get_int = (CfxApi.cfx_list_value_get_int_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_list_value_get_int, typeof(CfxApi.cfx_list_value_get_int_delegate));
            CfxApi.cfx_list_value_get_double = (CfxApi.cfx_list_value_get_double_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_list_value_get_double, typeof(CfxApi.cfx_list_value_get_double_delegate));
            CfxApi.cfx_list_value_get_string = (CfxApi.cfx_list_value_get_string_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_list_value_get_string, typeof(CfxApi.cfx_list_value_get_string_delegate));
            CfxApi.cfx_list_value_get_binary = (CfxApi.cfx_list_value_get_binary_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_list_value_get_binary, typeof(CfxApi.cfx_list_value_get_binary_delegate));
            CfxApi.cfx_list_value_get_dictionary = (CfxApi.cfx_list_value_get_dictionary_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_list_value_get_dictionary, typeof(CfxApi.cfx_list_value_get_dictionary_delegate));
            CfxApi.cfx_list_value_get_list = (CfxApi.cfx_list_value_get_list_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_list_value_get_list, typeof(CfxApi.cfx_list_value_get_list_delegate));
            CfxApi.cfx_list_value_set_value = (CfxApi.cfx_list_value_set_value_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_list_value_set_value, typeof(CfxApi.cfx_list_value_set_value_delegate));
            CfxApi.cfx_list_value_set_null = (CfxApi.cfx_list_value_set_null_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_list_value_set_null, typeof(CfxApi.cfx_list_value_set_null_delegate));
            CfxApi.cfx_list_value_set_bool = (CfxApi.cfx_list_value_set_bool_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_list_value_set_bool, typeof(CfxApi.cfx_list_value_set_bool_delegate));
            CfxApi.cfx_list_value_set_int = (CfxApi.cfx_list_value_set_int_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_list_value_set_int, typeof(CfxApi.cfx_list_value_set_int_delegate));
            CfxApi.cfx_list_value_set_double = (CfxApi.cfx_list_value_set_double_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_list_value_set_double, typeof(CfxApi.cfx_list_value_set_double_delegate));
            CfxApi.cfx_list_value_set_string = (CfxApi.cfx_list_value_set_string_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_list_value_set_string, typeof(CfxApi.cfx_list_value_set_string_delegate));
            CfxApi.cfx_list_value_set_binary = (CfxApi.cfx_list_value_set_binary_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_list_value_set_binary, typeof(CfxApi.cfx_list_value_set_binary_delegate));
            CfxApi.cfx_list_value_set_dictionary = (CfxApi.cfx_list_value_set_dictionary_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_list_value_set_dictionary, typeof(CfxApi.cfx_list_value_set_dictionary_delegate));
            CfxApi.cfx_list_value_set_list = (CfxApi.cfx_list_value_set_list_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_list_value_set_list, typeof(CfxApi.cfx_list_value_set_list_delegate));
        }

        private static bool CfxLoadHandlerApiLoaded;
        internal static void LoadCfxLoadHandlerApi() {
            if(CfxLoadHandlerApiLoaded) return;
            CfxLoadHandlerApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_load_handler_ctor = (CfxApi.cfx_ctor_with_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_load_handler_ctor, typeof(CfxApi.cfx_ctor_with_gc_handle_delegate));
            CfxApi.cfx_load_handler_get_gc_handle = (CfxApi.cfx_get_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_load_handler_get_gc_handle, typeof(CfxApi.cfx_get_gc_handle_delegate));
            CfxApi.cfx_load_handler_set_managed_callback = (CfxApi.cfx_set_callback_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_load_handler_set_managed_callback, typeof(CfxApi.cfx_set_callback_delegate));
        }

        private static bool CfxMainArgsLinuxApiLoaded;
        internal static void LoadCfxMainArgsLinuxApi() {
            if(CfxMainArgsLinuxApiLoaded) return;
            CfxMainArgsLinuxApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_main_args_linux_ctor = (CfxApi.cfx_ctor_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_main_args_linux_ctor, typeof(CfxApi.cfx_ctor_delegate));
            CfxApi.cfx_main_args_linux_dtor = (CfxApi.cfx_dtor_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_main_args_linux_dtor, typeof(CfxApi.cfx_dtor_delegate));
            CfxApi.cfx_main_args_linux_set_argc = (CfxApi.cfx_main_args_linux_set_argc_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_main_args_linux_set_argc, typeof(CfxApi.cfx_main_args_linux_set_argc_delegate));
            CfxApi.cfx_main_args_linux_get_argc = (CfxApi.cfx_main_args_linux_get_argc_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_main_args_linux_get_argc, typeof(CfxApi.cfx_main_args_linux_get_argc_delegate));
            CfxApi.cfx_main_args_linux_set_argv = (CfxApi.cfx_main_args_linux_set_argv_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_main_args_linux_set_argv, typeof(CfxApi.cfx_main_args_linux_set_argv_delegate));
            CfxApi.cfx_main_args_linux_get_argv = (CfxApi.cfx_main_args_linux_get_argv_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_main_args_linux_get_argv, typeof(CfxApi.cfx_main_args_linux_get_argv_delegate));
        }

        private static bool CfxMainArgsWindowsApiLoaded;
        internal static void LoadCfxMainArgsWindowsApi() {
            if(CfxMainArgsWindowsApiLoaded) return;
            CfxMainArgsWindowsApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_main_args_windows_ctor = (CfxApi.cfx_ctor_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_main_args_windows_ctor, typeof(CfxApi.cfx_ctor_delegate));
            CfxApi.cfx_main_args_windows_dtor = (CfxApi.cfx_dtor_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_main_args_windows_dtor, typeof(CfxApi.cfx_dtor_delegate));
            CfxApi.cfx_main_args_windows_set_instance = (CfxApi.cfx_main_args_windows_set_instance_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_main_args_windows_set_instance, typeof(CfxApi.cfx_main_args_windows_set_instance_delegate));
            CfxApi.cfx_main_args_windows_get_instance = (CfxApi.cfx_main_args_windows_get_instance_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_main_args_windows_get_instance, typeof(CfxApi.cfx_main_args_windows_get_instance_delegate));
        }

        private static bool CfxMenuModelApiLoaded;
        internal static void LoadCfxMenuModelApi() {
            if(CfxMenuModelApiLoaded) return;
            CfxMenuModelApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_menu_model_clear = (CfxApi.cfx_menu_model_clear_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_menu_model_clear, typeof(CfxApi.cfx_menu_model_clear_delegate));
            CfxApi.cfx_menu_model_get_count = (CfxApi.cfx_menu_model_get_count_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_menu_model_get_count, typeof(CfxApi.cfx_menu_model_get_count_delegate));
            CfxApi.cfx_menu_model_add_separator = (CfxApi.cfx_menu_model_add_separator_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_menu_model_add_separator, typeof(CfxApi.cfx_menu_model_add_separator_delegate));
            CfxApi.cfx_menu_model_add_item = (CfxApi.cfx_menu_model_add_item_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_menu_model_add_item, typeof(CfxApi.cfx_menu_model_add_item_delegate));
            CfxApi.cfx_menu_model_add_check_item = (CfxApi.cfx_menu_model_add_check_item_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_menu_model_add_check_item, typeof(CfxApi.cfx_menu_model_add_check_item_delegate));
            CfxApi.cfx_menu_model_add_radio_item = (CfxApi.cfx_menu_model_add_radio_item_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_menu_model_add_radio_item, typeof(CfxApi.cfx_menu_model_add_radio_item_delegate));
            CfxApi.cfx_menu_model_add_sub_menu = (CfxApi.cfx_menu_model_add_sub_menu_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_menu_model_add_sub_menu, typeof(CfxApi.cfx_menu_model_add_sub_menu_delegate));
            CfxApi.cfx_menu_model_insert_separator_at = (CfxApi.cfx_menu_model_insert_separator_at_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_menu_model_insert_separator_at, typeof(CfxApi.cfx_menu_model_insert_separator_at_delegate));
            CfxApi.cfx_menu_model_insert_item_at = (CfxApi.cfx_menu_model_insert_item_at_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_menu_model_insert_item_at, typeof(CfxApi.cfx_menu_model_insert_item_at_delegate));
            CfxApi.cfx_menu_model_insert_check_item_at = (CfxApi.cfx_menu_model_insert_check_item_at_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_menu_model_insert_check_item_at, typeof(CfxApi.cfx_menu_model_insert_check_item_at_delegate));
            CfxApi.cfx_menu_model_insert_radio_item_at = (CfxApi.cfx_menu_model_insert_radio_item_at_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_menu_model_insert_radio_item_at, typeof(CfxApi.cfx_menu_model_insert_radio_item_at_delegate));
            CfxApi.cfx_menu_model_insert_sub_menu_at = (CfxApi.cfx_menu_model_insert_sub_menu_at_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_menu_model_insert_sub_menu_at, typeof(CfxApi.cfx_menu_model_insert_sub_menu_at_delegate));
            CfxApi.cfx_menu_model_remove = (CfxApi.cfx_menu_model_remove_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_menu_model_remove, typeof(CfxApi.cfx_menu_model_remove_delegate));
            CfxApi.cfx_menu_model_remove_at = (CfxApi.cfx_menu_model_remove_at_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_menu_model_remove_at, typeof(CfxApi.cfx_menu_model_remove_at_delegate));
            CfxApi.cfx_menu_model_get_index_of = (CfxApi.cfx_menu_model_get_index_of_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_menu_model_get_index_of, typeof(CfxApi.cfx_menu_model_get_index_of_delegate));
            CfxApi.cfx_menu_model_get_command_id_at = (CfxApi.cfx_menu_model_get_command_id_at_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_menu_model_get_command_id_at, typeof(CfxApi.cfx_menu_model_get_command_id_at_delegate));
            CfxApi.cfx_menu_model_set_command_id_at = (CfxApi.cfx_menu_model_set_command_id_at_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_menu_model_set_command_id_at, typeof(CfxApi.cfx_menu_model_set_command_id_at_delegate));
            CfxApi.cfx_menu_model_get_label = (CfxApi.cfx_menu_model_get_label_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_menu_model_get_label, typeof(CfxApi.cfx_menu_model_get_label_delegate));
            CfxApi.cfx_menu_model_get_label_at = (CfxApi.cfx_menu_model_get_label_at_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_menu_model_get_label_at, typeof(CfxApi.cfx_menu_model_get_label_at_delegate));
            CfxApi.cfx_menu_model_set_label = (CfxApi.cfx_menu_model_set_label_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_menu_model_set_label, typeof(CfxApi.cfx_menu_model_set_label_delegate));
            CfxApi.cfx_menu_model_set_label_at = (CfxApi.cfx_menu_model_set_label_at_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_menu_model_set_label_at, typeof(CfxApi.cfx_menu_model_set_label_at_delegate));
            CfxApi.cfx_menu_model_get_type = (CfxApi.cfx_menu_model_get_type_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_menu_model_get_type, typeof(CfxApi.cfx_menu_model_get_type_delegate));
            CfxApi.cfx_menu_model_get_type_at = (CfxApi.cfx_menu_model_get_type_at_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_menu_model_get_type_at, typeof(CfxApi.cfx_menu_model_get_type_at_delegate));
            CfxApi.cfx_menu_model_get_group_id = (CfxApi.cfx_menu_model_get_group_id_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_menu_model_get_group_id, typeof(CfxApi.cfx_menu_model_get_group_id_delegate));
            CfxApi.cfx_menu_model_get_group_id_at = (CfxApi.cfx_menu_model_get_group_id_at_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_menu_model_get_group_id_at, typeof(CfxApi.cfx_menu_model_get_group_id_at_delegate));
            CfxApi.cfx_menu_model_set_group_id = (CfxApi.cfx_menu_model_set_group_id_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_menu_model_set_group_id, typeof(CfxApi.cfx_menu_model_set_group_id_delegate));
            CfxApi.cfx_menu_model_set_group_id_at = (CfxApi.cfx_menu_model_set_group_id_at_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_menu_model_set_group_id_at, typeof(CfxApi.cfx_menu_model_set_group_id_at_delegate));
            CfxApi.cfx_menu_model_get_sub_menu = (CfxApi.cfx_menu_model_get_sub_menu_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_menu_model_get_sub_menu, typeof(CfxApi.cfx_menu_model_get_sub_menu_delegate));
            CfxApi.cfx_menu_model_get_sub_menu_at = (CfxApi.cfx_menu_model_get_sub_menu_at_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_menu_model_get_sub_menu_at, typeof(CfxApi.cfx_menu_model_get_sub_menu_at_delegate));
            CfxApi.cfx_menu_model_is_visible = (CfxApi.cfx_menu_model_is_visible_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_menu_model_is_visible, typeof(CfxApi.cfx_menu_model_is_visible_delegate));
            CfxApi.cfx_menu_model_is_visible_at = (CfxApi.cfx_menu_model_is_visible_at_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_menu_model_is_visible_at, typeof(CfxApi.cfx_menu_model_is_visible_at_delegate));
            CfxApi.cfx_menu_model_set_visible = (CfxApi.cfx_menu_model_set_visible_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_menu_model_set_visible, typeof(CfxApi.cfx_menu_model_set_visible_delegate));
            CfxApi.cfx_menu_model_set_visible_at = (CfxApi.cfx_menu_model_set_visible_at_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_menu_model_set_visible_at, typeof(CfxApi.cfx_menu_model_set_visible_at_delegate));
            CfxApi.cfx_menu_model_is_enabled = (CfxApi.cfx_menu_model_is_enabled_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_menu_model_is_enabled, typeof(CfxApi.cfx_menu_model_is_enabled_delegate));
            CfxApi.cfx_menu_model_is_enabled_at = (CfxApi.cfx_menu_model_is_enabled_at_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_menu_model_is_enabled_at, typeof(CfxApi.cfx_menu_model_is_enabled_at_delegate));
            CfxApi.cfx_menu_model_set_enabled = (CfxApi.cfx_menu_model_set_enabled_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_menu_model_set_enabled, typeof(CfxApi.cfx_menu_model_set_enabled_delegate));
            CfxApi.cfx_menu_model_set_enabled_at = (CfxApi.cfx_menu_model_set_enabled_at_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_menu_model_set_enabled_at, typeof(CfxApi.cfx_menu_model_set_enabled_at_delegate));
            CfxApi.cfx_menu_model_is_checked = (CfxApi.cfx_menu_model_is_checked_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_menu_model_is_checked, typeof(CfxApi.cfx_menu_model_is_checked_delegate));
            CfxApi.cfx_menu_model_is_checked_at = (CfxApi.cfx_menu_model_is_checked_at_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_menu_model_is_checked_at, typeof(CfxApi.cfx_menu_model_is_checked_at_delegate));
            CfxApi.cfx_menu_model_set_checked = (CfxApi.cfx_menu_model_set_checked_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_menu_model_set_checked, typeof(CfxApi.cfx_menu_model_set_checked_delegate));
            CfxApi.cfx_menu_model_set_checked_at = (CfxApi.cfx_menu_model_set_checked_at_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_menu_model_set_checked_at, typeof(CfxApi.cfx_menu_model_set_checked_at_delegate));
            CfxApi.cfx_menu_model_has_accelerator = (CfxApi.cfx_menu_model_has_accelerator_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_menu_model_has_accelerator, typeof(CfxApi.cfx_menu_model_has_accelerator_delegate));
            CfxApi.cfx_menu_model_has_accelerator_at = (CfxApi.cfx_menu_model_has_accelerator_at_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_menu_model_has_accelerator_at, typeof(CfxApi.cfx_menu_model_has_accelerator_at_delegate));
            CfxApi.cfx_menu_model_set_accelerator = (CfxApi.cfx_menu_model_set_accelerator_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_menu_model_set_accelerator, typeof(CfxApi.cfx_menu_model_set_accelerator_delegate));
            CfxApi.cfx_menu_model_set_accelerator_at = (CfxApi.cfx_menu_model_set_accelerator_at_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_menu_model_set_accelerator_at, typeof(CfxApi.cfx_menu_model_set_accelerator_at_delegate));
            CfxApi.cfx_menu_model_remove_accelerator = (CfxApi.cfx_menu_model_remove_accelerator_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_menu_model_remove_accelerator, typeof(CfxApi.cfx_menu_model_remove_accelerator_delegate));
            CfxApi.cfx_menu_model_remove_accelerator_at = (CfxApi.cfx_menu_model_remove_accelerator_at_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_menu_model_remove_accelerator_at, typeof(CfxApi.cfx_menu_model_remove_accelerator_at_delegate));
            CfxApi.cfx_menu_model_get_accelerator = (CfxApi.cfx_menu_model_get_accelerator_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_menu_model_get_accelerator, typeof(CfxApi.cfx_menu_model_get_accelerator_delegate));
            CfxApi.cfx_menu_model_get_accelerator_at = (CfxApi.cfx_menu_model_get_accelerator_at_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_menu_model_get_accelerator_at, typeof(CfxApi.cfx_menu_model_get_accelerator_at_delegate));
        }

        private static bool CfxMouseEventApiLoaded;
        internal static void LoadCfxMouseEventApi() {
            if(CfxMouseEventApiLoaded) return;
            CfxMouseEventApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_mouse_event_ctor = (CfxApi.cfx_ctor_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_mouse_event_ctor, typeof(CfxApi.cfx_ctor_delegate));
            CfxApi.cfx_mouse_event_dtor = (CfxApi.cfx_dtor_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_mouse_event_dtor, typeof(CfxApi.cfx_dtor_delegate));
            CfxApi.cfx_mouse_event_set_x = (CfxApi.cfx_mouse_event_set_x_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_mouse_event_set_x, typeof(CfxApi.cfx_mouse_event_set_x_delegate));
            CfxApi.cfx_mouse_event_get_x = (CfxApi.cfx_mouse_event_get_x_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_mouse_event_get_x, typeof(CfxApi.cfx_mouse_event_get_x_delegate));
            CfxApi.cfx_mouse_event_set_y = (CfxApi.cfx_mouse_event_set_y_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_mouse_event_set_y, typeof(CfxApi.cfx_mouse_event_set_y_delegate));
            CfxApi.cfx_mouse_event_get_y = (CfxApi.cfx_mouse_event_get_y_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_mouse_event_get_y, typeof(CfxApi.cfx_mouse_event_get_y_delegate));
            CfxApi.cfx_mouse_event_set_modifiers = (CfxApi.cfx_mouse_event_set_modifiers_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_mouse_event_set_modifiers, typeof(CfxApi.cfx_mouse_event_set_modifiers_delegate));
            CfxApi.cfx_mouse_event_get_modifiers = (CfxApi.cfx_mouse_event_get_modifiers_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_mouse_event_get_modifiers, typeof(CfxApi.cfx_mouse_event_get_modifiers_delegate));
        }

        private static bool CfxNavigationEntryApiLoaded;
        internal static void LoadCfxNavigationEntryApi() {
            if(CfxNavigationEntryApiLoaded) return;
            CfxNavigationEntryApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_navigation_entry_is_valid = (CfxApi.cfx_navigation_entry_is_valid_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_navigation_entry_is_valid, typeof(CfxApi.cfx_navigation_entry_is_valid_delegate));
            CfxApi.cfx_navigation_entry_get_url = (CfxApi.cfx_navigation_entry_get_url_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_navigation_entry_get_url, typeof(CfxApi.cfx_navigation_entry_get_url_delegate));
            CfxApi.cfx_navigation_entry_get_display_url = (CfxApi.cfx_navigation_entry_get_display_url_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_navigation_entry_get_display_url, typeof(CfxApi.cfx_navigation_entry_get_display_url_delegate));
            CfxApi.cfx_navigation_entry_get_original_url = (CfxApi.cfx_navigation_entry_get_original_url_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_navigation_entry_get_original_url, typeof(CfxApi.cfx_navigation_entry_get_original_url_delegate));
            CfxApi.cfx_navigation_entry_get_title = (CfxApi.cfx_navigation_entry_get_title_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_navigation_entry_get_title, typeof(CfxApi.cfx_navigation_entry_get_title_delegate));
            CfxApi.cfx_navigation_entry_get_transition_type = (CfxApi.cfx_navigation_entry_get_transition_type_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_navigation_entry_get_transition_type, typeof(CfxApi.cfx_navigation_entry_get_transition_type_delegate));
            CfxApi.cfx_navigation_entry_has_post_data = (CfxApi.cfx_navigation_entry_has_post_data_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_navigation_entry_has_post_data, typeof(CfxApi.cfx_navigation_entry_has_post_data_delegate));
            CfxApi.cfx_navigation_entry_get_completion_time = (CfxApi.cfx_navigation_entry_get_completion_time_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_navigation_entry_get_completion_time, typeof(CfxApi.cfx_navigation_entry_get_completion_time_delegate));
            CfxApi.cfx_navigation_entry_get_http_status_code = (CfxApi.cfx_navigation_entry_get_http_status_code_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_navigation_entry_get_http_status_code, typeof(CfxApi.cfx_navigation_entry_get_http_status_code_delegate));
        }

        private static bool CfxNavigationEntryVisitorApiLoaded;
        internal static void LoadCfxNavigationEntryVisitorApi() {
            if(CfxNavigationEntryVisitorApiLoaded) return;
            CfxNavigationEntryVisitorApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_navigation_entry_visitor_ctor = (CfxApi.cfx_ctor_with_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_navigation_entry_visitor_ctor, typeof(CfxApi.cfx_ctor_with_gc_handle_delegate));
            CfxApi.cfx_navigation_entry_visitor_get_gc_handle = (CfxApi.cfx_get_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_navigation_entry_visitor_get_gc_handle, typeof(CfxApi.cfx_get_gc_handle_delegate));
            CfxApi.cfx_navigation_entry_visitor_set_managed_callback = (CfxApi.cfx_set_callback_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_navigation_entry_visitor_set_managed_callback, typeof(CfxApi.cfx_set_callback_delegate));
        }

        private static bool CfxPageRangeApiLoaded;
        internal static void LoadCfxPageRangeApi() {
            if(CfxPageRangeApiLoaded) return;
            CfxPageRangeApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_page_range_ctor = (CfxApi.cfx_ctor_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_page_range_ctor, typeof(CfxApi.cfx_ctor_delegate));
            CfxApi.cfx_page_range_dtor = (CfxApi.cfx_dtor_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_page_range_dtor, typeof(CfxApi.cfx_dtor_delegate));
            CfxApi.cfx_page_range_set_from = (CfxApi.cfx_page_range_set_from_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_page_range_set_from, typeof(CfxApi.cfx_page_range_set_from_delegate));
            CfxApi.cfx_page_range_get_from = (CfxApi.cfx_page_range_get_from_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_page_range_get_from, typeof(CfxApi.cfx_page_range_get_from_delegate));
            CfxApi.cfx_page_range_set_to = (CfxApi.cfx_page_range_set_to_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_page_range_set_to, typeof(CfxApi.cfx_page_range_set_to_delegate));
            CfxApi.cfx_page_range_get_to = (CfxApi.cfx_page_range_get_to_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_page_range_get_to, typeof(CfxApi.cfx_page_range_get_to_delegate));
        }

        private static bool CfxPdfPrintCallbackApiLoaded;
        internal static void LoadCfxPdfPrintCallbackApi() {
            if(CfxPdfPrintCallbackApiLoaded) return;
            CfxPdfPrintCallbackApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_pdf_print_callback_ctor = (CfxApi.cfx_ctor_with_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_pdf_print_callback_ctor, typeof(CfxApi.cfx_ctor_with_gc_handle_delegate));
            CfxApi.cfx_pdf_print_callback_get_gc_handle = (CfxApi.cfx_get_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_pdf_print_callback_get_gc_handle, typeof(CfxApi.cfx_get_gc_handle_delegate));
            CfxApi.cfx_pdf_print_callback_set_managed_callback = (CfxApi.cfx_set_callback_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_pdf_print_callback_set_managed_callback, typeof(CfxApi.cfx_set_callback_delegate));
        }

        private static bool CfxPdfPrintSettingsApiLoaded;
        internal static void LoadCfxPdfPrintSettingsApi() {
            if(CfxPdfPrintSettingsApiLoaded) return;
            CfxPdfPrintSettingsApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_pdf_print_settings_ctor = (CfxApi.cfx_ctor_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_pdf_print_settings_ctor, typeof(CfxApi.cfx_ctor_delegate));
            CfxApi.cfx_pdf_print_settings_dtor = (CfxApi.cfx_dtor_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_pdf_print_settings_dtor, typeof(CfxApi.cfx_dtor_delegate));
            CfxApi.cfx_pdf_print_settings_set_header_footer_title = (CfxApi.cfx_pdf_print_settings_set_header_footer_title_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_pdf_print_settings_set_header_footer_title, typeof(CfxApi.cfx_pdf_print_settings_set_header_footer_title_delegate));
            CfxApi.cfx_pdf_print_settings_get_header_footer_title = (CfxApi.cfx_pdf_print_settings_get_header_footer_title_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_pdf_print_settings_get_header_footer_title, typeof(CfxApi.cfx_pdf_print_settings_get_header_footer_title_delegate));
            CfxApi.cfx_pdf_print_settings_set_header_footer_url = (CfxApi.cfx_pdf_print_settings_set_header_footer_url_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_pdf_print_settings_set_header_footer_url, typeof(CfxApi.cfx_pdf_print_settings_set_header_footer_url_delegate));
            CfxApi.cfx_pdf_print_settings_get_header_footer_url = (CfxApi.cfx_pdf_print_settings_get_header_footer_url_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_pdf_print_settings_get_header_footer_url, typeof(CfxApi.cfx_pdf_print_settings_get_header_footer_url_delegate));
            CfxApi.cfx_pdf_print_settings_set_page_width = (CfxApi.cfx_pdf_print_settings_set_page_width_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_pdf_print_settings_set_page_width, typeof(CfxApi.cfx_pdf_print_settings_set_page_width_delegate));
            CfxApi.cfx_pdf_print_settings_get_page_width = (CfxApi.cfx_pdf_print_settings_get_page_width_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_pdf_print_settings_get_page_width, typeof(CfxApi.cfx_pdf_print_settings_get_page_width_delegate));
            CfxApi.cfx_pdf_print_settings_set_page_height = (CfxApi.cfx_pdf_print_settings_set_page_height_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_pdf_print_settings_set_page_height, typeof(CfxApi.cfx_pdf_print_settings_set_page_height_delegate));
            CfxApi.cfx_pdf_print_settings_get_page_height = (CfxApi.cfx_pdf_print_settings_get_page_height_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_pdf_print_settings_get_page_height, typeof(CfxApi.cfx_pdf_print_settings_get_page_height_delegate));
            CfxApi.cfx_pdf_print_settings_set_margin_top = (CfxApi.cfx_pdf_print_settings_set_margin_top_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_pdf_print_settings_set_margin_top, typeof(CfxApi.cfx_pdf_print_settings_set_margin_top_delegate));
            CfxApi.cfx_pdf_print_settings_get_margin_top = (CfxApi.cfx_pdf_print_settings_get_margin_top_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_pdf_print_settings_get_margin_top, typeof(CfxApi.cfx_pdf_print_settings_get_margin_top_delegate));
            CfxApi.cfx_pdf_print_settings_set_margin_right = (CfxApi.cfx_pdf_print_settings_set_margin_right_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_pdf_print_settings_set_margin_right, typeof(CfxApi.cfx_pdf_print_settings_set_margin_right_delegate));
            CfxApi.cfx_pdf_print_settings_get_margin_right = (CfxApi.cfx_pdf_print_settings_get_margin_right_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_pdf_print_settings_get_margin_right, typeof(CfxApi.cfx_pdf_print_settings_get_margin_right_delegate));
            CfxApi.cfx_pdf_print_settings_set_margin_bottom = (CfxApi.cfx_pdf_print_settings_set_margin_bottom_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_pdf_print_settings_set_margin_bottom, typeof(CfxApi.cfx_pdf_print_settings_set_margin_bottom_delegate));
            CfxApi.cfx_pdf_print_settings_get_margin_bottom = (CfxApi.cfx_pdf_print_settings_get_margin_bottom_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_pdf_print_settings_get_margin_bottom, typeof(CfxApi.cfx_pdf_print_settings_get_margin_bottom_delegate));
            CfxApi.cfx_pdf_print_settings_set_margin_left = (CfxApi.cfx_pdf_print_settings_set_margin_left_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_pdf_print_settings_set_margin_left, typeof(CfxApi.cfx_pdf_print_settings_set_margin_left_delegate));
            CfxApi.cfx_pdf_print_settings_get_margin_left = (CfxApi.cfx_pdf_print_settings_get_margin_left_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_pdf_print_settings_get_margin_left, typeof(CfxApi.cfx_pdf_print_settings_get_margin_left_delegate));
            CfxApi.cfx_pdf_print_settings_set_margin_type = (CfxApi.cfx_pdf_print_settings_set_margin_type_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_pdf_print_settings_set_margin_type, typeof(CfxApi.cfx_pdf_print_settings_set_margin_type_delegate));
            CfxApi.cfx_pdf_print_settings_get_margin_type = (CfxApi.cfx_pdf_print_settings_get_margin_type_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_pdf_print_settings_get_margin_type, typeof(CfxApi.cfx_pdf_print_settings_get_margin_type_delegate));
            CfxApi.cfx_pdf_print_settings_set_header_footer_enabled = (CfxApi.cfx_pdf_print_settings_set_header_footer_enabled_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_pdf_print_settings_set_header_footer_enabled, typeof(CfxApi.cfx_pdf_print_settings_set_header_footer_enabled_delegate));
            CfxApi.cfx_pdf_print_settings_get_header_footer_enabled = (CfxApi.cfx_pdf_print_settings_get_header_footer_enabled_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_pdf_print_settings_get_header_footer_enabled, typeof(CfxApi.cfx_pdf_print_settings_get_header_footer_enabled_delegate));
            CfxApi.cfx_pdf_print_settings_set_selection_only = (CfxApi.cfx_pdf_print_settings_set_selection_only_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_pdf_print_settings_set_selection_only, typeof(CfxApi.cfx_pdf_print_settings_set_selection_only_delegate));
            CfxApi.cfx_pdf_print_settings_get_selection_only = (CfxApi.cfx_pdf_print_settings_get_selection_only_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_pdf_print_settings_get_selection_only, typeof(CfxApi.cfx_pdf_print_settings_get_selection_only_delegate));
            CfxApi.cfx_pdf_print_settings_set_landscape = (CfxApi.cfx_pdf_print_settings_set_landscape_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_pdf_print_settings_set_landscape, typeof(CfxApi.cfx_pdf_print_settings_set_landscape_delegate));
            CfxApi.cfx_pdf_print_settings_get_landscape = (CfxApi.cfx_pdf_print_settings_get_landscape_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_pdf_print_settings_get_landscape, typeof(CfxApi.cfx_pdf_print_settings_get_landscape_delegate));
            CfxApi.cfx_pdf_print_settings_set_backgrounds_enabled = (CfxApi.cfx_pdf_print_settings_set_backgrounds_enabled_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_pdf_print_settings_set_backgrounds_enabled, typeof(CfxApi.cfx_pdf_print_settings_set_backgrounds_enabled_delegate));
            CfxApi.cfx_pdf_print_settings_get_backgrounds_enabled = (CfxApi.cfx_pdf_print_settings_get_backgrounds_enabled_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_pdf_print_settings_get_backgrounds_enabled, typeof(CfxApi.cfx_pdf_print_settings_get_backgrounds_enabled_delegate));
        }

        private static bool CfxPointApiLoaded;
        internal static void LoadCfxPointApi() {
            if(CfxPointApiLoaded) return;
            CfxPointApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_point_ctor = (CfxApi.cfx_ctor_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_point_ctor, typeof(CfxApi.cfx_ctor_delegate));
            CfxApi.cfx_point_dtor = (CfxApi.cfx_dtor_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_point_dtor, typeof(CfxApi.cfx_dtor_delegate));
            CfxApi.cfx_point_set_x = (CfxApi.cfx_point_set_x_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_point_set_x, typeof(CfxApi.cfx_point_set_x_delegate));
            CfxApi.cfx_point_get_x = (CfxApi.cfx_point_get_x_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_point_get_x, typeof(CfxApi.cfx_point_get_x_delegate));
            CfxApi.cfx_point_set_y = (CfxApi.cfx_point_set_y_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_point_set_y, typeof(CfxApi.cfx_point_set_y_delegate));
            CfxApi.cfx_point_get_y = (CfxApi.cfx_point_get_y_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_point_get_y, typeof(CfxApi.cfx_point_get_y_delegate));
        }

        private static bool CfxPopupFeaturesApiLoaded;
        internal static void LoadCfxPopupFeaturesApi() {
            if(CfxPopupFeaturesApiLoaded) return;
            CfxPopupFeaturesApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_popup_features_ctor = (CfxApi.cfx_ctor_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_popup_features_ctor, typeof(CfxApi.cfx_ctor_delegate));
            CfxApi.cfx_popup_features_dtor = (CfxApi.cfx_dtor_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_popup_features_dtor, typeof(CfxApi.cfx_dtor_delegate));
            CfxApi.cfx_popup_features_set_x = (CfxApi.cfx_popup_features_set_x_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_popup_features_set_x, typeof(CfxApi.cfx_popup_features_set_x_delegate));
            CfxApi.cfx_popup_features_get_x = (CfxApi.cfx_popup_features_get_x_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_popup_features_get_x, typeof(CfxApi.cfx_popup_features_get_x_delegate));
            CfxApi.cfx_popup_features_set_xSet = (CfxApi.cfx_popup_features_set_xSet_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_popup_features_set_xSet, typeof(CfxApi.cfx_popup_features_set_xSet_delegate));
            CfxApi.cfx_popup_features_get_xSet = (CfxApi.cfx_popup_features_get_xSet_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_popup_features_get_xSet, typeof(CfxApi.cfx_popup_features_get_xSet_delegate));
            CfxApi.cfx_popup_features_set_y = (CfxApi.cfx_popup_features_set_y_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_popup_features_set_y, typeof(CfxApi.cfx_popup_features_set_y_delegate));
            CfxApi.cfx_popup_features_get_y = (CfxApi.cfx_popup_features_get_y_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_popup_features_get_y, typeof(CfxApi.cfx_popup_features_get_y_delegate));
            CfxApi.cfx_popup_features_set_ySet = (CfxApi.cfx_popup_features_set_ySet_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_popup_features_set_ySet, typeof(CfxApi.cfx_popup_features_set_ySet_delegate));
            CfxApi.cfx_popup_features_get_ySet = (CfxApi.cfx_popup_features_get_ySet_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_popup_features_get_ySet, typeof(CfxApi.cfx_popup_features_get_ySet_delegate));
            CfxApi.cfx_popup_features_set_width = (CfxApi.cfx_popup_features_set_width_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_popup_features_set_width, typeof(CfxApi.cfx_popup_features_set_width_delegate));
            CfxApi.cfx_popup_features_get_width = (CfxApi.cfx_popup_features_get_width_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_popup_features_get_width, typeof(CfxApi.cfx_popup_features_get_width_delegate));
            CfxApi.cfx_popup_features_set_widthSet = (CfxApi.cfx_popup_features_set_widthSet_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_popup_features_set_widthSet, typeof(CfxApi.cfx_popup_features_set_widthSet_delegate));
            CfxApi.cfx_popup_features_get_widthSet = (CfxApi.cfx_popup_features_get_widthSet_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_popup_features_get_widthSet, typeof(CfxApi.cfx_popup_features_get_widthSet_delegate));
            CfxApi.cfx_popup_features_set_height = (CfxApi.cfx_popup_features_set_height_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_popup_features_set_height, typeof(CfxApi.cfx_popup_features_set_height_delegate));
            CfxApi.cfx_popup_features_get_height = (CfxApi.cfx_popup_features_get_height_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_popup_features_get_height, typeof(CfxApi.cfx_popup_features_get_height_delegate));
            CfxApi.cfx_popup_features_set_heightSet = (CfxApi.cfx_popup_features_set_heightSet_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_popup_features_set_heightSet, typeof(CfxApi.cfx_popup_features_set_heightSet_delegate));
            CfxApi.cfx_popup_features_get_heightSet = (CfxApi.cfx_popup_features_get_heightSet_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_popup_features_get_heightSet, typeof(CfxApi.cfx_popup_features_get_heightSet_delegate));
            CfxApi.cfx_popup_features_set_menuBarVisible = (CfxApi.cfx_popup_features_set_menuBarVisible_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_popup_features_set_menuBarVisible, typeof(CfxApi.cfx_popup_features_set_menuBarVisible_delegate));
            CfxApi.cfx_popup_features_get_menuBarVisible = (CfxApi.cfx_popup_features_get_menuBarVisible_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_popup_features_get_menuBarVisible, typeof(CfxApi.cfx_popup_features_get_menuBarVisible_delegate));
            CfxApi.cfx_popup_features_set_statusBarVisible = (CfxApi.cfx_popup_features_set_statusBarVisible_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_popup_features_set_statusBarVisible, typeof(CfxApi.cfx_popup_features_set_statusBarVisible_delegate));
            CfxApi.cfx_popup_features_get_statusBarVisible = (CfxApi.cfx_popup_features_get_statusBarVisible_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_popup_features_get_statusBarVisible, typeof(CfxApi.cfx_popup_features_get_statusBarVisible_delegate));
            CfxApi.cfx_popup_features_set_toolBarVisible = (CfxApi.cfx_popup_features_set_toolBarVisible_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_popup_features_set_toolBarVisible, typeof(CfxApi.cfx_popup_features_set_toolBarVisible_delegate));
            CfxApi.cfx_popup_features_get_toolBarVisible = (CfxApi.cfx_popup_features_get_toolBarVisible_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_popup_features_get_toolBarVisible, typeof(CfxApi.cfx_popup_features_get_toolBarVisible_delegate));
            CfxApi.cfx_popup_features_set_locationBarVisible = (CfxApi.cfx_popup_features_set_locationBarVisible_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_popup_features_set_locationBarVisible, typeof(CfxApi.cfx_popup_features_set_locationBarVisible_delegate));
            CfxApi.cfx_popup_features_get_locationBarVisible = (CfxApi.cfx_popup_features_get_locationBarVisible_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_popup_features_get_locationBarVisible, typeof(CfxApi.cfx_popup_features_get_locationBarVisible_delegate));
            CfxApi.cfx_popup_features_set_scrollbarsVisible = (CfxApi.cfx_popup_features_set_scrollbarsVisible_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_popup_features_set_scrollbarsVisible, typeof(CfxApi.cfx_popup_features_set_scrollbarsVisible_delegate));
            CfxApi.cfx_popup_features_get_scrollbarsVisible = (CfxApi.cfx_popup_features_get_scrollbarsVisible_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_popup_features_get_scrollbarsVisible, typeof(CfxApi.cfx_popup_features_get_scrollbarsVisible_delegate));
            CfxApi.cfx_popup_features_set_resizable = (CfxApi.cfx_popup_features_set_resizable_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_popup_features_set_resizable, typeof(CfxApi.cfx_popup_features_set_resizable_delegate));
            CfxApi.cfx_popup_features_get_resizable = (CfxApi.cfx_popup_features_get_resizable_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_popup_features_get_resizable, typeof(CfxApi.cfx_popup_features_get_resizable_delegate));
            CfxApi.cfx_popup_features_set_fullscreen = (CfxApi.cfx_popup_features_set_fullscreen_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_popup_features_set_fullscreen, typeof(CfxApi.cfx_popup_features_set_fullscreen_delegate));
            CfxApi.cfx_popup_features_get_fullscreen = (CfxApi.cfx_popup_features_get_fullscreen_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_popup_features_get_fullscreen, typeof(CfxApi.cfx_popup_features_get_fullscreen_delegate));
            CfxApi.cfx_popup_features_set_dialog = (CfxApi.cfx_popup_features_set_dialog_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_popup_features_set_dialog, typeof(CfxApi.cfx_popup_features_set_dialog_delegate));
            CfxApi.cfx_popup_features_get_dialog = (CfxApi.cfx_popup_features_get_dialog_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_popup_features_get_dialog, typeof(CfxApi.cfx_popup_features_get_dialog_delegate));
            CfxApi.cfx_popup_features_set_additionalFeatures = (CfxApi.cfx_popup_features_set_additionalFeatures_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_popup_features_set_additionalFeatures, typeof(CfxApi.cfx_popup_features_set_additionalFeatures_delegate));
            CfxApi.cfx_popup_features_get_additionalFeatures = (CfxApi.cfx_popup_features_get_additionalFeatures_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_popup_features_get_additionalFeatures, typeof(CfxApi.cfx_popup_features_get_additionalFeatures_delegate));
        }

        private static bool CfxPostDataApiLoaded;
        internal static void LoadCfxPostDataApi() {
            if(CfxPostDataApiLoaded) return;
            CfxPostDataApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_post_data_create = (CfxApi.cfx_post_data_create_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_post_data_create, typeof(CfxApi.cfx_post_data_create_delegate));
            CfxApi.cfx_post_data_is_read_only = (CfxApi.cfx_post_data_is_read_only_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_post_data_is_read_only, typeof(CfxApi.cfx_post_data_is_read_only_delegate));
            CfxApi.cfx_post_data_has_excluded_elements = (CfxApi.cfx_post_data_has_excluded_elements_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_post_data_has_excluded_elements, typeof(CfxApi.cfx_post_data_has_excluded_elements_delegate));
            CfxApi.cfx_post_data_get_element_count = (CfxApi.cfx_post_data_get_element_count_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_post_data_get_element_count, typeof(CfxApi.cfx_post_data_get_element_count_delegate));
            CfxApi.cfx_post_data_get_elements = (CfxApi.cfx_post_data_get_elements_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_post_data_get_elements, typeof(CfxApi.cfx_post_data_get_elements_delegate));
            CfxApi.cfx_post_data_remove_element = (CfxApi.cfx_post_data_remove_element_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_post_data_remove_element, typeof(CfxApi.cfx_post_data_remove_element_delegate));
            CfxApi.cfx_post_data_add_element = (CfxApi.cfx_post_data_add_element_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_post_data_add_element, typeof(CfxApi.cfx_post_data_add_element_delegate));
            CfxApi.cfx_post_data_remove_elements = (CfxApi.cfx_post_data_remove_elements_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_post_data_remove_elements, typeof(CfxApi.cfx_post_data_remove_elements_delegate));
        }

        private static bool CfxPostDataElementApiLoaded;
        internal static void LoadCfxPostDataElementApi() {
            if(CfxPostDataElementApiLoaded) return;
            CfxPostDataElementApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_post_data_element_create = (CfxApi.cfx_post_data_element_create_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_post_data_element_create, typeof(CfxApi.cfx_post_data_element_create_delegate));
            CfxApi.cfx_post_data_element_is_read_only = (CfxApi.cfx_post_data_element_is_read_only_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_post_data_element_is_read_only, typeof(CfxApi.cfx_post_data_element_is_read_only_delegate));
            CfxApi.cfx_post_data_element_set_to_empty = (CfxApi.cfx_post_data_element_set_to_empty_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_post_data_element_set_to_empty, typeof(CfxApi.cfx_post_data_element_set_to_empty_delegate));
            CfxApi.cfx_post_data_element_set_to_file = (CfxApi.cfx_post_data_element_set_to_file_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_post_data_element_set_to_file, typeof(CfxApi.cfx_post_data_element_set_to_file_delegate));
            CfxApi.cfx_post_data_element_set_to_bytes = (CfxApi.cfx_post_data_element_set_to_bytes_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_post_data_element_set_to_bytes, typeof(CfxApi.cfx_post_data_element_set_to_bytes_delegate));
            CfxApi.cfx_post_data_element_get_type = (CfxApi.cfx_post_data_element_get_type_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_post_data_element_get_type, typeof(CfxApi.cfx_post_data_element_get_type_delegate));
            CfxApi.cfx_post_data_element_get_file = (CfxApi.cfx_post_data_element_get_file_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_post_data_element_get_file, typeof(CfxApi.cfx_post_data_element_get_file_delegate));
            CfxApi.cfx_post_data_element_get_bytes_count = (CfxApi.cfx_post_data_element_get_bytes_count_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_post_data_element_get_bytes_count, typeof(CfxApi.cfx_post_data_element_get_bytes_count_delegate));
            CfxApi.cfx_post_data_element_get_bytes = (CfxApi.cfx_post_data_element_get_bytes_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_post_data_element_get_bytes, typeof(CfxApi.cfx_post_data_element_get_bytes_delegate));
        }

        private static bool CfxPrintDialogCallbackApiLoaded;
        internal static void LoadCfxPrintDialogCallbackApi() {
            if(CfxPrintDialogCallbackApiLoaded) return;
            CfxPrintDialogCallbackApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_print_dialog_callback_cont = (CfxApi.cfx_print_dialog_callback_cont_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_print_dialog_callback_cont, typeof(CfxApi.cfx_print_dialog_callback_cont_delegate));
            CfxApi.cfx_print_dialog_callback_cancel = (CfxApi.cfx_print_dialog_callback_cancel_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_print_dialog_callback_cancel, typeof(CfxApi.cfx_print_dialog_callback_cancel_delegate));
        }

        private static bool CfxPrintHandlerApiLoaded;
        internal static void LoadCfxPrintHandlerApi() {
            if(CfxPrintHandlerApiLoaded) return;
            CfxPrintHandlerApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_print_handler_ctor = (CfxApi.cfx_ctor_with_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_print_handler_ctor, typeof(CfxApi.cfx_ctor_with_gc_handle_delegate));
            CfxApi.cfx_print_handler_get_gc_handle = (CfxApi.cfx_get_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_print_handler_get_gc_handle, typeof(CfxApi.cfx_get_gc_handle_delegate));
            CfxApi.cfx_print_handler_set_managed_callback = (CfxApi.cfx_set_callback_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_print_handler_set_managed_callback, typeof(CfxApi.cfx_set_callback_delegate));
        }

        private static bool CfxPrintJobCallbackApiLoaded;
        internal static void LoadCfxPrintJobCallbackApi() {
            if(CfxPrintJobCallbackApiLoaded) return;
            CfxPrintJobCallbackApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_print_job_callback_cont = (CfxApi.cfx_print_job_callback_cont_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_print_job_callback_cont, typeof(CfxApi.cfx_print_job_callback_cont_delegate));
        }

        private static bool CfxPrintSettingsApiLoaded;
        internal static void LoadCfxPrintSettingsApi() {
            if(CfxPrintSettingsApiLoaded) return;
            CfxPrintSettingsApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_print_settings_create = (CfxApi.cfx_print_settings_create_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_print_settings_create, typeof(CfxApi.cfx_print_settings_create_delegate));
            CfxApi.cfx_print_settings_is_valid = (CfxApi.cfx_print_settings_is_valid_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_print_settings_is_valid, typeof(CfxApi.cfx_print_settings_is_valid_delegate));
            CfxApi.cfx_print_settings_is_read_only = (CfxApi.cfx_print_settings_is_read_only_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_print_settings_is_read_only, typeof(CfxApi.cfx_print_settings_is_read_only_delegate));
            CfxApi.cfx_print_settings_copy = (CfxApi.cfx_print_settings_copy_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_print_settings_copy, typeof(CfxApi.cfx_print_settings_copy_delegate));
            CfxApi.cfx_print_settings_set_orientation = (CfxApi.cfx_print_settings_set_orientation_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_print_settings_set_orientation, typeof(CfxApi.cfx_print_settings_set_orientation_delegate));
            CfxApi.cfx_print_settings_is_landscape = (CfxApi.cfx_print_settings_is_landscape_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_print_settings_is_landscape, typeof(CfxApi.cfx_print_settings_is_landscape_delegate));
            CfxApi.cfx_print_settings_set_printer_printable_area = (CfxApi.cfx_print_settings_set_printer_printable_area_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_print_settings_set_printer_printable_area, typeof(CfxApi.cfx_print_settings_set_printer_printable_area_delegate));
            CfxApi.cfx_print_settings_set_device_name = (CfxApi.cfx_print_settings_set_device_name_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_print_settings_set_device_name, typeof(CfxApi.cfx_print_settings_set_device_name_delegate));
            CfxApi.cfx_print_settings_get_device_name = (CfxApi.cfx_print_settings_get_device_name_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_print_settings_get_device_name, typeof(CfxApi.cfx_print_settings_get_device_name_delegate));
            CfxApi.cfx_print_settings_set_dpi = (CfxApi.cfx_print_settings_set_dpi_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_print_settings_set_dpi, typeof(CfxApi.cfx_print_settings_set_dpi_delegate));
            CfxApi.cfx_print_settings_get_dpi = (CfxApi.cfx_print_settings_get_dpi_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_print_settings_get_dpi, typeof(CfxApi.cfx_print_settings_get_dpi_delegate));
            CfxApi.cfx_print_settings_set_page_ranges = (CfxApi.cfx_print_settings_set_page_ranges_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_print_settings_set_page_ranges, typeof(CfxApi.cfx_print_settings_set_page_ranges_delegate));
            CfxApi.cfx_print_settings_get_page_ranges_count = (CfxApi.cfx_print_settings_get_page_ranges_count_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_print_settings_get_page_ranges_count, typeof(CfxApi.cfx_print_settings_get_page_ranges_count_delegate));
            CfxApi.cfx_print_settings_get_page_ranges = (CfxApi.cfx_print_settings_get_page_ranges_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_print_settings_get_page_ranges, typeof(CfxApi.cfx_print_settings_get_page_ranges_delegate));
            CfxApi.cfx_print_settings_set_selection_only = (CfxApi.cfx_print_settings_set_selection_only_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_print_settings_set_selection_only, typeof(CfxApi.cfx_print_settings_set_selection_only_delegate));
            CfxApi.cfx_print_settings_is_selection_only = (CfxApi.cfx_print_settings_is_selection_only_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_print_settings_is_selection_only, typeof(CfxApi.cfx_print_settings_is_selection_only_delegate));
            CfxApi.cfx_print_settings_set_collate = (CfxApi.cfx_print_settings_set_collate_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_print_settings_set_collate, typeof(CfxApi.cfx_print_settings_set_collate_delegate));
            CfxApi.cfx_print_settings_will_collate = (CfxApi.cfx_print_settings_will_collate_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_print_settings_will_collate, typeof(CfxApi.cfx_print_settings_will_collate_delegate));
            CfxApi.cfx_print_settings_set_color_model = (CfxApi.cfx_print_settings_set_color_model_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_print_settings_set_color_model, typeof(CfxApi.cfx_print_settings_set_color_model_delegate));
            CfxApi.cfx_print_settings_get_color_model = (CfxApi.cfx_print_settings_get_color_model_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_print_settings_get_color_model, typeof(CfxApi.cfx_print_settings_get_color_model_delegate));
            CfxApi.cfx_print_settings_set_copies = (CfxApi.cfx_print_settings_set_copies_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_print_settings_set_copies, typeof(CfxApi.cfx_print_settings_set_copies_delegate));
            CfxApi.cfx_print_settings_get_copies = (CfxApi.cfx_print_settings_get_copies_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_print_settings_get_copies, typeof(CfxApi.cfx_print_settings_get_copies_delegate));
            CfxApi.cfx_print_settings_set_duplex_mode = (CfxApi.cfx_print_settings_set_duplex_mode_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_print_settings_set_duplex_mode, typeof(CfxApi.cfx_print_settings_set_duplex_mode_delegate));
            CfxApi.cfx_print_settings_get_duplex_mode = (CfxApi.cfx_print_settings_get_duplex_mode_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_print_settings_get_duplex_mode, typeof(CfxApi.cfx_print_settings_get_duplex_mode_delegate));
        }

        private static bool CfxProcessMessageApiLoaded;
        internal static void LoadCfxProcessMessageApi() {
            if(CfxProcessMessageApiLoaded) return;
            CfxProcessMessageApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_process_message_create = (CfxApi.cfx_process_message_create_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_process_message_create, typeof(CfxApi.cfx_process_message_create_delegate));
            CfxApi.cfx_process_message_is_valid = (CfxApi.cfx_process_message_is_valid_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_process_message_is_valid, typeof(CfxApi.cfx_process_message_is_valid_delegate));
            CfxApi.cfx_process_message_is_read_only = (CfxApi.cfx_process_message_is_read_only_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_process_message_is_read_only, typeof(CfxApi.cfx_process_message_is_read_only_delegate));
            CfxApi.cfx_process_message_copy = (CfxApi.cfx_process_message_copy_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_process_message_copy, typeof(CfxApi.cfx_process_message_copy_delegate));
            CfxApi.cfx_process_message_get_name = (CfxApi.cfx_process_message_get_name_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_process_message_get_name, typeof(CfxApi.cfx_process_message_get_name_delegate));
            CfxApi.cfx_process_message_get_argument_list = (CfxApi.cfx_process_message_get_argument_list_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_process_message_get_argument_list, typeof(CfxApi.cfx_process_message_get_argument_list_delegate));
        }

        private static bool CfxReadHandlerApiLoaded;
        internal static void LoadCfxReadHandlerApi() {
            if(CfxReadHandlerApiLoaded) return;
            CfxReadHandlerApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_read_handler_ctor = (CfxApi.cfx_ctor_with_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_read_handler_ctor, typeof(CfxApi.cfx_ctor_with_gc_handle_delegate));
            CfxApi.cfx_read_handler_get_gc_handle = (CfxApi.cfx_get_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_read_handler_get_gc_handle, typeof(CfxApi.cfx_get_gc_handle_delegate));
            CfxApi.cfx_read_handler_set_managed_callback = (CfxApi.cfx_set_callback_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_read_handler_set_managed_callback, typeof(CfxApi.cfx_set_callback_delegate));
        }

        private static bool CfxRectApiLoaded;
        internal static void LoadCfxRectApi() {
            if(CfxRectApiLoaded) return;
            CfxRectApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_rect_ctor = (CfxApi.cfx_ctor_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_rect_ctor, typeof(CfxApi.cfx_ctor_delegate));
            CfxApi.cfx_rect_dtor = (CfxApi.cfx_dtor_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_rect_dtor, typeof(CfxApi.cfx_dtor_delegate));
            CfxApi.cfx_rect_set_x = (CfxApi.cfx_rect_set_x_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_rect_set_x, typeof(CfxApi.cfx_rect_set_x_delegate));
            CfxApi.cfx_rect_get_x = (CfxApi.cfx_rect_get_x_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_rect_get_x, typeof(CfxApi.cfx_rect_get_x_delegate));
            CfxApi.cfx_rect_set_y = (CfxApi.cfx_rect_set_y_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_rect_set_y, typeof(CfxApi.cfx_rect_set_y_delegate));
            CfxApi.cfx_rect_get_y = (CfxApi.cfx_rect_get_y_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_rect_get_y, typeof(CfxApi.cfx_rect_get_y_delegate));
            CfxApi.cfx_rect_set_width = (CfxApi.cfx_rect_set_width_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_rect_set_width, typeof(CfxApi.cfx_rect_set_width_delegate));
            CfxApi.cfx_rect_get_width = (CfxApi.cfx_rect_get_width_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_rect_get_width, typeof(CfxApi.cfx_rect_get_width_delegate));
            CfxApi.cfx_rect_set_height = (CfxApi.cfx_rect_set_height_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_rect_set_height, typeof(CfxApi.cfx_rect_set_height_delegate));
            CfxApi.cfx_rect_get_height = (CfxApi.cfx_rect_get_height_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_rect_get_height, typeof(CfxApi.cfx_rect_get_height_delegate));
        }

        private static bool CfxRenderHandlerApiLoaded;
        internal static void LoadCfxRenderHandlerApi() {
            if(CfxRenderHandlerApiLoaded) return;
            CfxRenderHandlerApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_render_handler_ctor = (CfxApi.cfx_ctor_with_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_render_handler_ctor, typeof(CfxApi.cfx_ctor_with_gc_handle_delegate));
            CfxApi.cfx_render_handler_get_gc_handle = (CfxApi.cfx_get_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_render_handler_get_gc_handle, typeof(CfxApi.cfx_get_gc_handle_delegate));
            CfxApi.cfx_render_handler_set_managed_callback = (CfxApi.cfx_set_callback_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_render_handler_set_managed_callback, typeof(CfxApi.cfx_set_callback_delegate));
        }

        private static bool CfxRenderProcessHandlerApiLoaded;
        internal static void LoadCfxRenderProcessHandlerApi() {
            if(CfxRenderProcessHandlerApiLoaded) return;
            CfxRenderProcessHandlerApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_render_process_handler_ctor = (CfxApi.cfx_ctor_with_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_render_process_handler_ctor, typeof(CfxApi.cfx_ctor_with_gc_handle_delegate));
            CfxApi.cfx_render_process_handler_get_gc_handle = (CfxApi.cfx_get_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_render_process_handler_get_gc_handle, typeof(CfxApi.cfx_get_gc_handle_delegate));
            CfxApi.cfx_render_process_handler_set_managed_callback = (CfxApi.cfx_set_callback_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_render_process_handler_set_managed_callback, typeof(CfxApi.cfx_set_callback_delegate));
        }

        private static bool CfxRequestApiLoaded;
        internal static void LoadCfxRequestApi() {
            if(CfxRequestApiLoaded) return;
            CfxRequestApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_request_create = (CfxApi.cfx_request_create_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_create, typeof(CfxApi.cfx_request_create_delegate));
            CfxApi.cfx_request_is_read_only = (CfxApi.cfx_request_is_read_only_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_is_read_only, typeof(CfxApi.cfx_request_is_read_only_delegate));
            CfxApi.cfx_request_get_url = (CfxApi.cfx_request_get_url_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_get_url, typeof(CfxApi.cfx_request_get_url_delegate));
            CfxApi.cfx_request_set_url = (CfxApi.cfx_request_set_url_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_set_url, typeof(CfxApi.cfx_request_set_url_delegate));
            CfxApi.cfx_request_get_method = (CfxApi.cfx_request_get_method_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_get_method, typeof(CfxApi.cfx_request_get_method_delegate));
            CfxApi.cfx_request_set_method = (CfxApi.cfx_request_set_method_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_set_method, typeof(CfxApi.cfx_request_set_method_delegate));
            CfxApi.cfx_request_set_referrer = (CfxApi.cfx_request_set_referrer_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_set_referrer, typeof(CfxApi.cfx_request_set_referrer_delegate));
            CfxApi.cfx_request_get_referrer_url = (CfxApi.cfx_request_get_referrer_url_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_get_referrer_url, typeof(CfxApi.cfx_request_get_referrer_url_delegate));
            CfxApi.cfx_request_get_referrer_policy = (CfxApi.cfx_request_get_referrer_policy_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_get_referrer_policy, typeof(CfxApi.cfx_request_get_referrer_policy_delegate));
            CfxApi.cfx_request_get_post_data = (CfxApi.cfx_request_get_post_data_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_get_post_data, typeof(CfxApi.cfx_request_get_post_data_delegate));
            CfxApi.cfx_request_set_post_data = (CfxApi.cfx_request_set_post_data_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_set_post_data, typeof(CfxApi.cfx_request_set_post_data_delegate));
            CfxApi.cfx_request_get_header_map = (CfxApi.cfx_request_get_header_map_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_get_header_map, typeof(CfxApi.cfx_request_get_header_map_delegate));
            CfxApi.cfx_request_set_header_map = (CfxApi.cfx_request_set_header_map_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_set_header_map, typeof(CfxApi.cfx_request_set_header_map_delegate));
            CfxApi.cfx_request_set = (CfxApi.cfx_request_set_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_set, typeof(CfxApi.cfx_request_set_delegate));
            CfxApi.cfx_request_get_flags = (CfxApi.cfx_request_get_flags_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_get_flags, typeof(CfxApi.cfx_request_get_flags_delegate));
            CfxApi.cfx_request_set_flags = (CfxApi.cfx_request_set_flags_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_set_flags, typeof(CfxApi.cfx_request_set_flags_delegate));
            CfxApi.cfx_request_get_first_party_for_cookies = (CfxApi.cfx_request_get_first_party_for_cookies_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_get_first_party_for_cookies, typeof(CfxApi.cfx_request_get_first_party_for_cookies_delegate));
            CfxApi.cfx_request_set_first_party_for_cookies = (CfxApi.cfx_request_set_first_party_for_cookies_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_set_first_party_for_cookies, typeof(CfxApi.cfx_request_set_first_party_for_cookies_delegate));
            CfxApi.cfx_request_get_resource_type = (CfxApi.cfx_request_get_resource_type_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_get_resource_type, typeof(CfxApi.cfx_request_get_resource_type_delegate));
            CfxApi.cfx_request_get_transition_type = (CfxApi.cfx_request_get_transition_type_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_get_transition_type, typeof(CfxApi.cfx_request_get_transition_type_delegate));
            CfxApi.cfx_request_get_identifier = (CfxApi.cfx_request_get_identifier_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_get_identifier, typeof(CfxApi.cfx_request_get_identifier_delegate));
        }

        private static bool CfxRequestCallbackApiLoaded;
        internal static void LoadCfxRequestCallbackApi() {
            if(CfxRequestCallbackApiLoaded) return;
            CfxRequestCallbackApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_request_callback_cont = (CfxApi.cfx_request_callback_cont_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_callback_cont, typeof(CfxApi.cfx_request_callback_cont_delegate));
            CfxApi.cfx_request_callback_cancel = (CfxApi.cfx_request_callback_cancel_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_callback_cancel, typeof(CfxApi.cfx_request_callback_cancel_delegate));
        }

        private static bool CfxRequestContextApiLoaded;
        internal static void LoadCfxRequestContextApi() {
            if(CfxRequestContextApiLoaded) return;
            CfxRequestContextApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_request_context_get_global_context = (CfxApi.cfx_request_context_get_global_context_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_context_get_global_context, typeof(CfxApi.cfx_request_context_get_global_context_delegate));
            CfxApi.cfx_request_context_create_context = (CfxApi.cfx_request_context_create_context_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_context_create_context, typeof(CfxApi.cfx_request_context_create_context_delegate));
            CfxApi.cfx_request_context_is_same = (CfxApi.cfx_request_context_is_same_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_context_is_same, typeof(CfxApi.cfx_request_context_is_same_delegate));
            CfxApi.cfx_request_context_is_sharing_with = (CfxApi.cfx_request_context_is_sharing_with_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_context_is_sharing_with, typeof(CfxApi.cfx_request_context_is_sharing_with_delegate));
            CfxApi.cfx_request_context_is_global = (CfxApi.cfx_request_context_is_global_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_context_is_global, typeof(CfxApi.cfx_request_context_is_global_delegate));
            CfxApi.cfx_request_context_get_handler = (CfxApi.cfx_request_context_get_handler_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_context_get_handler, typeof(CfxApi.cfx_request_context_get_handler_delegate));
            CfxApi.cfx_request_context_get_cache_path = (CfxApi.cfx_request_context_get_cache_path_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_context_get_cache_path, typeof(CfxApi.cfx_request_context_get_cache_path_delegate));
            CfxApi.cfx_request_context_get_default_cookie_manager = (CfxApi.cfx_request_context_get_default_cookie_manager_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_context_get_default_cookie_manager, typeof(CfxApi.cfx_request_context_get_default_cookie_manager_delegate));
            CfxApi.cfx_request_context_register_scheme_handler_factory = (CfxApi.cfx_request_context_register_scheme_handler_factory_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_context_register_scheme_handler_factory, typeof(CfxApi.cfx_request_context_register_scheme_handler_factory_delegate));
            CfxApi.cfx_request_context_clear_scheme_handler_factories = (CfxApi.cfx_request_context_clear_scheme_handler_factories_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_context_clear_scheme_handler_factories, typeof(CfxApi.cfx_request_context_clear_scheme_handler_factories_delegate));
            CfxApi.cfx_request_context_purge_plugin_list_cache = (CfxApi.cfx_request_context_purge_plugin_list_cache_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_context_purge_plugin_list_cache, typeof(CfxApi.cfx_request_context_purge_plugin_list_cache_delegate));
            CfxApi.cfx_request_context_has_preference = (CfxApi.cfx_request_context_has_preference_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_context_has_preference, typeof(CfxApi.cfx_request_context_has_preference_delegate));
            CfxApi.cfx_request_context_get_preference = (CfxApi.cfx_request_context_get_preference_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_context_get_preference, typeof(CfxApi.cfx_request_context_get_preference_delegate));
            CfxApi.cfx_request_context_get_all_preferences = (CfxApi.cfx_request_context_get_all_preferences_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_context_get_all_preferences, typeof(CfxApi.cfx_request_context_get_all_preferences_delegate));
            CfxApi.cfx_request_context_can_set_preference = (CfxApi.cfx_request_context_can_set_preference_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_context_can_set_preference, typeof(CfxApi.cfx_request_context_can_set_preference_delegate));
            CfxApi.cfx_request_context_set_preference = (CfxApi.cfx_request_context_set_preference_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_context_set_preference, typeof(CfxApi.cfx_request_context_set_preference_delegate));
            CfxApi.cfx_request_context_clear_certificate_exceptions = (CfxApi.cfx_request_context_clear_certificate_exceptions_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_context_clear_certificate_exceptions, typeof(CfxApi.cfx_request_context_clear_certificate_exceptions_delegate));
            CfxApi.cfx_request_context_close_all_connections = (CfxApi.cfx_request_context_close_all_connections_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_context_close_all_connections, typeof(CfxApi.cfx_request_context_close_all_connections_delegate));
            CfxApi.cfx_request_context_resolve_host = (CfxApi.cfx_request_context_resolve_host_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_context_resolve_host, typeof(CfxApi.cfx_request_context_resolve_host_delegate));
            CfxApi.cfx_request_context_resolve_host_cached = (CfxApi.cfx_request_context_resolve_host_cached_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_context_resolve_host_cached, typeof(CfxApi.cfx_request_context_resolve_host_cached_delegate));
        }

        private static bool CfxRequestContextHandlerApiLoaded;
        internal static void LoadCfxRequestContextHandlerApi() {
            if(CfxRequestContextHandlerApiLoaded) return;
            CfxRequestContextHandlerApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_request_context_handler_ctor = (CfxApi.cfx_ctor_with_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_context_handler_ctor, typeof(CfxApi.cfx_ctor_with_gc_handle_delegate));
            CfxApi.cfx_request_context_handler_get_gc_handle = (CfxApi.cfx_get_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_context_handler_get_gc_handle, typeof(CfxApi.cfx_get_gc_handle_delegate));
            CfxApi.cfx_request_context_handler_set_managed_callback = (CfxApi.cfx_set_callback_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_context_handler_set_managed_callback, typeof(CfxApi.cfx_set_callback_delegate));
        }

        private static bool CfxRequestContextSettingsApiLoaded;
        internal static void LoadCfxRequestContextSettingsApi() {
            if(CfxRequestContextSettingsApiLoaded) return;
            CfxRequestContextSettingsApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_request_context_settings_ctor = (CfxApi.cfx_ctor_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_context_settings_ctor, typeof(CfxApi.cfx_ctor_delegate));
            CfxApi.cfx_request_context_settings_dtor = (CfxApi.cfx_dtor_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_context_settings_dtor, typeof(CfxApi.cfx_dtor_delegate));
            CfxApi.cfx_request_context_settings_set_cache_path = (CfxApi.cfx_request_context_settings_set_cache_path_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_context_settings_set_cache_path, typeof(CfxApi.cfx_request_context_settings_set_cache_path_delegate));
            CfxApi.cfx_request_context_settings_get_cache_path = (CfxApi.cfx_request_context_settings_get_cache_path_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_context_settings_get_cache_path, typeof(CfxApi.cfx_request_context_settings_get_cache_path_delegate));
            CfxApi.cfx_request_context_settings_set_persist_session_cookies = (CfxApi.cfx_request_context_settings_set_persist_session_cookies_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_context_settings_set_persist_session_cookies, typeof(CfxApi.cfx_request_context_settings_set_persist_session_cookies_delegate));
            CfxApi.cfx_request_context_settings_get_persist_session_cookies = (CfxApi.cfx_request_context_settings_get_persist_session_cookies_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_context_settings_get_persist_session_cookies, typeof(CfxApi.cfx_request_context_settings_get_persist_session_cookies_delegate));
            CfxApi.cfx_request_context_settings_set_persist_user_preferences = (CfxApi.cfx_request_context_settings_set_persist_user_preferences_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_context_settings_set_persist_user_preferences, typeof(CfxApi.cfx_request_context_settings_set_persist_user_preferences_delegate));
            CfxApi.cfx_request_context_settings_get_persist_user_preferences = (CfxApi.cfx_request_context_settings_get_persist_user_preferences_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_context_settings_get_persist_user_preferences, typeof(CfxApi.cfx_request_context_settings_get_persist_user_preferences_delegate));
            CfxApi.cfx_request_context_settings_set_ignore_certificate_errors = (CfxApi.cfx_request_context_settings_set_ignore_certificate_errors_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_context_settings_set_ignore_certificate_errors, typeof(CfxApi.cfx_request_context_settings_set_ignore_certificate_errors_delegate));
            CfxApi.cfx_request_context_settings_get_ignore_certificate_errors = (CfxApi.cfx_request_context_settings_get_ignore_certificate_errors_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_context_settings_get_ignore_certificate_errors, typeof(CfxApi.cfx_request_context_settings_get_ignore_certificate_errors_delegate));
            CfxApi.cfx_request_context_settings_set_accept_language_list = (CfxApi.cfx_request_context_settings_set_accept_language_list_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_context_settings_set_accept_language_list, typeof(CfxApi.cfx_request_context_settings_set_accept_language_list_delegate));
            CfxApi.cfx_request_context_settings_get_accept_language_list = (CfxApi.cfx_request_context_settings_get_accept_language_list_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_context_settings_get_accept_language_list, typeof(CfxApi.cfx_request_context_settings_get_accept_language_list_delegate));
        }

        private static bool CfxRequestHandlerApiLoaded;
        internal static void LoadCfxRequestHandlerApi() {
            if(CfxRequestHandlerApiLoaded) return;
            CfxRequestHandlerApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_request_handler_ctor = (CfxApi.cfx_ctor_with_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_handler_ctor, typeof(CfxApi.cfx_ctor_with_gc_handle_delegate));
            CfxApi.cfx_request_handler_get_gc_handle = (CfxApi.cfx_get_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_handler_get_gc_handle, typeof(CfxApi.cfx_get_gc_handle_delegate));
            CfxApi.cfx_request_handler_set_managed_callback = (CfxApi.cfx_set_callback_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_handler_set_managed_callback, typeof(CfxApi.cfx_set_callback_delegate));
        }

        private static bool CfxResolveCallbackApiLoaded;
        internal static void LoadCfxResolveCallbackApi() {
            if(CfxResolveCallbackApiLoaded) return;
            CfxResolveCallbackApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_resolve_callback_ctor = (CfxApi.cfx_ctor_with_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_resolve_callback_ctor, typeof(CfxApi.cfx_ctor_with_gc_handle_delegate));
            CfxApi.cfx_resolve_callback_get_gc_handle = (CfxApi.cfx_get_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_resolve_callback_get_gc_handle, typeof(CfxApi.cfx_get_gc_handle_delegate));
            CfxApi.cfx_resolve_callback_set_managed_callback = (CfxApi.cfx_set_callback_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_resolve_callback_set_managed_callback, typeof(CfxApi.cfx_set_callback_delegate));
        }

        private static bool CfxResourceBundleApiLoaded;
        internal static void LoadCfxResourceBundleApi() {
            if(CfxResourceBundleApiLoaded) return;
            CfxResourceBundleApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_resource_bundle_get_global = (CfxApi.cfx_resource_bundle_get_global_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_resource_bundle_get_global, typeof(CfxApi.cfx_resource_bundle_get_global_delegate));
            CfxApi.cfx_resource_bundle_get_localized_string = (CfxApi.cfx_resource_bundle_get_localized_string_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_resource_bundle_get_localized_string, typeof(CfxApi.cfx_resource_bundle_get_localized_string_delegate));
            CfxApi.cfx_resource_bundle_get_data_resource = (CfxApi.cfx_resource_bundle_get_data_resource_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_resource_bundle_get_data_resource, typeof(CfxApi.cfx_resource_bundle_get_data_resource_delegate));
            CfxApi.cfx_resource_bundle_get_data_resource_for_scale = (CfxApi.cfx_resource_bundle_get_data_resource_for_scale_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_resource_bundle_get_data_resource_for_scale, typeof(CfxApi.cfx_resource_bundle_get_data_resource_for_scale_delegate));
        }

        private static bool CfxResourceBundleHandlerApiLoaded;
        internal static void LoadCfxResourceBundleHandlerApi() {
            if(CfxResourceBundleHandlerApiLoaded) return;
            CfxResourceBundleHandlerApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_resource_bundle_handler_ctor = (CfxApi.cfx_ctor_with_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_resource_bundle_handler_ctor, typeof(CfxApi.cfx_ctor_with_gc_handle_delegate));
            CfxApi.cfx_resource_bundle_handler_get_gc_handle = (CfxApi.cfx_get_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_resource_bundle_handler_get_gc_handle, typeof(CfxApi.cfx_get_gc_handle_delegate));
            CfxApi.cfx_resource_bundle_handler_set_managed_callback = (CfxApi.cfx_set_callback_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_resource_bundle_handler_set_managed_callback, typeof(CfxApi.cfx_set_callback_delegate));
        }

        private static bool CfxResourceHandlerApiLoaded;
        internal static void LoadCfxResourceHandlerApi() {
            if(CfxResourceHandlerApiLoaded) return;
            CfxResourceHandlerApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_resource_handler_ctor = (CfxApi.cfx_ctor_with_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_resource_handler_ctor, typeof(CfxApi.cfx_ctor_with_gc_handle_delegate));
            CfxApi.cfx_resource_handler_get_gc_handle = (CfxApi.cfx_get_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_resource_handler_get_gc_handle, typeof(CfxApi.cfx_get_gc_handle_delegate));
            CfxApi.cfx_resource_handler_set_managed_callback = (CfxApi.cfx_set_callback_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_resource_handler_set_managed_callback, typeof(CfxApi.cfx_set_callback_delegate));
        }

        private static bool CfxResponseApiLoaded;
        internal static void LoadCfxResponseApi() {
            if(CfxResponseApiLoaded) return;
            CfxResponseApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_response_create = (CfxApi.cfx_response_create_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_response_create, typeof(CfxApi.cfx_response_create_delegate));
            CfxApi.cfx_response_is_read_only = (CfxApi.cfx_response_is_read_only_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_response_is_read_only, typeof(CfxApi.cfx_response_is_read_only_delegate));
            CfxApi.cfx_response_get_status = (CfxApi.cfx_response_get_status_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_response_get_status, typeof(CfxApi.cfx_response_get_status_delegate));
            CfxApi.cfx_response_set_status = (CfxApi.cfx_response_set_status_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_response_set_status, typeof(CfxApi.cfx_response_set_status_delegate));
            CfxApi.cfx_response_get_status_text = (CfxApi.cfx_response_get_status_text_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_response_get_status_text, typeof(CfxApi.cfx_response_get_status_text_delegate));
            CfxApi.cfx_response_set_status_text = (CfxApi.cfx_response_set_status_text_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_response_set_status_text, typeof(CfxApi.cfx_response_set_status_text_delegate));
            CfxApi.cfx_response_get_mime_type = (CfxApi.cfx_response_get_mime_type_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_response_get_mime_type, typeof(CfxApi.cfx_response_get_mime_type_delegate));
            CfxApi.cfx_response_set_mime_type = (CfxApi.cfx_response_set_mime_type_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_response_set_mime_type, typeof(CfxApi.cfx_response_set_mime_type_delegate));
            CfxApi.cfx_response_get_header = (CfxApi.cfx_response_get_header_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_response_get_header, typeof(CfxApi.cfx_response_get_header_delegate));
            CfxApi.cfx_response_get_header_map = (CfxApi.cfx_response_get_header_map_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_response_get_header_map, typeof(CfxApi.cfx_response_get_header_map_delegate));
            CfxApi.cfx_response_set_header_map = (CfxApi.cfx_response_set_header_map_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_response_set_header_map, typeof(CfxApi.cfx_response_set_header_map_delegate));
        }

        private static bool CfxResponseFilterApiLoaded;
        internal static void LoadCfxResponseFilterApi() {
            if(CfxResponseFilterApiLoaded) return;
            CfxResponseFilterApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_response_filter_ctor = (CfxApi.cfx_ctor_with_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_response_filter_ctor, typeof(CfxApi.cfx_ctor_with_gc_handle_delegate));
            CfxApi.cfx_response_filter_get_gc_handle = (CfxApi.cfx_get_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_response_filter_get_gc_handle, typeof(CfxApi.cfx_get_gc_handle_delegate));
            CfxApi.cfx_response_filter_set_managed_callback = (CfxApi.cfx_set_callback_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_response_filter_set_managed_callback, typeof(CfxApi.cfx_set_callback_delegate));
        }

        private static bool CfxRunContextMenuCallbackApiLoaded;
        internal static void LoadCfxRunContextMenuCallbackApi() {
            if(CfxRunContextMenuCallbackApiLoaded) return;
            CfxRunContextMenuCallbackApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_run_context_menu_callback_cont = (CfxApi.cfx_run_context_menu_callback_cont_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_run_context_menu_callback_cont, typeof(CfxApi.cfx_run_context_menu_callback_cont_delegate));
            CfxApi.cfx_run_context_menu_callback_cancel = (CfxApi.cfx_run_context_menu_callback_cancel_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_run_context_menu_callback_cancel, typeof(CfxApi.cfx_run_context_menu_callback_cancel_delegate));
        }

        private static bool CfxRunFileDialogCallbackApiLoaded;
        internal static void LoadCfxRunFileDialogCallbackApi() {
            if(CfxRunFileDialogCallbackApiLoaded) return;
            CfxRunFileDialogCallbackApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_run_file_dialog_callback_ctor = (CfxApi.cfx_ctor_with_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_run_file_dialog_callback_ctor, typeof(CfxApi.cfx_ctor_with_gc_handle_delegate));
            CfxApi.cfx_run_file_dialog_callback_get_gc_handle = (CfxApi.cfx_get_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_run_file_dialog_callback_get_gc_handle, typeof(CfxApi.cfx_get_gc_handle_delegate));
            CfxApi.cfx_run_file_dialog_callback_set_managed_callback = (CfxApi.cfx_set_callback_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_run_file_dialog_callback_set_managed_callback, typeof(CfxApi.cfx_set_callback_delegate));
        }

        private static bool CfxSchemeHandlerFactoryApiLoaded;
        internal static void LoadCfxSchemeHandlerFactoryApi() {
            if(CfxSchemeHandlerFactoryApiLoaded) return;
            CfxSchemeHandlerFactoryApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_scheme_handler_factory_ctor = (CfxApi.cfx_ctor_with_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_scheme_handler_factory_ctor, typeof(CfxApi.cfx_ctor_with_gc_handle_delegate));
            CfxApi.cfx_scheme_handler_factory_get_gc_handle = (CfxApi.cfx_get_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_scheme_handler_factory_get_gc_handle, typeof(CfxApi.cfx_get_gc_handle_delegate));
            CfxApi.cfx_scheme_handler_factory_set_managed_callback = (CfxApi.cfx_set_callback_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_scheme_handler_factory_set_managed_callback, typeof(CfxApi.cfx_set_callback_delegate));
        }

        private static bool CfxSchemeRegistrarApiLoaded;
        internal static void LoadCfxSchemeRegistrarApi() {
            if(CfxSchemeRegistrarApiLoaded) return;
            CfxSchemeRegistrarApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_scheme_registrar_add_custom_scheme = (CfxApi.cfx_scheme_registrar_add_custom_scheme_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_scheme_registrar_add_custom_scheme, typeof(CfxApi.cfx_scheme_registrar_add_custom_scheme_delegate));
        }

        private static bool CfxScreenInfoApiLoaded;
        internal static void LoadCfxScreenInfoApi() {
            if(CfxScreenInfoApiLoaded) return;
            CfxScreenInfoApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_screen_info_ctor = (CfxApi.cfx_ctor_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_screen_info_ctor, typeof(CfxApi.cfx_ctor_delegate));
            CfxApi.cfx_screen_info_dtor = (CfxApi.cfx_dtor_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_screen_info_dtor, typeof(CfxApi.cfx_dtor_delegate));
            CfxApi.cfx_screen_info_set_device_scale_factor = (CfxApi.cfx_screen_info_set_device_scale_factor_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_screen_info_set_device_scale_factor, typeof(CfxApi.cfx_screen_info_set_device_scale_factor_delegate));
            CfxApi.cfx_screen_info_get_device_scale_factor = (CfxApi.cfx_screen_info_get_device_scale_factor_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_screen_info_get_device_scale_factor, typeof(CfxApi.cfx_screen_info_get_device_scale_factor_delegate));
            CfxApi.cfx_screen_info_set_depth = (CfxApi.cfx_screen_info_set_depth_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_screen_info_set_depth, typeof(CfxApi.cfx_screen_info_set_depth_delegate));
            CfxApi.cfx_screen_info_get_depth = (CfxApi.cfx_screen_info_get_depth_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_screen_info_get_depth, typeof(CfxApi.cfx_screen_info_get_depth_delegate));
            CfxApi.cfx_screen_info_set_depth_per_component = (CfxApi.cfx_screen_info_set_depth_per_component_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_screen_info_set_depth_per_component, typeof(CfxApi.cfx_screen_info_set_depth_per_component_delegate));
            CfxApi.cfx_screen_info_get_depth_per_component = (CfxApi.cfx_screen_info_get_depth_per_component_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_screen_info_get_depth_per_component, typeof(CfxApi.cfx_screen_info_get_depth_per_component_delegate));
            CfxApi.cfx_screen_info_set_is_monochrome = (CfxApi.cfx_screen_info_set_is_monochrome_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_screen_info_set_is_monochrome, typeof(CfxApi.cfx_screen_info_set_is_monochrome_delegate));
            CfxApi.cfx_screen_info_get_is_monochrome = (CfxApi.cfx_screen_info_get_is_monochrome_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_screen_info_get_is_monochrome, typeof(CfxApi.cfx_screen_info_get_is_monochrome_delegate));
            CfxApi.cfx_screen_info_set_rect = (CfxApi.cfx_screen_info_set_rect_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_screen_info_set_rect, typeof(CfxApi.cfx_screen_info_set_rect_delegate));
            CfxApi.cfx_screen_info_get_rect = (CfxApi.cfx_screen_info_get_rect_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_screen_info_get_rect, typeof(CfxApi.cfx_screen_info_get_rect_delegate));
            CfxApi.cfx_screen_info_set_available_rect = (CfxApi.cfx_screen_info_set_available_rect_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_screen_info_set_available_rect, typeof(CfxApi.cfx_screen_info_set_available_rect_delegate));
            CfxApi.cfx_screen_info_get_available_rect = (CfxApi.cfx_screen_info_get_available_rect_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_screen_info_get_available_rect, typeof(CfxApi.cfx_screen_info_get_available_rect_delegate));
        }

        private static bool CfxSetCookieCallbackApiLoaded;
        internal static void LoadCfxSetCookieCallbackApi() {
            if(CfxSetCookieCallbackApiLoaded) return;
            CfxSetCookieCallbackApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_set_cookie_callback_ctor = (CfxApi.cfx_ctor_with_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_set_cookie_callback_ctor, typeof(CfxApi.cfx_ctor_with_gc_handle_delegate));
            CfxApi.cfx_set_cookie_callback_get_gc_handle = (CfxApi.cfx_get_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_set_cookie_callback_get_gc_handle, typeof(CfxApi.cfx_get_gc_handle_delegate));
            CfxApi.cfx_set_cookie_callback_set_managed_callback = (CfxApi.cfx_set_callback_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_set_cookie_callback_set_managed_callback, typeof(CfxApi.cfx_set_callback_delegate));
        }

        private static bool CfxSettingsApiLoaded;
        internal static void LoadCfxSettingsApi() {
            if(CfxSettingsApiLoaded) return;
            CfxSettingsApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_settings_ctor = (CfxApi.cfx_ctor_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_ctor, typeof(CfxApi.cfx_ctor_delegate));
            CfxApi.cfx_settings_dtor = (CfxApi.cfx_dtor_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_dtor, typeof(CfxApi.cfx_dtor_delegate));
            CfxApi.cfx_settings_set_single_process = (CfxApi.cfx_settings_set_single_process_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_set_single_process, typeof(CfxApi.cfx_settings_set_single_process_delegate));
            CfxApi.cfx_settings_get_single_process = (CfxApi.cfx_settings_get_single_process_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_get_single_process, typeof(CfxApi.cfx_settings_get_single_process_delegate));
            CfxApi.cfx_settings_set_no_sandbox = (CfxApi.cfx_settings_set_no_sandbox_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_set_no_sandbox, typeof(CfxApi.cfx_settings_set_no_sandbox_delegate));
            CfxApi.cfx_settings_get_no_sandbox = (CfxApi.cfx_settings_get_no_sandbox_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_get_no_sandbox, typeof(CfxApi.cfx_settings_get_no_sandbox_delegate));
            CfxApi.cfx_settings_set_browser_subprocess_path = (CfxApi.cfx_settings_set_browser_subprocess_path_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_set_browser_subprocess_path, typeof(CfxApi.cfx_settings_set_browser_subprocess_path_delegate));
            CfxApi.cfx_settings_get_browser_subprocess_path = (CfxApi.cfx_settings_get_browser_subprocess_path_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_get_browser_subprocess_path, typeof(CfxApi.cfx_settings_get_browser_subprocess_path_delegate));
            CfxApi.cfx_settings_set_multi_threaded_message_loop = (CfxApi.cfx_settings_set_multi_threaded_message_loop_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_set_multi_threaded_message_loop, typeof(CfxApi.cfx_settings_set_multi_threaded_message_loop_delegate));
            CfxApi.cfx_settings_get_multi_threaded_message_loop = (CfxApi.cfx_settings_get_multi_threaded_message_loop_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_get_multi_threaded_message_loop, typeof(CfxApi.cfx_settings_get_multi_threaded_message_loop_delegate));
            CfxApi.cfx_settings_set_windowless_rendering_enabled = (CfxApi.cfx_settings_set_windowless_rendering_enabled_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_set_windowless_rendering_enabled, typeof(CfxApi.cfx_settings_set_windowless_rendering_enabled_delegate));
            CfxApi.cfx_settings_get_windowless_rendering_enabled = (CfxApi.cfx_settings_get_windowless_rendering_enabled_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_get_windowless_rendering_enabled, typeof(CfxApi.cfx_settings_get_windowless_rendering_enabled_delegate));
            CfxApi.cfx_settings_set_command_line_args_disabled = (CfxApi.cfx_settings_set_command_line_args_disabled_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_set_command_line_args_disabled, typeof(CfxApi.cfx_settings_set_command_line_args_disabled_delegate));
            CfxApi.cfx_settings_get_command_line_args_disabled = (CfxApi.cfx_settings_get_command_line_args_disabled_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_get_command_line_args_disabled, typeof(CfxApi.cfx_settings_get_command_line_args_disabled_delegate));
            CfxApi.cfx_settings_set_cache_path = (CfxApi.cfx_settings_set_cache_path_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_set_cache_path, typeof(CfxApi.cfx_settings_set_cache_path_delegate));
            CfxApi.cfx_settings_get_cache_path = (CfxApi.cfx_settings_get_cache_path_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_get_cache_path, typeof(CfxApi.cfx_settings_get_cache_path_delegate));
            CfxApi.cfx_settings_set_user_data_path = (CfxApi.cfx_settings_set_user_data_path_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_set_user_data_path, typeof(CfxApi.cfx_settings_set_user_data_path_delegate));
            CfxApi.cfx_settings_get_user_data_path = (CfxApi.cfx_settings_get_user_data_path_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_get_user_data_path, typeof(CfxApi.cfx_settings_get_user_data_path_delegate));
            CfxApi.cfx_settings_set_persist_session_cookies = (CfxApi.cfx_settings_set_persist_session_cookies_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_set_persist_session_cookies, typeof(CfxApi.cfx_settings_set_persist_session_cookies_delegate));
            CfxApi.cfx_settings_get_persist_session_cookies = (CfxApi.cfx_settings_get_persist_session_cookies_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_get_persist_session_cookies, typeof(CfxApi.cfx_settings_get_persist_session_cookies_delegate));
            CfxApi.cfx_settings_set_persist_user_preferences = (CfxApi.cfx_settings_set_persist_user_preferences_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_set_persist_user_preferences, typeof(CfxApi.cfx_settings_set_persist_user_preferences_delegate));
            CfxApi.cfx_settings_get_persist_user_preferences = (CfxApi.cfx_settings_get_persist_user_preferences_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_get_persist_user_preferences, typeof(CfxApi.cfx_settings_get_persist_user_preferences_delegate));
            CfxApi.cfx_settings_set_user_agent = (CfxApi.cfx_settings_set_user_agent_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_set_user_agent, typeof(CfxApi.cfx_settings_set_user_agent_delegate));
            CfxApi.cfx_settings_get_user_agent = (CfxApi.cfx_settings_get_user_agent_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_get_user_agent, typeof(CfxApi.cfx_settings_get_user_agent_delegate));
            CfxApi.cfx_settings_set_product_version = (CfxApi.cfx_settings_set_product_version_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_set_product_version, typeof(CfxApi.cfx_settings_set_product_version_delegate));
            CfxApi.cfx_settings_get_product_version = (CfxApi.cfx_settings_get_product_version_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_get_product_version, typeof(CfxApi.cfx_settings_get_product_version_delegate));
            CfxApi.cfx_settings_set_locale = (CfxApi.cfx_settings_set_locale_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_set_locale, typeof(CfxApi.cfx_settings_set_locale_delegate));
            CfxApi.cfx_settings_get_locale = (CfxApi.cfx_settings_get_locale_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_get_locale, typeof(CfxApi.cfx_settings_get_locale_delegate));
            CfxApi.cfx_settings_set_log_file = (CfxApi.cfx_settings_set_log_file_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_set_log_file, typeof(CfxApi.cfx_settings_set_log_file_delegate));
            CfxApi.cfx_settings_get_log_file = (CfxApi.cfx_settings_get_log_file_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_get_log_file, typeof(CfxApi.cfx_settings_get_log_file_delegate));
            CfxApi.cfx_settings_set_log_severity = (CfxApi.cfx_settings_set_log_severity_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_set_log_severity, typeof(CfxApi.cfx_settings_set_log_severity_delegate));
            CfxApi.cfx_settings_get_log_severity = (CfxApi.cfx_settings_get_log_severity_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_get_log_severity, typeof(CfxApi.cfx_settings_get_log_severity_delegate));
            CfxApi.cfx_settings_set_javascript_flags = (CfxApi.cfx_settings_set_javascript_flags_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_set_javascript_flags, typeof(CfxApi.cfx_settings_set_javascript_flags_delegate));
            CfxApi.cfx_settings_get_javascript_flags = (CfxApi.cfx_settings_get_javascript_flags_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_get_javascript_flags, typeof(CfxApi.cfx_settings_get_javascript_flags_delegate));
            CfxApi.cfx_settings_set_resources_dir_path = (CfxApi.cfx_settings_set_resources_dir_path_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_set_resources_dir_path, typeof(CfxApi.cfx_settings_set_resources_dir_path_delegate));
            CfxApi.cfx_settings_get_resources_dir_path = (CfxApi.cfx_settings_get_resources_dir_path_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_get_resources_dir_path, typeof(CfxApi.cfx_settings_get_resources_dir_path_delegate));
            CfxApi.cfx_settings_set_locales_dir_path = (CfxApi.cfx_settings_set_locales_dir_path_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_set_locales_dir_path, typeof(CfxApi.cfx_settings_set_locales_dir_path_delegate));
            CfxApi.cfx_settings_get_locales_dir_path = (CfxApi.cfx_settings_get_locales_dir_path_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_get_locales_dir_path, typeof(CfxApi.cfx_settings_get_locales_dir_path_delegate));
            CfxApi.cfx_settings_set_pack_loading_disabled = (CfxApi.cfx_settings_set_pack_loading_disabled_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_set_pack_loading_disabled, typeof(CfxApi.cfx_settings_set_pack_loading_disabled_delegate));
            CfxApi.cfx_settings_get_pack_loading_disabled = (CfxApi.cfx_settings_get_pack_loading_disabled_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_get_pack_loading_disabled, typeof(CfxApi.cfx_settings_get_pack_loading_disabled_delegate));
            CfxApi.cfx_settings_set_remote_debugging_port = (CfxApi.cfx_settings_set_remote_debugging_port_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_set_remote_debugging_port, typeof(CfxApi.cfx_settings_set_remote_debugging_port_delegate));
            CfxApi.cfx_settings_get_remote_debugging_port = (CfxApi.cfx_settings_get_remote_debugging_port_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_get_remote_debugging_port, typeof(CfxApi.cfx_settings_get_remote_debugging_port_delegate));
            CfxApi.cfx_settings_set_uncaught_exception_stack_size = (CfxApi.cfx_settings_set_uncaught_exception_stack_size_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_set_uncaught_exception_stack_size, typeof(CfxApi.cfx_settings_set_uncaught_exception_stack_size_delegate));
            CfxApi.cfx_settings_get_uncaught_exception_stack_size = (CfxApi.cfx_settings_get_uncaught_exception_stack_size_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_get_uncaught_exception_stack_size, typeof(CfxApi.cfx_settings_get_uncaught_exception_stack_size_delegate));
            CfxApi.cfx_settings_set_context_safety_implementation = (CfxApi.cfx_settings_set_context_safety_implementation_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_set_context_safety_implementation, typeof(CfxApi.cfx_settings_set_context_safety_implementation_delegate));
            CfxApi.cfx_settings_get_context_safety_implementation = (CfxApi.cfx_settings_get_context_safety_implementation_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_get_context_safety_implementation, typeof(CfxApi.cfx_settings_get_context_safety_implementation_delegate));
            CfxApi.cfx_settings_set_ignore_certificate_errors = (CfxApi.cfx_settings_set_ignore_certificate_errors_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_set_ignore_certificate_errors, typeof(CfxApi.cfx_settings_set_ignore_certificate_errors_delegate));
            CfxApi.cfx_settings_get_ignore_certificate_errors = (CfxApi.cfx_settings_get_ignore_certificate_errors_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_get_ignore_certificate_errors, typeof(CfxApi.cfx_settings_get_ignore_certificate_errors_delegate));
            CfxApi.cfx_settings_set_background_color = (CfxApi.cfx_settings_set_background_color_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_set_background_color, typeof(CfxApi.cfx_settings_set_background_color_delegate));
            CfxApi.cfx_settings_get_background_color = (CfxApi.cfx_settings_get_background_color_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_get_background_color, typeof(CfxApi.cfx_settings_get_background_color_delegate));
            CfxApi.cfx_settings_set_accept_language_list = (CfxApi.cfx_settings_set_accept_language_list_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_set_accept_language_list, typeof(CfxApi.cfx_settings_set_accept_language_list_delegate));
            CfxApi.cfx_settings_get_accept_language_list = (CfxApi.cfx_settings_get_accept_language_list_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_get_accept_language_list, typeof(CfxApi.cfx_settings_get_accept_language_list_delegate));
        }

        private static bool CfxSizeApiLoaded;
        internal static void LoadCfxSizeApi() {
            if(CfxSizeApiLoaded) return;
            CfxSizeApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_size_ctor = (CfxApi.cfx_ctor_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_size_ctor, typeof(CfxApi.cfx_ctor_delegate));
            CfxApi.cfx_size_dtor = (CfxApi.cfx_dtor_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_size_dtor, typeof(CfxApi.cfx_dtor_delegate));
            CfxApi.cfx_size_set_width = (CfxApi.cfx_size_set_width_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_size_set_width, typeof(CfxApi.cfx_size_set_width_delegate));
            CfxApi.cfx_size_get_width = (CfxApi.cfx_size_get_width_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_size_get_width, typeof(CfxApi.cfx_size_get_width_delegate));
            CfxApi.cfx_size_set_height = (CfxApi.cfx_size_set_height_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_size_set_height, typeof(CfxApi.cfx_size_set_height_delegate));
            CfxApi.cfx_size_get_height = (CfxApi.cfx_size_get_height_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_size_get_height, typeof(CfxApi.cfx_size_get_height_delegate));
        }

        private static bool CfxSslCertPrincipalApiLoaded;
        internal static void LoadCfxSslCertPrincipalApi() {
            if(CfxSslCertPrincipalApiLoaded) return;
            CfxSslCertPrincipalApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_sslcert_principal_get_display_name = (CfxApi.cfx_sslcert_principal_get_display_name_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_sslcert_principal_get_display_name, typeof(CfxApi.cfx_sslcert_principal_get_display_name_delegate));
            CfxApi.cfx_sslcert_principal_get_common_name = (CfxApi.cfx_sslcert_principal_get_common_name_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_sslcert_principal_get_common_name, typeof(CfxApi.cfx_sslcert_principal_get_common_name_delegate));
            CfxApi.cfx_sslcert_principal_get_locality_name = (CfxApi.cfx_sslcert_principal_get_locality_name_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_sslcert_principal_get_locality_name, typeof(CfxApi.cfx_sslcert_principal_get_locality_name_delegate));
            CfxApi.cfx_sslcert_principal_get_state_or_province_name = (CfxApi.cfx_sslcert_principal_get_state_or_province_name_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_sslcert_principal_get_state_or_province_name, typeof(CfxApi.cfx_sslcert_principal_get_state_or_province_name_delegate));
            CfxApi.cfx_sslcert_principal_get_country_name = (CfxApi.cfx_sslcert_principal_get_country_name_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_sslcert_principal_get_country_name, typeof(CfxApi.cfx_sslcert_principal_get_country_name_delegate));
            CfxApi.cfx_sslcert_principal_get_street_addresses = (CfxApi.cfx_sslcert_principal_get_street_addresses_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_sslcert_principal_get_street_addresses, typeof(CfxApi.cfx_sslcert_principal_get_street_addresses_delegate));
            CfxApi.cfx_sslcert_principal_get_organization_names = (CfxApi.cfx_sslcert_principal_get_organization_names_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_sslcert_principal_get_organization_names, typeof(CfxApi.cfx_sslcert_principal_get_organization_names_delegate));
            CfxApi.cfx_sslcert_principal_get_organization_unit_names = (CfxApi.cfx_sslcert_principal_get_organization_unit_names_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_sslcert_principal_get_organization_unit_names, typeof(CfxApi.cfx_sslcert_principal_get_organization_unit_names_delegate));
            CfxApi.cfx_sslcert_principal_get_domain_components = (CfxApi.cfx_sslcert_principal_get_domain_components_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_sslcert_principal_get_domain_components, typeof(CfxApi.cfx_sslcert_principal_get_domain_components_delegate));
        }

        private static bool CfxSslInfoApiLoaded;
        internal static void LoadCfxSslInfoApi() {
            if(CfxSslInfoApiLoaded) return;
            CfxSslInfoApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_sslinfo_get_cert_status = (CfxApi.cfx_sslinfo_get_cert_status_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_sslinfo_get_cert_status, typeof(CfxApi.cfx_sslinfo_get_cert_status_delegate));
            CfxApi.cfx_sslinfo_is_cert_status_error = (CfxApi.cfx_sslinfo_is_cert_status_error_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_sslinfo_is_cert_status_error, typeof(CfxApi.cfx_sslinfo_is_cert_status_error_delegate));
            CfxApi.cfx_sslinfo_is_cert_status_minor_error = (CfxApi.cfx_sslinfo_is_cert_status_minor_error_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_sslinfo_is_cert_status_minor_error, typeof(CfxApi.cfx_sslinfo_is_cert_status_minor_error_delegate));
            CfxApi.cfx_sslinfo_get_subject = (CfxApi.cfx_sslinfo_get_subject_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_sslinfo_get_subject, typeof(CfxApi.cfx_sslinfo_get_subject_delegate));
            CfxApi.cfx_sslinfo_get_issuer = (CfxApi.cfx_sslinfo_get_issuer_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_sslinfo_get_issuer, typeof(CfxApi.cfx_sslinfo_get_issuer_delegate));
            CfxApi.cfx_sslinfo_get_serial_number = (CfxApi.cfx_sslinfo_get_serial_number_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_sslinfo_get_serial_number, typeof(CfxApi.cfx_sslinfo_get_serial_number_delegate));
            CfxApi.cfx_sslinfo_get_valid_start = (CfxApi.cfx_sslinfo_get_valid_start_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_sslinfo_get_valid_start, typeof(CfxApi.cfx_sslinfo_get_valid_start_delegate));
            CfxApi.cfx_sslinfo_get_valid_expiry = (CfxApi.cfx_sslinfo_get_valid_expiry_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_sslinfo_get_valid_expiry, typeof(CfxApi.cfx_sslinfo_get_valid_expiry_delegate));
            CfxApi.cfx_sslinfo_get_derencoded = (CfxApi.cfx_sslinfo_get_derencoded_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_sslinfo_get_derencoded, typeof(CfxApi.cfx_sslinfo_get_derencoded_delegate));
            CfxApi.cfx_sslinfo_get_pemencoded = (CfxApi.cfx_sslinfo_get_pemencoded_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_sslinfo_get_pemencoded, typeof(CfxApi.cfx_sslinfo_get_pemencoded_delegate));
            CfxApi.cfx_sslinfo_get_issuer_chain_size = (CfxApi.cfx_sslinfo_get_issuer_chain_size_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_sslinfo_get_issuer_chain_size, typeof(CfxApi.cfx_sslinfo_get_issuer_chain_size_delegate));
            CfxApi.cfx_sslinfo_get_derencoded_issuer_chain = (CfxApi.cfx_sslinfo_get_derencoded_issuer_chain_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_sslinfo_get_derencoded_issuer_chain, typeof(CfxApi.cfx_sslinfo_get_derencoded_issuer_chain_delegate));
            CfxApi.cfx_sslinfo_get_pemencoded_issuer_chain = (CfxApi.cfx_sslinfo_get_pemencoded_issuer_chain_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_sslinfo_get_pemencoded_issuer_chain, typeof(CfxApi.cfx_sslinfo_get_pemencoded_issuer_chain_delegate));
        }

        private static bool CfxStreamReaderApiLoaded;
        internal static void LoadCfxStreamReaderApi() {
            if(CfxStreamReaderApiLoaded) return;
            CfxStreamReaderApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_stream_reader_create_for_file = (CfxApi.cfx_stream_reader_create_for_file_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_stream_reader_create_for_file, typeof(CfxApi.cfx_stream_reader_create_for_file_delegate));
            CfxApi.cfx_stream_reader_create_for_data = (CfxApi.cfx_stream_reader_create_for_data_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_stream_reader_create_for_data, typeof(CfxApi.cfx_stream_reader_create_for_data_delegate));
            CfxApi.cfx_stream_reader_create_for_handler = (CfxApi.cfx_stream_reader_create_for_handler_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_stream_reader_create_for_handler, typeof(CfxApi.cfx_stream_reader_create_for_handler_delegate));
            CfxApi.cfx_stream_reader_read = (CfxApi.cfx_stream_reader_read_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_stream_reader_read, typeof(CfxApi.cfx_stream_reader_read_delegate));
            CfxApi.cfx_stream_reader_seek = (CfxApi.cfx_stream_reader_seek_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_stream_reader_seek, typeof(CfxApi.cfx_stream_reader_seek_delegate));
            CfxApi.cfx_stream_reader_tell = (CfxApi.cfx_stream_reader_tell_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_stream_reader_tell, typeof(CfxApi.cfx_stream_reader_tell_delegate));
            CfxApi.cfx_stream_reader_eof = (CfxApi.cfx_stream_reader_eof_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_stream_reader_eof, typeof(CfxApi.cfx_stream_reader_eof_delegate));
            CfxApi.cfx_stream_reader_may_block = (CfxApi.cfx_stream_reader_may_block_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_stream_reader_may_block, typeof(CfxApi.cfx_stream_reader_may_block_delegate));
        }

        private static bool CfxStreamWriterApiLoaded;
        internal static void LoadCfxStreamWriterApi() {
            if(CfxStreamWriterApiLoaded) return;
            CfxStreamWriterApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_stream_writer_create_for_file = (CfxApi.cfx_stream_writer_create_for_file_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_stream_writer_create_for_file, typeof(CfxApi.cfx_stream_writer_create_for_file_delegate));
            CfxApi.cfx_stream_writer_create_for_handler = (CfxApi.cfx_stream_writer_create_for_handler_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_stream_writer_create_for_handler, typeof(CfxApi.cfx_stream_writer_create_for_handler_delegate));
            CfxApi.cfx_stream_writer_write = (CfxApi.cfx_stream_writer_write_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_stream_writer_write, typeof(CfxApi.cfx_stream_writer_write_delegate));
            CfxApi.cfx_stream_writer_seek = (CfxApi.cfx_stream_writer_seek_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_stream_writer_seek, typeof(CfxApi.cfx_stream_writer_seek_delegate));
            CfxApi.cfx_stream_writer_tell = (CfxApi.cfx_stream_writer_tell_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_stream_writer_tell, typeof(CfxApi.cfx_stream_writer_tell_delegate));
            CfxApi.cfx_stream_writer_flush = (CfxApi.cfx_stream_writer_flush_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_stream_writer_flush, typeof(CfxApi.cfx_stream_writer_flush_delegate));
            CfxApi.cfx_stream_writer_may_block = (CfxApi.cfx_stream_writer_may_block_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_stream_writer_may_block, typeof(CfxApi.cfx_stream_writer_may_block_delegate));
        }

        private static bool CfxStringVisitorApiLoaded;
        internal static void LoadCfxStringVisitorApi() {
            if(CfxStringVisitorApiLoaded) return;
            CfxStringVisitorApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_string_visitor_ctor = (CfxApi.cfx_ctor_with_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_string_visitor_ctor, typeof(CfxApi.cfx_ctor_with_gc_handle_delegate));
            CfxApi.cfx_string_visitor_get_gc_handle = (CfxApi.cfx_get_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_string_visitor_get_gc_handle, typeof(CfxApi.cfx_get_gc_handle_delegate));
            CfxApi.cfx_string_visitor_set_managed_callback = (CfxApi.cfx_set_callback_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_string_visitor_set_managed_callback, typeof(CfxApi.cfx_set_callback_delegate));
        }

        private static bool CfxTaskApiLoaded;
        internal static void LoadCfxTaskApi() {
            if(CfxTaskApiLoaded) return;
            CfxTaskApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_task_ctor = (CfxApi.cfx_ctor_with_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_task_ctor, typeof(CfxApi.cfx_ctor_with_gc_handle_delegate));
            CfxApi.cfx_task_get_gc_handle = (CfxApi.cfx_get_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_task_get_gc_handle, typeof(CfxApi.cfx_get_gc_handle_delegate));
            CfxApi.cfx_task_set_managed_callback = (CfxApi.cfx_set_callback_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_task_set_managed_callback, typeof(CfxApi.cfx_set_callback_delegate));
        }

        private static bool CfxTaskRunnerApiLoaded;
        internal static void LoadCfxTaskRunnerApi() {
            if(CfxTaskRunnerApiLoaded) return;
            CfxTaskRunnerApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_task_runner_get_for_current_thread = (CfxApi.cfx_task_runner_get_for_current_thread_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_task_runner_get_for_current_thread, typeof(CfxApi.cfx_task_runner_get_for_current_thread_delegate));
            CfxApi.cfx_task_runner_get_for_thread = (CfxApi.cfx_task_runner_get_for_thread_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_task_runner_get_for_thread, typeof(CfxApi.cfx_task_runner_get_for_thread_delegate));
            CfxApi.cfx_task_runner_is_same = (CfxApi.cfx_task_runner_is_same_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_task_runner_is_same, typeof(CfxApi.cfx_task_runner_is_same_delegate));
            CfxApi.cfx_task_runner_belongs_to_current_thread = (CfxApi.cfx_task_runner_belongs_to_current_thread_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_task_runner_belongs_to_current_thread, typeof(CfxApi.cfx_task_runner_belongs_to_current_thread_delegate));
            CfxApi.cfx_task_runner_belongs_to_thread = (CfxApi.cfx_task_runner_belongs_to_thread_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_task_runner_belongs_to_thread, typeof(CfxApi.cfx_task_runner_belongs_to_thread_delegate));
            CfxApi.cfx_task_runner_post_task = (CfxApi.cfx_task_runner_post_task_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_task_runner_post_task, typeof(CfxApi.cfx_task_runner_post_task_delegate));
            CfxApi.cfx_task_runner_post_delayed_task = (CfxApi.cfx_task_runner_post_delayed_task_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_task_runner_post_delayed_task, typeof(CfxApi.cfx_task_runner_post_delayed_task_delegate));
        }

        private static bool CfxTimeApiLoaded;
        internal static void LoadCfxTimeApi() {
            if(CfxTimeApiLoaded) return;
            CfxTimeApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_time_ctor = (CfxApi.cfx_ctor_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_time_ctor, typeof(CfxApi.cfx_ctor_delegate));
            CfxApi.cfx_time_dtor = (CfxApi.cfx_dtor_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_time_dtor, typeof(CfxApi.cfx_dtor_delegate));
            CfxApi.cfx_time_set_year = (CfxApi.cfx_time_set_year_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_time_set_year, typeof(CfxApi.cfx_time_set_year_delegate));
            CfxApi.cfx_time_get_year = (CfxApi.cfx_time_get_year_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_time_get_year, typeof(CfxApi.cfx_time_get_year_delegate));
            CfxApi.cfx_time_set_month = (CfxApi.cfx_time_set_month_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_time_set_month, typeof(CfxApi.cfx_time_set_month_delegate));
            CfxApi.cfx_time_get_month = (CfxApi.cfx_time_get_month_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_time_get_month, typeof(CfxApi.cfx_time_get_month_delegate));
            CfxApi.cfx_time_set_day_of_week = (CfxApi.cfx_time_set_day_of_week_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_time_set_day_of_week, typeof(CfxApi.cfx_time_set_day_of_week_delegate));
            CfxApi.cfx_time_get_day_of_week = (CfxApi.cfx_time_get_day_of_week_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_time_get_day_of_week, typeof(CfxApi.cfx_time_get_day_of_week_delegate));
            CfxApi.cfx_time_set_day_of_month = (CfxApi.cfx_time_set_day_of_month_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_time_set_day_of_month, typeof(CfxApi.cfx_time_set_day_of_month_delegate));
            CfxApi.cfx_time_get_day_of_month = (CfxApi.cfx_time_get_day_of_month_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_time_get_day_of_month, typeof(CfxApi.cfx_time_get_day_of_month_delegate));
            CfxApi.cfx_time_set_hour = (CfxApi.cfx_time_set_hour_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_time_set_hour, typeof(CfxApi.cfx_time_set_hour_delegate));
            CfxApi.cfx_time_get_hour = (CfxApi.cfx_time_get_hour_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_time_get_hour, typeof(CfxApi.cfx_time_get_hour_delegate));
            CfxApi.cfx_time_set_minute = (CfxApi.cfx_time_set_minute_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_time_set_minute, typeof(CfxApi.cfx_time_set_minute_delegate));
            CfxApi.cfx_time_get_minute = (CfxApi.cfx_time_get_minute_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_time_get_minute, typeof(CfxApi.cfx_time_get_minute_delegate));
            CfxApi.cfx_time_set_second = (CfxApi.cfx_time_set_second_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_time_set_second, typeof(CfxApi.cfx_time_set_second_delegate));
            CfxApi.cfx_time_get_second = (CfxApi.cfx_time_get_second_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_time_get_second, typeof(CfxApi.cfx_time_get_second_delegate));
            CfxApi.cfx_time_set_millisecond = (CfxApi.cfx_time_set_millisecond_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_time_set_millisecond, typeof(CfxApi.cfx_time_set_millisecond_delegate));
            CfxApi.cfx_time_get_millisecond = (CfxApi.cfx_time_get_millisecond_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_time_get_millisecond, typeof(CfxApi.cfx_time_get_millisecond_delegate));
        }

        private static bool CfxUrlPartsApiLoaded;
        internal static void LoadCfxUrlPartsApi() {
            if(CfxUrlPartsApiLoaded) return;
            CfxUrlPartsApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_urlparts_ctor = (CfxApi.cfx_ctor_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_urlparts_ctor, typeof(CfxApi.cfx_ctor_delegate));
            CfxApi.cfx_urlparts_dtor = (CfxApi.cfx_dtor_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_urlparts_dtor, typeof(CfxApi.cfx_dtor_delegate));
            CfxApi.cfx_urlparts_set_spec = (CfxApi.cfx_urlparts_set_spec_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_urlparts_set_spec, typeof(CfxApi.cfx_urlparts_set_spec_delegate));
            CfxApi.cfx_urlparts_get_spec = (CfxApi.cfx_urlparts_get_spec_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_urlparts_get_spec, typeof(CfxApi.cfx_urlparts_get_spec_delegate));
            CfxApi.cfx_urlparts_set_scheme = (CfxApi.cfx_urlparts_set_scheme_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_urlparts_set_scheme, typeof(CfxApi.cfx_urlparts_set_scheme_delegate));
            CfxApi.cfx_urlparts_get_scheme = (CfxApi.cfx_urlparts_get_scheme_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_urlparts_get_scheme, typeof(CfxApi.cfx_urlparts_get_scheme_delegate));
            CfxApi.cfx_urlparts_set_username = (CfxApi.cfx_urlparts_set_username_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_urlparts_set_username, typeof(CfxApi.cfx_urlparts_set_username_delegate));
            CfxApi.cfx_urlparts_get_username = (CfxApi.cfx_urlparts_get_username_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_urlparts_get_username, typeof(CfxApi.cfx_urlparts_get_username_delegate));
            CfxApi.cfx_urlparts_set_password = (CfxApi.cfx_urlparts_set_password_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_urlparts_set_password, typeof(CfxApi.cfx_urlparts_set_password_delegate));
            CfxApi.cfx_urlparts_get_password = (CfxApi.cfx_urlparts_get_password_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_urlparts_get_password, typeof(CfxApi.cfx_urlparts_get_password_delegate));
            CfxApi.cfx_urlparts_set_host = (CfxApi.cfx_urlparts_set_host_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_urlparts_set_host, typeof(CfxApi.cfx_urlparts_set_host_delegate));
            CfxApi.cfx_urlparts_get_host = (CfxApi.cfx_urlparts_get_host_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_urlparts_get_host, typeof(CfxApi.cfx_urlparts_get_host_delegate));
            CfxApi.cfx_urlparts_set_port = (CfxApi.cfx_urlparts_set_port_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_urlparts_set_port, typeof(CfxApi.cfx_urlparts_set_port_delegate));
            CfxApi.cfx_urlparts_get_port = (CfxApi.cfx_urlparts_get_port_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_urlparts_get_port, typeof(CfxApi.cfx_urlparts_get_port_delegate));
            CfxApi.cfx_urlparts_set_origin = (CfxApi.cfx_urlparts_set_origin_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_urlparts_set_origin, typeof(CfxApi.cfx_urlparts_set_origin_delegate));
            CfxApi.cfx_urlparts_get_origin = (CfxApi.cfx_urlparts_get_origin_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_urlparts_get_origin, typeof(CfxApi.cfx_urlparts_get_origin_delegate));
            CfxApi.cfx_urlparts_set_path = (CfxApi.cfx_urlparts_set_path_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_urlparts_set_path, typeof(CfxApi.cfx_urlparts_set_path_delegate));
            CfxApi.cfx_urlparts_get_path = (CfxApi.cfx_urlparts_get_path_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_urlparts_get_path, typeof(CfxApi.cfx_urlparts_get_path_delegate));
            CfxApi.cfx_urlparts_set_query = (CfxApi.cfx_urlparts_set_query_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_urlparts_set_query, typeof(CfxApi.cfx_urlparts_set_query_delegate));
            CfxApi.cfx_urlparts_get_query = (CfxApi.cfx_urlparts_get_query_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_urlparts_get_query, typeof(CfxApi.cfx_urlparts_get_query_delegate));
        }

        private static bool CfxUrlRequestApiLoaded;
        internal static void LoadCfxUrlRequestApi() {
            if(CfxUrlRequestApiLoaded) return;
            CfxUrlRequestApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_urlrequest_create = (CfxApi.cfx_urlrequest_create_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_urlrequest_create, typeof(CfxApi.cfx_urlrequest_create_delegate));
            CfxApi.cfx_urlrequest_get_request = (CfxApi.cfx_urlrequest_get_request_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_urlrequest_get_request, typeof(CfxApi.cfx_urlrequest_get_request_delegate));
            CfxApi.cfx_urlrequest_get_client = (CfxApi.cfx_urlrequest_get_client_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_urlrequest_get_client, typeof(CfxApi.cfx_urlrequest_get_client_delegate));
            CfxApi.cfx_urlrequest_get_request_status = (CfxApi.cfx_urlrequest_get_request_status_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_urlrequest_get_request_status, typeof(CfxApi.cfx_urlrequest_get_request_status_delegate));
            CfxApi.cfx_urlrequest_get_request_error = (CfxApi.cfx_urlrequest_get_request_error_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_urlrequest_get_request_error, typeof(CfxApi.cfx_urlrequest_get_request_error_delegate));
            CfxApi.cfx_urlrequest_get_response = (CfxApi.cfx_urlrequest_get_response_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_urlrequest_get_response, typeof(CfxApi.cfx_urlrequest_get_response_delegate));
            CfxApi.cfx_urlrequest_cancel = (CfxApi.cfx_urlrequest_cancel_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_urlrequest_cancel, typeof(CfxApi.cfx_urlrequest_cancel_delegate));
        }

        private static bool CfxUrlRequestClientApiLoaded;
        internal static void LoadCfxUrlRequestClientApi() {
            if(CfxUrlRequestClientApiLoaded) return;
            CfxUrlRequestClientApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_urlrequest_client_ctor = (CfxApi.cfx_ctor_with_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_urlrequest_client_ctor, typeof(CfxApi.cfx_ctor_with_gc_handle_delegate));
            CfxApi.cfx_urlrequest_client_get_gc_handle = (CfxApi.cfx_get_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_urlrequest_client_get_gc_handle, typeof(CfxApi.cfx_get_gc_handle_delegate));
            CfxApi.cfx_urlrequest_client_set_managed_callback = (CfxApi.cfx_set_callback_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_urlrequest_client_set_managed_callback, typeof(CfxApi.cfx_set_callback_delegate));
        }

        private static bool CfxV8AccessorApiLoaded;
        internal static void LoadCfxV8AccessorApi() {
            if(CfxV8AccessorApiLoaded) return;
            CfxV8AccessorApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_v8accessor_ctor = (CfxApi.cfx_ctor_with_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8accessor_ctor, typeof(CfxApi.cfx_ctor_with_gc_handle_delegate));
            CfxApi.cfx_v8accessor_get_gc_handle = (CfxApi.cfx_get_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8accessor_get_gc_handle, typeof(CfxApi.cfx_get_gc_handle_delegate));
            CfxApi.cfx_v8accessor_set_managed_callback = (CfxApi.cfx_set_callback_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8accessor_set_managed_callback, typeof(CfxApi.cfx_set_callback_delegate));
        }

        private static bool CfxV8ContextApiLoaded;
        internal static void LoadCfxV8ContextApi() {
            if(CfxV8ContextApiLoaded) return;
            CfxV8ContextApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_v8context_get_current_context = (CfxApi.cfx_v8context_get_current_context_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8context_get_current_context, typeof(CfxApi.cfx_v8context_get_current_context_delegate));
            CfxApi.cfx_v8context_get_entered_context = (CfxApi.cfx_v8context_get_entered_context_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8context_get_entered_context, typeof(CfxApi.cfx_v8context_get_entered_context_delegate));
            CfxApi.cfx_v8context_in_context = (CfxApi.cfx_v8context_in_context_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8context_in_context, typeof(CfxApi.cfx_v8context_in_context_delegate));
            CfxApi.cfx_v8context_get_task_runner = (CfxApi.cfx_v8context_get_task_runner_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8context_get_task_runner, typeof(CfxApi.cfx_v8context_get_task_runner_delegate));
            CfxApi.cfx_v8context_is_valid = (CfxApi.cfx_v8context_is_valid_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8context_is_valid, typeof(CfxApi.cfx_v8context_is_valid_delegate));
            CfxApi.cfx_v8context_get_browser = (CfxApi.cfx_v8context_get_browser_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8context_get_browser, typeof(CfxApi.cfx_v8context_get_browser_delegate));
            CfxApi.cfx_v8context_get_frame = (CfxApi.cfx_v8context_get_frame_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8context_get_frame, typeof(CfxApi.cfx_v8context_get_frame_delegate));
            CfxApi.cfx_v8context_get_global = (CfxApi.cfx_v8context_get_global_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8context_get_global, typeof(CfxApi.cfx_v8context_get_global_delegate));
            CfxApi.cfx_v8context_enter = (CfxApi.cfx_v8context_enter_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8context_enter, typeof(CfxApi.cfx_v8context_enter_delegate));
            CfxApi.cfx_v8context_exit = (CfxApi.cfx_v8context_exit_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8context_exit, typeof(CfxApi.cfx_v8context_exit_delegate));
            CfxApi.cfx_v8context_is_same = (CfxApi.cfx_v8context_is_same_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8context_is_same, typeof(CfxApi.cfx_v8context_is_same_delegate));
            CfxApi.cfx_v8context_eval = (CfxApi.cfx_v8context_eval_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8context_eval, typeof(CfxApi.cfx_v8context_eval_delegate));
        }

        private static bool CfxV8ExceptionApiLoaded;
        internal static void LoadCfxV8ExceptionApi() {
            if(CfxV8ExceptionApiLoaded) return;
            CfxV8ExceptionApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_v8exception_get_message = (CfxApi.cfx_v8exception_get_message_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8exception_get_message, typeof(CfxApi.cfx_v8exception_get_message_delegate));
            CfxApi.cfx_v8exception_get_source_line = (CfxApi.cfx_v8exception_get_source_line_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8exception_get_source_line, typeof(CfxApi.cfx_v8exception_get_source_line_delegate));
            CfxApi.cfx_v8exception_get_script_resource_name = (CfxApi.cfx_v8exception_get_script_resource_name_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8exception_get_script_resource_name, typeof(CfxApi.cfx_v8exception_get_script_resource_name_delegate));
            CfxApi.cfx_v8exception_get_line_number = (CfxApi.cfx_v8exception_get_line_number_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8exception_get_line_number, typeof(CfxApi.cfx_v8exception_get_line_number_delegate));
            CfxApi.cfx_v8exception_get_start_position = (CfxApi.cfx_v8exception_get_start_position_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8exception_get_start_position, typeof(CfxApi.cfx_v8exception_get_start_position_delegate));
            CfxApi.cfx_v8exception_get_end_position = (CfxApi.cfx_v8exception_get_end_position_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8exception_get_end_position, typeof(CfxApi.cfx_v8exception_get_end_position_delegate));
            CfxApi.cfx_v8exception_get_start_column = (CfxApi.cfx_v8exception_get_start_column_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8exception_get_start_column, typeof(CfxApi.cfx_v8exception_get_start_column_delegate));
            CfxApi.cfx_v8exception_get_end_column = (CfxApi.cfx_v8exception_get_end_column_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8exception_get_end_column, typeof(CfxApi.cfx_v8exception_get_end_column_delegate));
        }

        private static bool CfxV8HandlerApiLoaded;
        internal static void LoadCfxV8HandlerApi() {
            if(CfxV8HandlerApiLoaded) return;
            CfxV8HandlerApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_v8handler_ctor = (CfxApi.cfx_ctor_with_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8handler_ctor, typeof(CfxApi.cfx_ctor_with_gc_handle_delegate));
            CfxApi.cfx_v8handler_get_gc_handle = (CfxApi.cfx_get_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8handler_get_gc_handle, typeof(CfxApi.cfx_get_gc_handle_delegate));
            CfxApi.cfx_v8handler_set_managed_callback = (CfxApi.cfx_set_callback_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8handler_set_managed_callback, typeof(CfxApi.cfx_set_callback_delegate));
        }

        private static bool CfxV8StackFrameApiLoaded;
        internal static void LoadCfxV8StackFrameApi() {
            if(CfxV8StackFrameApiLoaded) return;
            CfxV8StackFrameApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_v8stack_frame_is_valid = (CfxApi.cfx_v8stack_frame_is_valid_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8stack_frame_is_valid, typeof(CfxApi.cfx_v8stack_frame_is_valid_delegate));
            CfxApi.cfx_v8stack_frame_get_script_name = (CfxApi.cfx_v8stack_frame_get_script_name_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8stack_frame_get_script_name, typeof(CfxApi.cfx_v8stack_frame_get_script_name_delegate));
            CfxApi.cfx_v8stack_frame_get_script_name_or_source_url = (CfxApi.cfx_v8stack_frame_get_script_name_or_source_url_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8stack_frame_get_script_name_or_source_url, typeof(CfxApi.cfx_v8stack_frame_get_script_name_or_source_url_delegate));
            CfxApi.cfx_v8stack_frame_get_function_name = (CfxApi.cfx_v8stack_frame_get_function_name_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8stack_frame_get_function_name, typeof(CfxApi.cfx_v8stack_frame_get_function_name_delegate));
            CfxApi.cfx_v8stack_frame_get_line_number = (CfxApi.cfx_v8stack_frame_get_line_number_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8stack_frame_get_line_number, typeof(CfxApi.cfx_v8stack_frame_get_line_number_delegate));
            CfxApi.cfx_v8stack_frame_get_column = (CfxApi.cfx_v8stack_frame_get_column_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8stack_frame_get_column, typeof(CfxApi.cfx_v8stack_frame_get_column_delegate));
            CfxApi.cfx_v8stack_frame_is_eval = (CfxApi.cfx_v8stack_frame_is_eval_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8stack_frame_is_eval, typeof(CfxApi.cfx_v8stack_frame_is_eval_delegate));
            CfxApi.cfx_v8stack_frame_is_constructor = (CfxApi.cfx_v8stack_frame_is_constructor_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8stack_frame_is_constructor, typeof(CfxApi.cfx_v8stack_frame_is_constructor_delegate));
        }

        private static bool CfxV8StackTraceApiLoaded;
        internal static void LoadCfxV8StackTraceApi() {
            if(CfxV8StackTraceApiLoaded) return;
            CfxV8StackTraceApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_v8stack_trace_get_current = (CfxApi.cfx_v8stack_trace_get_current_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8stack_trace_get_current, typeof(CfxApi.cfx_v8stack_trace_get_current_delegate));
            CfxApi.cfx_v8stack_trace_is_valid = (CfxApi.cfx_v8stack_trace_is_valid_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8stack_trace_is_valid, typeof(CfxApi.cfx_v8stack_trace_is_valid_delegate));
            CfxApi.cfx_v8stack_trace_get_frame_count = (CfxApi.cfx_v8stack_trace_get_frame_count_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8stack_trace_get_frame_count, typeof(CfxApi.cfx_v8stack_trace_get_frame_count_delegate));
            CfxApi.cfx_v8stack_trace_get_frame = (CfxApi.cfx_v8stack_trace_get_frame_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8stack_trace_get_frame, typeof(CfxApi.cfx_v8stack_trace_get_frame_delegate));
        }

        private static bool CfxV8ValueApiLoaded;
        internal static void LoadCfxV8ValueApi() {
            if(CfxV8ValueApiLoaded) return;
            CfxV8ValueApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_v8value_create_undefined = (CfxApi.cfx_v8value_create_undefined_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_create_undefined, typeof(CfxApi.cfx_v8value_create_undefined_delegate));
            CfxApi.cfx_v8value_create_null = (CfxApi.cfx_v8value_create_null_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_create_null, typeof(CfxApi.cfx_v8value_create_null_delegate));
            CfxApi.cfx_v8value_create_bool = (CfxApi.cfx_v8value_create_bool_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_create_bool, typeof(CfxApi.cfx_v8value_create_bool_delegate));
            CfxApi.cfx_v8value_create_int = (CfxApi.cfx_v8value_create_int_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_create_int, typeof(CfxApi.cfx_v8value_create_int_delegate));
            CfxApi.cfx_v8value_create_uint = (CfxApi.cfx_v8value_create_uint_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_create_uint, typeof(CfxApi.cfx_v8value_create_uint_delegate));
            CfxApi.cfx_v8value_create_double = (CfxApi.cfx_v8value_create_double_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_create_double, typeof(CfxApi.cfx_v8value_create_double_delegate));
            CfxApi.cfx_v8value_create_date = (CfxApi.cfx_v8value_create_date_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_create_date, typeof(CfxApi.cfx_v8value_create_date_delegate));
            CfxApi.cfx_v8value_create_string = (CfxApi.cfx_v8value_create_string_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_create_string, typeof(CfxApi.cfx_v8value_create_string_delegate));
            CfxApi.cfx_v8value_create_object = (CfxApi.cfx_v8value_create_object_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_create_object, typeof(CfxApi.cfx_v8value_create_object_delegate));
            CfxApi.cfx_v8value_create_array = (CfxApi.cfx_v8value_create_array_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_create_array, typeof(CfxApi.cfx_v8value_create_array_delegate));
            CfxApi.cfx_v8value_create_function = (CfxApi.cfx_v8value_create_function_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_create_function, typeof(CfxApi.cfx_v8value_create_function_delegate));
            CfxApi.cfx_v8value_is_valid = (CfxApi.cfx_v8value_is_valid_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_is_valid, typeof(CfxApi.cfx_v8value_is_valid_delegate));
            CfxApi.cfx_v8value_is_undefined = (CfxApi.cfx_v8value_is_undefined_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_is_undefined, typeof(CfxApi.cfx_v8value_is_undefined_delegate));
            CfxApi.cfx_v8value_is_null = (CfxApi.cfx_v8value_is_null_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_is_null, typeof(CfxApi.cfx_v8value_is_null_delegate));
            CfxApi.cfx_v8value_is_bool = (CfxApi.cfx_v8value_is_bool_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_is_bool, typeof(CfxApi.cfx_v8value_is_bool_delegate));
            CfxApi.cfx_v8value_is_int = (CfxApi.cfx_v8value_is_int_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_is_int, typeof(CfxApi.cfx_v8value_is_int_delegate));
            CfxApi.cfx_v8value_is_uint = (CfxApi.cfx_v8value_is_uint_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_is_uint, typeof(CfxApi.cfx_v8value_is_uint_delegate));
            CfxApi.cfx_v8value_is_double = (CfxApi.cfx_v8value_is_double_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_is_double, typeof(CfxApi.cfx_v8value_is_double_delegate));
            CfxApi.cfx_v8value_is_date = (CfxApi.cfx_v8value_is_date_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_is_date, typeof(CfxApi.cfx_v8value_is_date_delegate));
            CfxApi.cfx_v8value_is_string = (CfxApi.cfx_v8value_is_string_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_is_string, typeof(CfxApi.cfx_v8value_is_string_delegate));
            CfxApi.cfx_v8value_is_object = (CfxApi.cfx_v8value_is_object_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_is_object, typeof(CfxApi.cfx_v8value_is_object_delegate));
            CfxApi.cfx_v8value_is_array = (CfxApi.cfx_v8value_is_array_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_is_array, typeof(CfxApi.cfx_v8value_is_array_delegate));
            CfxApi.cfx_v8value_is_function = (CfxApi.cfx_v8value_is_function_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_is_function, typeof(CfxApi.cfx_v8value_is_function_delegate));
            CfxApi.cfx_v8value_is_same = (CfxApi.cfx_v8value_is_same_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_is_same, typeof(CfxApi.cfx_v8value_is_same_delegate));
            CfxApi.cfx_v8value_get_bool_value = (CfxApi.cfx_v8value_get_bool_value_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_get_bool_value, typeof(CfxApi.cfx_v8value_get_bool_value_delegate));
            CfxApi.cfx_v8value_get_int_value = (CfxApi.cfx_v8value_get_int_value_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_get_int_value, typeof(CfxApi.cfx_v8value_get_int_value_delegate));
            CfxApi.cfx_v8value_get_uint_value = (CfxApi.cfx_v8value_get_uint_value_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_get_uint_value, typeof(CfxApi.cfx_v8value_get_uint_value_delegate));
            CfxApi.cfx_v8value_get_double_value = (CfxApi.cfx_v8value_get_double_value_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_get_double_value, typeof(CfxApi.cfx_v8value_get_double_value_delegate));
            CfxApi.cfx_v8value_get_date_value = (CfxApi.cfx_v8value_get_date_value_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_get_date_value, typeof(CfxApi.cfx_v8value_get_date_value_delegate));
            CfxApi.cfx_v8value_get_string_value = (CfxApi.cfx_v8value_get_string_value_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_get_string_value, typeof(CfxApi.cfx_v8value_get_string_value_delegate));
            CfxApi.cfx_v8value_is_user_created = (CfxApi.cfx_v8value_is_user_created_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_is_user_created, typeof(CfxApi.cfx_v8value_is_user_created_delegate));
            CfxApi.cfx_v8value_has_exception = (CfxApi.cfx_v8value_has_exception_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_has_exception, typeof(CfxApi.cfx_v8value_has_exception_delegate));
            CfxApi.cfx_v8value_get_exception = (CfxApi.cfx_v8value_get_exception_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_get_exception, typeof(CfxApi.cfx_v8value_get_exception_delegate));
            CfxApi.cfx_v8value_clear_exception = (CfxApi.cfx_v8value_clear_exception_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_clear_exception, typeof(CfxApi.cfx_v8value_clear_exception_delegate));
            CfxApi.cfx_v8value_will_rethrow_exceptions = (CfxApi.cfx_v8value_will_rethrow_exceptions_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_will_rethrow_exceptions, typeof(CfxApi.cfx_v8value_will_rethrow_exceptions_delegate));
            CfxApi.cfx_v8value_set_rethrow_exceptions = (CfxApi.cfx_v8value_set_rethrow_exceptions_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_set_rethrow_exceptions, typeof(CfxApi.cfx_v8value_set_rethrow_exceptions_delegate));
            CfxApi.cfx_v8value_has_value_bykey = (CfxApi.cfx_v8value_has_value_bykey_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_has_value_bykey, typeof(CfxApi.cfx_v8value_has_value_bykey_delegate));
            CfxApi.cfx_v8value_has_value_byindex = (CfxApi.cfx_v8value_has_value_byindex_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_has_value_byindex, typeof(CfxApi.cfx_v8value_has_value_byindex_delegate));
            CfxApi.cfx_v8value_delete_value_bykey = (CfxApi.cfx_v8value_delete_value_bykey_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_delete_value_bykey, typeof(CfxApi.cfx_v8value_delete_value_bykey_delegate));
            CfxApi.cfx_v8value_delete_value_byindex = (CfxApi.cfx_v8value_delete_value_byindex_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_delete_value_byindex, typeof(CfxApi.cfx_v8value_delete_value_byindex_delegate));
            CfxApi.cfx_v8value_get_value_bykey = (CfxApi.cfx_v8value_get_value_bykey_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_get_value_bykey, typeof(CfxApi.cfx_v8value_get_value_bykey_delegate));
            CfxApi.cfx_v8value_get_value_byindex = (CfxApi.cfx_v8value_get_value_byindex_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_get_value_byindex, typeof(CfxApi.cfx_v8value_get_value_byindex_delegate));
            CfxApi.cfx_v8value_set_value_bykey = (CfxApi.cfx_v8value_set_value_bykey_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_set_value_bykey, typeof(CfxApi.cfx_v8value_set_value_bykey_delegate));
            CfxApi.cfx_v8value_set_value_byindex = (CfxApi.cfx_v8value_set_value_byindex_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_set_value_byindex, typeof(CfxApi.cfx_v8value_set_value_byindex_delegate));
            CfxApi.cfx_v8value_set_value_byaccessor = (CfxApi.cfx_v8value_set_value_byaccessor_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_set_value_byaccessor, typeof(CfxApi.cfx_v8value_set_value_byaccessor_delegate));
            CfxApi.cfx_v8value_get_keys = (CfxApi.cfx_v8value_get_keys_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_get_keys, typeof(CfxApi.cfx_v8value_get_keys_delegate));
            CfxApi.cfx_v8value_set_user_data = (CfxApi.cfx_v8value_set_user_data_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_set_user_data, typeof(CfxApi.cfx_v8value_set_user_data_delegate));
            CfxApi.cfx_v8value_get_user_data = (CfxApi.cfx_v8value_get_user_data_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_get_user_data, typeof(CfxApi.cfx_v8value_get_user_data_delegate));
            CfxApi.cfx_v8value_get_externally_allocated_memory = (CfxApi.cfx_v8value_get_externally_allocated_memory_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_get_externally_allocated_memory, typeof(CfxApi.cfx_v8value_get_externally_allocated_memory_delegate));
            CfxApi.cfx_v8value_adjust_externally_allocated_memory = (CfxApi.cfx_v8value_adjust_externally_allocated_memory_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_adjust_externally_allocated_memory, typeof(CfxApi.cfx_v8value_adjust_externally_allocated_memory_delegate));
            CfxApi.cfx_v8value_get_array_length = (CfxApi.cfx_v8value_get_array_length_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_get_array_length, typeof(CfxApi.cfx_v8value_get_array_length_delegate));
            CfxApi.cfx_v8value_get_function_name = (CfxApi.cfx_v8value_get_function_name_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_get_function_name, typeof(CfxApi.cfx_v8value_get_function_name_delegate));
            CfxApi.cfx_v8value_get_function_handler = (CfxApi.cfx_v8value_get_function_handler_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_get_function_handler, typeof(CfxApi.cfx_v8value_get_function_handler_delegate));
            CfxApi.cfx_v8value_execute_function = (CfxApi.cfx_v8value_execute_function_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_execute_function, typeof(CfxApi.cfx_v8value_execute_function_delegate));
            CfxApi.cfx_v8value_execute_function_with_context = (CfxApi.cfx_v8value_execute_function_with_context_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_execute_function_with_context, typeof(CfxApi.cfx_v8value_execute_function_with_context_delegate));
        }

        private static bool CfxValueApiLoaded;
        internal static void LoadCfxValueApi() {
            if(CfxValueApiLoaded) return;
            CfxValueApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_value_create = (CfxApi.cfx_value_create_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_value_create, typeof(CfxApi.cfx_value_create_delegate));
            CfxApi.cfx_value_is_valid = (CfxApi.cfx_value_is_valid_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_value_is_valid, typeof(CfxApi.cfx_value_is_valid_delegate));
            CfxApi.cfx_value_is_owned = (CfxApi.cfx_value_is_owned_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_value_is_owned, typeof(CfxApi.cfx_value_is_owned_delegate));
            CfxApi.cfx_value_is_read_only = (CfxApi.cfx_value_is_read_only_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_value_is_read_only, typeof(CfxApi.cfx_value_is_read_only_delegate));
            CfxApi.cfx_value_is_same = (CfxApi.cfx_value_is_same_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_value_is_same, typeof(CfxApi.cfx_value_is_same_delegate));
            CfxApi.cfx_value_is_equal = (CfxApi.cfx_value_is_equal_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_value_is_equal, typeof(CfxApi.cfx_value_is_equal_delegate));
            CfxApi.cfx_value_copy = (CfxApi.cfx_value_copy_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_value_copy, typeof(CfxApi.cfx_value_copy_delegate));
            CfxApi.cfx_value_get_type = (CfxApi.cfx_value_get_type_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_value_get_type, typeof(CfxApi.cfx_value_get_type_delegate));
            CfxApi.cfx_value_get_bool = (CfxApi.cfx_value_get_bool_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_value_get_bool, typeof(CfxApi.cfx_value_get_bool_delegate));
            CfxApi.cfx_value_get_int = (CfxApi.cfx_value_get_int_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_value_get_int, typeof(CfxApi.cfx_value_get_int_delegate));
            CfxApi.cfx_value_get_double = (CfxApi.cfx_value_get_double_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_value_get_double, typeof(CfxApi.cfx_value_get_double_delegate));
            CfxApi.cfx_value_get_string = (CfxApi.cfx_value_get_string_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_value_get_string, typeof(CfxApi.cfx_value_get_string_delegate));
            CfxApi.cfx_value_get_binary = (CfxApi.cfx_value_get_binary_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_value_get_binary, typeof(CfxApi.cfx_value_get_binary_delegate));
            CfxApi.cfx_value_get_dictionary = (CfxApi.cfx_value_get_dictionary_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_value_get_dictionary, typeof(CfxApi.cfx_value_get_dictionary_delegate));
            CfxApi.cfx_value_get_list = (CfxApi.cfx_value_get_list_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_value_get_list, typeof(CfxApi.cfx_value_get_list_delegate));
            CfxApi.cfx_value_set_null = (CfxApi.cfx_value_set_null_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_value_set_null, typeof(CfxApi.cfx_value_set_null_delegate));
            CfxApi.cfx_value_set_bool = (CfxApi.cfx_value_set_bool_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_value_set_bool, typeof(CfxApi.cfx_value_set_bool_delegate));
            CfxApi.cfx_value_set_int = (CfxApi.cfx_value_set_int_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_value_set_int, typeof(CfxApi.cfx_value_set_int_delegate));
            CfxApi.cfx_value_set_double = (CfxApi.cfx_value_set_double_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_value_set_double, typeof(CfxApi.cfx_value_set_double_delegate));
            CfxApi.cfx_value_set_string = (CfxApi.cfx_value_set_string_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_value_set_string, typeof(CfxApi.cfx_value_set_string_delegate));
            CfxApi.cfx_value_set_binary = (CfxApi.cfx_value_set_binary_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_value_set_binary, typeof(CfxApi.cfx_value_set_binary_delegate));
            CfxApi.cfx_value_set_dictionary = (CfxApi.cfx_value_set_dictionary_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_value_set_dictionary, typeof(CfxApi.cfx_value_set_dictionary_delegate));
            CfxApi.cfx_value_set_list = (CfxApi.cfx_value_set_list_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_value_set_list, typeof(CfxApi.cfx_value_set_list_delegate));
        }

        private static bool CfxWebPluginInfoApiLoaded;
        internal static void LoadCfxWebPluginInfoApi() {
            if(CfxWebPluginInfoApiLoaded) return;
            CfxWebPluginInfoApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_web_plugin_info_get_name = (CfxApi.cfx_web_plugin_info_get_name_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_web_plugin_info_get_name, typeof(CfxApi.cfx_web_plugin_info_get_name_delegate));
            CfxApi.cfx_web_plugin_info_get_path = (CfxApi.cfx_web_plugin_info_get_path_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_web_plugin_info_get_path, typeof(CfxApi.cfx_web_plugin_info_get_path_delegate));
            CfxApi.cfx_web_plugin_info_get_version = (CfxApi.cfx_web_plugin_info_get_version_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_web_plugin_info_get_version, typeof(CfxApi.cfx_web_plugin_info_get_version_delegate));
            CfxApi.cfx_web_plugin_info_get_description = (CfxApi.cfx_web_plugin_info_get_description_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_web_plugin_info_get_description, typeof(CfxApi.cfx_web_plugin_info_get_description_delegate));
        }

        private static bool CfxWebPluginInfoVisitorApiLoaded;
        internal static void LoadCfxWebPluginInfoVisitorApi() {
            if(CfxWebPluginInfoVisitorApiLoaded) return;
            CfxWebPluginInfoVisitorApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_web_plugin_info_visitor_ctor = (CfxApi.cfx_ctor_with_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_web_plugin_info_visitor_ctor, typeof(CfxApi.cfx_ctor_with_gc_handle_delegate));
            CfxApi.cfx_web_plugin_info_visitor_get_gc_handle = (CfxApi.cfx_get_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_web_plugin_info_visitor_get_gc_handle, typeof(CfxApi.cfx_get_gc_handle_delegate));
            CfxApi.cfx_web_plugin_info_visitor_set_managed_callback = (CfxApi.cfx_set_callback_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_web_plugin_info_visitor_set_managed_callback, typeof(CfxApi.cfx_set_callback_delegate));
        }

        private static bool CfxWebPluginUnstableCallbackApiLoaded;
        internal static void LoadCfxWebPluginUnstableCallbackApi() {
            if(CfxWebPluginUnstableCallbackApiLoaded) return;
            CfxWebPluginUnstableCallbackApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_web_plugin_unstable_callback_ctor = (CfxApi.cfx_ctor_with_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_web_plugin_unstable_callback_ctor, typeof(CfxApi.cfx_ctor_with_gc_handle_delegate));
            CfxApi.cfx_web_plugin_unstable_callback_get_gc_handle = (CfxApi.cfx_get_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_web_plugin_unstable_callback_get_gc_handle, typeof(CfxApi.cfx_get_gc_handle_delegate));
            CfxApi.cfx_web_plugin_unstable_callback_set_managed_callback = (CfxApi.cfx_set_callback_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_web_plugin_unstable_callback_set_managed_callback, typeof(CfxApi.cfx_set_callback_delegate));
        }

        private static bool CfxWindowInfoLinuxApiLoaded;
        internal static void LoadCfxWindowInfoLinuxApi() {
            if(CfxWindowInfoLinuxApiLoaded) return;
            CfxWindowInfoLinuxApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_window_info_linux_ctor = (CfxApi.cfx_ctor_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_window_info_linux_ctor, typeof(CfxApi.cfx_ctor_delegate));
            CfxApi.cfx_window_info_linux_dtor = (CfxApi.cfx_dtor_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_window_info_linux_dtor, typeof(CfxApi.cfx_dtor_delegate));
            CfxApi.cfx_window_info_linux_set_x = (CfxApi.cfx_window_info_linux_set_x_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_window_info_linux_set_x, typeof(CfxApi.cfx_window_info_linux_set_x_delegate));
            CfxApi.cfx_window_info_linux_get_x = (CfxApi.cfx_window_info_linux_get_x_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_window_info_linux_get_x, typeof(CfxApi.cfx_window_info_linux_get_x_delegate));
            CfxApi.cfx_window_info_linux_set_y = (CfxApi.cfx_window_info_linux_set_y_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_window_info_linux_set_y, typeof(CfxApi.cfx_window_info_linux_set_y_delegate));
            CfxApi.cfx_window_info_linux_get_y = (CfxApi.cfx_window_info_linux_get_y_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_window_info_linux_get_y, typeof(CfxApi.cfx_window_info_linux_get_y_delegate));
            CfxApi.cfx_window_info_linux_set_width = (CfxApi.cfx_window_info_linux_set_width_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_window_info_linux_set_width, typeof(CfxApi.cfx_window_info_linux_set_width_delegate));
            CfxApi.cfx_window_info_linux_get_width = (CfxApi.cfx_window_info_linux_get_width_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_window_info_linux_get_width, typeof(CfxApi.cfx_window_info_linux_get_width_delegate));
            CfxApi.cfx_window_info_linux_set_height = (CfxApi.cfx_window_info_linux_set_height_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_window_info_linux_set_height, typeof(CfxApi.cfx_window_info_linux_set_height_delegate));
            CfxApi.cfx_window_info_linux_get_height = (CfxApi.cfx_window_info_linux_get_height_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_window_info_linux_get_height, typeof(CfxApi.cfx_window_info_linux_get_height_delegate));
            CfxApi.cfx_window_info_linux_set_parent_window = (CfxApi.cfx_window_info_linux_set_parent_window_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_window_info_linux_set_parent_window, typeof(CfxApi.cfx_window_info_linux_set_parent_window_delegate));
            CfxApi.cfx_window_info_linux_get_parent_window = (CfxApi.cfx_window_info_linux_get_parent_window_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_window_info_linux_get_parent_window, typeof(CfxApi.cfx_window_info_linux_get_parent_window_delegate));
            CfxApi.cfx_window_info_linux_set_windowless_rendering_enabled = (CfxApi.cfx_window_info_linux_set_windowless_rendering_enabled_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_window_info_linux_set_windowless_rendering_enabled, typeof(CfxApi.cfx_window_info_linux_set_windowless_rendering_enabled_delegate));
            CfxApi.cfx_window_info_linux_get_windowless_rendering_enabled = (CfxApi.cfx_window_info_linux_get_windowless_rendering_enabled_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_window_info_linux_get_windowless_rendering_enabled, typeof(CfxApi.cfx_window_info_linux_get_windowless_rendering_enabled_delegate));
            CfxApi.cfx_window_info_linux_set_transparent_painting_enabled = (CfxApi.cfx_window_info_linux_set_transparent_painting_enabled_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_window_info_linux_set_transparent_painting_enabled, typeof(CfxApi.cfx_window_info_linux_set_transparent_painting_enabled_delegate));
            CfxApi.cfx_window_info_linux_get_transparent_painting_enabled = (CfxApi.cfx_window_info_linux_get_transparent_painting_enabled_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_window_info_linux_get_transparent_painting_enabled, typeof(CfxApi.cfx_window_info_linux_get_transparent_painting_enabled_delegate));
            CfxApi.cfx_window_info_linux_set_window = (CfxApi.cfx_window_info_linux_set_window_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_window_info_linux_set_window, typeof(CfxApi.cfx_window_info_linux_set_window_delegate));
            CfxApi.cfx_window_info_linux_get_window = (CfxApi.cfx_window_info_linux_get_window_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_window_info_linux_get_window, typeof(CfxApi.cfx_window_info_linux_get_window_delegate));
        }

        private static bool CfxWindowInfoWindowsApiLoaded;
        internal static void LoadCfxWindowInfoWindowsApi() {
            if(CfxWindowInfoWindowsApiLoaded) return;
            CfxWindowInfoWindowsApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_window_info_windows_ctor = (CfxApi.cfx_ctor_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_window_info_windows_ctor, typeof(CfxApi.cfx_ctor_delegate));
            CfxApi.cfx_window_info_windows_dtor = (CfxApi.cfx_dtor_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_window_info_windows_dtor, typeof(CfxApi.cfx_dtor_delegate));
            CfxApi.cfx_window_info_windows_set_ex_style = (CfxApi.cfx_window_info_windows_set_ex_style_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_window_info_windows_set_ex_style, typeof(CfxApi.cfx_window_info_windows_set_ex_style_delegate));
            CfxApi.cfx_window_info_windows_get_ex_style = (CfxApi.cfx_window_info_windows_get_ex_style_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_window_info_windows_get_ex_style, typeof(CfxApi.cfx_window_info_windows_get_ex_style_delegate));
            CfxApi.cfx_window_info_windows_set_window_name = (CfxApi.cfx_window_info_windows_set_window_name_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_window_info_windows_set_window_name, typeof(CfxApi.cfx_window_info_windows_set_window_name_delegate));
            CfxApi.cfx_window_info_windows_get_window_name = (CfxApi.cfx_window_info_windows_get_window_name_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_window_info_windows_get_window_name, typeof(CfxApi.cfx_window_info_windows_get_window_name_delegate));
            CfxApi.cfx_window_info_windows_set_style = (CfxApi.cfx_window_info_windows_set_style_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_window_info_windows_set_style, typeof(CfxApi.cfx_window_info_windows_set_style_delegate));
            CfxApi.cfx_window_info_windows_get_style = (CfxApi.cfx_window_info_windows_get_style_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_window_info_windows_get_style, typeof(CfxApi.cfx_window_info_windows_get_style_delegate));
            CfxApi.cfx_window_info_windows_set_x = (CfxApi.cfx_window_info_windows_set_x_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_window_info_windows_set_x, typeof(CfxApi.cfx_window_info_windows_set_x_delegate));
            CfxApi.cfx_window_info_windows_get_x = (CfxApi.cfx_window_info_windows_get_x_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_window_info_windows_get_x, typeof(CfxApi.cfx_window_info_windows_get_x_delegate));
            CfxApi.cfx_window_info_windows_set_y = (CfxApi.cfx_window_info_windows_set_y_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_window_info_windows_set_y, typeof(CfxApi.cfx_window_info_windows_set_y_delegate));
            CfxApi.cfx_window_info_windows_get_y = (CfxApi.cfx_window_info_windows_get_y_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_window_info_windows_get_y, typeof(CfxApi.cfx_window_info_windows_get_y_delegate));
            CfxApi.cfx_window_info_windows_set_width = (CfxApi.cfx_window_info_windows_set_width_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_window_info_windows_set_width, typeof(CfxApi.cfx_window_info_windows_set_width_delegate));
            CfxApi.cfx_window_info_windows_get_width = (CfxApi.cfx_window_info_windows_get_width_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_window_info_windows_get_width, typeof(CfxApi.cfx_window_info_windows_get_width_delegate));
            CfxApi.cfx_window_info_windows_set_height = (CfxApi.cfx_window_info_windows_set_height_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_window_info_windows_set_height, typeof(CfxApi.cfx_window_info_windows_set_height_delegate));
            CfxApi.cfx_window_info_windows_get_height = (CfxApi.cfx_window_info_windows_get_height_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_window_info_windows_get_height, typeof(CfxApi.cfx_window_info_windows_get_height_delegate));
            CfxApi.cfx_window_info_windows_set_parent_window = (CfxApi.cfx_window_info_windows_set_parent_window_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_window_info_windows_set_parent_window, typeof(CfxApi.cfx_window_info_windows_set_parent_window_delegate));
            CfxApi.cfx_window_info_windows_get_parent_window = (CfxApi.cfx_window_info_windows_get_parent_window_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_window_info_windows_get_parent_window, typeof(CfxApi.cfx_window_info_windows_get_parent_window_delegate));
            CfxApi.cfx_window_info_windows_set_menu = (CfxApi.cfx_window_info_windows_set_menu_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_window_info_windows_set_menu, typeof(CfxApi.cfx_window_info_windows_set_menu_delegate));
            CfxApi.cfx_window_info_windows_get_menu = (CfxApi.cfx_window_info_windows_get_menu_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_window_info_windows_get_menu, typeof(CfxApi.cfx_window_info_windows_get_menu_delegate));
            CfxApi.cfx_window_info_windows_set_windowless_rendering_enabled = (CfxApi.cfx_window_info_windows_set_windowless_rendering_enabled_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_window_info_windows_set_windowless_rendering_enabled, typeof(CfxApi.cfx_window_info_windows_set_windowless_rendering_enabled_delegate));
            CfxApi.cfx_window_info_windows_get_windowless_rendering_enabled = (CfxApi.cfx_window_info_windows_get_windowless_rendering_enabled_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_window_info_windows_get_windowless_rendering_enabled, typeof(CfxApi.cfx_window_info_windows_get_windowless_rendering_enabled_delegate));
            CfxApi.cfx_window_info_windows_set_transparent_painting_enabled = (CfxApi.cfx_window_info_windows_set_transparent_painting_enabled_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_window_info_windows_set_transparent_painting_enabled, typeof(CfxApi.cfx_window_info_windows_set_transparent_painting_enabled_delegate));
            CfxApi.cfx_window_info_windows_get_transparent_painting_enabled = (CfxApi.cfx_window_info_windows_get_transparent_painting_enabled_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_window_info_windows_get_transparent_painting_enabled, typeof(CfxApi.cfx_window_info_windows_get_transparent_painting_enabled_delegate));
            CfxApi.cfx_window_info_windows_set_window = (CfxApi.cfx_window_info_windows_set_window_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_window_info_windows_set_window, typeof(CfxApi.cfx_window_info_windows_set_window_delegate));
            CfxApi.cfx_window_info_windows_get_window = (CfxApi.cfx_window_info_windows_get_window_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_window_info_windows_get_window, typeof(CfxApi.cfx_window_info_windows_get_window_delegate));
        }

        private static bool CfxWriteHandlerApiLoaded;
        internal static void LoadCfxWriteHandlerApi() {
            if(CfxWriteHandlerApiLoaded) return;
            CfxWriteHandlerApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_write_handler_ctor = (CfxApi.cfx_ctor_with_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_write_handler_ctor, typeof(CfxApi.cfx_ctor_with_gc_handle_delegate));
            CfxApi.cfx_write_handler_get_gc_handle = (CfxApi.cfx_get_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_write_handler_get_gc_handle, typeof(CfxApi.cfx_get_gc_handle_delegate));
            CfxApi.cfx_write_handler_set_managed_callback = (CfxApi.cfx_set_callback_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_write_handler_set_managed_callback, typeof(CfxApi.cfx_set_callback_delegate));
        }

        private static bool CfxXmlReaderApiLoaded;
        internal static void LoadCfxXmlReaderApi() {
            if(CfxXmlReaderApiLoaded) return;
            CfxXmlReaderApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_xml_reader_create = (CfxApi.cfx_xml_reader_create_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_xml_reader_create, typeof(CfxApi.cfx_xml_reader_create_delegate));
            CfxApi.cfx_xml_reader_move_to_next_node = (CfxApi.cfx_xml_reader_move_to_next_node_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_xml_reader_move_to_next_node, typeof(CfxApi.cfx_xml_reader_move_to_next_node_delegate));
            CfxApi.cfx_xml_reader_close = (CfxApi.cfx_xml_reader_close_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_xml_reader_close, typeof(CfxApi.cfx_xml_reader_close_delegate));
            CfxApi.cfx_xml_reader_has_error = (CfxApi.cfx_xml_reader_has_error_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_xml_reader_has_error, typeof(CfxApi.cfx_xml_reader_has_error_delegate));
            CfxApi.cfx_xml_reader_get_error = (CfxApi.cfx_xml_reader_get_error_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_xml_reader_get_error, typeof(CfxApi.cfx_xml_reader_get_error_delegate));
            CfxApi.cfx_xml_reader_get_type = (CfxApi.cfx_xml_reader_get_type_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_xml_reader_get_type, typeof(CfxApi.cfx_xml_reader_get_type_delegate));
            CfxApi.cfx_xml_reader_get_depth = (CfxApi.cfx_xml_reader_get_depth_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_xml_reader_get_depth, typeof(CfxApi.cfx_xml_reader_get_depth_delegate));
            CfxApi.cfx_xml_reader_get_local_name = (CfxApi.cfx_xml_reader_get_local_name_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_xml_reader_get_local_name, typeof(CfxApi.cfx_xml_reader_get_local_name_delegate));
            CfxApi.cfx_xml_reader_get_prefix = (CfxApi.cfx_xml_reader_get_prefix_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_xml_reader_get_prefix, typeof(CfxApi.cfx_xml_reader_get_prefix_delegate));
            CfxApi.cfx_xml_reader_get_qualified_name = (CfxApi.cfx_xml_reader_get_qualified_name_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_xml_reader_get_qualified_name, typeof(CfxApi.cfx_xml_reader_get_qualified_name_delegate));
            CfxApi.cfx_xml_reader_get_namespace_uri = (CfxApi.cfx_xml_reader_get_namespace_uri_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_xml_reader_get_namespace_uri, typeof(CfxApi.cfx_xml_reader_get_namespace_uri_delegate));
            CfxApi.cfx_xml_reader_get_base_uri = (CfxApi.cfx_xml_reader_get_base_uri_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_xml_reader_get_base_uri, typeof(CfxApi.cfx_xml_reader_get_base_uri_delegate));
            CfxApi.cfx_xml_reader_get_xml_lang = (CfxApi.cfx_xml_reader_get_xml_lang_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_xml_reader_get_xml_lang, typeof(CfxApi.cfx_xml_reader_get_xml_lang_delegate));
            CfxApi.cfx_xml_reader_is_empty_element = (CfxApi.cfx_xml_reader_is_empty_element_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_xml_reader_is_empty_element, typeof(CfxApi.cfx_xml_reader_is_empty_element_delegate));
            CfxApi.cfx_xml_reader_has_value = (CfxApi.cfx_xml_reader_has_value_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_xml_reader_has_value, typeof(CfxApi.cfx_xml_reader_has_value_delegate));
            CfxApi.cfx_xml_reader_get_value = (CfxApi.cfx_xml_reader_get_value_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_xml_reader_get_value, typeof(CfxApi.cfx_xml_reader_get_value_delegate));
            CfxApi.cfx_xml_reader_has_attributes = (CfxApi.cfx_xml_reader_has_attributes_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_xml_reader_has_attributes, typeof(CfxApi.cfx_xml_reader_has_attributes_delegate));
            CfxApi.cfx_xml_reader_get_attribute_count = (CfxApi.cfx_xml_reader_get_attribute_count_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_xml_reader_get_attribute_count, typeof(CfxApi.cfx_xml_reader_get_attribute_count_delegate));
            CfxApi.cfx_xml_reader_get_attribute_byindex = (CfxApi.cfx_xml_reader_get_attribute_byindex_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_xml_reader_get_attribute_byindex, typeof(CfxApi.cfx_xml_reader_get_attribute_byindex_delegate));
            CfxApi.cfx_xml_reader_get_attribute_byqname = (CfxApi.cfx_xml_reader_get_attribute_byqname_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_xml_reader_get_attribute_byqname, typeof(CfxApi.cfx_xml_reader_get_attribute_byqname_delegate));
            CfxApi.cfx_xml_reader_get_attribute_bylname = (CfxApi.cfx_xml_reader_get_attribute_bylname_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_xml_reader_get_attribute_bylname, typeof(CfxApi.cfx_xml_reader_get_attribute_bylname_delegate));
            CfxApi.cfx_xml_reader_get_inner_xml = (CfxApi.cfx_xml_reader_get_inner_xml_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_xml_reader_get_inner_xml, typeof(CfxApi.cfx_xml_reader_get_inner_xml_delegate));
            CfxApi.cfx_xml_reader_get_outer_xml = (CfxApi.cfx_xml_reader_get_outer_xml_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_xml_reader_get_outer_xml, typeof(CfxApi.cfx_xml_reader_get_outer_xml_delegate));
            CfxApi.cfx_xml_reader_get_line_number = (CfxApi.cfx_xml_reader_get_line_number_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_xml_reader_get_line_number, typeof(CfxApi.cfx_xml_reader_get_line_number_delegate));
            CfxApi.cfx_xml_reader_move_to_attribute_byindex = (CfxApi.cfx_xml_reader_move_to_attribute_byindex_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_xml_reader_move_to_attribute_byindex, typeof(CfxApi.cfx_xml_reader_move_to_attribute_byindex_delegate));
            CfxApi.cfx_xml_reader_move_to_attribute_byqname = (CfxApi.cfx_xml_reader_move_to_attribute_byqname_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_xml_reader_move_to_attribute_byqname, typeof(CfxApi.cfx_xml_reader_move_to_attribute_byqname_delegate));
            CfxApi.cfx_xml_reader_move_to_attribute_bylname = (CfxApi.cfx_xml_reader_move_to_attribute_bylname_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_xml_reader_move_to_attribute_bylname, typeof(CfxApi.cfx_xml_reader_move_to_attribute_bylname_delegate));
            CfxApi.cfx_xml_reader_move_to_first_attribute = (CfxApi.cfx_xml_reader_move_to_first_attribute_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_xml_reader_move_to_first_attribute, typeof(CfxApi.cfx_xml_reader_move_to_first_attribute_delegate));
            CfxApi.cfx_xml_reader_move_to_next_attribute = (CfxApi.cfx_xml_reader_move_to_next_attribute_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_xml_reader_move_to_next_attribute, typeof(CfxApi.cfx_xml_reader_move_to_next_attribute_delegate));
            CfxApi.cfx_xml_reader_move_to_carrying_element = (CfxApi.cfx_xml_reader_move_to_carrying_element_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_xml_reader_move_to_carrying_element, typeof(CfxApi.cfx_xml_reader_move_to_carrying_element_delegate));
        }

        private static bool CfxZipReaderApiLoaded;
        internal static void LoadCfxZipReaderApi() {
            if(CfxZipReaderApiLoaded) return;
            CfxZipReaderApiLoaded = true;
            CfxApi.Probe();
            CfxApi.cfx_zip_reader_create = (CfxApi.cfx_zip_reader_create_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_zip_reader_create, typeof(CfxApi.cfx_zip_reader_create_delegate));
            CfxApi.cfx_zip_reader_move_to_first_file = (CfxApi.cfx_zip_reader_move_to_first_file_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_zip_reader_move_to_first_file, typeof(CfxApi.cfx_zip_reader_move_to_first_file_delegate));
            CfxApi.cfx_zip_reader_move_to_next_file = (CfxApi.cfx_zip_reader_move_to_next_file_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_zip_reader_move_to_next_file, typeof(CfxApi.cfx_zip_reader_move_to_next_file_delegate));
            CfxApi.cfx_zip_reader_move_to_file = (CfxApi.cfx_zip_reader_move_to_file_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_zip_reader_move_to_file, typeof(CfxApi.cfx_zip_reader_move_to_file_delegate));
            CfxApi.cfx_zip_reader_close = (CfxApi.cfx_zip_reader_close_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_zip_reader_close, typeof(CfxApi.cfx_zip_reader_close_delegate));
            CfxApi.cfx_zip_reader_get_file_name = (CfxApi.cfx_zip_reader_get_file_name_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_zip_reader_get_file_name, typeof(CfxApi.cfx_zip_reader_get_file_name_delegate));
            CfxApi.cfx_zip_reader_get_file_size = (CfxApi.cfx_zip_reader_get_file_size_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_zip_reader_get_file_size, typeof(CfxApi.cfx_zip_reader_get_file_size_delegate));
            CfxApi.cfx_zip_reader_get_file_last_modified = (CfxApi.cfx_zip_reader_get_file_last_modified_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_zip_reader_get_file_last_modified, typeof(CfxApi.cfx_zip_reader_get_file_last_modified_delegate));
            CfxApi.cfx_zip_reader_open_file = (CfxApi.cfx_zip_reader_open_file_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_zip_reader_open_file, typeof(CfxApi.cfx_zip_reader_open_file_delegate));
            CfxApi.cfx_zip_reader_close_file = (CfxApi.cfx_zip_reader_close_file_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_zip_reader_close_file, typeof(CfxApi.cfx_zip_reader_close_file_delegate));
            CfxApi.cfx_zip_reader_read_file = (CfxApi.cfx_zip_reader_read_file_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_zip_reader_read_file, typeof(CfxApi.cfx_zip_reader_read_file_delegate));
            CfxApi.cfx_zip_reader_tell = (CfxApi.cfx_zip_reader_tell_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_zip_reader_tell, typeof(CfxApi.cfx_zip_reader_tell_delegate));
            CfxApi.cfx_zip_reader_eof = (CfxApi.cfx_zip_reader_eof_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_zip_reader_eof, typeof(CfxApi.cfx_zip_reader_eof_delegate));
        }

    }
}
