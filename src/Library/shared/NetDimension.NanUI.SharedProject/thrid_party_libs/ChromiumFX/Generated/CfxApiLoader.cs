// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium {
    internal partial class CfxApiLoader {
        internal enum FunctionIndex {
            cfx_add_cross_origin_whitelist_entry,
            cfx_api_hash,
            cfx_base64decode,
            cfx_base64encode,
            cfx_begin_tracing,
            cfx_clear_cross_origin_whitelist,
            cfx_clear_scheme_handler_factories,
            cfx_crash_reporting_enabled,
            cfx_create_context_shared,
            cfx_create_directory,
            cfx_create_new_temp_directory,
            cfx_create_temp_directory_in_directory,
            cfx_create_url,
            cfx_currently_on,
            cfx_delete_file,
            cfx_directory_exists,
            cfx_do_message_loop_work,
            cfx_enable_highdpi_support,
            cfx_end_tracing,
            cfx_execute_process,
            cfx_format_url_for_security_display,
            cfx_get_extensions_for_mime_type,
            cfx_get_mime_type,
            cfx_get_path,
            cfx_get_temp_directory,
            cfx_get_xdisplay,
            cfx_initialize,
            cfx_is_cert_status_error,
            cfx_is_cert_status_minor_error,
            cfx_is_web_plugin_unstable,
            cfx_launch_process,
            cfx_load_crlsets_file,
            cfx_now_from_system_trace_time,
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
            cfx_register_widevine_cdm,
            cfx_remove_cross_origin_whitelist_entry,
            cfx_run_message_loop,
            cfx_set_crash_key_value,
            cfx_set_osmodal_loop,
            cfx_shutdown,
            cfx_unregister_internal_web_plugin,
            cfx_uridecode,
            cfx_uriencode,
            cfx_version_info,
            cfx_visit_web_plugin_info,
            cfx_write_json,
            cfx_zip_directory,
            cfx_accessibility_handler_ctor,
            cfx_accessibility_handler_set_callback,
            cfx_app_ctor,
            cfx_app_set_callback,
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
            cfx_box_layout_settings_ctor,
            cfx_box_layout_settings_dtor,
            cfx_box_layout_settings_set_horizontal,
            cfx_box_layout_settings_get_horizontal,
            cfx_box_layout_settings_set_inside_border_horizontal_spacing,
            cfx_box_layout_settings_get_inside_border_horizontal_spacing,
            cfx_box_layout_settings_set_inside_border_vertical_spacing,
            cfx_box_layout_settings_get_inside_border_vertical_spacing,
            cfx_box_layout_settings_set_inside_border_insets,
            cfx_box_layout_settings_get_inside_border_insets,
            cfx_box_layout_settings_set_between_child_spacing,
            cfx_box_layout_settings_get_between_child_spacing,
            cfx_box_layout_settings_set_main_axis_alignment,
            cfx_box_layout_settings_get_main_axis_alignment,
            cfx_box_layout_settings_set_cross_axis_alignment,
            cfx_box_layout_settings_get_cross_axis_alignment,
            cfx_box_layout_settings_set_minimum_cross_axis_size,
            cfx_box_layout_settings_get_minimum_cross_axis_size,
            cfx_box_layout_settings_set_default_flex,
            cfx_box_layout_settings_get_default_flex,
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
            cfx_browser_host_create_browser,
            cfx_browser_host_create_browser_sync,
            cfx_browser_host_get_browser,
            cfx_browser_host_close_browser,
            cfx_browser_host_try_close_browser,
            cfx_browser_host_set_focus,
            cfx_browser_host_get_window_handle,
            cfx_browser_host_get_opener_window_handle,
            cfx_browser_host_has_view,
            cfx_browser_host_get_client,
            cfx_browser_host_get_request_context,
            cfx_browser_host_get_zoom_level,
            cfx_browser_host_set_zoom_level,
            cfx_browser_host_run_file_dialog,
            cfx_browser_host_start_download,
            cfx_browser_host_download_image,
            cfx_browser_host_print,
            cfx_browser_host_print_to_pdf,
            cfx_browser_host_find,
            cfx_browser_host_stop_finding,
            cfx_browser_host_show_dev_tools,
            cfx_browser_host_close_dev_tools,
            cfx_browser_host_has_dev_tools,
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
            cfx_browser_host_send_external_begin_frame,
            cfx_browser_host_send_key_event,
            cfx_browser_host_send_mouse_click_event,
            cfx_browser_host_send_mouse_move_event,
            cfx_browser_host_send_mouse_wheel_event,
            cfx_browser_host_send_touch_event,
            cfx_browser_host_send_focus_event,
            cfx_browser_host_send_capture_lost_event,
            cfx_browser_host_notify_move_or_resize_started,
            cfx_browser_host_get_windowless_frame_rate,
            cfx_browser_host_set_windowless_frame_rate,
            cfx_browser_host_ime_set_composition,
            cfx_browser_host_ime_commit_text,
            cfx_browser_host_ime_finish_composing_text,
            cfx_browser_host_ime_cancel_composition,
            cfx_browser_host_drag_target_drag_enter,
            cfx_browser_host_drag_target_drag_over,
            cfx_browser_host_drag_target_drag_leave,
            cfx_browser_host_drag_target_drop,
            cfx_browser_host_drag_source_ended_at,
            cfx_browser_host_drag_source_system_drag_ended,
            cfx_browser_host_get_visible_navigation_entry,
            cfx_browser_host_set_accessibility_state,
            cfx_browser_host_set_auto_resize_enabled,
            cfx_browser_host_get_extension,
            cfx_browser_host_is_background_host,
            cfx_browser_host_set_audio_muted,
            cfx_browser_host_is_audio_muted,
            cfx_browser_process_handler_ctor,
            cfx_browser_process_handler_set_callback,
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
            cfx_browser_settings_set_javascript_close_windows,
            cfx_browser_settings_get_javascript_close_windows,
            cfx_browser_settings_set_javascript_access_clipboard,
            cfx_browser_settings_get_javascript_access_clipboard,
            cfx_browser_settings_set_javascript_dom_paste,
            cfx_browser_settings_get_javascript_dom_paste,
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
            cfx_client_set_callback,
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
            cfx_completion_callback_set_callback,
            cfx_composition_underline_ctor,
            cfx_composition_underline_dtor,
            cfx_composition_underline_set_range,
            cfx_composition_underline_get_range,
            cfx_composition_underline_set_color,
            cfx_composition_underline_get_color,
            cfx_composition_underline_set_background_color,
            cfx_composition_underline_get_background_color,
            cfx_composition_underline_set_thick,
            cfx_composition_underline_get_thick,
            cfx_context_menu_handler_ctor,
            cfx_context_menu_handler_set_callback,
            cfx_context_menu_params_get_xcoord,
            cfx_context_menu_params_get_ycoord,
            cfx_context_menu_params_get_type_flags,
            cfx_context_menu_params_get_link_url,
            cfx_context_menu_params_get_unfiltered_link_url,
            cfx_context_menu_params_get_source_url,
            cfx_context_menu_params_has_image_contents,
            cfx_context_menu_params_get_title_text,
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
            cfx_cookie_access_filter_ctor,
            cfx_cookie_access_filter_set_callback,
            cfx_cookie_manager_get_global_manager,
            cfx_cookie_manager_set_supported_schemes,
            cfx_cookie_manager_visit_all_cookies,
            cfx_cookie_manager_visit_url_cookies,
            cfx_cookie_manager_set_cookie,
            cfx_cookie_manager_delete_cookies,
            cfx_cookie_manager_flush_store,
            cfx_cookie_visitor_ctor,
            cfx_cookie_visitor_set_callback,
            cfx_cursor_info_ctor,
            cfx_cursor_info_dtor,
            cfx_cursor_info_set_hotspot,
            cfx_cursor_info_get_hotspot,
            cfx_cursor_info_set_image_scale_factor,
            cfx_cursor_info_get_image_scale_factor,
            cfx_cursor_info_set_buffer,
            cfx_cursor_info_get_buffer,
            cfx_cursor_info_set_size,
            cfx_cursor_info_get_size,
            cfx_delete_cookies_callback_ctor,
            cfx_delete_cookies_callback_set_callback,
            cfx_dialog_handler_ctor,
            cfx_dialog_handler_set_callback,
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
            cfx_display_handler_set_callback,
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
            cfx_domnode_get_element_bounds,
            cfx_domvisitor_ctor,
            cfx_domvisitor_set_callback,
            cfx_download_handler_ctor,
            cfx_download_handler_set_callback,
            cfx_download_image_callback_ctor,
            cfx_download_image_callback_set_callback,
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
            cfx_drag_data_get_image,
            cfx_drag_data_get_image_hotspot,
            cfx_drag_data_has_image,
            cfx_drag_handler_ctor,
            cfx_drag_handler_set_callback,
            cfx_draggable_region_ctor,
            cfx_draggable_region_dtor,
            cfx_draggable_region_set_bounds,
            cfx_draggable_region_get_bounds,
            cfx_draggable_region_set_draggable,
            cfx_draggable_region_get_draggable,
            cfx_end_tracing_callback_ctor,
            cfx_end_tracing_callback_set_callback,
            cfx_extension_get_identifier,
            cfx_extension_get_path,
            cfx_extension_get_manifest,
            cfx_extension_is_same,
            cfx_extension_get_handler,
            cfx_extension_get_loader_context,
            cfx_extension_is_loaded,
            cfx_extension_unload,
            cfx_extension_handler_ctor,
            cfx_extension_handler_get_gc_handle,
            cfx_extension_handler_set_callback,
            cfx_file_dialog_callback_cont,
            cfx_file_dialog_callback_cancel,
            cfx_find_handler_ctor,
            cfx_find_handler_set_callback,
            cfx_focus_handler_ctor,
            cfx_focus_handler_set_callback,
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
            cfx_frame_create_urlrequest,
            cfx_frame_send_process_message,
            cfx_get_extension_resource_callback_cont,
            cfx_get_extension_resource_callback_cancel,
            cfx_image_create,
            cfx_image_is_empty,
            cfx_image_is_same,
            cfx_image_add_bitmap,
            cfx_image_add_png,
            cfx_image_add_jpeg,
            cfx_image_get_width,
            cfx_image_get_height,
            cfx_image_has_representation,
            cfx_image_remove_representation,
            cfx_image_get_representation_info,
            cfx_image_get_as_bitmap,
            cfx_image_get_as_png,
            cfx_image_get_as_jpeg,
            cfx_insets_ctor,
            cfx_insets_dtor,
            cfx_insets_set_top,
            cfx_insets_get_top,
            cfx_insets_set_left,
            cfx_insets_get_left,
            cfx_insets_set_bottom,
            cfx_insets_get_bottom,
            cfx_insets_set_right,
            cfx_insets_get_right,
            cfx_jsdialog_callback_cont,
            cfx_jsdialog_handler_ctor,
            cfx_jsdialog_handler_set_callback,
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
            cfx_keyboard_handler_set_callback,
            cfx_life_span_handler_ctor,
            cfx_life_span_handler_set_callback,
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
            cfx_load_handler_set_callback,
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
            cfx_menu_model_create,
            cfx_menu_model_is_sub_menu,
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
            cfx_menu_model_set_color,
            cfx_menu_model_set_color_at,
            cfx_menu_model_get_color,
            cfx_menu_model_get_color_at,
            cfx_menu_model_set_font_list,
            cfx_menu_model_set_font_list_at,
            cfx_menu_model_delegate_ctor,
            cfx_menu_model_delegate_set_callback,
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
            cfx_navigation_entry_get_sslstatus,
            cfx_navigation_entry_visitor_ctor,
            cfx_navigation_entry_visitor_set_callback,
            cfx_pdf_print_callback_ctor,
            cfx_pdf_print_callback_set_callback,
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
            cfx_pdf_print_settings_set_scale_factor,
            cfx_pdf_print_settings_get_scale_factor,
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
            cfx_popup_features_set_scrollbarsVisible,
            cfx_popup_features_get_scrollbarsVisible,
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
            cfx_print_handler_set_callback,
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
            cfx_range_ctor,
            cfx_range_dtor,
            cfx_range_set_from,
            cfx_range_get_from,
            cfx_range_set_to,
            cfx_range_get_to,
            cfx_read_handler_ctor,
            cfx_read_handler_set_callback,
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
            cfx_register_cdm_callback_ctor,
            cfx_register_cdm_callback_set_callback,
            cfx_render_handler_ctor,
            cfx_render_handler_set_callback,
            cfx_render_process_handler_ctor,
            cfx_render_process_handler_set_callback,
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
            cfx_request_get_header_by_name,
            cfx_request_set_header_by_name,
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
            cfx_request_context_get_cookie_manager,
            cfx_request_context_register_scheme_handler_factory,
            cfx_request_context_clear_scheme_handler_factories,
            cfx_request_context_purge_plugin_list_cache,
            cfx_request_context_has_preference,
            cfx_request_context_get_preference,
            cfx_request_context_get_all_preferences,
            cfx_request_context_can_set_preference,
            cfx_request_context_set_preference,
            cfx_request_context_clear_certificate_exceptions,
            cfx_request_context_clear_http_auth_credentials,
            cfx_request_context_close_all_connections,
            cfx_request_context_resolve_host,
            cfx_request_context_load_extension,
            cfx_request_context_did_load_extension,
            cfx_request_context_has_extension,
            cfx_request_context_get_extensions,
            cfx_request_context_get_extension,
            cfx_request_context_handler_ctor,
            cfx_request_context_handler_get_gc_handle,
            cfx_request_context_handler_set_callback,
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
            cfx_request_context_settings_set_enable_net_security_expiration,
            cfx_request_context_settings_get_enable_net_security_expiration,
            cfx_request_context_settings_set_accept_language_list,
            cfx_request_context_settings_get_accept_language_list,
            cfx_request_handler_ctor,
            cfx_request_handler_set_callback,
            cfx_resolve_callback_ctor,
            cfx_resolve_callback_set_callback,
            cfx_resource_bundle_get_global,
            cfx_resource_bundle_get_localized_string,
            cfx_resource_bundle_get_data_resource,
            cfx_resource_bundle_get_data_resource_for_scale,
            cfx_resource_bundle_handler_ctor,
            cfx_resource_bundle_handler_set_callback,
            cfx_resource_handler_ctor,
            cfx_resource_handler_set_callback,
            cfx_resource_read_callback_cont,
            cfx_resource_request_handler_ctor,
            cfx_resource_request_handler_set_callback,
            cfx_resource_skip_callback_cont,
            cfx_response_create,
            cfx_response_is_read_only,
            cfx_response_get_error,
            cfx_response_set_error,
            cfx_response_get_status,
            cfx_response_set_status,
            cfx_response_get_status_text,
            cfx_response_set_status_text,
            cfx_response_get_mime_type,
            cfx_response_set_mime_type,
            cfx_response_get_charset,
            cfx_response_set_charset,
            cfx_response_get_header,
            cfx_response_get_header_map,
            cfx_response_set_header_map,
            cfx_response_get_url,
            cfx_response_set_url,
            cfx_response_filter_ctor,
            cfx_response_filter_set_callback,
            cfx_run_context_menu_callback_cont,
            cfx_run_context_menu_callback_cancel,
            cfx_run_file_dialog_callback_ctor,
            cfx_run_file_dialog_callback_set_callback,
            cfx_scheme_handler_factory_ctor,
            cfx_scheme_handler_factory_set_callback,
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
            cfx_select_client_certificate_callback_select,
            cfx_server_create,
            cfx_server_get_task_runner,
            cfx_server_shutdown,
            cfx_server_is_running,
            cfx_server_get_address,
            cfx_server_has_connection,
            cfx_server_is_valid_connection,
            cfx_server_send_http200response,
            cfx_server_send_http404response,
            cfx_server_send_http500response,
            cfx_server_send_http_response,
            cfx_server_send_raw_data,
            cfx_server_close_connection,
            cfx_server_send_web_socket_message,
            cfx_server_handler_ctor,
            cfx_server_handler_set_callback,
            cfx_set_cookie_callback_ctor,
            cfx_set_cookie_callback_set_callback,
            cfx_settings_ctor,
            cfx_settings_dtor,
            cfx_settings_set_no_sandbox,
            cfx_settings_get_no_sandbox,
            cfx_settings_set_browser_subprocess_path,
            cfx_settings_get_browser_subprocess_path,
            cfx_settings_set_framework_dir_path,
            cfx_settings_get_framework_dir_path,
            cfx_settings_set_main_bundle_path,
            cfx_settings_get_main_bundle_path,
            cfx_settings_set_multi_threaded_message_loop,
            cfx_settings_get_multi_threaded_message_loop,
            cfx_settings_set_external_message_pump,
            cfx_settings_get_external_message_pump,
            cfx_settings_set_windowless_rendering_enabled,
            cfx_settings_get_windowless_rendering_enabled,
            cfx_settings_set_command_line_args_disabled,
            cfx_settings_get_command_line_args_disabled,
            cfx_settings_set_cache_path,
            cfx_settings_get_cache_path,
            cfx_settings_set_root_cache_path,
            cfx_settings_get_root_cache_path,
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
            cfx_settings_set_ignore_certificate_errors,
            cfx_settings_get_ignore_certificate_errors,
            cfx_settings_set_enable_net_security_expiration,
            cfx_settings_get_enable_net_security_expiration,
            cfx_settings_set_background_color,
            cfx_settings_get_background_color,
            cfx_settings_set_accept_language_list,
            cfx_settings_get_accept_language_list,
            cfx_settings_set_application_client_id_for_file_scanning,
            cfx_settings_get_application_client_id_for_file_scanning,
            cfx_size_ctor,
            cfx_size_dtor,
            cfx_size_set_width,
            cfx_size_get_width,
            cfx_size_set_height,
            cfx_size_get_height,
            cfx_sslinfo_get_cert_status,
            cfx_sslinfo_get_x509certificate,
            cfx_sslstatus_is_secure_connection,
            cfx_sslstatus_get_cert_status,
            cfx_sslstatus_get_sslversion,
            cfx_sslstatus_get_content_status,
            cfx_sslstatus_get_x509certificate,
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
            cfx_string_visitor_set_callback,
            cfx_task_ctor,
            cfx_task_set_callback,
            cfx_task_runner_get_for_current_thread,
            cfx_task_runner_get_for_thread,
            cfx_task_runner_is_same,
            cfx_task_runner_belongs_to_current_thread,
            cfx_task_runner_belongs_to_thread,
            cfx_task_runner_post_task,
            cfx_task_runner_post_delayed_task,
            cfx_thread_create,
            cfx_thread_get_task_runner,
            cfx_thread_get_platform_thread_id,
            cfx_thread_stop,
            cfx_thread_is_running,
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
            cfx_touch_event_ctor,
            cfx_touch_event_dtor,
            cfx_touch_event_set_id,
            cfx_touch_event_get_id,
            cfx_touch_event_set_x,
            cfx_touch_event_get_x,
            cfx_touch_event_set_y,
            cfx_touch_event_get_y,
            cfx_touch_event_set_radius_x,
            cfx_touch_event_get_radius_x,
            cfx_touch_event_set_radius_y,
            cfx_touch_event_get_radius_y,
            cfx_touch_event_set_rotation_angle,
            cfx_touch_event_get_rotation_angle,
            cfx_touch_event_set_pressure,
            cfx_touch_event_get_pressure,
            cfx_touch_event_set_type,
            cfx_touch_event_get_type,
            cfx_touch_event_set_modifiers,
            cfx_touch_event_get_modifiers,
            cfx_touch_event_set_pointer_type,
            cfx_touch_event_get_pointer_type,
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
            cfx_urlrequest_response_was_cached,
            cfx_urlrequest_cancel,
            cfx_urlrequest_client_ctor,
            cfx_urlrequest_client_get_gc_handle,
            cfx_urlrequest_client_set_callback,
            cfx_v8accessor_ctor,
            cfx_v8accessor_set_callback,
            cfx_v8array_buffer_release_callback_ctor,
            cfx_v8array_buffer_release_callback_get_gc_handle,
            cfx_v8array_buffer_release_callback_set_callback,
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
            cfx_v8handler_set_callback,
            cfx_v8interceptor_ctor,
            cfx_v8interceptor_set_callback,
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
            cfx_v8value_create_array_buffer,
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
            cfx_v8value_is_array_buffer,
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
            cfx_v8value_get_array_buffer_release_callback,
            cfx_v8value_neuter_array_buffer,
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
            cfx_waitable_event_create,
            cfx_waitable_event_reset,
            cfx_waitable_event_signal,
            cfx_waitable_event_is_signaled,
            cfx_waitable_event_wait,
            cfx_waitable_event_timed_wait,
            cfx_web_plugin_info_get_name,
            cfx_web_plugin_info_get_path,
            cfx_web_plugin_info_get_version,
            cfx_web_plugin_info_get_description,
            cfx_web_plugin_info_visitor_ctor,
            cfx_web_plugin_info_visitor_set_callback,
            cfx_web_plugin_unstable_callback_ctor,
            cfx_web_plugin_unstable_callback_set_callback,
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
            cfx_window_info_linux_set_shared_texture_enabled,
            cfx_window_info_linux_get_shared_texture_enabled,
            cfx_window_info_linux_set_external_begin_frame_enabled,
            cfx_window_info_linux_get_external_begin_frame_enabled,
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
            cfx_window_info_windows_set_shared_texture_enabled,
            cfx_window_info_windows_get_shared_texture_enabled,
            cfx_window_info_windows_set_external_begin_frame_enabled,
            cfx_window_info_windows_get_external_begin_frame_enabled,
            cfx_window_info_windows_set_window,
            cfx_window_info_windows_get_window,
            cfx_write_handler_ctor,
            cfx_write_handler_set_callback,
            cfx_x509cert_principal_get_display_name,
            cfx_x509cert_principal_get_common_name,
            cfx_x509cert_principal_get_locality_name,
            cfx_x509cert_principal_get_state_or_province_name,
            cfx_x509cert_principal_get_country_name,
            cfx_x509cert_principal_get_street_addresses,
            cfx_x509cert_principal_get_organization_names,
            cfx_x509cert_principal_get_organization_unit_names,
            cfx_x509cert_principal_get_domain_components,
            cfx_x509certificate_get_subject,
            cfx_x509certificate_get_issuer,
            cfx_x509certificate_get_serial_number,
            cfx_x509certificate_get_valid_start,
            cfx_x509certificate_get_valid_expiry,
            cfx_x509certificate_get_derencoded,
            cfx_x509certificate_get_pemencoded,
            cfx_x509certificate_get_issuer_chain_size,
            cfx_x509certificate_get_derencoded_issuer_chain,
            cfx_x509certificate_get_pemencoded_issuer_chain,
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
            CfxApi.Runtime.cfx_add_cross_origin_whitelist_entry = (CfxApi.Runtime.cfx_add_cross_origin_whitelist_entry_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_add_cross_origin_whitelist_entry, typeof(CfxApi.Runtime.cfx_add_cross_origin_whitelist_entry_delegate));
            CfxApi.Runtime.cfx_api_hash = (CfxApi.Runtime.cfx_api_hash_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_api_hash, typeof(CfxApi.Runtime.cfx_api_hash_delegate));
            CfxApi.Runtime.cfx_base64decode = (CfxApi.Runtime.cfx_base64decode_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_base64decode, typeof(CfxApi.Runtime.cfx_base64decode_delegate));
            CfxApi.Runtime.cfx_base64encode = (CfxApi.Runtime.cfx_base64encode_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_base64encode, typeof(CfxApi.Runtime.cfx_base64encode_delegate));
            CfxApi.Runtime.cfx_begin_tracing = (CfxApi.Runtime.cfx_begin_tracing_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_begin_tracing, typeof(CfxApi.Runtime.cfx_begin_tracing_delegate));
            CfxApi.Runtime.cfx_clear_cross_origin_whitelist = (CfxApi.Runtime.cfx_clear_cross_origin_whitelist_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_clear_cross_origin_whitelist, typeof(CfxApi.Runtime.cfx_clear_cross_origin_whitelist_delegate));
            CfxApi.Runtime.cfx_clear_scheme_handler_factories = (CfxApi.Runtime.cfx_clear_scheme_handler_factories_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_clear_scheme_handler_factories, typeof(CfxApi.Runtime.cfx_clear_scheme_handler_factories_delegate));
            CfxApi.Runtime.cfx_crash_reporting_enabled = (CfxApi.Runtime.cfx_crash_reporting_enabled_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_crash_reporting_enabled, typeof(CfxApi.Runtime.cfx_crash_reporting_enabled_delegate));
            CfxApi.Runtime.cfx_create_context_shared = (CfxApi.Runtime.cfx_create_context_shared_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_create_context_shared, typeof(CfxApi.Runtime.cfx_create_context_shared_delegate));
            CfxApi.Runtime.cfx_create_directory = (CfxApi.Runtime.cfx_create_directory_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_create_directory, typeof(CfxApi.Runtime.cfx_create_directory_delegate));
            CfxApi.Runtime.cfx_create_new_temp_directory = (CfxApi.Runtime.cfx_create_new_temp_directory_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_create_new_temp_directory, typeof(CfxApi.Runtime.cfx_create_new_temp_directory_delegate));
            CfxApi.Runtime.cfx_create_temp_directory_in_directory = (CfxApi.Runtime.cfx_create_temp_directory_in_directory_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_create_temp_directory_in_directory, typeof(CfxApi.Runtime.cfx_create_temp_directory_in_directory_delegate));
            CfxApi.Runtime.cfx_create_url = (CfxApi.Runtime.cfx_create_url_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_create_url, typeof(CfxApi.Runtime.cfx_create_url_delegate));
            CfxApi.Runtime.cfx_currently_on = (CfxApi.Runtime.cfx_currently_on_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_currently_on, typeof(CfxApi.Runtime.cfx_currently_on_delegate));
            CfxApi.Runtime.cfx_delete_file = (CfxApi.Runtime.cfx_delete_file_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_delete_file, typeof(CfxApi.Runtime.cfx_delete_file_delegate));
            CfxApi.Runtime.cfx_directory_exists = (CfxApi.Runtime.cfx_directory_exists_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_directory_exists, typeof(CfxApi.Runtime.cfx_directory_exists_delegate));
            CfxApi.Runtime.cfx_do_message_loop_work = (CfxApi.Runtime.cfx_do_message_loop_work_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_do_message_loop_work, typeof(CfxApi.Runtime.cfx_do_message_loop_work_delegate));
            CfxApi.Runtime.cfx_enable_highdpi_support = (CfxApi.Runtime.cfx_enable_highdpi_support_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_enable_highdpi_support, typeof(CfxApi.Runtime.cfx_enable_highdpi_support_delegate));
            CfxApi.Runtime.cfx_end_tracing = (CfxApi.Runtime.cfx_end_tracing_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_end_tracing, typeof(CfxApi.Runtime.cfx_end_tracing_delegate));
            CfxApi.Runtime.cfx_execute_process = (CfxApi.Runtime.cfx_execute_process_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_execute_process, typeof(CfxApi.Runtime.cfx_execute_process_delegate));
            CfxApi.Runtime.cfx_format_url_for_security_display = (CfxApi.Runtime.cfx_format_url_for_security_display_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_format_url_for_security_display, typeof(CfxApi.Runtime.cfx_format_url_for_security_display_delegate));
            CfxApi.Runtime.cfx_get_extensions_for_mime_type = (CfxApi.Runtime.cfx_get_extensions_for_mime_type_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_get_extensions_for_mime_type, typeof(CfxApi.Runtime.cfx_get_extensions_for_mime_type_delegate));
            CfxApi.Runtime.cfx_get_mime_type = (CfxApi.Runtime.cfx_get_mime_type_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_get_mime_type, typeof(CfxApi.Runtime.cfx_get_mime_type_delegate));
            CfxApi.Runtime.cfx_get_path = (CfxApi.Runtime.cfx_get_path_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_get_path, typeof(CfxApi.Runtime.cfx_get_path_delegate));
            CfxApi.Runtime.cfx_get_temp_directory = (CfxApi.Runtime.cfx_get_temp_directory_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_get_temp_directory, typeof(CfxApi.Runtime.cfx_get_temp_directory_delegate));
            if(CfxApi.PlatformOS == CfxPlatformOS.Linux) {
                CfxApi.Runtime.cfx_get_xdisplay = (CfxApi.Runtime.cfx_get_xdisplay_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_get_xdisplay, typeof(CfxApi.Runtime.cfx_get_xdisplay_delegate));
            }
            CfxApi.Runtime.cfx_initialize = (CfxApi.Runtime.cfx_initialize_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_initialize, typeof(CfxApi.Runtime.cfx_initialize_delegate));
            CfxApi.Runtime.cfx_is_cert_status_error = (CfxApi.Runtime.cfx_is_cert_status_error_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_is_cert_status_error, typeof(CfxApi.Runtime.cfx_is_cert_status_error_delegate));
            CfxApi.Runtime.cfx_is_cert_status_minor_error = (CfxApi.Runtime.cfx_is_cert_status_minor_error_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_is_cert_status_minor_error, typeof(CfxApi.Runtime.cfx_is_cert_status_minor_error_delegate));
            CfxApi.Runtime.cfx_is_web_plugin_unstable = (CfxApi.Runtime.cfx_is_web_plugin_unstable_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_is_web_plugin_unstable, typeof(CfxApi.Runtime.cfx_is_web_plugin_unstable_delegate));
            CfxApi.Runtime.cfx_launch_process = (CfxApi.Runtime.cfx_launch_process_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_launch_process, typeof(CfxApi.Runtime.cfx_launch_process_delegate));
            CfxApi.Runtime.cfx_load_crlsets_file = (CfxApi.Runtime.cfx_load_crlsets_file_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_load_crlsets_file, typeof(CfxApi.Runtime.cfx_load_crlsets_file_delegate));
            CfxApi.Runtime.cfx_now_from_system_trace_time = (CfxApi.Runtime.cfx_now_from_system_trace_time_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_now_from_system_trace_time, typeof(CfxApi.Runtime.cfx_now_from_system_trace_time_delegate));
            CfxApi.Runtime.cfx_parse_json = (CfxApi.Runtime.cfx_parse_json_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_parse_json, typeof(CfxApi.Runtime.cfx_parse_json_delegate));
            CfxApi.Runtime.cfx_parse_jsonand_return_error = (CfxApi.Runtime.cfx_parse_jsonand_return_error_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_parse_jsonand_return_error, typeof(CfxApi.Runtime.cfx_parse_jsonand_return_error_delegate));
            CfxApi.Runtime.cfx_parse_url = (CfxApi.Runtime.cfx_parse_url_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_parse_url, typeof(CfxApi.Runtime.cfx_parse_url_delegate));
            CfxApi.Runtime.cfx_post_delayed_task = (CfxApi.Runtime.cfx_post_delayed_task_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_post_delayed_task, typeof(CfxApi.Runtime.cfx_post_delayed_task_delegate));
            CfxApi.Runtime.cfx_post_task = (CfxApi.Runtime.cfx_post_task_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_post_task, typeof(CfxApi.Runtime.cfx_post_task_delegate));
            CfxApi.Runtime.cfx_quit_message_loop = (CfxApi.Runtime.cfx_quit_message_loop_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_quit_message_loop, typeof(CfxApi.Runtime.cfx_quit_message_loop_delegate));
            CfxApi.Runtime.cfx_refresh_web_plugins = (CfxApi.Runtime.cfx_refresh_web_plugins_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_refresh_web_plugins, typeof(CfxApi.Runtime.cfx_refresh_web_plugins_delegate));
            CfxApi.Runtime.cfx_register_extension = (CfxApi.Runtime.cfx_register_extension_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_register_extension, typeof(CfxApi.Runtime.cfx_register_extension_delegate));
            CfxApi.Runtime.cfx_register_scheme_handler_factory = (CfxApi.Runtime.cfx_register_scheme_handler_factory_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_register_scheme_handler_factory, typeof(CfxApi.Runtime.cfx_register_scheme_handler_factory_delegate));
            CfxApi.Runtime.cfx_register_web_plugin_crash = (CfxApi.Runtime.cfx_register_web_plugin_crash_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_register_web_plugin_crash, typeof(CfxApi.Runtime.cfx_register_web_plugin_crash_delegate));
            CfxApi.Runtime.cfx_register_widevine_cdm = (CfxApi.Runtime.cfx_register_widevine_cdm_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_register_widevine_cdm, typeof(CfxApi.Runtime.cfx_register_widevine_cdm_delegate));
            CfxApi.Runtime.cfx_remove_cross_origin_whitelist_entry = (CfxApi.Runtime.cfx_remove_cross_origin_whitelist_entry_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_remove_cross_origin_whitelist_entry, typeof(CfxApi.Runtime.cfx_remove_cross_origin_whitelist_entry_delegate));
            CfxApi.Runtime.cfx_run_message_loop = (CfxApi.Runtime.cfx_run_message_loop_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_run_message_loop, typeof(CfxApi.Runtime.cfx_run_message_loop_delegate));
            CfxApi.Runtime.cfx_set_crash_key_value = (CfxApi.Runtime.cfx_set_crash_key_value_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_set_crash_key_value, typeof(CfxApi.Runtime.cfx_set_crash_key_value_delegate));
            CfxApi.Runtime.cfx_set_osmodal_loop = (CfxApi.Runtime.cfx_set_osmodal_loop_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_set_osmodal_loop, typeof(CfxApi.Runtime.cfx_set_osmodal_loop_delegate));
            CfxApi.Runtime.cfx_shutdown = (CfxApi.Runtime.cfx_shutdown_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_shutdown, typeof(CfxApi.Runtime.cfx_shutdown_delegate));
            CfxApi.Runtime.cfx_unregister_internal_web_plugin = (CfxApi.Runtime.cfx_unregister_internal_web_plugin_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_unregister_internal_web_plugin, typeof(CfxApi.Runtime.cfx_unregister_internal_web_plugin_delegate));
            CfxApi.Runtime.cfx_uridecode = (CfxApi.Runtime.cfx_uridecode_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_uridecode, typeof(CfxApi.Runtime.cfx_uridecode_delegate));
            CfxApi.Runtime.cfx_uriencode = (CfxApi.Runtime.cfx_uriencode_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_uriencode, typeof(CfxApi.Runtime.cfx_uriencode_delegate));
            CfxApi.Runtime.cfx_version_info = (CfxApi.Runtime.cfx_version_info_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_version_info, typeof(CfxApi.Runtime.cfx_version_info_delegate));
            CfxApi.Runtime.cfx_visit_web_plugin_info = (CfxApi.Runtime.cfx_visit_web_plugin_info_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_visit_web_plugin_info, typeof(CfxApi.Runtime.cfx_visit_web_plugin_info_delegate));
            CfxApi.Runtime.cfx_write_json = (CfxApi.Runtime.cfx_write_json_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_write_json, typeof(CfxApi.Runtime.cfx_write_json_delegate));
            CfxApi.Runtime.cfx_zip_directory = (CfxApi.Runtime.cfx_zip_directory_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_zip_directory, typeof(CfxApi.Runtime.cfx_zip_directory_delegate));
        }

        internal static void LoadStringCollectionApi() {
            CfxApi.Probe();
            CfxApi.Runtime.cfx_string_list_alloc = (CfxApi.Runtime.cfx_string_list_alloc_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_string_list_alloc, typeof(CfxApi.Runtime.cfx_string_list_alloc_delegate));
            CfxApi.Runtime.cfx_string_list_size = (CfxApi.Runtime.cfx_string_list_size_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_string_list_size, typeof(CfxApi.Runtime.cfx_string_list_size_delegate));
            CfxApi.Runtime.cfx_string_list_value = (CfxApi.Runtime.cfx_string_list_value_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_string_list_value, typeof(CfxApi.Runtime.cfx_string_list_value_delegate));
            CfxApi.Runtime.cfx_string_list_append = (CfxApi.Runtime.cfx_string_list_append_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_string_list_append, typeof(CfxApi.Runtime.cfx_string_list_append_delegate));
            CfxApi.Runtime.cfx_string_list_clear = (CfxApi.Runtime.cfx_string_list_clear_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_string_list_clear, typeof(CfxApi.Runtime.cfx_string_list_clear_delegate));
            CfxApi.Runtime.cfx_string_list_free = (CfxApi.Runtime.cfx_string_list_free_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_string_list_free, typeof(CfxApi.Runtime.cfx_string_list_free_delegate));
            CfxApi.Runtime.cfx_string_list_copy = (CfxApi.Runtime.cfx_string_list_copy_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_string_list_copy, typeof(CfxApi.Runtime.cfx_string_list_copy_delegate));
            CfxApi.Runtime.cfx_string_map_alloc = (CfxApi.Runtime.cfx_string_map_alloc_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_string_map_alloc, typeof(CfxApi.Runtime.cfx_string_map_alloc_delegate));
            CfxApi.Runtime.cfx_string_map_size = (CfxApi.Runtime.cfx_string_map_size_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_string_map_size, typeof(CfxApi.Runtime.cfx_string_map_size_delegate));
            CfxApi.Runtime.cfx_string_map_find = (CfxApi.Runtime.cfx_string_map_find_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_string_map_find, typeof(CfxApi.Runtime.cfx_string_map_find_delegate));
            CfxApi.Runtime.cfx_string_map_key = (CfxApi.Runtime.cfx_string_map_key_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_string_map_key, typeof(CfxApi.Runtime.cfx_string_map_key_delegate));
            CfxApi.Runtime.cfx_string_map_value = (CfxApi.Runtime.cfx_string_map_value_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_string_map_value, typeof(CfxApi.Runtime.cfx_string_map_value_delegate));
            CfxApi.Runtime.cfx_string_map_append = (CfxApi.Runtime.cfx_string_map_append_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_string_map_append, typeof(CfxApi.Runtime.cfx_string_map_append_delegate));
            CfxApi.Runtime.cfx_string_map_clear = (CfxApi.Runtime.cfx_string_map_clear_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_string_map_clear, typeof(CfxApi.Runtime.cfx_string_map_clear_delegate));
            CfxApi.Runtime.cfx_string_map_free = (CfxApi.Runtime.cfx_string_map_free_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_string_map_free, typeof(CfxApi.Runtime.cfx_string_map_free_delegate));
            CfxApi.Runtime.cfx_string_multimap_alloc = (CfxApi.Runtime.cfx_string_multimap_alloc_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_string_multimap_alloc, typeof(CfxApi.Runtime.cfx_string_multimap_alloc_delegate));
            CfxApi.Runtime.cfx_string_multimap_size = (CfxApi.Runtime.cfx_string_multimap_size_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_string_multimap_size, typeof(CfxApi.Runtime.cfx_string_multimap_size_delegate));
            CfxApi.Runtime.cfx_string_multimap_find_count = (CfxApi.Runtime.cfx_string_multimap_find_count_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_string_multimap_find_count, typeof(CfxApi.Runtime.cfx_string_multimap_find_count_delegate));
            CfxApi.Runtime.cfx_string_multimap_enumerate = (CfxApi.Runtime.cfx_string_multimap_enumerate_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_string_multimap_enumerate, typeof(CfxApi.Runtime.cfx_string_multimap_enumerate_delegate));
            CfxApi.Runtime.cfx_string_multimap_key = (CfxApi.Runtime.cfx_string_multimap_key_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_string_multimap_key, typeof(CfxApi.Runtime.cfx_string_multimap_key_delegate));
            CfxApi.Runtime.cfx_string_multimap_value = (CfxApi.Runtime.cfx_string_multimap_value_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_string_multimap_value, typeof(CfxApi.Runtime.cfx_string_multimap_value_delegate));
            CfxApi.Runtime.cfx_string_multimap_append = (CfxApi.Runtime.cfx_string_multimap_append_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_string_multimap_append, typeof(CfxApi.Runtime.cfx_string_multimap_append_delegate));
            CfxApi.Runtime.cfx_string_multimap_clear = (CfxApi.Runtime.cfx_string_multimap_clear_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_string_multimap_clear, typeof(CfxApi.Runtime.cfx_string_multimap_clear_delegate));
            CfxApi.Runtime.cfx_string_multimap_free = (CfxApi.Runtime.cfx_string_multimap_free_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_string_multimap_free, typeof(CfxApi.Runtime.cfx_string_multimap_free_delegate));
        }

        internal static void LoadCfxAccessibilityHandlerApi() {
            CfxApi.Probe();
            CfxApi.AccessibilityHandler.cfx_accessibility_handler_ctor = (CfxApi.cfx_ctor_with_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_accessibility_handler_ctor, typeof(CfxApi.cfx_ctor_with_gc_handle_delegate));
            CfxApi.AccessibilityHandler.cfx_accessibility_handler_set_callback = (CfxApi.cfx_set_callback_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_accessibility_handler_set_callback, typeof(CfxApi.cfx_set_callback_delegate));
            CfxAccessibilityHandler.SetNativeCallbacks();
        }

        internal static void LoadCfxAppApi() {
            CfxApi.Probe();
            CfxApi.App.cfx_app_ctor = (CfxApi.cfx_ctor_with_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_app_ctor, typeof(CfxApi.cfx_ctor_with_gc_handle_delegate));
            CfxApi.App.cfx_app_set_callback = (CfxApi.cfx_set_callback_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_app_set_callback, typeof(CfxApi.cfx_set_callback_delegate));
            CfxApp.SetNativeCallbacks();
        }

        internal static void LoadCfxAuthCallbackApi() {
            CfxApi.Probe();
            CfxApi.AuthCallback.cfx_auth_callback_cont = (CfxApi.AuthCallback.cfx_auth_callback_cont_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_auth_callback_cont, typeof(CfxApi.AuthCallback.cfx_auth_callback_cont_delegate));
            CfxApi.AuthCallback.cfx_auth_callback_cancel = (CfxApi.AuthCallback.cfx_auth_callback_cancel_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_auth_callback_cancel, typeof(CfxApi.AuthCallback.cfx_auth_callback_cancel_delegate));
        }

        internal static void LoadCfxBeforeDownloadCallbackApi() {
            CfxApi.Probe();
            CfxApi.BeforeDownloadCallback.cfx_before_download_callback_cont = (CfxApi.BeforeDownloadCallback.cfx_before_download_callback_cont_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_before_download_callback_cont, typeof(CfxApi.BeforeDownloadCallback.cfx_before_download_callback_cont_delegate));
        }

        internal static void LoadCfxBinaryValueApi() {
            CfxApi.Probe();
            CfxApi.BinaryValue.cfx_binary_value_create = (CfxApi.BinaryValue.cfx_binary_value_create_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_binary_value_create, typeof(CfxApi.BinaryValue.cfx_binary_value_create_delegate));
            CfxApi.BinaryValue.cfx_binary_value_is_valid = (CfxApi.BinaryValue.cfx_binary_value_is_valid_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_binary_value_is_valid, typeof(CfxApi.BinaryValue.cfx_binary_value_is_valid_delegate));
            CfxApi.BinaryValue.cfx_binary_value_is_owned = (CfxApi.BinaryValue.cfx_binary_value_is_owned_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_binary_value_is_owned, typeof(CfxApi.BinaryValue.cfx_binary_value_is_owned_delegate));
            CfxApi.BinaryValue.cfx_binary_value_is_same = (CfxApi.BinaryValue.cfx_binary_value_is_same_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_binary_value_is_same, typeof(CfxApi.BinaryValue.cfx_binary_value_is_same_delegate));
            CfxApi.BinaryValue.cfx_binary_value_is_equal = (CfxApi.BinaryValue.cfx_binary_value_is_equal_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_binary_value_is_equal, typeof(CfxApi.BinaryValue.cfx_binary_value_is_equal_delegate));
            CfxApi.BinaryValue.cfx_binary_value_copy = (CfxApi.BinaryValue.cfx_binary_value_copy_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_binary_value_copy, typeof(CfxApi.BinaryValue.cfx_binary_value_copy_delegate));
            CfxApi.BinaryValue.cfx_binary_value_get_size = (CfxApi.BinaryValue.cfx_binary_value_get_size_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_binary_value_get_size, typeof(CfxApi.BinaryValue.cfx_binary_value_get_size_delegate));
            CfxApi.BinaryValue.cfx_binary_value_get_data = (CfxApi.BinaryValue.cfx_binary_value_get_data_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_binary_value_get_data, typeof(CfxApi.BinaryValue.cfx_binary_value_get_data_delegate));
        }

        internal static void LoadCfxBoxLayoutSettingsApi() {
            CfxApi.Probe();
            CfxApi.BoxLayoutSettings.cfx_box_layout_settings_ctor = (CfxApi.cfx_ctor_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_box_layout_settings_ctor, typeof(CfxApi.cfx_ctor_delegate));
            CfxApi.BoxLayoutSettings.cfx_box_layout_settings_dtor = (CfxApi.cfx_dtor_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_box_layout_settings_dtor, typeof(CfxApi.cfx_dtor_delegate));
            CfxApi.BoxLayoutSettings.cfx_box_layout_settings_set_horizontal = (CfxApi.BoxLayoutSettings.cfx_box_layout_settings_set_horizontal_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_box_layout_settings_set_horizontal, typeof(CfxApi.BoxLayoutSettings.cfx_box_layout_settings_set_horizontal_delegate));
            CfxApi.BoxLayoutSettings.cfx_box_layout_settings_get_horizontal = (CfxApi.BoxLayoutSettings.cfx_box_layout_settings_get_horizontal_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_box_layout_settings_get_horizontal, typeof(CfxApi.BoxLayoutSettings.cfx_box_layout_settings_get_horizontal_delegate));
            CfxApi.BoxLayoutSettings.cfx_box_layout_settings_set_inside_border_horizontal_spacing = (CfxApi.BoxLayoutSettings.cfx_box_layout_settings_set_inside_border_horizontal_spacing_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_box_layout_settings_set_inside_border_horizontal_spacing, typeof(CfxApi.BoxLayoutSettings.cfx_box_layout_settings_set_inside_border_horizontal_spacing_delegate));
            CfxApi.BoxLayoutSettings.cfx_box_layout_settings_get_inside_border_horizontal_spacing = (CfxApi.BoxLayoutSettings.cfx_box_layout_settings_get_inside_border_horizontal_spacing_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_box_layout_settings_get_inside_border_horizontal_spacing, typeof(CfxApi.BoxLayoutSettings.cfx_box_layout_settings_get_inside_border_horizontal_spacing_delegate));
            CfxApi.BoxLayoutSettings.cfx_box_layout_settings_set_inside_border_vertical_spacing = (CfxApi.BoxLayoutSettings.cfx_box_layout_settings_set_inside_border_vertical_spacing_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_box_layout_settings_set_inside_border_vertical_spacing, typeof(CfxApi.BoxLayoutSettings.cfx_box_layout_settings_set_inside_border_vertical_spacing_delegate));
            CfxApi.BoxLayoutSettings.cfx_box_layout_settings_get_inside_border_vertical_spacing = (CfxApi.BoxLayoutSettings.cfx_box_layout_settings_get_inside_border_vertical_spacing_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_box_layout_settings_get_inside_border_vertical_spacing, typeof(CfxApi.BoxLayoutSettings.cfx_box_layout_settings_get_inside_border_vertical_spacing_delegate));
            CfxApi.BoxLayoutSettings.cfx_box_layout_settings_set_inside_border_insets = (CfxApi.BoxLayoutSettings.cfx_box_layout_settings_set_inside_border_insets_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_box_layout_settings_set_inside_border_insets, typeof(CfxApi.BoxLayoutSettings.cfx_box_layout_settings_set_inside_border_insets_delegate));
            CfxApi.BoxLayoutSettings.cfx_box_layout_settings_get_inside_border_insets = (CfxApi.BoxLayoutSettings.cfx_box_layout_settings_get_inside_border_insets_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_box_layout_settings_get_inside_border_insets, typeof(CfxApi.BoxLayoutSettings.cfx_box_layout_settings_get_inside_border_insets_delegate));
            CfxApi.BoxLayoutSettings.cfx_box_layout_settings_set_between_child_spacing = (CfxApi.BoxLayoutSettings.cfx_box_layout_settings_set_between_child_spacing_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_box_layout_settings_set_between_child_spacing, typeof(CfxApi.BoxLayoutSettings.cfx_box_layout_settings_set_between_child_spacing_delegate));
            CfxApi.BoxLayoutSettings.cfx_box_layout_settings_get_between_child_spacing = (CfxApi.BoxLayoutSettings.cfx_box_layout_settings_get_between_child_spacing_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_box_layout_settings_get_between_child_spacing, typeof(CfxApi.BoxLayoutSettings.cfx_box_layout_settings_get_between_child_spacing_delegate));
            CfxApi.BoxLayoutSettings.cfx_box_layout_settings_set_main_axis_alignment = (CfxApi.BoxLayoutSettings.cfx_box_layout_settings_set_main_axis_alignment_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_box_layout_settings_set_main_axis_alignment, typeof(CfxApi.BoxLayoutSettings.cfx_box_layout_settings_set_main_axis_alignment_delegate));
            CfxApi.BoxLayoutSettings.cfx_box_layout_settings_get_main_axis_alignment = (CfxApi.BoxLayoutSettings.cfx_box_layout_settings_get_main_axis_alignment_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_box_layout_settings_get_main_axis_alignment, typeof(CfxApi.BoxLayoutSettings.cfx_box_layout_settings_get_main_axis_alignment_delegate));
            CfxApi.BoxLayoutSettings.cfx_box_layout_settings_set_cross_axis_alignment = (CfxApi.BoxLayoutSettings.cfx_box_layout_settings_set_cross_axis_alignment_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_box_layout_settings_set_cross_axis_alignment, typeof(CfxApi.BoxLayoutSettings.cfx_box_layout_settings_set_cross_axis_alignment_delegate));
            CfxApi.BoxLayoutSettings.cfx_box_layout_settings_get_cross_axis_alignment = (CfxApi.BoxLayoutSettings.cfx_box_layout_settings_get_cross_axis_alignment_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_box_layout_settings_get_cross_axis_alignment, typeof(CfxApi.BoxLayoutSettings.cfx_box_layout_settings_get_cross_axis_alignment_delegate));
            CfxApi.BoxLayoutSettings.cfx_box_layout_settings_set_minimum_cross_axis_size = (CfxApi.BoxLayoutSettings.cfx_box_layout_settings_set_minimum_cross_axis_size_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_box_layout_settings_set_minimum_cross_axis_size, typeof(CfxApi.BoxLayoutSettings.cfx_box_layout_settings_set_minimum_cross_axis_size_delegate));
            CfxApi.BoxLayoutSettings.cfx_box_layout_settings_get_minimum_cross_axis_size = (CfxApi.BoxLayoutSettings.cfx_box_layout_settings_get_minimum_cross_axis_size_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_box_layout_settings_get_minimum_cross_axis_size, typeof(CfxApi.BoxLayoutSettings.cfx_box_layout_settings_get_minimum_cross_axis_size_delegate));
            CfxApi.BoxLayoutSettings.cfx_box_layout_settings_set_default_flex = (CfxApi.BoxLayoutSettings.cfx_box_layout_settings_set_default_flex_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_box_layout_settings_set_default_flex, typeof(CfxApi.BoxLayoutSettings.cfx_box_layout_settings_set_default_flex_delegate));
            CfxApi.BoxLayoutSettings.cfx_box_layout_settings_get_default_flex = (CfxApi.BoxLayoutSettings.cfx_box_layout_settings_get_default_flex_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_box_layout_settings_get_default_flex, typeof(CfxApi.BoxLayoutSettings.cfx_box_layout_settings_get_default_flex_delegate));
        }

        internal static void LoadCfxBrowserApi() {
            CfxApi.Probe();
            CfxApi.Browser.cfx_browser_get_host = (CfxApi.Browser.cfx_browser_get_host_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_get_host, typeof(CfxApi.Browser.cfx_browser_get_host_delegate));
            CfxApi.Browser.cfx_browser_can_go_back = (CfxApi.Browser.cfx_browser_can_go_back_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_can_go_back, typeof(CfxApi.Browser.cfx_browser_can_go_back_delegate));
            CfxApi.Browser.cfx_browser_go_back = (CfxApi.Browser.cfx_browser_go_back_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_go_back, typeof(CfxApi.Browser.cfx_browser_go_back_delegate));
            CfxApi.Browser.cfx_browser_can_go_forward = (CfxApi.Browser.cfx_browser_can_go_forward_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_can_go_forward, typeof(CfxApi.Browser.cfx_browser_can_go_forward_delegate));
            CfxApi.Browser.cfx_browser_go_forward = (CfxApi.Browser.cfx_browser_go_forward_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_go_forward, typeof(CfxApi.Browser.cfx_browser_go_forward_delegate));
            CfxApi.Browser.cfx_browser_is_loading = (CfxApi.Browser.cfx_browser_is_loading_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_is_loading, typeof(CfxApi.Browser.cfx_browser_is_loading_delegate));
            CfxApi.Browser.cfx_browser_reload = (CfxApi.Browser.cfx_browser_reload_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_reload, typeof(CfxApi.Browser.cfx_browser_reload_delegate));
            CfxApi.Browser.cfx_browser_reload_ignore_cache = (CfxApi.Browser.cfx_browser_reload_ignore_cache_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_reload_ignore_cache, typeof(CfxApi.Browser.cfx_browser_reload_ignore_cache_delegate));
            CfxApi.Browser.cfx_browser_stop_load = (CfxApi.Browser.cfx_browser_stop_load_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_stop_load, typeof(CfxApi.Browser.cfx_browser_stop_load_delegate));
            CfxApi.Browser.cfx_browser_get_identifier = (CfxApi.Browser.cfx_browser_get_identifier_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_get_identifier, typeof(CfxApi.Browser.cfx_browser_get_identifier_delegate));
            CfxApi.Browser.cfx_browser_is_same = (CfxApi.Browser.cfx_browser_is_same_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_is_same, typeof(CfxApi.Browser.cfx_browser_is_same_delegate));
            CfxApi.Browser.cfx_browser_is_popup = (CfxApi.Browser.cfx_browser_is_popup_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_is_popup, typeof(CfxApi.Browser.cfx_browser_is_popup_delegate));
            CfxApi.Browser.cfx_browser_has_document = (CfxApi.Browser.cfx_browser_has_document_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_has_document, typeof(CfxApi.Browser.cfx_browser_has_document_delegate));
            CfxApi.Browser.cfx_browser_get_main_frame = (CfxApi.Browser.cfx_browser_get_main_frame_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_get_main_frame, typeof(CfxApi.Browser.cfx_browser_get_main_frame_delegate));
            CfxApi.Browser.cfx_browser_get_focused_frame = (CfxApi.Browser.cfx_browser_get_focused_frame_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_get_focused_frame, typeof(CfxApi.Browser.cfx_browser_get_focused_frame_delegate));
            CfxApi.Browser.cfx_browser_get_frame_byident = (CfxApi.Browser.cfx_browser_get_frame_byident_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_get_frame_byident, typeof(CfxApi.Browser.cfx_browser_get_frame_byident_delegate));
            CfxApi.Browser.cfx_browser_get_frame = (CfxApi.Browser.cfx_browser_get_frame_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_get_frame, typeof(CfxApi.Browser.cfx_browser_get_frame_delegate));
            CfxApi.Browser.cfx_browser_get_frame_count = (CfxApi.Browser.cfx_browser_get_frame_count_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_get_frame_count, typeof(CfxApi.Browser.cfx_browser_get_frame_count_delegate));
            CfxApi.Browser.cfx_browser_get_frame_identifiers = (CfxApi.Browser.cfx_browser_get_frame_identifiers_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_get_frame_identifiers, typeof(CfxApi.Browser.cfx_browser_get_frame_identifiers_delegate));
            CfxApi.Browser.cfx_browser_get_frame_names = (CfxApi.Browser.cfx_browser_get_frame_names_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_get_frame_names, typeof(CfxApi.Browser.cfx_browser_get_frame_names_delegate));
        }

        internal static void LoadCfxBrowserHostApi() {
            CfxApi.Probe();
            CfxApi.BrowserHost.cfx_browser_host_create_browser = (CfxApi.BrowserHost.cfx_browser_host_create_browser_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_host_create_browser, typeof(CfxApi.BrowserHost.cfx_browser_host_create_browser_delegate));
            CfxApi.BrowserHost.cfx_browser_host_create_browser_sync = (CfxApi.BrowserHost.cfx_browser_host_create_browser_sync_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_host_create_browser_sync, typeof(CfxApi.BrowserHost.cfx_browser_host_create_browser_sync_delegate));
            CfxApi.BrowserHost.cfx_browser_host_get_browser = (CfxApi.BrowserHost.cfx_browser_host_get_browser_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_host_get_browser, typeof(CfxApi.BrowserHost.cfx_browser_host_get_browser_delegate));
            CfxApi.BrowserHost.cfx_browser_host_close_browser = (CfxApi.BrowserHost.cfx_browser_host_close_browser_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_host_close_browser, typeof(CfxApi.BrowserHost.cfx_browser_host_close_browser_delegate));
            CfxApi.BrowserHost.cfx_browser_host_try_close_browser = (CfxApi.BrowserHost.cfx_browser_host_try_close_browser_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_host_try_close_browser, typeof(CfxApi.BrowserHost.cfx_browser_host_try_close_browser_delegate));
            CfxApi.BrowserHost.cfx_browser_host_set_focus = (CfxApi.BrowserHost.cfx_browser_host_set_focus_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_host_set_focus, typeof(CfxApi.BrowserHost.cfx_browser_host_set_focus_delegate));
            CfxApi.BrowserHost.cfx_browser_host_get_window_handle = (CfxApi.BrowserHost.cfx_browser_host_get_window_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_host_get_window_handle, typeof(CfxApi.BrowserHost.cfx_browser_host_get_window_handle_delegate));
            CfxApi.BrowserHost.cfx_browser_host_get_opener_window_handle = (CfxApi.BrowserHost.cfx_browser_host_get_opener_window_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_host_get_opener_window_handle, typeof(CfxApi.BrowserHost.cfx_browser_host_get_opener_window_handle_delegate));
            CfxApi.BrowserHost.cfx_browser_host_has_view = (CfxApi.BrowserHost.cfx_browser_host_has_view_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_host_has_view, typeof(CfxApi.BrowserHost.cfx_browser_host_has_view_delegate));
            CfxApi.BrowserHost.cfx_browser_host_get_client = (CfxApi.BrowserHost.cfx_browser_host_get_client_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_host_get_client, typeof(CfxApi.BrowserHost.cfx_browser_host_get_client_delegate));
            CfxApi.BrowserHost.cfx_browser_host_get_request_context = (CfxApi.BrowserHost.cfx_browser_host_get_request_context_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_host_get_request_context, typeof(CfxApi.BrowserHost.cfx_browser_host_get_request_context_delegate));
            CfxApi.BrowserHost.cfx_browser_host_get_zoom_level = (CfxApi.BrowserHost.cfx_browser_host_get_zoom_level_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_host_get_zoom_level, typeof(CfxApi.BrowserHost.cfx_browser_host_get_zoom_level_delegate));
            CfxApi.BrowserHost.cfx_browser_host_set_zoom_level = (CfxApi.BrowserHost.cfx_browser_host_set_zoom_level_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_host_set_zoom_level, typeof(CfxApi.BrowserHost.cfx_browser_host_set_zoom_level_delegate));
            CfxApi.BrowserHost.cfx_browser_host_run_file_dialog = (CfxApi.BrowserHost.cfx_browser_host_run_file_dialog_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_host_run_file_dialog, typeof(CfxApi.BrowserHost.cfx_browser_host_run_file_dialog_delegate));
            CfxApi.BrowserHost.cfx_browser_host_start_download = (CfxApi.BrowserHost.cfx_browser_host_start_download_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_host_start_download, typeof(CfxApi.BrowserHost.cfx_browser_host_start_download_delegate));
            CfxApi.BrowserHost.cfx_browser_host_download_image = (CfxApi.BrowserHost.cfx_browser_host_download_image_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_host_download_image, typeof(CfxApi.BrowserHost.cfx_browser_host_download_image_delegate));
            CfxApi.BrowserHost.cfx_browser_host_print = (CfxApi.BrowserHost.cfx_browser_host_print_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_host_print, typeof(CfxApi.BrowserHost.cfx_browser_host_print_delegate));
            CfxApi.BrowserHost.cfx_browser_host_print_to_pdf = (CfxApi.BrowserHost.cfx_browser_host_print_to_pdf_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_host_print_to_pdf, typeof(CfxApi.BrowserHost.cfx_browser_host_print_to_pdf_delegate));
            CfxApi.BrowserHost.cfx_browser_host_find = (CfxApi.BrowserHost.cfx_browser_host_find_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_host_find, typeof(CfxApi.BrowserHost.cfx_browser_host_find_delegate));
            CfxApi.BrowserHost.cfx_browser_host_stop_finding = (CfxApi.BrowserHost.cfx_browser_host_stop_finding_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_host_stop_finding, typeof(CfxApi.BrowserHost.cfx_browser_host_stop_finding_delegate));
            CfxApi.BrowserHost.cfx_browser_host_show_dev_tools = (CfxApi.BrowserHost.cfx_browser_host_show_dev_tools_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_host_show_dev_tools, typeof(CfxApi.BrowserHost.cfx_browser_host_show_dev_tools_delegate));
            CfxApi.BrowserHost.cfx_browser_host_close_dev_tools = (CfxApi.BrowserHost.cfx_browser_host_close_dev_tools_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_host_close_dev_tools, typeof(CfxApi.BrowserHost.cfx_browser_host_close_dev_tools_delegate));
            CfxApi.BrowserHost.cfx_browser_host_has_dev_tools = (CfxApi.BrowserHost.cfx_browser_host_has_dev_tools_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_host_has_dev_tools, typeof(CfxApi.BrowserHost.cfx_browser_host_has_dev_tools_delegate));
            CfxApi.BrowserHost.cfx_browser_host_get_navigation_entries = (CfxApi.BrowserHost.cfx_browser_host_get_navigation_entries_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_host_get_navigation_entries, typeof(CfxApi.BrowserHost.cfx_browser_host_get_navigation_entries_delegate));
            CfxApi.BrowserHost.cfx_browser_host_set_mouse_cursor_change_disabled = (CfxApi.BrowserHost.cfx_browser_host_set_mouse_cursor_change_disabled_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_host_set_mouse_cursor_change_disabled, typeof(CfxApi.BrowserHost.cfx_browser_host_set_mouse_cursor_change_disabled_delegate));
            CfxApi.BrowserHost.cfx_browser_host_is_mouse_cursor_change_disabled = (CfxApi.BrowserHost.cfx_browser_host_is_mouse_cursor_change_disabled_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_host_is_mouse_cursor_change_disabled, typeof(CfxApi.BrowserHost.cfx_browser_host_is_mouse_cursor_change_disabled_delegate));
            CfxApi.BrowserHost.cfx_browser_host_replace_misspelling = (CfxApi.BrowserHost.cfx_browser_host_replace_misspelling_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_host_replace_misspelling, typeof(CfxApi.BrowserHost.cfx_browser_host_replace_misspelling_delegate));
            CfxApi.BrowserHost.cfx_browser_host_add_word_to_dictionary = (CfxApi.BrowserHost.cfx_browser_host_add_word_to_dictionary_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_host_add_word_to_dictionary, typeof(CfxApi.BrowserHost.cfx_browser_host_add_word_to_dictionary_delegate));
            CfxApi.BrowserHost.cfx_browser_host_is_window_rendering_disabled = (CfxApi.BrowserHost.cfx_browser_host_is_window_rendering_disabled_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_host_is_window_rendering_disabled, typeof(CfxApi.BrowserHost.cfx_browser_host_is_window_rendering_disabled_delegate));
            CfxApi.BrowserHost.cfx_browser_host_was_resized = (CfxApi.BrowserHost.cfx_browser_host_was_resized_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_host_was_resized, typeof(CfxApi.BrowserHost.cfx_browser_host_was_resized_delegate));
            CfxApi.BrowserHost.cfx_browser_host_was_hidden = (CfxApi.BrowserHost.cfx_browser_host_was_hidden_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_host_was_hidden, typeof(CfxApi.BrowserHost.cfx_browser_host_was_hidden_delegate));
            CfxApi.BrowserHost.cfx_browser_host_notify_screen_info_changed = (CfxApi.BrowserHost.cfx_browser_host_notify_screen_info_changed_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_host_notify_screen_info_changed, typeof(CfxApi.BrowserHost.cfx_browser_host_notify_screen_info_changed_delegate));
            CfxApi.BrowserHost.cfx_browser_host_invalidate = (CfxApi.BrowserHost.cfx_browser_host_invalidate_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_host_invalidate, typeof(CfxApi.BrowserHost.cfx_browser_host_invalidate_delegate));
            CfxApi.BrowserHost.cfx_browser_host_send_external_begin_frame = (CfxApi.BrowserHost.cfx_browser_host_send_external_begin_frame_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_host_send_external_begin_frame, typeof(CfxApi.BrowserHost.cfx_browser_host_send_external_begin_frame_delegate));
            CfxApi.BrowserHost.cfx_browser_host_send_key_event = (CfxApi.BrowserHost.cfx_browser_host_send_key_event_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_host_send_key_event, typeof(CfxApi.BrowserHost.cfx_browser_host_send_key_event_delegate));
            CfxApi.BrowserHost.cfx_browser_host_send_mouse_click_event = (CfxApi.BrowserHost.cfx_browser_host_send_mouse_click_event_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_host_send_mouse_click_event, typeof(CfxApi.BrowserHost.cfx_browser_host_send_mouse_click_event_delegate));
            CfxApi.BrowserHost.cfx_browser_host_send_mouse_move_event = (CfxApi.BrowserHost.cfx_browser_host_send_mouse_move_event_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_host_send_mouse_move_event, typeof(CfxApi.BrowserHost.cfx_browser_host_send_mouse_move_event_delegate));
            CfxApi.BrowserHost.cfx_browser_host_send_mouse_wheel_event = (CfxApi.BrowserHost.cfx_browser_host_send_mouse_wheel_event_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_host_send_mouse_wheel_event, typeof(CfxApi.BrowserHost.cfx_browser_host_send_mouse_wheel_event_delegate));
            CfxApi.BrowserHost.cfx_browser_host_send_touch_event = (CfxApi.BrowserHost.cfx_browser_host_send_touch_event_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_host_send_touch_event, typeof(CfxApi.BrowserHost.cfx_browser_host_send_touch_event_delegate));
            CfxApi.BrowserHost.cfx_browser_host_send_focus_event = (CfxApi.BrowserHost.cfx_browser_host_send_focus_event_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_host_send_focus_event, typeof(CfxApi.BrowserHost.cfx_browser_host_send_focus_event_delegate));
            CfxApi.BrowserHost.cfx_browser_host_send_capture_lost_event = (CfxApi.BrowserHost.cfx_browser_host_send_capture_lost_event_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_host_send_capture_lost_event, typeof(CfxApi.BrowserHost.cfx_browser_host_send_capture_lost_event_delegate));
            CfxApi.BrowserHost.cfx_browser_host_notify_move_or_resize_started = (CfxApi.BrowserHost.cfx_browser_host_notify_move_or_resize_started_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_host_notify_move_or_resize_started, typeof(CfxApi.BrowserHost.cfx_browser_host_notify_move_or_resize_started_delegate));
            CfxApi.BrowserHost.cfx_browser_host_get_windowless_frame_rate = (CfxApi.BrowserHost.cfx_browser_host_get_windowless_frame_rate_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_host_get_windowless_frame_rate, typeof(CfxApi.BrowserHost.cfx_browser_host_get_windowless_frame_rate_delegate));
            CfxApi.BrowserHost.cfx_browser_host_set_windowless_frame_rate = (CfxApi.BrowserHost.cfx_browser_host_set_windowless_frame_rate_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_host_set_windowless_frame_rate, typeof(CfxApi.BrowserHost.cfx_browser_host_set_windowless_frame_rate_delegate));
            CfxApi.BrowserHost.cfx_browser_host_ime_set_composition = (CfxApi.BrowserHost.cfx_browser_host_ime_set_composition_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_host_ime_set_composition, typeof(CfxApi.BrowserHost.cfx_browser_host_ime_set_composition_delegate));
            CfxApi.BrowserHost.cfx_browser_host_ime_commit_text = (CfxApi.BrowserHost.cfx_browser_host_ime_commit_text_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_host_ime_commit_text, typeof(CfxApi.BrowserHost.cfx_browser_host_ime_commit_text_delegate));
            CfxApi.BrowserHost.cfx_browser_host_ime_finish_composing_text = (CfxApi.BrowserHost.cfx_browser_host_ime_finish_composing_text_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_host_ime_finish_composing_text, typeof(CfxApi.BrowserHost.cfx_browser_host_ime_finish_composing_text_delegate));
            CfxApi.BrowserHost.cfx_browser_host_ime_cancel_composition = (CfxApi.BrowserHost.cfx_browser_host_ime_cancel_composition_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_host_ime_cancel_composition, typeof(CfxApi.BrowserHost.cfx_browser_host_ime_cancel_composition_delegate));
            CfxApi.BrowserHost.cfx_browser_host_drag_target_drag_enter = (CfxApi.BrowserHost.cfx_browser_host_drag_target_drag_enter_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_host_drag_target_drag_enter, typeof(CfxApi.BrowserHost.cfx_browser_host_drag_target_drag_enter_delegate));
            CfxApi.BrowserHost.cfx_browser_host_drag_target_drag_over = (CfxApi.BrowserHost.cfx_browser_host_drag_target_drag_over_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_host_drag_target_drag_over, typeof(CfxApi.BrowserHost.cfx_browser_host_drag_target_drag_over_delegate));
            CfxApi.BrowserHost.cfx_browser_host_drag_target_drag_leave = (CfxApi.BrowserHost.cfx_browser_host_drag_target_drag_leave_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_host_drag_target_drag_leave, typeof(CfxApi.BrowserHost.cfx_browser_host_drag_target_drag_leave_delegate));
            CfxApi.BrowserHost.cfx_browser_host_drag_target_drop = (CfxApi.BrowserHost.cfx_browser_host_drag_target_drop_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_host_drag_target_drop, typeof(CfxApi.BrowserHost.cfx_browser_host_drag_target_drop_delegate));
            CfxApi.BrowserHost.cfx_browser_host_drag_source_ended_at = (CfxApi.BrowserHost.cfx_browser_host_drag_source_ended_at_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_host_drag_source_ended_at, typeof(CfxApi.BrowserHost.cfx_browser_host_drag_source_ended_at_delegate));
            CfxApi.BrowserHost.cfx_browser_host_drag_source_system_drag_ended = (CfxApi.BrowserHost.cfx_browser_host_drag_source_system_drag_ended_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_host_drag_source_system_drag_ended, typeof(CfxApi.BrowserHost.cfx_browser_host_drag_source_system_drag_ended_delegate));
            CfxApi.BrowserHost.cfx_browser_host_get_visible_navigation_entry = (CfxApi.BrowserHost.cfx_browser_host_get_visible_navigation_entry_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_host_get_visible_navigation_entry, typeof(CfxApi.BrowserHost.cfx_browser_host_get_visible_navigation_entry_delegate));
            CfxApi.BrowserHost.cfx_browser_host_set_accessibility_state = (CfxApi.BrowserHost.cfx_browser_host_set_accessibility_state_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_host_set_accessibility_state, typeof(CfxApi.BrowserHost.cfx_browser_host_set_accessibility_state_delegate));
            CfxApi.BrowserHost.cfx_browser_host_set_auto_resize_enabled = (CfxApi.BrowserHost.cfx_browser_host_set_auto_resize_enabled_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_host_set_auto_resize_enabled, typeof(CfxApi.BrowserHost.cfx_browser_host_set_auto_resize_enabled_delegate));
            CfxApi.BrowserHost.cfx_browser_host_get_extension = (CfxApi.BrowserHost.cfx_browser_host_get_extension_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_host_get_extension, typeof(CfxApi.BrowserHost.cfx_browser_host_get_extension_delegate));
            CfxApi.BrowserHost.cfx_browser_host_is_background_host = (CfxApi.BrowserHost.cfx_browser_host_is_background_host_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_host_is_background_host, typeof(CfxApi.BrowserHost.cfx_browser_host_is_background_host_delegate));
            CfxApi.BrowserHost.cfx_browser_host_set_audio_muted = (CfxApi.BrowserHost.cfx_browser_host_set_audio_muted_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_host_set_audio_muted, typeof(CfxApi.BrowserHost.cfx_browser_host_set_audio_muted_delegate));
            CfxApi.BrowserHost.cfx_browser_host_is_audio_muted = (CfxApi.BrowserHost.cfx_browser_host_is_audio_muted_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_host_is_audio_muted, typeof(CfxApi.BrowserHost.cfx_browser_host_is_audio_muted_delegate));
        }

        internal static void LoadCfxBrowserProcessHandlerApi() {
            CfxApi.Probe();
            CfxApi.BrowserProcessHandler.cfx_browser_process_handler_ctor = (CfxApi.cfx_ctor_with_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_process_handler_ctor, typeof(CfxApi.cfx_ctor_with_gc_handle_delegate));
            CfxApi.BrowserProcessHandler.cfx_browser_process_handler_set_callback = (CfxApi.cfx_set_callback_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_process_handler_set_callback, typeof(CfxApi.cfx_set_callback_delegate));
            CfxBrowserProcessHandler.SetNativeCallbacks();
        }

        internal static void LoadCfxBrowserSettingsApi() {
            CfxApi.Probe();
            CfxApi.BrowserSettings.cfx_browser_settings_ctor = (CfxApi.cfx_ctor_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_ctor, typeof(CfxApi.cfx_ctor_delegate));
            CfxApi.BrowserSettings.cfx_browser_settings_dtor = (CfxApi.cfx_dtor_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_dtor, typeof(CfxApi.cfx_dtor_delegate));
            CfxApi.BrowserSettings.cfx_browser_settings_set_windowless_frame_rate = (CfxApi.BrowserSettings.cfx_browser_settings_set_windowless_frame_rate_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_set_windowless_frame_rate, typeof(CfxApi.BrowserSettings.cfx_browser_settings_set_windowless_frame_rate_delegate));
            CfxApi.BrowserSettings.cfx_browser_settings_get_windowless_frame_rate = (CfxApi.BrowserSettings.cfx_browser_settings_get_windowless_frame_rate_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_get_windowless_frame_rate, typeof(CfxApi.BrowserSettings.cfx_browser_settings_get_windowless_frame_rate_delegate));
            CfxApi.BrowserSettings.cfx_browser_settings_set_standard_font_family = (CfxApi.BrowserSettings.cfx_browser_settings_set_standard_font_family_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_set_standard_font_family, typeof(CfxApi.BrowserSettings.cfx_browser_settings_set_standard_font_family_delegate));
            CfxApi.BrowserSettings.cfx_browser_settings_get_standard_font_family = (CfxApi.BrowserSettings.cfx_browser_settings_get_standard_font_family_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_get_standard_font_family, typeof(CfxApi.BrowserSettings.cfx_browser_settings_get_standard_font_family_delegate));
            CfxApi.BrowserSettings.cfx_browser_settings_set_fixed_font_family = (CfxApi.BrowserSettings.cfx_browser_settings_set_fixed_font_family_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_set_fixed_font_family, typeof(CfxApi.BrowserSettings.cfx_browser_settings_set_fixed_font_family_delegate));
            CfxApi.BrowserSettings.cfx_browser_settings_get_fixed_font_family = (CfxApi.BrowserSettings.cfx_browser_settings_get_fixed_font_family_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_get_fixed_font_family, typeof(CfxApi.BrowserSettings.cfx_browser_settings_get_fixed_font_family_delegate));
            CfxApi.BrowserSettings.cfx_browser_settings_set_serif_font_family = (CfxApi.BrowserSettings.cfx_browser_settings_set_serif_font_family_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_set_serif_font_family, typeof(CfxApi.BrowserSettings.cfx_browser_settings_set_serif_font_family_delegate));
            CfxApi.BrowserSettings.cfx_browser_settings_get_serif_font_family = (CfxApi.BrowserSettings.cfx_browser_settings_get_serif_font_family_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_get_serif_font_family, typeof(CfxApi.BrowserSettings.cfx_browser_settings_get_serif_font_family_delegate));
            CfxApi.BrowserSettings.cfx_browser_settings_set_sans_serif_font_family = (CfxApi.BrowserSettings.cfx_browser_settings_set_sans_serif_font_family_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_set_sans_serif_font_family, typeof(CfxApi.BrowserSettings.cfx_browser_settings_set_sans_serif_font_family_delegate));
            CfxApi.BrowserSettings.cfx_browser_settings_get_sans_serif_font_family = (CfxApi.BrowserSettings.cfx_browser_settings_get_sans_serif_font_family_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_get_sans_serif_font_family, typeof(CfxApi.BrowserSettings.cfx_browser_settings_get_sans_serif_font_family_delegate));
            CfxApi.BrowserSettings.cfx_browser_settings_set_cursive_font_family = (CfxApi.BrowserSettings.cfx_browser_settings_set_cursive_font_family_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_set_cursive_font_family, typeof(CfxApi.BrowserSettings.cfx_browser_settings_set_cursive_font_family_delegate));
            CfxApi.BrowserSettings.cfx_browser_settings_get_cursive_font_family = (CfxApi.BrowserSettings.cfx_browser_settings_get_cursive_font_family_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_get_cursive_font_family, typeof(CfxApi.BrowserSettings.cfx_browser_settings_get_cursive_font_family_delegate));
            CfxApi.BrowserSettings.cfx_browser_settings_set_fantasy_font_family = (CfxApi.BrowserSettings.cfx_browser_settings_set_fantasy_font_family_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_set_fantasy_font_family, typeof(CfxApi.BrowserSettings.cfx_browser_settings_set_fantasy_font_family_delegate));
            CfxApi.BrowserSettings.cfx_browser_settings_get_fantasy_font_family = (CfxApi.BrowserSettings.cfx_browser_settings_get_fantasy_font_family_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_get_fantasy_font_family, typeof(CfxApi.BrowserSettings.cfx_browser_settings_get_fantasy_font_family_delegate));
            CfxApi.BrowserSettings.cfx_browser_settings_set_default_font_size = (CfxApi.BrowserSettings.cfx_browser_settings_set_default_font_size_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_set_default_font_size, typeof(CfxApi.BrowserSettings.cfx_browser_settings_set_default_font_size_delegate));
            CfxApi.BrowserSettings.cfx_browser_settings_get_default_font_size = (CfxApi.BrowserSettings.cfx_browser_settings_get_default_font_size_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_get_default_font_size, typeof(CfxApi.BrowserSettings.cfx_browser_settings_get_default_font_size_delegate));
            CfxApi.BrowserSettings.cfx_browser_settings_set_default_fixed_font_size = (CfxApi.BrowserSettings.cfx_browser_settings_set_default_fixed_font_size_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_set_default_fixed_font_size, typeof(CfxApi.BrowserSettings.cfx_browser_settings_set_default_fixed_font_size_delegate));
            CfxApi.BrowserSettings.cfx_browser_settings_get_default_fixed_font_size = (CfxApi.BrowserSettings.cfx_browser_settings_get_default_fixed_font_size_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_get_default_fixed_font_size, typeof(CfxApi.BrowserSettings.cfx_browser_settings_get_default_fixed_font_size_delegate));
            CfxApi.BrowserSettings.cfx_browser_settings_set_minimum_font_size = (CfxApi.BrowserSettings.cfx_browser_settings_set_minimum_font_size_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_set_minimum_font_size, typeof(CfxApi.BrowserSettings.cfx_browser_settings_set_minimum_font_size_delegate));
            CfxApi.BrowserSettings.cfx_browser_settings_get_minimum_font_size = (CfxApi.BrowserSettings.cfx_browser_settings_get_minimum_font_size_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_get_minimum_font_size, typeof(CfxApi.BrowserSettings.cfx_browser_settings_get_minimum_font_size_delegate));
            CfxApi.BrowserSettings.cfx_browser_settings_set_minimum_logical_font_size = (CfxApi.BrowserSettings.cfx_browser_settings_set_minimum_logical_font_size_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_set_minimum_logical_font_size, typeof(CfxApi.BrowserSettings.cfx_browser_settings_set_minimum_logical_font_size_delegate));
            CfxApi.BrowserSettings.cfx_browser_settings_get_minimum_logical_font_size = (CfxApi.BrowserSettings.cfx_browser_settings_get_minimum_logical_font_size_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_get_minimum_logical_font_size, typeof(CfxApi.BrowserSettings.cfx_browser_settings_get_minimum_logical_font_size_delegate));
            CfxApi.BrowserSettings.cfx_browser_settings_set_default_encoding = (CfxApi.BrowserSettings.cfx_browser_settings_set_default_encoding_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_set_default_encoding, typeof(CfxApi.BrowserSettings.cfx_browser_settings_set_default_encoding_delegate));
            CfxApi.BrowserSettings.cfx_browser_settings_get_default_encoding = (CfxApi.BrowserSettings.cfx_browser_settings_get_default_encoding_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_get_default_encoding, typeof(CfxApi.BrowserSettings.cfx_browser_settings_get_default_encoding_delegate));
            CfxApi.BrowserSettings.cfx_browser_settings_set_remote_fonts = (CfxApi.BrowserSettings.cfx_browser_settings_set_remote_fonts_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_set_remote_fonts, typeof(CfxApi.BrowserSettings.cfx_browser_settings_set_remote_fonts_delegate));
            CfxApi.BrowserSettings.cfx_browser_settings_get_remote_fonts = (CfxApi.BrowserSettings.cfx_browser_settings_get_remote_fonts_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_get_remote_fonts, typeof(CfxApi.BrowserSettings.cfx_browser_settings_get_remote_fonts_delegate));
            CfxApi.BrowserSettings.cfx_browser_settings_set_javascript = (CfxApi.BrowserSettings.cfx_browser_settings_set_javascript_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_set_javascript, typeof(CfxApi.BrowserSettings.cfx_browser_settings_set_javascript_delegate));
            CfxApi.BrowserSettings.cfx_browser_settings_get_javascript = (CfxApi.BrowserSettings.cfx_browser_settings_get_javascript_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_get_javascript, typeof(CfxApi.BrowserSettings.cfx_browser_settings_get_javascript_delegate));
            CfxApi.BrowserSettings.cfx_browser_settings_set_javascript_close_windows = (CfxApi.BrowserSettings.cfx_browser_settings_set_javascript_close_windows_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_set_javascript_close_windows, typeof(CfxApi.BrowserSettings.cfx_browser_settings_set_javascript_close_windows_delegate));
            CfxApi.BrowserSettings.cfx_browser_settings_get_javascript_close_windows = (CfxApi.BrowserSettings.cfx_browser_settings_get_javascript_close_windows_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_get_javascript_close_windows, typeof(CfxApi.BrowserSettings.cfx_browser_settings_get_javascript_close_windows_delegate));
            CfxApi.BrowserSettings.cfx_browser_settings_set_javascript_access_clipboard = (CfxApi.BrowserSettings.cfx_browser_settings_set_javascript_access_clipboard_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_set_javascript_access_clipboard, typeof(CfxApi.BrowserSettings.cfx_browser_settings_set_javascript_access_clipboard_delegate));
            CfxApi.BrowserSettings.cfx_browser_settings_get_javascript_access_clipboard = (CfxApi.BrowserSettings.cfx_browser_settings_get_javascript_access_clipboard_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_get_javascript_access_clipboard, typeof(CfxApi.BrowserSettings.cfx_browser_settings_get_javascript_access_clipboard_delegate));
            CfxApi.BrowserSettings.cfx_browser_settings_set_javascript_dom_paste = (CfxApi.BrowserSettings.cfx_browser_settings_set_javascript_dom_paste_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_set_javascript_dom_paste, typeof(CfxApi.BrowserSettings.cfx_browser_settings_set_javascript_dom_paste_delegate));
            CfxApi.BrowserSettings.cfx_browser_settings_get_javascript_dom_paste = (CfxApi.BrowserSettings.cfx_browser_settings_get_javascript_dom_paste_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_get_javascript_dom_paste, typeof(CfxApi.BrowserSettings.cfx_browser_settings_get_javascript_dom_paste_delegate));
            CfxApi.BrowserSettings.cfx_browser_settings_set_plugins = (CfxApi.BrowserSettings.cfx_browser_settings_set_plugins_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_set_plugins, typeof(CfxApi.BrowserSettings.cfx_browser_settings_set_plugins_delegate));
            CfxApi.BrowserSettings.cfx_browser_settings_get_plugins = (CfxApi.BrowserSettings.cfx_browser_settings_get_plugins_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_get_plugins, typeof(CfxApi.BrowserSettings.cfx_browser_settings_get_plugins_delegate));
            CfxApi.BrowserSettings.cfx_browser_settings_set_universal_access_from_file_urls = (CfxApi.BrowserSettings.cfx_browser_settings_set_universal_access_from_file_urls_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_set_universal_access_from_file_urls, typeof(CfxApi.BrowserSettings.cfx_browser_settings_set_universal_access_from_file_urls_delegate));
            CfxApi.BrowserSettings.cfx_browser_settings_get_universal_access_from_file_urls = (CfxApi.BrowserSettings.cfx_browser_settings_get_universal_access_from_file_urls_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_get_universal_access_from_file_urls, typeof(CfxApi.BrowserSettings.cfx_browser_settings_get_universal_access_from_file_urls_delegate));
            CfxApi.BrowserSettings.cfx_browser_settings_set_file_access_from_file_urls = (CfxApi.BrowserSettings.cfx_browser_settings_set_file_access_from_file_urls_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_set_file_access_from_file_urls, typeof(CfxApi.BrowserSettings.cfx_browser_settings_set_file_access_from_file_urls_delegate));
            CfxApi.BrowserSettings.cfx_browser_settings_get_file_access_from_file_urls = (CfxApi.BrowserSettings.cfx_browser_settings_get_file_access_from_file_urls_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_get_file_access_from_file_urls, typeof(CfxApi.BrowserSettings.cfx_browser_settings_get_file_access_from_file_urls_delegate));
            CfxApi.BrowserSettings.cfx_browser_settings_set_web_security = (CfxApi.BrowserSettings.cfx_browser_settings_set_web_security_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_set_web_security, typeof(CfxApi.BrowserSettings.cfx_browser_settings_set_web_security_delegate));
            CfxApi.BrowserSettings.cfx_browser_settings_get_web_security = (CfxApi.BrowserSettings.cfx_browser_settings_get_web_security_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_get_web_security, typeof(CfxApi.BrowserSettings.cfx_browser_settings_get_web_security_delegate));
            CfxApi.BrowserSettings.cfx_browser_settings_set_image_loading = (CfxApi.BrowserSettings.cfx_browser_settings_set_image_loading_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_set_image_loading, typeof(CfxApi.BrowserSettings.cfx_browser_settings_set_image_loading_delegate));
            CfxApi.BrowserSettings.cfx_browser_settings_get_image_loading = (CfxApi.BrowserSettings.cfx_browser_settings_get_image_loading_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_get_image_loading, typeof(CfxApi.BrowserSettings.cfx_browser_settings_get_image_loading_delegate));
            CfxApi.BrowserSettings.cfx_browser_settings_set_image_shrink_standalone_to_fit = (CfxApi.BrowserSettings.cfx_browser_settings_set_image_shrink_standalone_to_fit_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_set_image_shrink_standalone_to_fit, typeof(CfxApi.BrowserSettings.cfx_browser_settings_set_image_shrink_standalone_to_fit_delegate));
            CfxApi.BrowserSettings.cfx_browser_settings_get_image_shrink_standalone_to_fit = (CfxApi.BrowserSettings.cfx_browser_settings_get_image_shrink_standalone_to_fit_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_get_image_shrink_standalone_to_fit, typeof(CfxApi.BrowserSettings.cfx_browser_settings_get_image_shrink_standalone_to_fit_delegate));
            CfxApi.BrowserSettings.cfx_browser_settings_set_text_area_resize = (CfxApi.BrowserSettings.cfx_browser_settings_set_text_area_resize_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_set_text_area_resize, typeof(CfxApi.BrowserSettings.cfx_browser_settings_set_text_area_resize_delegate));
            CfxApi.BrowserSettings.cfx_browser_settings_get_text_area_resize = (CfxApi.BrowserSettings.cfx_browser_settings_get_text_area_resize_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_get_text_area_resize, typeof(CfxApi.BrowserSettings.cfx_browser_settings_get_text_area_resize_delegate));
            CfxApi.BrowserSettings.cfx_browser_settings_set_tab_to_links = (CfxApi.BrowserSettings.cfx_browser_settings_set_tab_to_links_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_set_tab_to_links, typeof(CfxApi.BrowserSettings.cfx_browser_settings_set_tab_to_links_delegate));
            CfxApi.BrowserSettings.cfx_browser_settings_get_tab_to_links = (CfxApi.BrowserSettings.cfx_browser_settings_get_tab_to_links_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_get_tab_to_links, typeof(CfxApi.BrowserSettings.cfx_browser_settings_get_tab_to_links_delegate));
            CfxApi.BrowserSettings.cfx_browser_settings_set_local_storage = (CfxApi.BrowserSettings.cfx_browser_settings_set_local_storage_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_set_local_storage, typeof(CfxApi.BrowserSettings.cfx_browser_settings_set_local_storage_delegate));
            CfxApi.BrowserSettings.cfx_browser_settings_get_local_storage = (CfxApi.BrowserSettings.cfx_browser_settings_get_local_storage_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_get_local_storage, typeof(CfxApi.BrowserSettings.cfx_browser_settings_get_local_storage_delegate));
            CfxApi.BrowserSettings.cfx_browser_settings_set_databases = (CfxApi.BrowserSettings.cfx_browser_settings_set_databases_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_set_databases, typeof(CfxApi.BrowserSettings.cfx_browser_settings_set_databases_delegate));
            CfxApi.BrowserSettings.cfx_browser_settings_get_databases = (CfxApi.BrowserSettings.cfx_browser_settings_get_databases_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_get_databases, typeof(CfxApi.BrowserSettings.cfx_browser_settings_get_databases_delegate));
            CfxApi.BrowserSettings.cfx_browser_settings_set_application_cache = (CfxApi.BrowserSettings.cfx_browser_settings_set_application_cache_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_set_application_cache, typeof(CfxApi.BrowserSettings.cfx_browser_settings_set_application_cache_delegate));
            CfxApi.BrowserSettings.cfx_browser_settings_get_application_cache = (CfxApi.BrowserSettings.cfx_browser_settings_get_application_cache_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_get_application_cache, typeof(CfxApi.BrowserSettings.cfx_browser_settings_get_application_cache_delegate));
            CfxApi.BrowserSettings.cfx_browser_settings_set_webgl = (CfxApi.BrowserSettings.cfx_browser_settings_set_webgl_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_set_webgl, typeof(CfxApi.BrowserSettings.cfx_browser_settings_set_webgl_delegate));
            CfxApi.BrowserSettings.cfx_browser_settings_get_webgl = (CfxApi.BrowserSettings.cfx_browser_settings_get_webgl_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_get_webgl, typeof(CfxApi.BrowserSettings.cfx_browser_settings_get_webgl_delegate));
            CfxApi.BrowserSettings.cfx_browser_settings_set_background_color = (CfxApi.BrowserSettings.cfx_browser_settings_set_background_color_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_set_background_color, typeof(CfxApi.BrowserSettings.cfx_browser_settings_set_background_color_delegate));
            CfxApi.BrowserSettings.cfx_browser_settings_get_background_color = (CfxApi.BrowserSettings.cfx_browser_settings_get_background_color_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_get_background_color, typeof(CfxApi.BrowserSettings.cfx_browser_settings_get_background_color_delegate));
            CfxApi.BrowserSettings.cfx_browser_settings_set_accept_language_list = (CfxApi.BrowserSettings.cfx_browser_settings_set_accept_language_list_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_set_accept_language_list, typeof(CfxApi.BrowserSettings.cfx_browser_settings_set_accept_language_list_delegate));
            CfxApi.BrowserSettings.cfx_browser_settings_get_accept_language_list = (CfxApi.BrowserSettings.cfx_browser_settings_get_accept_language_list_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_browser_settings_get_accept_language_list, typeof(CfxApi.BrowserSettings.cfx_browser_settings_get_accept_language_list_delegate));
        }

        internal static void LoadCfxCallbackApi() {
            CfxApi.Probe();
            CfxApi.Callback.cfx_callback_cont = (CfxApi.Callback.cfx_callback_cont_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_callback_cont, typeof(CfxApi.Callback.cfx_callback_cont_delegate));
            CfxApi.Callback.cfx_callback_cancel = (CfxApi.Callback.cfx_callback_cancel_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_callback_cancel, typeof(CfxApi.Callback.cfx_callback_cancel_delegate));
        }

        internal static void LoadCfxClientApi() {
            CfxApi.Probe();
            CfxApi.Client.cfx_client_ctor = (CfxApi.cfx_ctor_with_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_client_ctor, typeof(CfxApi.cfx_ctor_with_gc_handle_delegate));
            CfxApi.Client.cfx_client_get_gc_handle = (CfxApi.cfx_get_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_client_get_gc_handle, typeof(CfxApi.cfx_get_gc_handle_delegate));
            CfxApi.Client.cfx_client_set_callback = (CfxApi.cfx_set_callback_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_client_set_callback, typeof(CfxApi.cfx_set_callback_delegate));
            CfxClient.SetNativeCallbacks();
        }

        internal static void LoadCfxCommandLineApi() {
            CfxApi.Probe();
            CfxApi.CommandLine.cfx_command_line_create = (CfxApi.CommandLine.cfx_command_line_create_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_command_line_create, typeof(CfxApi.CommandLine.cfx_command_line_create_delegate));
            CfxApi.CommandLine.cfx_command_line_get_global = (CfxApi.CommandLine.cfx_command_line_get_global_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_command_line_get_global, typeof(CfxApi.CommandLine.cfx_command_line_get_global_delegate));
            CfxApi.CommandLine.cfx_command_line_is_valid = (CfxApi.CommandLine.cfx_command_line_is_valid_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_command_line_is_valid, typeof(CfxApi.CommandLine.cfx_command_line_is_valid_delegate));
            CfxApi.CommandLine.cfx_command_line_is_read_only = (CfxApi.CommandLine.cfx_command_line_is_read_only_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_command_line_is_read_only, typeof(CfxApi.CommandLine.cfx_command_line_is_read_only_delegate));
            CfxApi.CommandLine.cfx_command_line_copy = (CfxApi.CommandLine.cfx_command_line_copy_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_command_line_copy, typeof(CfxApi.CommandLine.cfx_command_line_copy_delegate));
            CfxApi.CommandLine.cfx_command_line_init_from_argv = (CfxApi.CommandLine.cfx_command_line_init_from_argv_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_command_line_init_from_argv, typeof(CfxApi.CommandLine.cfx_command_line_init_from_argv_delegate));
            CfxApi.CommandLine.cfx_command_line_init_from_string = (CfxApi.CommandLine.cfx_command_line_init_from_string_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_command_line_init_from_string, typeof(CfxApi.CommandLine.cfx_command_line_init_from_string_delegate));
            CfxApi.CommandLine.cfx_command_line_reset = (CfxApi.CommandLine.cfx_command_line_reset_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_command_line_reset, typeof(CfxApi.CommandLine.cfx_command_line_reset_delegate));
            CfxApi.CommandLine.cfx_command_line_get_argv = (CfxApi.CommandLine.cfx_command_line_get_argv_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_command_line_get_argv, typeof(CfxApi.CommandLine.cfx_command_line_get_argv_delegate));
            CfxApi.CommandLine.cfx_command_line_get_command_line_string = (CfxApi.CommandLine.cfx_command_line_get_command_line_string_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_command_line_get_command_line_string, typeof(CfxApi.CommandLine.cfx_command_line_get_command_line_string_delegate));
            CfxApi.CommandLine.cfx_command_line_get_program = (CfxApi.CommandLine.cfx_command_line_get_program_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_command_line_get_program, typeof(CfxApi.CommandLine.cfx_command_line_get_program_delegate));
            CfxApi.CommandLine.cfx_command_line_set_program = (CfxApi.CommandLine.cfx_command_line_set_program_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_command_line_set_program, typeof(CfxApi.CommandLine.cfx_command_line_set_program_delegate));
            CfxApi.CommandLine.cfx_command_line_has_switches = (CfxApi.CommandLine.cfx_command_line_has_switches_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_command_line_has_switches, typeof(CfxApi.CommandLine.cfx_command_line_has_switches_delegate));
            CfxApi.CommandLine.cfx_command_line_has_switch = (CfxApi.CommandLine.cfx_command_line_has_switch_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_command_line_has_switch, typeof(CfxApi.CommandLine.cfx_command_line_has_switch_delegate));
            CfxApi.CommandLine.cfx_command_line_get_switch_value = (CfxApi.CommandLine.cfx_command_line_get_switch_value_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_command_line_get_switch_value, typeof(CfxApi.CommandLine.cfx_command_line_get_switch_value_delegate));
            CfxApi.CommandLine.cfx_command_line_get_switches = (CfxApi.CommandLine.cfx_command_line_get_switches_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_command_line_get_switches, typeof(CfxApi.CommandLine.cfx_command_line_get_switches_delegate));
            CfxApi.CommandLine.cfx_command_line_append_switch = (CfxApi.CommandLine.cfx_command_line_append_switch_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_command_line_append_switch, typeof(CfxApi.CommandLine.cfx_command_line_append_switch_delegate));
            CfxApi.CommandLine.cfx_command_line_append_switch_with_value = (CfxApi.CommandLine.cfx_command_line_append_switch_with_value_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_command_line_append_switch_with_value, typeof(CfxApi.CommandLine.cfx_command_line_append_switch_with_value_delegate));
            CfxApi.CommandLine.cfx_command_line_has_arguments = (CfxApi.CommandLine.cfx_command_line_has_arguments_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_command_line_has_arguments, typeof(CfxApi.CommandLine.cfx_command_line_has_arguments_delegate));
            CfxApi.CommandLine.cfx_command_line_get_arguments = (CfxApi.CommandLine.cfx_command_line_get_arguments_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_command_line_get_arguments, typeof(CfxApi.CommandLine.cfx_command_line_get_arguments_delegate));
            CfxApi.CommandLine.cfx_command_line_append_argument = (CfxApi.CommandLine.cfx_command_line_append_argument_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_command_line_append_argument, typeof(CfxApi.CommandLine.cfx_command_line_append_argument_delegate));
            CfxApi.CommandLine.cfx_command_line_prepend_wrapper = (CfxApi.CommandLine.cfx_command_line_prepend_wrapper_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_command_line_prepend_wrapper, typeof(CfxApi.CommandLine.cfx_command_line_prepend_wrapper_delegate));
        }

        internal static void LoadCfxCompletionCallbackApi() {
            CfxApi.Probe();
            CfxApi.CompletionCallback.cfx_completion_callback_ctor = (CfxApi.cfx_ctor_with_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_completion_callback_ctor, typeof(CfxApi.cfx_ctor_with_gc_handle_delegate));
            CfxApi.CompletionCallback.cfx_completion_callback_set_callback = (CfxApi.cfx_set_callback_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_completion_callback_set_callback, typeof(CfxApi.cfx_set_callback_delegate));
            CfxCompletionCallback.SetNativeCallbacks();
        }

        internal static void LoadCfxCompositionUnderlineApi() {
            CfxApi.Probe();
            CfxApi.CompositionUnderline.cfx_composition_underline_ctor = (CfxApi.cfx_ctor_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_composition_underline_ctor, typeof(CfxApi.cfx_ctor_delegate));
            CfxApi.CompositionUnderline.cfx_composition_underline_dtor = (CfxApi.cfx_dtor_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_composition_underline_dtor, typeof(CfxApi.cfx_dtor_delegate));
            CfxApi.CompositionUnderline.cfx_composition_underline_set_range = (CfxApi.CompositionUnderline.cfx_composition_underline_set_range_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_composition_underline_set_range, typeof(CfxApi.CompositionUnderline.cfx_composition_underline_set_range_delegate));
            CfxApi.CompositionUnderline.cfx_composition_underline_get_range = (CfxApi.CompositionUnderline.cfx_composition_underline_get_range_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_composition_underline_get_range, typeof(CfxApi.CompositionUnderline.cfx_composition_underline_get_range_delegate));
            CfxApi.CompositionUnderline.cfx_composition_underline_set_color = (CfxApi.CompositionUnderline.cfx_composition_underline_set_color_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_composition_underline_set_color, typeof(CfxApi.CompositionUnderline.cfx_composition_underline_set_color_delegate));
            CfxApi.CompositionUnderline.cfx_composition_underline_get_color = (CfxApi.CompositionUnderline.cfx_composition_underline_get_color_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_composition_underline_get_color, typeof(CfxApi.CompositionUnderline.cfx_composition_underline_get_color_delegate));
            CfxApi.CompositionUnderline.cfx_composition_underline_set_background_color = (CfxApi.CompositionUnderline.cfx_composition_underline_set_background_color_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_composition_underline_set_background_color, typeof(CfxApi.CompositionUnderline.cfx_composition_underline_set_background_color_delegate));
            CfxApi.CompositionUnderline.cfx_composition_underline_get_background_color = (CfxApi.CompositionUnderline.cfx_composition_underline_get_background_color_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_composition_underline_get_background_color, typeof(CfxApi.CompositionUnderline.cfx_composition_underline_get_background_color_delegate));
            CfxApi.CompositionUnderline.cfx_composition_underline_set_thick = (CfxApi.CompositionUnderline.cfx_composition_underline_set_thick_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_composition_underline_set_thick, typeof(CfxApi.CompositionUnderline.cfx_composition_underline_set_thick_delegate));
            CfxApi.CompositionUnderline.cfx_composition_underline_get_thick = (CfxApi.CompositionUnderline.cfx_composition_underline_get_thick_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_composition_underline_get_thick, typeof(CfxApi.CompositionUnderline.cfx_composition_underline_get_thick_delegate));
        }

        internal static void LoadCfxContextMenuHandlerApi() {
            CfxApi.Probe();
            CfxApi.ContextMenuHandler.cfx_context_menu_handler_ctor = (CfxApi.cfx_ctor_with_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_context_menu_handler_ctor, typeof(CfxApi.cfx_ctor_with_gc_handle_delegate));
            CfxApi.ContextMenuHandler.cfx_context_menu_handler_set_callback = (CfxApi.cfx_set_callback_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_context_menu_handler_set_callback, typeof(CfxApi.cfx_set_callback_delegate));
            CfxContextMenuHandler.SetNativeCallbacks();
        }

        internal static void LoadCfxContextMenuParamsApi() {
            CfxApi.Probe();
            CfxApi.ContextMenuParams.cfx_context_menu_params_get_xcoord = (CfxApi.ContextMenuParams.cfx_context_menu_params_get_xcoord_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_context_menu_params_get_xcoord, typeof(CfxApi.ContextMenuParams.cfx_context_menu_params_get_xcoord_delegate));
            CfxApi.ContextMenuParams.cfx_context_menu_params_get_ycoord = (CfxApi.ContextMenuParams.cfx_context_menu_params_get_ycoord_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_context_menu_params_get_ycoord, typeof(CfxApi.ContextMenuParams.cfx_context_menu_params_get_ycoord_delegate));
            CfxApi.ContextMenuParams.cfx_context_menu_params_get_type_flags = (CfxApi.ContextMenuParams.cfx_context_menu_params_get_type_flags_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_context_menu_params_get_type_flags, typeof(CfxApi.ContextMenuParams.cfx_context_menu_params_get_type_flags_delegate));
            CfxApi.ContextMenuParams.cfx_context_menu_params_get_link_url = (CfxApi.ContextMenuParams.cfx_context_menu_params_get_link_url_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_context_menu_params_get_link_url, typeof(CfxApi.ContextMenuParams.cfx_context_menu_params_get_link_url_delegate));
            CfxApi.ContextMenuParams.cfx_context_menu_params_get_unfiltered_link_url = (CfxApi.ContextMenuParams.cfx_context_menu_params_get_unfiltered_link_url_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_context_menu_params_get_unfiltered_link_url, typeof(CfxApi.ContextMenuParams.cfx_context_menu_params_get_unfiltered_link_url_delegate));
            CfxApi.ContextMenuParams.cfx_context_menu_params_get_source_url = (CfxApi.ContextMenuParams.cfx_context_menu_params_get_source_url_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_context_menu_params_get_source_url, typeof(CfxApi.ContextMenuParams.cfx_context_menu_params_get_source_url_delegate));
            CfxApi.ContextMenuParams.cfx_context_menu_params_has_image_contents = (CfxApi.ContextMenuParams.cfx_context_menu_params_has_image_contents_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_context_menu_params_has_image_contents, typeof(CfxApi.ContextMenuParams.cfx_context_menu_params_has_image_contents_delegate));
            CfxApi.ContextMenuParams.cfx_context_menu_params_get_title_text = (CfxApi.ContextMenuParams.cfx_context_menu_params_get_title_text_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_context_menu_params_get_title_text, typeof(CfxApi.ContextMenuParams.cfx_context_menu_params_get_title_text_delegate));
            CfxApi.ContextMenuParams.cfx_context_menu_params_get_page_url = (CfxApi.ContextMenuParams.cfx_context_menu_params_get_page_url_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_context_menu_params_get_page_url, typeof(CfxApi.ContextMenuParams.cfx_context_menu_params_get_page_url_delegate));
            CfxApi.ContextMenuParams.cfx_context_menu_params_get_frame_url = (CfxApi.ContextMenuParams.cfx_context_menu_params_get_frame_url_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_context_menu_params_get_frame_url, typeof(CfxApi.ContextMenuParams.cfx_context_menu_params_get_frame_url_delegate));
            CfxApi.ContextMenuParams.cfx_context_menu_params_get_frame_charset = (CfxApi.ContextMenuParams.cfx_context_menu_params_get_frame_charset_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_context_menu_params_get_frame_charset, typeof(CfxApi.ContextMenuParams.cfx_context_menu_params_get_frame_charset_delegate));
            CfxApi.ContextMenuParams.cfx_context_menu_params_get_media_type = (CfxApi.ContextMenuParams.cfx_context_menu_params_get_media_type_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_context_menu_params_get_media_type, typeof(CfxApi.ContextMenuParams.cfx_context_menu_params_get_media_type_delegate));
            CfxApi.ContextMenuParams.cfx_context_menu_params_get_media_state_flags = (CfxApi.ContextMenuParams.cfx_context_menu_params_get_media_state_flags_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_context_menu_params_get_media_state_flags, typeof(CfxApi.ContextMenuParams.cfx_context_menu_params_get_media_state_flags_delegate));
            CfxApi.ContextMenuParams.cfx_context_menu_params_get_selection_text = (CfxApi.ContextMenuParams.cfx_context_menu_params_get_selection_text_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_context_menu_params_get_selection_text, typeof(CfxApi.ContextMenuParams.cfx_context_menu_params_get_selection_text_delegate));
            CfxApi.ContextMenuParams.cfx_context_menu_params_get_misspelled_word = (CfxApi.ContextMenuParams.cfx_context_menu_params_get_misspelled_word_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_context_menu_params_get_misspelled_word, typeof(CfxApi.ContextMenuParams.cfx_context_menu_params_get_misspelled_word_delegate));
            CfxApi.ContextMenuParams.cfx_context_menu_params_get_dictionary_suggestions = (CfxApi.ContextMenuParams.cfx_context_menu_params_get_dictionary_suggestions_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_context_menu_params_get_dictionary_suggestions, typeof(CfxApi.ContextMenuParams.cfx_context_menu_params_get_dictionary_suggestions_delegate));
            CfxApi.ContextMenuParams.cfx_context_menu_params_is_editable = (CfxApi.ContextMenuParams.cfx_context_menu_params_is_editable_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_context_menu_params_is_editable, typeof(CfxApi.ContextMenuParams.cfx_context_menu_params_is_editable_delegate));
            CfxApi.ContextMenuParams.cfx_context_menu_params_is_spell_check_enabled = (CfxApi.ContextMenuParams.cfx_context_menu_params_is_spell_check_enabled_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_context_menu_params_is_spell_check_enabled, typeof(CfxApi.ContextMenuParams.cfx_context_menu_params_is_spell_check_enabled_delegate));
            CfxApi.ContextMenuParams.cfx_context_menu_params_get_edit_state_flags = (CfxApi.ContextMenuParams.cfx_context_menu_params_get_edit_state_flags_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_context_menu_params_get_edit_state_flags, typeof(CfxApi.ContextMenuParams.cfx_context_menu_params_get_edit_state_flags_delegate));
            CfxApi.ContextMenuParams.cfx_context_menu_params_is_custom_menu = (CfxApi.ContextMenuParams.cfx_context_menu_params_is_custom_menu_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_context_menu_params_is_custom_menu, typeof(CfxApi.ContextMenuParams.cfx_context_menu_params_is_custom_menu_delegate));
            CfxApi.ContextMenuParams.cfx_context_menu_params_is_pepper_menu = (CfxApi.ContextMenuParams.cfx_context_menu_params_is_pepper_menu_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_context_menu_params_is_pepper_menu, typeof(CfxApi.ContextMenuParams.cfx_context_menu_params_is_pepper_menu_delegate));
        }

        internal static void LoadCfxCookieApi() {
            CfxApi.Probe();
            CfxApi.Cookie.cfx_cookie_ctor = (CfxApi.cfx_ctor_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_cookie_ctor, typeof(CfxApi.cfx_ctor_delegate));
            CfxApi.Cookie.cfx_cookie_dtor = (CfxApi.cfx_dtor_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_cookie_dtor, typeof(CfxApi.cfx_dtor_delegate));
            CfxApi.Cookie.cfx_cookie_set_name = (CfxApi.Cookie.cfx_cookie_set_name_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_cookie_set_name, typeof(CfxApi.Cookie.cfx_cookie_set_name_delegate));
            CfxApi.Cookie.cfx_cookie_get_name = (CfxApi.Cookie.cfx_cookie_get_name_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_cookie_get_name, typeof(CfxApi.Cookie.cfx_cookie_get_name_delegate));
            CfxApi.Cookie.cfx_cookie_set_value = (CfxApi.Cookie.cfx_cookie_set_value_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_cookie_set_value, typeof(CfxApi.Cookie.cfx_cookie_set_value_delegate));
            CfxApi.Cookie.cfx_cookie_get_value = (CfxApi.Cookie.cfx_cookie_get_value_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_cookie_get_value, typeof(CfxApi.Cookie.cfx_cookie_get_value_delegate));
            CfxApi.Cookie.cfx_cookie_set_domain = (CfxApi.Cookie.cfx_cookie_set_domain_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_cookie_set_domain, typeof(CfxApi.Cookie.cfx_cookie_set_domain_delegate));
            CfxApi.Cookie.cfx_cookie_get_domain = (CfxApi.Cookie.cfx_cookie_get_domain_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_cookie_get_domain, typeof(CfxApi.Cookie.cfx_cookie_get_domain_delegate));
            CfxApi.Cookie.cfx_cookie_set_path = (CfxApi.Cookie.cfx_cookie_set_path_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_cookie_set_path, typeof(CfxApi.Cookie.cfx_cookie_set_path_delegate));
            CfxApi.Cookie.cfx_cookie_get_path = (CfxApi.Cookie.cfx_cookie_get_path_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_cookie_get_path, typeof(CfxApi.Cookie.cfx_cookie_get_path_delegate));
            CfxApi.Cookie.cfx_cookie_set_secure = (CfxApi.Cookie.cfx_cookie_set_secure_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_cookie_set_secure, typeof(CfxApi.Cookie.cfx_cookie_set_secure_delegate));
            CfxApi.Cookie.cfx_cookie_get_secure = (CfxApi.Cookie.cfx_cookie_get_secure_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_cookie_get_secure, typeof(CfxApi.Cookie.cfx_cookie_get_secure_delegate));
            CfxApi.Cookie.cfx_cookie_set_httponly = (CfxApi.Cookie.cfx_cookie_set_httponly_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_cookie_set_httponly, typeof(CfxApi.Cookie.cfx_cookie_set_httponly_delegate));
            CfxApi.Cookie.cfx_cookie_get_httponly = (CfxApi.Cookie.cfx_cookie_get_httponly_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_cookie_get_httponly, typeof(CfxApi.Cookie.cfx_cookie_get_httponly_delegate));
            CfxApi.Cookie.cfx_cookie_set_creation = (CfxApi.Cookie.cfx_cookie_set_creation_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_cookie_set_creation, typeof(CfxApi.Cookie.cfx_cookie_set_creation_delegate));
            CfxApi.Cookie.cfx_cookie_get_creation = (CfxApi.Cookie.cfx_cookie_get_creation_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_cookie_get_creation, typeof(CfxApi.Cookie.cfx_cookie_get_creation_delegate));
            CfxApi.Cookie.cfx_cookie_set_last_access = (CfxApi.Cookie.cfx_cookie_set_last_access_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_cookie_set_last_access, typeof(CfxApi.Cookie.cfx_cookie_set_last_access_delegate));
            CfxApi.Cookie.cfx_cookie_get_last_access = (CfxApi.Cookie.cfx_cookie_get_last_access_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_cookie_get_last_access, typeof(CfxApi.Cookie.cfx_cookie_get_last_access_delegate));
            CfxApi.Cookie.cfx_cookie_set_has_expires = (CfxApi.Cookie.cfx_cookie_set_has_expires_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_cookie_set_has_expires, typeof(CfxApi.Cookie.cfx_cookie_set_has_expires_delegate));
            CfxApi.Cookie.cfx_cookie_get_has_expires = (CfxApi.Cookie.cfx_cookie_get_has_expires_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_cookie_get_has_expires, typeof(CfxApi.Cookie.cfx_cookie_get_has_expires_delegate));
            CfxApi.Cookie.cfx_cookie_set_expires = (CfxApi.Cookie.cfx_cookie_set_expires_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_cookie_set_expires, typeof(CfxApi.Cookie.cfx_cookie_set_expires_delegate));
            CfxApi.Cookie.cfx_cookie_get_expires = (CfxApi.Cookie.cfx_cookie_get_expires_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_cookie_get_expires, typeof(CfxApi.Cookie.cfx_cookie_get_expires_delegate));
        }

        internal static void LoadCfxCookieAccessFilterApi() {
            CfxApi.Probe();
            CfxApi.CookieAccessFilter.cfx_cookie_access_filter_ctor = (CfxApi.cfx_ctor_with_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_cookie_access_filter_ctor, typeof(CfxApi.cfx_ctor_with_gc_handle_delegate));
            CfxApi.CookieAccessFilter.cfx_cookie_access_filter_set_callback = (CfxApi.cfx_set_callback_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_cookie_access_filter_set_callback, typeof(CfxApi.cfx_set_callback_delegate));
            CfxCookieAccessFilter.SetNativeCallbacks();
        }

        internal static void LoadCfxCookieManagerApi() {
            CfxApi.Probe();
            CfxApi.CookieManager.cfx_cookie_manager_get_global_manager = (CfxApi.CookieManager.cfx_cookie_manager_get_global_manager_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_cookie_manager_get_global_manager, typeof(CfxApi.CookieManager.cfx_cookie_manager_get_global_manager_delegate));
            CfxApi.CookieManager.cfx_cookie_manager_set_supported_schemes = (CfxApi.CookieManager.cfx_cookie_manager_set_supported_schemes_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_cookie_manager_set_supported_schemes, typeof(CfxApi.CookieManager.cfx_cookie_manager_set_supported_schemes_delegate));
            CfxApi.CookieManager.cfx_cookie_manager_visit_all_cookies = (CfxApi.CookieManager.cfx_cookie_manager_visit_all_cookies_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_cookie_manager_visit_all_cookies, typeof(CfxApi.CookieManager.cfx_cookie_manager_visit_all_cookies_delegate));
            CfxApi.CookieManager.cfx_cookie_manager_visit_url_cookies = (CfxApi.CookieManager.cfx_cookie_manager_visit_url_cookies_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_cookie_manager_visit_url_cookies, typeof(CfxApi.CookieManager.cfx_cookie_manager_visit_url_cookies_delegate));
            CfxApi.CookieManager.cfx_cookie_manager_set_cookie = (CfxApi.CookieManager.cfx_cookie_manager_set_cookie_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_cookie_manager_set_cookie, typeof(CfxApi.CookieManager.cfx_cookie_manager_set_cookie_delegate));
            CfxApi.CookieManager.cfx_cookie_manager_delete_cookies = (CfxApi.CookieManager.cfx_cookie_manager_delete_cookies_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_cookie_manager_delete_cookies, typeof(CfxApi.CookieManager.cfx_cookie_manager_delete_cookies_delegate));
            CfxApi.CookieManager.cfx_cookie_manager_flush_store = (CfxApi.CookieManager.cfx_cookie_manager_flush_store_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_cookie_manager_flush_store, typeof(CfxApi.CookieManager.cfx_cookie_manager_flush_store_delegate));
        }

        internal static void LoadCfxCookieVisitorApi() {
            CfxApi.Probe();
            CfxApi.CookieVisitor.cfx_cookie_visitor_ctor = (CfxApi.cfx_ctor_with_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_cookie_visitor_ctor, typeof(CfxApi.cfx_ctor_with_gc_handle_delegate));
            CfxApi.CookieVisitor.cfx_cookie_visitor_set_callback = (CfxApi.cfx_set_callback_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_cookie_visitor_set_callback, typeof(CfxApi.cfx_set_callback_delegate));
            CfxCookieVisitor.SetNativeCallbacks();
        }

        internal static void LoadCfxCursorInfoApi() {
            CfxApi.Probe();
            CfxApi.CursorInfo.cfx_cursor_info_ctor = (CfxApi.cfx_ctor_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_cursor_info_ctor, typeof(CfxApi.cfx_ctor_delegate));
            CfxApi.CursorInfo.cfx_cursor_info_dtor = (CfxApi.cfx_dtor_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_cursor_info_dtor, typeof(CfxApi.cfx_dtor_delegate));
            CfxApi.CursorInfo.cfx_cursor_info_set_hotspot = (CfxApi.CursorInfo.cfx_cursor_info_set_hotspot_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_cursor_info_set_hotspot, typeof(CfxApi.CursorInfo.cfx_cursor_info_set_hotspot_delegate));
            CfxApi.CursorInfo.cfx_cursor_info_get_hotspot = (CfxApi.CursorInfo.cfx_cursor_info_get_hotspot_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_cursor_info_get_hotspot, typeof(CfxApi.CursorInfo.cfx_cursor_info_get_hotspot_delegate));
            CfxApi.CursorInfo.cfx_cursor_info_set_image_scale_factor = (CfxApi.CursorInfo.cfx_cursor_info_set_image_scale_factor_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_cursor_info_set_image_scale_factor, typeof(CfxApi.CursorInfo.cfx_cursor_info_set_image_scale_factor_delegate));
            CfxApi.CursorInfo.cfx_cursor_info_get_image_scale_factor = (CfxApi.CursorInfo.cfx_cursor_info_get_image_scale_factor_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_cursor_info_get_image_scale_factor, typeof(CfxApi.CursorInfo.cfx_cursor_info_get_image_scale_factor_delegate));
            CfxApi.CursorInfo.cfx_cursor_info_set_buffer = (CfxApi.CursorInfo.cfx_cursor_info_set_buffer_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_cursor_info_set_buffer, typeof(CfxApi.CursorInfo.cfx_cursor_info_set_buffer_delegate));
            CfxApi.CursorInfo.cfx_cursor_info_get_buffer = (CfxApi.CursorInfo.cfx_cursor_info_get_buffer_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_cursor_info_get_buffer, typeof(CfxApi.CursorInfo.cfx_cursor_info_get_buffer_delegate));
            CfxApi.CursorInfo.cfx_cursor_info_set_size = (CfxApi.CursorInfo.cfx_cursor_info_set_size_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_cursor_info_set_size, typeof(CfxApi.CursorInfo.cfx_cursor_info_set_size_delegate));
            CfxApi.CursorInfo.cfx_cursor_info_get_size = (CfxApi.CursorInfo.cfx_cursor_info_get_size_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_cursor_info_get_size, typeof(CfxApi.CursorInfo.cfx_cursor_info_get_size_delegate));
        }

        internal static void LoadCfxDeleteCookiesCallbackApi() {
            CfxApi.Probe();
            CfxApi.DeleteCookiesCallback.cfx_delete_cookies_callback_ctor = (CfxApi.cfx_ctor_with_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_delete_cookies_callback_ctor, typeof(CfxApi.cfx_ctor_with_gc_handle_delegate));
            CfxApi.DeleteCookiesCallback.cfx_delete_cookies_callback_set_callback = (CfxApi.cfx_set_callback_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_delete_cookies_callback_set_callback, typeof(CfxApi.cfx_set_callback_delegate));
            CfxDeleteCookiesCallback.SetNativeCallbacks();
        }

        internal static void LoadCfxDialogHandlerApi() {
            CfxApi.Probe();
            CfxApi.DialogHandler.cfx_dialog_handler_ctor = (CfxApi.cfx_ctor_with_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_dialog_handler_ctor, typeof(CfxApi.cfx_ctor_with_gc_handle_delegate));
            CfxApi.DialogHandler.cfx_dialog_handler_set_callback = (CfxApi.cfx_set_callback_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_dialog_handler_set_callback, typeof(CfxApi.cfx_set_callback_delegate));
            CfxDialogHandler.SetNativeCallbacks();
        }

        internal static void LoadCfxDictionaryValueApi() {
            CfxApi.Probe();
            CfxApi.DictionaryValue.cfx_dictionary_value_create = (CfxApi.DictionaryValue.cfx_dictionary_value_create_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_dictionary_value_create, typeof(CfxApi.DictionaryValue.cfx_dictionary_value_create_delegate));
            CfxApi.DictionaryValue.cfx_dictionary_value_is_valid = (CfxApi.DictionaryValue.cfx_dictionary_value_is_valid_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_dictionary_value_is_valid, typeof(CfxApi.DictionaryValue.cfx_dictionary_value_is_valid_delegate));
            CfxApi.DictionaryValue.cfx_dictionary_value_is_owned = (CfxApi.DictionaryValue.cfx_dictionary_value_is_owned_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_dictionary_value_is_owned, typeof(CfxApi.DictionaryValue.cfx_dictionary_value_is_owned_delegate));
            CfxApi.DictionaryValue.cfx_dictionary_value_is_read_only = (CfxApi.DictionaryValue.cfx_dictionary_value_is_read_only_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_dictionary_value_is_read_only, typeof(CfxApi.DictionaryValue.cfx_dictionary_value_is_read_only_delegate));
            CfxApi.DictionaryValue.cfx_dictionary_value_is_same = (CfxApi.DictionaryValue.cfx_dictionary_value_is_same_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_dictionary_value_is_same, typeof(CfxApi.DictionaryValue.cfx_dictionary_value_is_same_delegate));
            CfxApi.DictionaryValue.cfx_dictionary_value_is_equal = (CfxApi.DictionaryValue.cfx_dictionary_value_is_equal_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_dictionary_value_is_equal, typeof(CfxApi.DictionaryValue.cfx_dictionary_value_is_equal_delegate));
            CfxApi.DictionaryValue.cfx_dictionary_value_copy = (CfxApi.DictionaryValue.cfx_dictionary_value_copy_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_dictionary_value_copy, typeof(CfxApi.DictionaryValue.cfx_dictionary_value_copy_delegate));
            CfxApi.DictionaryValue.cfx_dictionary_value_get_size = (CfxApi.DictionaryValue.cfx_dictionary_value_get_size_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_dictionary_value_get_size, typeof(CfxApi.DictionaryValue.cfx_dictionary_value_get_size_delegate));
            CfxApi.DictionaryValue.cfx_dictionary_value_clear = (CfxApi.DictionaryValue.cfx_dictionary_value_clear_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_dictionary_value_clear, typeof(CfxApi.DictionaryValue.cfx_dictionary_value_clear_delegate));
            CfxApi.DictionaryValue.cfx_dictionary_value_has_key = (CfxApi.DictionaryValue.cfx_dictionary_value_has_key_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_dictionary_value_has_key, typeof(CfxApi.DictionaryValue.cfx_dictionary_value_has_key_delegate));
            CfxApi.DictionaryValue.cfx_dictionary_value_get_keys = (CfxApi.DictionaryValue.cfx_dictionary_value_get_keys_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_dictionary_value_get_keys, typeof(CfxApi.DictionaryValue.cfx_dictionary_value_get_keys_delegate));
            CfxApi.DictionaryValue.cfx_dictionary_value_remove = (CfxApi.DictionaryValue.cfx_dictionary_value_remove_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_dictionary_value_remove, typeof(CfxApi.DictionaryValue.cfx_dictionary_value_remove_delegate));
            CfxApi.DictionaryValue.cfx_dictionary_value_get_type = (CfxApi.DictionaryValue.cfx_dictionary_value_get_type_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_dictionary_value_get_type, typeof(CfxApi.DictionaryValue.cfx_dictionary_value_get_type_delegate));
            CfxApi.DictionaryValue.cfx_dictionary_value_get_value = (CfxApi.DictionaryValue.cfx_dictionary_value_get_value_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_dictionary_value_get_value, typeof(CfxApi.DictionaryValue.cfx_dictionary_value_get_value_delegate));
            CfxApi.DictionaryValue.cfx_dictionary_value_get_bool = (CfxApi.DictionaryValue.cfx_dictionary_value_get_bool_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_dictionary_value_get_bool, typeof(CfxApi.DictionaryValue.cfx_dictionary_value_get_bool_delegate));
            CfxApi.DictionaryValue.cfx_dictionary_value_get_int = (CfxApi.DictionaryValue.cfx_dictionary_value_get_int_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_dictionary_value_get_int, typeof(CfxApi.DictionaryValue.cfx_dictionary_value_get_int_delegate));
            CfxApi.DictionaryValue.cfx_dictionary_value_get_double = (CfxApi.DictionaryValue.cfx_dictionary_value_get_double_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_dictionary_value_get_double, typeof(CfxApi.DictionaryValue.cfx_dictionary_value_get_double_delegate));
            CfxApi.DictionaryValue.cfx_dictionary_value_get_string = (CfxApi.DictionaryValue.cfx_dictionary_value_get_string_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_dictionary_value_get_string, typeof(CfxApi.DictionaryValue.cfx_dictionary_value_get_string_delegate));
            CfxApi.DictionaryValue.cfx_dictionary_value_get_binary = (CfxApi.DictionaryValue.cfx_dictionary_value_get_binary_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_dictionary_value_get_binary, typeof(CfxApi.DictionaryValue.cfx_dictionary_value_get_binary_delegate));
            CfxApi.DictionaryValue.cfx_dictionary_value_get_dictionary = (CfxApi.DictionaryValue.cfx_dictionary_value_get_dictionary_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_dictionary_value_get_dictionary, typeof(CfxApi.DictionaryValue.cfx_dictionary_value_get_dictionary_delegate));
            CfxApi.DictionaryValue.cfx_dictionary_value_get_list = (CfxApi.DictionaryValue.cfx_dictionary_value_get_list_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_dictionary_value_get_list, typeof(CfxApi.DictionaryValue.cfx_dictionary_value_get_list_delegate));
            CfxApi.DictionaryValue.cfx_dictionary_value_set_value = (CfxApi.DictionaryValue.cfx_dictionary_value_set_value_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_dictionary_value_set_value, typeof(CfxApi.DictionaryValue.cfx_dictionary_value_set_value_delegate));
            CfxApi.DictionaryValue.cfx_dictionary_value_set_null = (CfxApi.DictionaryValue.cfx_dictionary_value_set_null_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_dictionary_value_set_null, typeof(CfxApi.DictionaryValue.cfx_dictionary_value_set_null_delegate));
            CfxApi.DictionaryValue.cfx_dictionary_value_set_bool = (CfxApi.DictionaryValue.cfx_dictionary_value_set_bool_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_dictionary_value_set_bool, typeof(CfxApi.DictionaryValue.cfx_dictionary_value_set_bool_delegate));
            CfxApi.DictionaryValue.cfx_dictionary_value_set_int = (CfxApi.DictionaryValue.cfx_dictionary_value_set_int_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_dictionary_value_set_int, typeof(CfxApi.DictionaryValue.cfx_dictionary_value_set_int_delegate));
            CfxApi.DictionaryValue.cfx_dictionary_value_set_double = (CfxApi.DictionaryValue.cfx_dictionary_value_set_double_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_dictionary_value_set_double, typeof(CfxApi.DictionaryValue.cfx_dictionary_value_set_double_delegate));
            CfxApi.DictionaryValue.cfx_dictionary_value_set_string = (CfxApi.DictionaryValue.cfx_dictionary_value_set_string_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_dictionary_value_set_string, typeof(CfxApi.DictionaryValue.cfx_dictionary_value_set_string_delegate));
            CfxApi.DictionaryValue.cfx_dictionary_value_set_binary = (CfxApi.DictionaryValue.cfx_dictionary_value_set_binary_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_dictionary_value_set_binary, typeof(CfxApi.DictionaryValue.cfx_dictionary_value_set_binary_delegate));
            CfxApi.DictionaryValue.cfx_dictionary_value_set_dictionary = (CfxApi.DictionaryValue.cfx_dictionary_value_set_dictionary_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_dictionary_value_set_dictionary, typeof(CfxApi.DictionaryValue.cfx_dictionary_value_set_dictionary_delegate));
            CfxApi.DictionaryValue.cfx_dictionary_value_set_list = (CfxApi.DictionaryValue.cfx_dictionary_value_set_list_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_dictionary_value_set_list, typeof(CfxApi.DictionaryValue.cfx_dictionary_value_set_list_delegate));
        }

        internal static void LoadCfxDisplayHandlerApi() {
            CfxApi.Probe();
            CfxApi.DisplayHandler.cfx_display_handler_ctor = (CfxApi.cfx_ctor_with_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_display_handler_ctor, typeof(CfxApi.cfx_ctor_with_gc_handle_delegate));
            CfxApi.DisplayHandler.cfx_display_handler_set_callback = (CfxApi.cfx_set_callback_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_display_handler_set_callback, typeof(CfxApi.cfx_set_callback_delegate));
            CfxDisplayHandler.SetNativeCallbacks();
        }

        internal static void LoadCfxDomDocumentApi() {
            CfxApi.Probe();
            CfxApi.DomDocument.cfx_domdocument_get_type = (CfxApi.DomDocument.cfx_domdocument_get_type_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_domdocument_get_type, typeof(CfxApi.DomDocument.cfx_domdocument_get_type_delegate));
            CfxApi.DomDocument.cfx_domdocument_get_document = (CfxApi.DomDocument.cfx_domdocument_get_document_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_domdocument_get_document, typeof(CfxApi.DomDocument.cfx_domdocument_get_document_delegate));
            CfxApi.DomDocument.cfx_domdocument_get_body = (CfxApi.DomDocument.cfx_domdocument_get_body_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_domdocument_get_body, typeof(CfxApi.DomDocument.cfx_domdocument_get_body_delegate));
            CfxApi.DomDocument.cfx_domdocument_get_head = (CfxApi.DomDocument.cfx_domdocument_get_head_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_domdocument_get_head, typeof(CfxApi.DomDocument.cfx_domdocument_get_head_delegate));
            CfxApi.DomDocument.cfx_domdocument_get_title = (CfxApi.DomDocument.cfx_domdocument_get_title_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_domdocument_get_title, typeof(CfxApi.DomDocument.cfx_domdocument_get_title_delegate));
            CfxApi.DomDocument.cfx_domdocument_get_element_by_id = (CfxApi.DomDocument.cfx_domdocument_get_element_by_id_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_domdocument_get_element_by_id, typeof(CfxApi.DomDocument.cfx_domdocument_get_element_by_id_delegate));
            CfxApi.DomDocument.cfx_domdocument_get_focused_node = (CfxApi.DomDocument.cfx_domdocument_get_focused_node_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_domdocument_get_focused_node, typeof(CfxApi.DomDocument.cfx_domdocument_get_focused_node_delegate));
            CfxApi.DomDocument.cfx_domdocument_has_selection = (CfxApi.DomDocument.cfx_domdocument_has_selection_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_domdocument_has_selection, typeof(CfxApi.DomDocument.cfx_domdocument_has_selection_delegate));
            CfxApi.DomDocument.cfx_domdocument_get_selection_start_offset = (CfxApi.DomDocument.cfx_domdocument_get_selection_start_offset_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_domdocument_get_selection_start_offset, typeof(CfxApi.DomDocument.cfx_domdocument_get_selection_start_offset_delegate));
            CfxApi.DomDocument.cfx_domdocument_get_selection_end_offset = (CfxApi.DomDocument.cfx_domdocument_get_selection_end_offset_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_domdocument_get_selection_end_offset, typeof(CfxApi.DomDocument.cfx_domdocument_get_selection_end_offset_delegate));
            CfxApi.DomDocument.cfx_domdocument_get_selection_as_markup = (CfxApi.DomDocument.cfx_domdocument_get_selection_as_markup_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_domdocument_get_selection_as_markup, typeof(CfxApi.DomDocument.cfx_domdocument_get_selection_as_markup_delegate));
            CfxApi.DomDocument.cfx_domdocument_get_selection_as_text = (CfxApi.DomDocument.cfx_domdocument_get_selection_as_text_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_domdocument_get_selection_as_text, typeof(CfxApi.DomDocument.cfx_domdocument_get_selection_as_text_delegate));
            CfxApi.DomDocument.cfx_domdocument_get_base_url = (CfxApi.DomDocument.cfx_domdocument_get_base_url_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_domdocument_get_base_url, typeof(CfxApi.DomDocument.cfx_domdocument_get_base_url_delegate));
            CfxApi.DomDocument.cfx_domdocument_get_complete_url = (CfxApi.DomDocument.cfx_domdocument_get_complete_url_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_domdocument_get_complete_url, typeof(CfxApi.DomDocument.cfx_domdocument_get_complete_url_delegate));
        }

        internal static void LoadCfxDomNodeApi() {
            CfxApi.Probe();
            CfxApi.DomNode.cfx_domnode_get_type = (CfxApi.DomNode.cfx_domnode_get_type_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_domnode_get_type, typeof(CfxApi.DomNode.cfx_domnode_get_type_delegate));
            CfxApi.DomNode.cfx_domnode_is_text = (CfxApi.DomNode.cfx_domnode_is_text_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_domnode_is_text, typeof(CfxApi.DomNode.cfx_domnode_is_text_delegate));
            CfxApi.DomNode.cfx_domnode_is_element = (CfxApi.DomNode.cfx_domnode_is_element_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_domnode_is_element, typeof(CfxApi.DomNode.cfx_domnode_is_element_delegate));
            CfxApi.DomNode.cfx_domnode_is_editable = (CfxApi.DomNode.cfx_domnode_is_editable_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_domnode_is_editable, typeof(CfxApi.DomNode.cfx_domnode_is_editable_delegate));
            CfxApi.DomNode.cfx_domnode_is_form_control_element = (CfxApi.DomNode.cfx_domnode_is_form_control_element_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_domnode_is_form_control_element, typeof(CfxApi.DomNode.cfx_domnode_is_form_control_element_delegate));
            CfxApi.DomNode.cfx_domnode_get_form_control_element_type = (CfxApi.DomNode.cfx_domnode_get_form_control_element_type_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_domnode_get_form_control_element_type, typeof(CfxApi.DomNode.cfx_domnode_get_form_control_element_type_delegate));
            CfxApi.DomNode.cfx_domnode_is_same = (CfxApi.DomNode.cfx_domnode_is_same_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_domnode_is_same, typeof(CfxApi.DomNode.cfx_domnode_is_same_delegate));
            CfxApi.DomNode.cfx_domnode_get_name = (CfxApi.DomNode.cfx_domnode_get_name_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_domnode_get_name, typeof(CfxApi.DomNode.cfx_domnode_get_name_delegate));
            CfxApi.DomNode.cfx_domnode_get_value = (CfxApi.DomNode.cfx_domnode_get_value_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_domnode_get_value, typeof(CfxApi.DomNode.cfx_domnode_get_value_delegate));
            CfxApi.DomNode.cfx_domnode_set_value = (CfxApi.DomNode.cfx_domnode_set_value_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_domnode_set_value, typeof(CfxApi.DomNode.cfx_domnode_set_value_delegate));
            CfxApi.DomNode.cfx_domnode_get_as_markup = (CfxApi.DomNode.cfx_domnode_get_as_markup_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_domnode_get_as_markup, typeof(CfxApi.DomNode.cfx_domnode_get_as_markup_delegate));
            CfxApi.DomNode.cfx_domnode_get_document = (CfxApi.DomNode.cfx_domnode_get_document_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_domnode_get_document, typeof(CfxApi.DomNode.cfx_domnode_get_document_delegate));
            CfxApi.DomNode.cfx_domnode_get_parent = (CfxApi.DomNode.cfx_domnode_get_parent_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_domnode_get_parent, typeof(CfxApi.DomNode.cfx_domnode_get_parent_delegate));
            CfxApi.DomNode.cfx_domnode_get_previous_sibling = (CfxApi.DomNode.cfx_domnode_get_previous_sibling_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_domnode_get_previous_sibling, typeof(CfxApi.DomNode.cfx_domnode_get_previous_sibling_delegate));
            CfxApi.DomNode.cfx_domnode_get_next_sibling = (CfxApi.DomNode.cfx_domnode_get_next_sibling_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_domnode_get_next_sibling, typeof(CfxApi.DomNode.cfx_domnode_get_next_sibling_delegate));
            CfxApi.DomNode.cfx_domnode_has_children = (CfxApi.DomNode.cfx_domnode_has_children_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_domnode_has_children, typeof(CfxApi.DomNode.cfx_domnode_has_children_delegate));
            CfxApi.DomNode.cfx_domnode_get_first_child = (CfxApi.DomNode.cfx_domnode_get_first_child_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_domnode_get_first_child, typeof(CfxApi.DomNode.cfx_domnode_get_first_child_delegate));
            CfxApi.DomNode.cfx_domnode_get_last_child = (CfxApi.DomNode.cfx_domnode_get_last_child_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_domnode_get_last_child, typeof(CfxApi.DomNode.cfx_domnode_get_last_child_delegate));
            CfxApi.DomNode.cfx_domnode_get_element_tag_name = (CfxApi.DomNode.cfx_domnode_get_element_tag_name_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_domnode_get_element_tag_name, typeof(CfxApi.DomNode.cfx_domnode_get_element_tag_name_delegate));
            CfxApi.DomNode.cfx_domnode_has_element_attributes = (CfxApi.DomNode.cfx_domnode_has_element_attributes_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_domnode_has_element_attributes, typeof(CfxApi.DomNode.cfx_domnode_has_element_attributes_delegate));
            CfxApi.DomNode.cfx_domnode_has_element_attribute = (CfxApi.DomNode.cfx_domnode_has_element_attribute_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_domnode_has_element_attribute, typeof(CfxApi.DomNode.cfx_domnode_has_element_attribute_delegate));
            CfxApi.DomNode.cfx_domnode_get_element_attribute = (CfxApi.DomNode.cfx_domnode_get_element_attribute_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_domnode_get_element_attribute, typeof(CfxApi.DomNode.cfx_domnode_get_element_attribute_delegate));
            CfxApi.DomNode.cfx_domnode_get_element_attributes = (CfxApi.DomNode.cfx_domnode_get_element_attributes_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_domnode_get_element_attributes, typeof(CfxApi.DomNode.cfx_domnode_get_element_attributes_delegate));
            CfxApi.DomNode.cfx_domnode_set_element_attribute = (CfxApi.DomNode.cfx_domnode_set_element_attribute_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_domnode_set_element_attribute, typeof(CfxApi.DomNode.cfx_domnode_set_element_attribute_delegate));
            CfxApi.DomNode.cfx_domnode_get_element_inner_text = (CfxApi.DomNode.cfx_domnode_get_element_inner_text_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_domnode_get_element_inner_text, typeof(CfxApi.DomNode.cfx_domnode_get_element_inner_text_delegate));
            CfxApi.DomNode.cfx_domnode_get_element_bounds = (CfxApi.DomNode.cfx_domnode_get_element_bounds_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_domnode_get_element_bounds, typeof(CfxApi.DomNode.cfx_domnode_get_element_bounds_delegate));
        }

        internal static void LoadCfxDomVisitorApi() {
            CfxApi.Probe();
            CfxApi.DomVisitor.cfx_domvisitor_ctor = (CfxApi.cfx_ctor_with_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_domvisitor_ctor, typeof(CfxApi.cfx_ctor_with_gc_handle_delegate));
            CfxApi.DomVisitor.cfx_domvisitor_set_callback = (CfxApi.cfx_set_callback_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_domvisitor_set_callback, typeof(CfxApi.cfx_set_callback_delegate));
            CfxDomVisitor.SetNativeCallbacks();
        }

        internal static void LoadCfxDownloadHandlerApi() {
            CfxApi.Probe();
            CfxApi.DownloadHandler.cfx_download_handler_ctor = (CfxApi.cfx_ctor_with_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_download_handler_ctor, typeof(CfxApi.cfx_ctor_with_gc_handle_delegate));
            CfxApi.DownloadHandler.cfx_download_handler_set_callback = (CfxApi.cfx_set_callback_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_download_handler_set_callback, typeof(CfxApi.cfx_set_callback_delegate));
            CfxDownloadHandler.SetNativeCallbacks();
        }

        internal static void LoadCfxDownloadImageCallbackApi() {
            CfxApi.Probe();
            CfxApi.DownloadImageCallback.cfx_download_image_callback_ctor = (CfxApi.cfx_ctor_with_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_download_image_callback_ctor, typeof(CfxApi.cfx_ctor_with_gc_handle_delegate));
            CfxApi.DownloadImageCallback.cfx_download_image_callback_set_callback = (CfxApi.cfx_set_callback_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_download_image_callback_set_callback, typeof(CfxApi.cfx_set_callback_delegate));
            CfxDownloadImageCallback.SetNativeCallbacks();
        }

        internal static void LoadCfxDownloadItemApi() {
            CfxApi.Probe();
            CfxApi.DownloadItem.cfx_download_item_is_valid = (CfxApi.DownloadItem.cfx_download_item_is_valid_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_download_item_is_valid, typeof(CfxApi.DownloadItem.cfx_download_item_is_valid_delegate));
            CfxApi.DownloadItem.cfx_download_item_is_in_progress = (CfxApi.DownloadItem.cfx_download_item_is_in_progress_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_download_item_is_in_progress, typeof(CfxApi.DownloadItem.cfx_download_item_is_in_progress_delegate));
            CfxApi.DownloadItem.cfx_download_item_is_complete = (CfxApi.DownloadItem.cfx_download_item_is_complete_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_download_item_is_complete, typeof(CfxApi.DownloadItem.cfx_download_item_is_complete_delegate));
            CfxApi.DownloadItem.cfx_download_item_is_canceled = (CfxApi.DownloadItem.cfx_download_item_is_canceled_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_download_item_is_canceled, typeof(CfxApi.DownloadItem.cfx_download_item_is_canceled_delegate));
            CfxApi.DownloadItem.cfx_download_item_get_current_speed = (CfxApi.DownloadItem.cfx_download_item_get_current_speed_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_download_item_get_current_speed, typeof(CfxApi.DownloadItem.cfx_download_item_get_current_speed_delegate));
            CfxApi.DownloadItem.cfx_download_item_get_percent_complete = (CfxApi.DownloadItem.cfx_download_item_get_percent_complete_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_download_item_get_percent_complete, typeof(CfxApi.DownloadItem.cfx_download_item_get_percent_complete_delegate));
            CfxApi.DownloadItem.cfx_download_item_get_total_bytes = (CfxApi.DownloadItem.cfx_download_item_get_total_bytes_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_download_item_get_total_bytes, typeof(CfxApi.DownloadItem.cfx_download_item_get_total_bytes_delegate));
            CfxApi.DownloadItem.cfx_download_item_get_received_bytes = (CfxApi.DownloadItem.cfx_download_item_get_received_bytes_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_download_item_get_received_bytes, typeof(CfxApi.DownloadItem.cfx_download_item_get_received_bytes_delegate));
            CfxApi.DownloadItem.cfx_download_item_get_start_time = (CfxApi.DownloadItem.cfx_download_item_get_start_time_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_download_item_get_start_time, typeof(CfxApi.DownloadItem.cfx_download_item_get_start_time_delegate));
            CfxApi.DownloadItem.cfx_download_item_get_end_time = (CfxApi.DownloadItem.cfx_download_item_get_end_time_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_download_item_get_end_time, typeof(CfxApi.DownloadItem.cfx_download_item_get_end_time_delegate));
            CfxApi.DownloadItem.cfx_download_item_get_full_path = (CfxApi.DownloadItem.cfx_download_item_get_full_path_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_download_item_get_full_path, typeof(CfxApi.DownloadItem.cfx_download_item_get_full_path_delegate));
            CfxApi.DownloadItem.cfx_download_item_get_id = (CfxApi.DownloadItem.cfx_download_item_get_id_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_download_item_get_id, typeof(CfxApi.DownloadItem.cfx_download_item_get_id_delegate));
            CfxApi.DownloadItem.cfx_download_item_get_url = (CfxApi.DownloadItem.cfx_download_item_get_url_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_download_item_get_url, typeof(CfxApi.DownloadItem.cfx_download_item_get_url_delegate));
            CfxApi.DownloadItem.cfx_download_item_get_original_url = (CfxApi.DownloadItem.cfx_download_item_get_original_url_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_download_item_get_original_url, typeof(CfxApi.DownloadItem.cfx_download_item_get_original_url_delegate));
            CfxApi.DownloadItem.cfx_download_item_get_suggested_file_name = (CfxApi.DownloadItem.cfx_download_item_get_suggested_file_name_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_download_item_get_suggested_file_name, typeof(CfxApi.DownloadItem.cfx_download_item_get_suggested_file_name_delegate));
            CfxApi.DownloadItem.cfx_download_item_get_content_disposition = (CfxApi.DownloadItem.cfx_download_item_get_content_disposition_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_download_item_get_content_disposition, typeof(CfxApi.DownloadItem.cfx_download_item_get_content_disposition_delegate));
            CfxApi.DownloadItem.cfx_download_item_get_mime_type = (CfxApi.DownloadItem.cfx_download_item_get_mime_type_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_download_item_get_mime_type, typeof(CfxApi.DownloadItem.cfx_download_item_get_mime_type_delegate));
        }

        internal static void LoadCfxDownloadItemCallbackApi() {
            CfxApi.Probe();
            CfxApi.DownloadItemCallback.cfx_download_item_callback_cancel = (CfxApi.DownloadItemCallback.cfx_download_item_callback_cancel_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_download_item_callback_cancel, typeof(CfxApi.DownloadItemCallback.cfx_download_item_callback_cancel_delegate));
            CfxApi.DownloadItemCallback.cfx_download_item_callback_pause = (CfxApi.DownloadItemCallback.cfx_download_item_callback_pause_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_download_item_callback_pause, typeof(CfxApi.DownloadItemCallback.cfx_download_item_callback_pause_delegate));
            CfxApi.DownloadItemCallback.cfx_download_item_callback_resume = (CfxApi.DownloadItemCallback.cfx_download_item_callback_resume_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_download_item_callback_resume, typeof(CfxApi.DownloadItemCallback.cfx_download_item_callback_resume_delegate));
        }

        internal static void LoadCfxDragDataApi() {
            CfxApi.Probe();
            CfxApi.DragData.cfx_drag_data_create = (CfxApi.DragData.cfx_drag_data_create_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_drag_data_create, typeof(CfxApi.DragData.cfx_drag_data_create_delegate));
            CfxApi.DragData.cfx_drag_data_clone = (CfxApi.DragData.cfx_drag_data_clone_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_drag_data_clone, typeof(CfxApi.DragData.cfx_drag_data_clone_delegate));
            CfxApi.DragData.cfx_drag_data_is_read_only = (CfxApi.DragData.cfx_drag_data_is_read_only_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_drag_data_is_read_only, typeof(CfxApi.DragData.cfx_drag_data_is_read_only_delegate));
            CfxApi.DragData.cfx_drag_data_is_link = (CfxApi.DragData.cfx_drag_data_is_link_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_drag_data_is_link, typeof(CfxApi.DragData.cfx_drag_data_is_link_delegate));
            CfxApi.DragData.cfx_drag_data_is_fragment = (CfxApi.DragData.cfx_drag_data_is_fragment_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_drag_data_is_fragment, typeof(CfxApi.DragData.cfx_drag_data_is_fragment_delegate));
            CfxApi.DragData.cfx_drag_data_is_file = (CfxApi.DragData.cfx_drag_data_is_file_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_drag_data_is_file, typeof(CfxApi.DragData.cfx_drag_data_is_file_delegate));
            CfxApi.DragData.cfx_drag_data_get_link_url = (CfxApi.DragData.cfx_drag_data_get_link_url_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_drag_data_get_link_url, typeof(CfxApi.DragData.cfx_drag_data_get_link_url_delegate));
            CfxApi.DragData.cfx_drag_data_get_link_title = (CfxApi.DragData.cfx_drag_data_get_link_title_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_drag_data_get_link_title, typeof(CfxApi.DragData.cfx_drag_data_get_link_title_delegate));
            CfxApi.DragData.cfx_drag_data_get_link_metadata = (CfxApi.DragData.cfx_drag_data_get_link_metadata_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_drag_data_get_link_metadata, typeof(CfxApi.DragData.cfx_drag_data_get_link_metadata_delegate));
            CfxApi.DragData.cfx_drag_data_get_fragment_text = (CfxApi.DragData.cfx_drag_data_get_fragment_text_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_drag_data_get_fragment_text, typeof(CfxApi.DragData.cfx_drag_data_get_fragment_text_delegate));
            CfxApi.DragData.cfx_drag_data_get_fragment_html = (CfxApi.DragData.cfx_drag_data_get_fragment_html_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_drag_data_get_fragment_html, typeof(CfxApi.DragData.cfx_drag_data_get_fragment_html_delegate));
            CfxApi.DragData.cfx_drag_data_get_fragment_base_url = (CfxApi.DragData.cfx_drag_data_get_fragment_base_url_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_drag_data_get_fragment_base_url, typeof(CfxApi.DragData.cfx_drag_data_get_fragment_base_url_delegate));
            CfxApi.DragData.cfx_drag_data_get_file_name = (CfxApi.DragData.cfx_drag_data_get_file_name_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_drag_data_get_file_name, typeof(CfxApi.DragData.cfx_drag_data_get_file_name_delegate));
            CfxApi.DragData.cfx_drag_data_get_file_contents = (CfxApi.DragData.cfx_drag_data_get_file_contents_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_drag_data_get_file_contents, typeof(CfxApi.DragData.cfx_drag_data_get_file_contents_delegate));
            CfxApi.DragData.cfx_drag_data_get_file_names = (CfxApi.DragData.cfx_drag_data_get_file_names_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_drag_data_get_file_names, typeof(CfxApi.DragData.cfx_drag_data_get_file_names_delegate));
            CfxApi.DragData.cfx_drag_data_set_link_url = (CfxApi.DragData.cfx_drag_data_set_link_url_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_drag_data_set_link_url, typeof(CfxApi.DragData.cfx_drag_data_set_link_url_delegate));
            CfxApi.DragData.cfx_drag_data_set_link_title = (CfxApi.DragData.cfx_drag_data_set_link_title_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_drag_data_set_link_title, typeof(CfxApi.DragData.cfx_drag_data_set_link_title_delegate));
            CfxApi.DragData.cfx_drag_data_set_link_metadata = (CfxApi.DragData.cfx_drag_data_set_link_metadata_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_drag_data_set_link_metadata, typeof(CfxApi.DragData.cfx_drag_data_set_link_metadata_delegate));
            CfxApi.DragData.cfx_drag_data_set_fragment_text = (CfxApi.DragData.cfx_drag_data_set_fragment_text_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_drag_data_set_fragment_text, typeof(CfxApi.DragData.cfx_drag_data_set_fragment_text_delegate));
            CfxApi.DragData.cfx_drag_data_set_fragment_html = (CfxApi.DragData.cfx_drag_data_set_fragment_html_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_drag_data_set_fragment_html, typeof(CfxApi.DragData.cfx_drag_data_set_fragment_html_delegate));
            CfxApi.DragData.cfx_drag_data_set_fragment_base_url = (CfxApi.DragData.cfx_drag_data_set_fragment_base_url_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_drag_data_set_fragment_base_url, typeof(CfxApi.DragData.cfx_drag_data_set_fragment_base_url_delegate));
            CfxApi.DragData.cfx_drag_data_reset_file_contents = (CfxApi.DragData.cfx_drag_data_reset_file_contents_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_drag_data_reset_file_contents, typeof(CfxApi.DragData.cfx_drag_data_reset_file_contents_delegate));
            CfxApi.DragData.cfx_drag_data_add_file = (CfxApi.DragData.cfx_drag_data_add_file_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_drag_data_add_file, typeof(CfxApi.DragData.cfx_drag_data_add_file_delegate));
            CfxApi.DragData.cfx_drag_data_get_image = (CfxApi.DragData.cfx_drag_data_get_image_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_drag_data_get_image, typeof(CfxApi.DragData.cfx_drag_data_get_image_delegate));
            CfxApi.DragData.cfx_drag_data_get_image_hotspot = (CfxApi.DragData.cfx_drag_data_get_image_hotspot_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_drag_data_get_image_hotspot, typeof(CfxApi.DragData.cfx_drag_data_get_image_hotspot_delegate));
            CfxApi.DragData.cfx_drag_data_has_image = (CfxApi.DragData.cfx_drag_data_has_image_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_drag_data_has_image, typeof(CfxApi.DragData.cfx_drag_data_has_image_delegate));
        }

        internal static void LoadCfxDragHandlerApi() {
            CfxApi.Probe();
            CfxApi.DragHandler.cfx_drag_handler_ctor = (CfxApi.cfx_ctor_with_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_drag_handler_ctor, typeof(CfxApi.cfx_ctor_with_gc_handle_delegate));
            CfxApi.DragHandler.cfx_drag_handler_set_callback = (CfxApi.cfx_set_callback_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_drag_handler_set_callback, typeof(CfxApi.cfx_set_callback_delegate));
            CfxDragHandler.SetNativeCallbacks();
        }

        internal static void LoadCfxDraggableRegionApi() {
            CfxApi.Probe();
            CfxApi.DraggableRegion.cfx_draggable_region_ctor = (CfxApi.cfx_ctor_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_draggable_region_ctor, typeof(CfxApi.cfx_ctor_delegate));
            CfxApi.DraggableRegion.cfx_draggable_region_dtor = (CfxApi.cfx_dtor_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_draggable_region_dtor, typeof(CfxApi.cfx_dtor_delegate));
            CfxApi.DraggableRegion.cfx_draggable_region_set_bounds = (CfxApi.DraggableRegion.cfx_draggable_region_set_bounds_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_draggable_region_set_bounds, typeof(CfxApi.DraggableRegion.cfx_draggable_region_set_bounds_delegate));
            CfxApi.DraggableRegion.cfx_draggable_region_get_bounds = (CfxApi.DraggableRegion.cfx_draggable_region_get_bounds_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_draggable_region_get_bounds, typeof(CfxApi.DraggableRegion.cfx_draggable_region_get_bounds_delegate));
            CfxApi.DraggableRegion.cfx_draggable_region_set_draggable = (CfxApi.DraggableRegion.cfx_draggable_region_set_draggable_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_draggable_region_set_draggable, typeof(CfxApi.DraggableRegion.cfx_draggable_region_set_draggable_delegate));
            CfxApi.DraggableRegion.cfx_draggable_region_get_draggable = (CfxApi.DraggableRegion.cfx_draggable_region_get_draggable_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_draggable_region_get_draggable, typeof(CfxApi.DraggableRegion.cfx_draggable_region_get_draggable_delegate));
        }

        internal static void LoadCfxEndTracingCallbackApi() {
            CfxApi.Probe();
            CfxApi.EndTracingCallback.cfx_end_tracing_callback_ctor = (CfxApi.cfx_ctor_with_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_end_tracing_callback_ctor, typeof(CfxApi.cfx_ctor_with_gc_handle_delegate));
            CfxApi.EndTracingCallback.cfx_end_tracing_callback_set_callback = (CfxApi.cfx_set_callback_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_end_tracing_callback_set_callback, typeof(CfxApi.cfx_set_callback_delegate));
            CfxEndTracingCallback.SetNativeCallbacks();
        }

        internal static void LoadCfxExtensionApi() {
            CfxApi.Probe();
            CfxApi.Extension.cfx_extension_get_identifier = (CfxApi.Extension.cfx_extension_get_identifier_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_extension_get_identifier, typeof(CfxApi.Extension.cfx_extension_get_identifier_delegate));
            CfxApi.Extension.cfx_extension_get_path = (CfxApi.Extension.cfx_extension_get_path_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_extension_get_path, typeof(CfxApi.Extension.cfx_extension_get_path_delegate));
            CfxApi.Extension.cfx_extension_get_manifest = (CfxApi.Extension.cfx_extension_get_manifest_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_extension_get_manifest, typeof(CfxApi.Extension.cfx_extension_get_manifest_delegate));
            CfxApi.Extension.cfx_extension_is_same = (CfxApi.Extension.cfx_extension_is_same_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_extension_is_same, typeof(CfxApi.Extension.cfx_extension_is_same_delegate));
            CfxApi.Extension.cfx_extension_get_handler = (CfxApi.Extension.cfx_extension_get_handler_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_extension_get_handler, typeof(CfxApi.Extension.cfx_extension_get_handler_delegate));
            CfxApi.Extension.cfx_extension_get_loader_context = (CfxApi.Extension.cfx_extension_get_loader_context_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_extension_get_loader_context, typeof(CfxApi.Extension.cfx_extension_get_loader_context_delegate));
            CfxApi.Extension.cfx_extension_is_loaded = (CfxApi.Extension.cfx_extension_is_loaded_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_extension_is_loaded, typeof(CfxApi.Extension.cfx_extension_is_loaded_delegate));
            CfxApi.Extension.cfx_extension_unload = (CfxApi.Extension.cfx_extension_unload_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_extension_unload, typeof(CfxApi.Extension.cfx_extension_unload_delegate));
        }

        internal static void LoadCfxExtensionHandlerApi() {
            CfxApi.Probe();
            CfxApi.ExtensionHandler.cfx_extension_handler_ctor = (CfxApi.cfx_ctor_with_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_extension_handler_ctor, typeof(CfxApi.cfx_ctor_with_gc_handle_delegate));
            CfxApi.ExtensionHandler.cfx_extension_handler_get_gc_handle = (CfxApi.cfx_get_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_extension_handler_get_gc_handle, typeof(CfxApi.cfx_get_gc_handle_delegate));
            CfxApi.ExtensionHandler.cfx_extension_handler_set_callback = (CfxApi.cfx_set_callback_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_extension_handler_set_callback, typeof(CfxApi.cfx_set_callback_delegate));
            CfxExtensionHandler.SetNativeCallbacks();
        }

        internal static void LoadCfxFileDialogCallbackApi() {
            CfxApi.Probe();
            CfxApi.FileDialogCallback.cfx_file_dialog_callback_cont = (CfxApi.FileDialogCallback.cfx_file_dialog_callback_cont_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_file_dialog_callback_cont, typeof(CfxApi.FileDialogCallback.cfx_file_dialog_callback_cont_delegate));
            CfxApi.FileDialogCallback.cfx_file_dialog_callback_cancel = (CfxApi.FileDialogCallback.cfx_file_dialog_callback_cancel_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_file_dialog_callback_cancel, typeof(CfxApi.FileDialogCallback.cfx_file_dialog_callback_cancel_delegate));
        }

        internal static void LoadCfxFindHandlerApi() {
            CfxApi.Probe();
            CfxApi.FindHandler.cfx_find_handler_ctor = (CfxApi.cfx_ctor_with_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_find_handler_ctor, typeof(CfxApi.cfx_ctor_with_gc_handle_delegate));
            CfxApi.FindHandler.cfx_find_handler_set_callback = (CfxApi.cfx_set_callback_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_find_handler_set_callback, typeof(CfxApi.cfx_set_callback_delegate));
            CfxFindHandler.SetNativeCallbacks();
        }

        internal static void LoadCfxFocusHandlerApi() {
            CfxApi.Probe();
            CfxApi.FocusHandler.cfx_focus_handler_ctor = (CfxApi.cfx_ctor_with_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_focus_handler_ctor, typeof(CfxApi.cfx_ctor_with_gc_handle_delegate));
            CfxApi.FocusHandler.cfx_focus_handler_set_callback = (CfxApi.cfx_set_callback_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_focus_handler_set_callback, typeof(CfxApi.cfx_set_callback_delegate));
            CfxFocusHandler.SetNativeCallbacks();
        }

        internal static void LoadCfxFrameApi() {
            CfxApi.Probe();
            CfxApi.Frame.cfx_frame_is_valid = (CfxApi.Frame.cfx_frame_is_valid_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_frame_is_valid, typeof(CfxApi.Frame.cfx_frame_is_valid_delegate));
            CfxApi.Frame.cfx_frame_undo = (CfxApi.Frame.cfx_frame_undo_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_frame_undo, typeof(CfxApi.Frame.cfx_frame_undo_delegate));
            CfxApi.Frame.cfx_frame_redo = (CfxApi.Frame.cfx_frame_redo_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_frame_redo, typeof(CfxApi.Frame.cfx_frame_redo_delegate));
            CfxApi.Frame.cfx_frame_cut = (CfxApi.Frame.cfx_frame_cut_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_frame_cut, typeof(CfxApi.Frame.cfx_frame_cut_delegate));
            CfxApi.Frame.cfx_frame_copy = (CfxApi.Frame.cfx_frame_copy_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_frame_copy, typeof(CfxApi.Frame.cfx_frame_copy_delegate));
            CfxApi.Frame.cfx_frame_paste = (CfxApi.Frame.cfx_frame_paste_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_frame_paste, typeof(CfxApi.Frame.cfx_frame_paste_delegate));
            CfxApi.Frame.cfx_frame_del = (CfxApi.Frame.cfx_frame_del_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_frame_del, typeof(CfxApi.Frame.cfx_frame_del_delegate));
            CfxApi.Frame.cfx_frame_select_all = (CfxApi.Frame.cfx_frame_select_all_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_frame_select_all, typeof(CfxApi.Frame.cfx_frame_select_all_delegate));
            CfxApi.Frame.cfx_frame_view_source = (CfxApi.Frame.cfx_frame_view_source_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_frame_view_source, typeof(CfxApi.Frame.cfx_frame_view_source_delegate));
            CfxApi.Frame.cfx_frame_get_source = (CfxApi.Frame.cfx_frame_get_source_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_frame_get_source, typeof(CfxApi.Frame.cfx_frame_get_source_delegate));
            CfxApi.Frame.cfx_frame_get_text = (CfxApi.Frame.cfx_frame_get_text_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_frame_get_text, typeof(CfxApi.Frame.cfx_frame_get_text_delegate));
            CfxApi.Frame.cfx_frame_load_request = (CfxApi.Frame.cfx_frame_load_request_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_frame_load_request, typeof(CfxApi.Frame.cfx_frame_load_request_delegate));
            CfxApi.Frame.cfx_frame_load_url = (CfxApi.Frame.cfx_frame_load_url_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_frame_load_url, typeof(CfxApi.Frame.cfx_frame_load_url_delegate));
            CfxApi.Frame.cfx_frame_load_string = (CfxApi.Frame.cfx_frame_load_string_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_frame_load_string, typeof(CfxApi.Frame.cfx_frame_load_string_delegate));
            CfxApi.Frame.cfx_frame_execute_java_script = (CfxApi.Frame.cfx_frame_execute_java_script_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_frame_execute_java_script, typeof(CfxApi.Frame.cfx_frame_execute_java_script_delegate));
            CfxApi.Frame.cfx_frame_is_main = (CfxApi.Frame.cfx_frame_is_main_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_frame_is_main, typeof(CfxApi.Frame.cfx_frame_is_main_delegate));
            CfxApi.Frame.cfx_frame_is_focused = (CfxApi.Frame.cfx_frame_is_focused_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_frame_is_focused, typeof(CfxApi.Frame.cfx_frame_is_focused_delegate));
            CfxApi.Frame.cfx_frame_get_name = (CfxApi.Frame.cfx_frame_get_name_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_frame_get_name, typeof(CfxApi.Frame.cfx_frame_get_name_delegate));
            CfxApi.Frame.cfx_frame_get_identifier = (CfxApi.Frame.cfx_frame_get_identifier_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_frame_get_identifier, typeof(CfxApi.Frame.cfx_frame_get_identifier_delegate));
            CfxApi.Frame.cfx_frame_get_parent = (CfxApi.Frame.cfx_frame_get_parent_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_frame_get_parent, typeof(CfxApi.Frame.cfx_frame_get_parent_delegate));
            CfxApi.Frame.cfx_frame_get_url = (CfxApi.Frame.cfx_frame_get_url_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_frame_get_url, typeof(CfxApi.Frame.cfx_frame_get_url_delegate));
            CfxApi.Frame.cfx_frame_get_browser = (CfxApi.Frame.cfx_frame_get_browser_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_frame_get_browser, typeof(CfxApi.Frame.cfx_frame_get_browser_delegate));
            CfxApi.Frame.cfx_frame_get_v8context = (CfxApi.Frame.cfx_frame_get_v8context_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_frame_get_v8context, typeof(CfxApi.Frame.cfx_frame_get_v8context_delegate));
            CfxApi.Frame.cfx_frame_visit_dom = (CfxApi.Frame.cfx_frame_visit_dom_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_frame_visit_dom, typeof(CfxApi.Frame.cfx_frame_visit_dom_delegate));
            CfxApi.Frame.cfx_frame_create_urlrequest = (CfxApi.Frame.cfx_frame_create_urlrequest_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_frame_create_urlrequest, typeof(CfxApi.Frame.cfx_frame_create_urlrequest_delegate));
            CfxApi.Frame.cfx_frame_send_process_message = (CfxApi.Frame.cfx_frame_send_process_message_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_frame_send_process_message, typeof(CfxApi.Frame.cfx_frame_send_process_message_delegate));
        }

        internal static void LoadCfxGetExtensionResourceCallbackApi() {
            CfxApi.Probe();
            CfxApi.GetExtensionResourceCallback.cfx_get_extension_resource_callback_cont = (CfxApi.GetExtensionResourceCallback.cfx_get_extension_resource_callback_cont_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_get_extension_resource_callback_cont, typeof(CfxApi.GetExtensionResourceCallback.cfx_get_extension_resource_callback_cont_delegate));
            CfxApi.GetExtensionResourceCallback.cfx_get_extension_resource_callback_cancel = (CfxApi.GetExtensionResourceCallback.cfx_get_extension_resource_callback_cancel_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_get_extension_resource_callback_cancel, typeof(CfxApi.GetExtensionResourceCallback.cfx_get_extension_resource_callback_cancel_delegate));
        }

        internal static void LoadCfxImageApi() {
            CfxApi.Probe();
            CfxApi.Image.cfx_image_create = (CfxApi.Image.cfx_image_create_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_image_create, typeof(CfxApi.Image.cfx_image_create_delegate));
            CfxApi.Image.cfx_image_is_empty = (CfxApi.Image.cfx_image_is_empty_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_image_is_empty, typeof(CfxApi.Image.cfx_image_is_empty_delegate));
            CfxApi.Image.cfx_image_is_same = (CfxApi.Image.cfx_image_is_same_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_image_is_same, typeof(CfxApi.Image.cfx_image_is_same_delegate));
            CfxApi.Image.cfx_image_add_bitmap = (CfxApi.Image.cfx_image_add_bitmap_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_image_add_bitmap, typeof(CfxApi.Image.cfx_image_add_bitmap_delegate));
            CfxApi.Image.cfx_image_add_png = (CfxApi.Image.cfx_image_add_png_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_image_add_png, typeof(CfxApi.Image.cfx_image_add_png_delegate));
            CfxApi.Image.cfx_image_add_jpeg = (CfxApi.Image.cfx_image_add_jpeg_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_image_add_jpeg, typeof(CfxApi.Image.cfx_image_add_jpeg_delegate));
            CfxApi.Image.cfx_image_get_width = (CfxApi.Image.cfx_image_get_width_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_image_get_width, typeof(CfxApi.Image.cfx_image_get_width_delegate));
            CfxApi.Image.cfx_image_get_height = (CfxApi.Image.cfx_image_get_height_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_image_get_height, typeof(CfxApi.Image.cfx_image_get_height_delegate));
            CfxApi.Image.cfx_image_has_representation = (CfxApi.Image.cfx_image_has_representation_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_image_has_representation, typeof(CfxApi.Image.cfx_image_has_representation_delegate));
            CfxApi.Image.cfx_image_remove_representation = (CfxApi.Image.cfx_image_remove_representation_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_image_remove_representation, typeof(CfxApi.Image.cfx_image_remove_representation_delegate));
            CfxApi.Image.cfx_image_get_representation_info = (CfxApi.Image.cfx_image_get_representation_info_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_image_get_representation_info, typeof(CfxApi.Image.cfx_image_get_representation_info_delegate));
            CfxApi.Image.cfx_image_get_as_bitmap = (CfxApi.Image.cfx_image_get_as_bitmap_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_image_get_as_bitmap, typeof(CfxApi.Image.cfx_image_get_as_bitmap_delegate));
            CfxApi.Image.cfx_image_get_as_png = (CfxApi.Image.cfx_image_get_as_png_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_image_get_as_png, typeof(CfxApi.Image.cfx_image_get_as_png_delegate));
            CfxApi.Image.cfx_image_get_as_jpeg = (CfxApi.Image.cfx_image_get_as_jpeg_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_image_get_as_jpeg, typeof(CfxApi.Image.cfx_image_get_as_jpeg_delegate));
        }

        internal static void LoadCfxInsetsApi() {
            CfxApi.Probe();
            CfxApi.Insets.cfx_insets_ctor = (CfxApi.cfx_ctor_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_insets_ctor, typeof(CfxApi.cfx_ctor_delegate));
            CfxApi.Insets.cfx_insets_dtor = (CfxApi.cfx_dtor_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_insets_dtor, typeof(CfxApi.cfx_dtor_delegate));
            CfxApi.Insets.cfx_insets_set_top = (CfxApi.Insets.cfx_insets_set_top_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_insets_set_top, typeof(CfxApi.Insets.cfx_insets_set_top_delegate));
            CfxApi.Insets.cfx_insets_get_top = (CfxApi.Insets.cfx_insets_get_top_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_insets_get_top, typeof(CfxApi.Insets.cfx_insets_get_top_delegate));
            CfxApi.Insets.cfx_insets_set_left = (CfxApi.Insets.cfx_insets_set_left_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_insets_set_left, typeof(CfxApi.Insets.cfx_insets_set_left_delegate));
            CfxApi.Insets.cfx_insets_get_left = (CfxApi.Insets.cfx_insets_get_left_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_insets_get_left, typeof(CfxApi.Insets.cfx_insets_get_left_delegate));
            CfxApi.Insets.cfx_insets_set_bottom = (CfxApi.Insets.cfx_insets_set_bottom_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_insets_set_bottom, typeof(CfxApi.Insets.cfx_insets_set_bottom_delegate));
            CfxApi.Insets.cfx_insets_get_bottom = (CfxApi.Insets.cfx_insets_get_bottom_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_insets_get_bottom, typeof(CfxApi.Insets.cfx_insets_get_bottom_delegate));
            CfxApi.Insets.cfx_insets_set_right = (CfxApi.Insets.cfx_insets_set_right_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_insets_set_right, typeof(CfxApi.Insets.cfx_insets_set_right_delegate));
            CfxApi.Insets.cfx_insets_get_right = (CfxApi.Insets.cfx_insets_get_right_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_insets_get_right, typeof(CfxApi.Insets.cfx_insets_get_right_delegate));
        }

        internal static void LoadCfxJsDialogCallbackApi() {
            CfxApi.Probe();
            CfxApi.JsDialogCallback.cfx_jsdialog_callback_cont = (CfxApi.JsDialogCallback.cfx_jsdialog_callback_cont_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_jsdialog_callback_cont, typeof(CfxApi.JsDialogCallback.cfx_jsdialog_callback_cont_delegate));
        }

        internal static void LoadCfxJsDialogHandlerApi() {
            CfxApi.Probe();
            CfxApi.JsDialogHandler.cfx_jsdialog_handler_ctor = (CfxApi.cfx_ctor_with_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_jsdialog_handler_ctor, typeof(CfxApi.cfx_ctor_with_gc_handle_delegate));
            CfxApi.JsDialogHandler.cfx_jsdialog_handler_set_callback = (CfxApi.cfx_set_callback_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_jsdialog_handler_set_callback, typeof(CfxApi.cfx_set_callback_delegate));
            CfxJsDialogHandler.SetNativeCallbacks();
        }

        internal static void LoadCfxKeyEventApi() {
            CfxApi.Probe();
            CfxApi.KeyEvent.cfx_key_event_ctor = (CfxApi.cfx_ctor_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_key_event_ctor, typeof(CfxApi.cfx_ctor_delegate));
            CfxApi.KeyEvent.cfx_key_event_dtor = (CfxApi.cfx_dtor_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_key_event_dtor, typeof(CfxApi.cfx_dtor_delegate));
            CfxApi.KeyEvent.cfx_key_event_set_type = (CfxApi.KeyEvent.cfx_key_event_set_type_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_key_event_set_type, typeof(CfxApi.KeyEvent.cfx_key_event_set_type_delegate));
            CfxApi.KeyEvent.cfx_key_event_get_type = (CfxApi.KeyEvent.cfx_key_event_get_type_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_key_event_get_type, typeof(CfxApi.KeyEvent.cfx_key_event_get_type_delegate));
            CfxApi.KeyEvent.cfx_key_event_set_modifiers = (CfxApi.KeyEvent.cfx_key_event_set_modifiers_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_key_event_set_modifiers, typeof(CfxApi.KeyEvent.cfx_key_event_set_modifiers_delegate));
            CfxApi.KeyEvent.cfx_key_event_get_modifiers = (CfxApi.KeyEvent.cfx_key_event_get_modifiers_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_key_event_get_modifiers, typeof(CfxApi.KeyEvent.cfx_key_event_get_modifiers_delegate));
            CfxApi.KeyEvent.cfx_key_event_set_windows_key_code = (CfxApi.KeyEvent.cfx_key_event_set_windows_key_code_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_key_event_set_windows_key_code, typeof(CfxApi.KeyEvent.cfx_key_event_set_windows_key_code_delegate));
            CfxApi.KeyEvent.cfx_key_event_get_windows_key_code = (CfxApi.KeyEvent.cfx_key_event_get_windows_key_code_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_key_event_get_windows_key_code, typeof(CfxApi.KeyEvent.cfx_key_event_get_windows_key_code_delegate));
            CfxApi.KeyEvent.cfx_key_event_set_native_key_code = (CfxApi.KeyEvent.cfx_key_event_set_native_key_code_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_key_event_set_native_key_code, typeof(CfxApi.KeyEvent.cfx_key_event_set_native_key_code_delegate));
            CfxApi.KeyEvent.cfx_key_event_get_native_key_code = (CfxApi.KeyEvent.cfx_key_event_get_native_key_code_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_key_event_get_native_key_code, typeof(CfxApi.KeyEvent.cfx_key_event_get_native_key_code_delegate));
            CfxApi.KeyEvent.cfx_key_event_set_is_system_key = (CfxApi.KeyEvent.cfx_key_event_set_is_system_key_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_key_event_set_is_system_key, typeof(CfxApi.KeyEvent.cfx_key_event_set_is_system_key_delegate));
            CfxApi.KeyEvent.cfx_key_event_get_is_system_key = (CfxApi.KeyEvent.cfx_key_event_get_is_system_key_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_key_event_get_is_system_key, typeof(CfxApi.KeyEvent.cfx_key_event_get_is_system_key_delegate));
            CfxApi.KeyEvent.cfx_key_event_set_character = (CfxApi.KeyEvent.cfx_key_event_set_character_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_key_event_set_character, typeof(CfxApi.KeyEvent.cfx_key_event_set_character_delegate));
            CfxApi.KeyEvent.cfx_key_event_get_character = (CfxApi.KeyEvent.cfx_key_event_get_character_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_key_event_get_character, typeof(CfxApi.KeyEvent.cfx_key_event_get_character_delegate));
            CfxApi.KeyEvent.cfx_key_event_set_unmodified_character = (CfxApi.KeyEvent.cfx_key_event_set_unmodified_character_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_key_event_set_unmodified_character, typeof(CfxApi.KeyEvent.cfx_key_event_set_unmodified_character_delegate));
            CfxApi.KeyEvent.cfx_key_event_get_unmodified_character = (CfxApi.KeyEvent.cfx_key_event_get_unmodified_character_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_key_event_get_unmodified_character, typeof(CfxApi.KeyEvent.cfx_key_event_get_unmodified_character_delegate));
            CfxApi.KeyEvent.cfx_key_event_set_focus_on_editable_field = (CfxApi.KeyEvent.cfx_key_event_set_focus_on_editable_field_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_key_event_set_focus_on_editable_field, typeof(CfxApi.KeyEvent.cfx_key_event_set_focus_on_editable_field_delegate));
            CfxApi.KeyEvent.cfx_key_event_get_focus_on_editable_field = (CfxApi.KeyEvent.cfx_key_event_get_focus_on_editable_field_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_key_event_get_focus_on_editable_field, typeof(CfxApi.KeyEvent.cfx_key_event_get_focus_on_editable_field_delegate));
        }

        internal static void LoadCfxKeyboardHandlerApi() {
            CfxApi.Probe();
            CfxApi.KeyboardHandler.cfx_keyboard_handler_ctor = (CfxApi.cfx_ctor_with_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_keyboard_handler_ctor, typeof(CfxApi.cfx_ctor_with_gc_handle_delegate));
            CfxApi.KeyboardHandler.cfx_keyboard_handler_set_callback = (CfxApi.cfx_set_callback_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_keyboard_handler_set_callback, typeof(CfxApi.cfx_set_callback_delegate));
            CfxKeyboardHandler.SetNativeCallbacks();
        }

        internal static void LoadCfxLifeSpanHandlerApi() {
            CfxApi.Probe();
            CfxApi.LifeSpanHandler.cfx_life_span_handler_ctor = (CfxApi.cfx_ctor_with_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_life_span_handler_ctor, typeof(CfxApi.cfx_ctor_with_gc_handle_delegate));
            CfxApi.LifeSpanHandler.cfx_life_span_handler_set_callback = (CfxApi.cfx_set_callback_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_life_span_handler_set_callback, typeof(CfxApi.cfx_set_callback_delegate));
            CfxLifeSpanHandler.SetNativeCallbacks();
        }

        internal static void LoadCfxListValueApi() {
            CfxApi.Probe();
            CfxApi.ListValue.cfx_list_value_create = (CfxApi.ListValue.cfx_list_value_create_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_list_value_create, typeof(CfxApi.ListValue.cfx_list_value_create_delegate));
            CfxApi.ListValue.cfx_list_value_is_valid = (CfxApi.ListValue.cfx_list_value_is_valid_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_list_value_is_valid, typeof(CfxApi.ListValue.cfx_list_value_is_valid_delegate));
            CfxApi.ListValue.cfx_list_value_is_owned = (CfxApi.ListValue.cfx_list_value_is_owned_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_list_value_is_owned, typeof(CfxApi.ListValue.cfx_list_value_is_owned_delegate));
            CfxApi.ListValue.cfx_list_value_is_read_only = (CfxApi.ListValue.cfx_list_value_is_read_only_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_list_value_is_read_only, typeof(CfxApi.ListValue.cfx_list_value_is_read_only_delegate));
            CfxApi.ListValue.cfx_list_value_is_same = (CfxApi.ListValue.cfx_list_value_is_same_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_list_value_is_same, typeof(CfxApi.ListValue.cfx_list_value_is_same_delegate));
            CfxApi.ListValue.cfx_list_value_is_equal = (CfxApi.ListValue.cfx_list_value_is_equal_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_list_value_is_equal, typeof(CfxApi.ListValue.cfx_list_value_is_equal_delegate));
            CfxApi.ListValue.cfx_list_value_copy = (CfxApi.ListValue.cfx_list_value_copy_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_list_value_copy, typeof(CfxApi.ListValue.cfx_list_value_copy_delegate));
            CfxApi.ListValue.cfx_list_value_set_size = (CfxApi.ListValue.cfx_list_value_set_size_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_list_value_set_size, typeof(CfxApi.ListValue.cfx_list_value_set_size_delegate));
            CfxApi.ListValue.cfx_list_value_get_size = (CfxApi.ListValue.cfx_list_value_get_size_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_list_value_get_size, typeof(CfxApi.ListValue.cfx_list_value_get_size_delegate));
            CfxApi.ListValue.cfx_list_value_clear = (CfxApi.ListValue.cfx_list_value_clear_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_list_value_clear, typeof(CfxApi.ListValue.cfx_list_value_clear_delegate));
            CfxApi.ListValue.cfx_list_value_remove = (CfxApi.ListValue.cfx_list_value_remove_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_list_value_remove, typeof(CfxApi.ListValue.cfx_list_value_remove_delegate));
            CfxApi.ListValue.cfx_list_value_get_type = (CfxApi.ListValue.cfx_list_value_get_type_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_list_value_get_type, typeof(CfxApi.ListValue.cfx_list_value_get_type_delegate));
            CfxApi.ListValue.cfx_list_value_get_value = (CfxApi.ListValue.cfx_list_value_get_value_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_list_value_get_value, typeof(CfxApi.ListValue.cfx_list_value_get_value_delegate));
            CfxApi.ListValue.cfx_list_value_get_bool = (CfxApi.ListValue.cfx_list_value_get_bool_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_list_value_get_bool, typeof(CfxApi.ListValue.cfx_list_value_get_bool_delegate));
            CfxApi.ListValue.cfx_list_value_get_int = (CfxApi.ListValue.cfx_list_value_get_int_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_list_value_get_int, typeof(CfxApi.ListValue.cfx_list_value_get_int_delegate));
            CfxApi.ListValue.cfx_list_value_get_double = (CfxApi.ListValue.cfx_list_value_get_double_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_list_value_get_double, typeof(CfxApi.ListValue.cfx_list_value_get_double_delegate));
            CfxApi.ListValue.cfx_list_value_get_string = (CfxApi.ListValue.cfx_list_value_get_string_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_list_value_get_string, typeof(CfxApi.ListValue.cfx_list_value_get_string_delegate));
            CfxApi.ListValue.cfx_list_value_get_binary = (CfxApi.ListValue.cfx_list_value_get_binary_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_list_value_get_binary, typeof(CfxApi.ListValue.cfx_list_value_get_binary_delegate));
            CfxApi.ListValue.cfx_list_value_get_dictionary = (CfxApi.ListValue.cfx_list_value_get_dictionary_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_list_value_get_dictionary, typeof(CfxApi.ListValue.cfx_list_value_get_dictionary_delegate));
            CfxApi.ListValue.cfx_list_value_get_list = (CfxApi.ListValue.cfx_list_value_get_list_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_list_value_get_list, typeof(CfxApi.ListValue.cfx_list_value_get_list_delegate));
            CfxApi.ListValue.cfx_list_value_set_value = (CfxApi.ListValue.cfx_list_value_set_value_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_list_value_set_value, typeof(CfxApi.ListValue.cfx_list_value_set_value_delegate));
            CfxApi.ListValue.cfx_list_value_set_null = (CfxApi.ListValue.cfx_list_value_set_null_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_list_value_set_null, typeof(CfxApi.ListValue.cfx_list_value_set_null_delegate));
            CfxApi.ListValue.cfx_list_value_set_bool = (CfxApi.ListValue.cfx_list_value_set_bool_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_list_value_set_bool, typeof(CfxApi.ListValue.cfx_list_value_set_bool_delegate));
            CfxApi.ListValue.cfx_list_value_set_int = (CfxApi.ListValue.cfx_list_value_set_int_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_list_value_set_int, typeof(CfxApi.ListValue.cfx_list_value_set_int_delegate));
            CfxApi.ListValue.cfx_list_value_set_double = (CfxApi.ListValue.cfx_list_value_set_double_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_list_value_set_double, typeof(CfxApi.ListValue.cfx_list_value_set_double_delegate));
            CfxApi.ListValue.cfx_list_value_set_string = (CfxApi.ListValue.cfx_list_value_set_string_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_list_value_set_string, typeof(CfxApi.ListValue.cfx_list_value_set_string_delegate));
            CfxApi.ListValue.cfx_list_value_set_binary = (CfxApi.ListValue.cfx_list_value_set_binary_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_list_value_set_binary, typeof(CfxApi.ListValue.cfx_list_value_set_binary_delegate));
            CfxApi.ListValue.cfx_list_value_set_dictionary = (CfxApi.ListValue.cfx_list_value_set_dictionary_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_list_value_set_dictionary, typeof(CfxApi.ListValue.cfx_list_value_set_dictionary_delegate));
            CfxApi.ListValue.cfx_list_value_set_list = (CfxApi.ListValue.cfx_list_value_set_list_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_list_value_set_list, typeof(CfxApi.ListValue.cfx_list_value_set_list_delegate));
        }

        internal static void LoadCfxLoadHandlerApi() {
            CfxApi.Probe();
            CfxApi.LoadHandler.cfx_load_handler_ctor = (CfxApi.cfx_ctor_with_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_load_handler_ctor, typeof(CfxApi.cfx_ctor_with_gc_handle_delegate));
            CfxApi.LoadHandler.cfx_load_handler_set_callback = (CfxApi.cfx_set_callback_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_load_handler_set_callback, typeof(CfxApi.cfx_set_callback_delegate));
            CfxLoadHandler.SetNativeCallbacks();
        }

        internal static void LoadCfxMainArgsLinuxApi() {
            CfxApi.Probe();
            CfxApi.MainArgsLinux.cfx_main_args_linux_ctor = (CfxApi.cfx_ctor_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_main_args_linux_ctor, typeof(CfxApi.cfx_ctor_delegate));
            CfxApi.MainArgsLinux.cfx_main_args_linux_dtor = (CfxApi.cfx_dtor_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_main_args_linux_dtor, typeof(CfxApi.cfx_dtor_delegate));
            CfxApi.MainArgsLinux.cfx_main_args_linux_set_argc = (CfxApi.MainArgsLinux.cfx_main_args_linux_set_argc_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_main_args_linux_set_argc, typeof(CfxApi.MainArgsLinux.cfx_main_args_linux_set_argc_delegate));
            CfxApi.MainArgsLinux.cfx_main_args_linux_get_argc = (CfxApi.MainArgsLinux.cfx_main_args_linux_get_argc_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_main_args_linux_get_argc, typeof(CfxApi.MainArgsLinux.cfx_main_args_linux_get_argc_delegate));
            CfxApi.MainArgsLinux.cfx_main_args_linux_set_argv = (CfxApi.MainArgsLinux.cfx_main_args_linux_set_argv_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_main_args_linux_set_argv, typeof(CfxApi.MainArgsLinux.cfx_main_args_linux_set_argv_delegate));
            CfxApi.MainArgsLinux.cfx_main_args_linux_get_argv = (CfxApi.MainArgsLinux.cfx_main_args_linux_get_argv_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_main_args_linux_get_argv, typeof(CfxApi.MainArgsLinux.cfx_main_args_linux_get_argv_delegate));
        }

        internal static void LoadCfxMainArgsWindowsApi() {
            CfxApi.Probe();
            CfxApi.MainArgsWindows.cfx_main_args_windows_ctor = (CfxApi.cfx_ctor_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_main_args_windows_ctor, typeof(CfxApi.cfx_ctor_delegate));
            CfxApi.MainArgsWindows.cfx_main_args_windows_dtor = (CfxApi.cfx_dtor_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_main_args_windows_dtor, typeof(CfxApi.cfx_dtor_delegate));
            CfxApi.MainArgsWindows.cfx_main_args_windows_set_instance = (CfxApi.MainArgsWindows.cfx_main_args_windows_set_instance_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_main_args_windows_set_instance, typeof(CfxApi.MainArgsWindows.cfx_main_args_windows_set_instance_delegate));
            CfxApi.MainArgsWindows.cfx_main_args_windows_get_instance = (CfxApi.MainArgsWindows.cfx_main_args_windows_get_instance_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_main_args_windows_get_instance, typeof(CfxApi.MainArgsWindows.cfx_main_args_windows_get_instance_delegate));
        }

        internal static void LoadCfxMenuModelApi() {
            CfxApi.Probe();
            CfxApi.MenuModel.cfx_menu_model_create = (CfxApi.MenuModel.cfx_menu_model_create_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_menu_model_create, typeof(CfxApi.MenuModel.cfx_menu_model_create_delegate));
            CfxApi.MenuModel.cfx_menu_model_is_sub_menu = (CfxApi.MenuModel.cfx_menu_model_is_sub_menu_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_menu_model_is_sub_menu, typeof(CfxApi.MenuModel.cfx_menu_model_is_sub_menu_delegate));
            CfxApi.MenuModel.cfx_menu_model_clear = (CfxApi.MenuModel.cfx_menu_model_clear_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_menu_model_clear, typeof(CfxApi.MenuModel.cfx_menu_model_clear_delegate));
            CfxApi.MenuModel.cfx_menu_model_get_count = (CfxApi.MenuModel.cfx_menu_model_get_count_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_menu_model_get_count, typeof(CfxApi.MenuModel.cfx_menu_model_get_count_delegate));
            CfxApi.MenuModel.cfx_menu_model_add_separator = (CfxApi.MenuModel.cfx_menu_model_add_separator_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_menu_model_add_separator, typeof(CfxApi.MenuModel.cfx_menu_model_add_separator_delegate));
            CfxApi.MenuModel.cfx_menu_model_add_item = (CfxApi.MenuModel.cfx_menu_model_add_item_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_menu_model_add_item, typeof(CfxApi.MenuModel.cfx_menu_model_add_item_delegate));
            CfxApi.MenuModel.cfx_menu_model_add_check_item = (CfxApi.MenuModel.cfx_menu_model_add_check_item_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_menu_model_add_check_item, typeof(CfxApi.MenuModel.cfx_menu_model_add_check_item_delegate));
            CfxApi.MenuModel.cfx_menu_model_add_radio_item = (CfxApi.MenuModel.cfx_menu_model_add_radio_item_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_menu_model_add_radio_item, typeof(CfxApi.MenuModel.cfx_menu_model_add_radio_item_delegate));
            CfxApi.MenuModel.cfx_menu_model_add_sub_menu = (CfxApi.MenuModel.cfx_menu_model_add_sub_menu_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_menu_model_add_sub_menu, typeof(CfxApi.MenuModel.cfx_menu_model_add_sub_menu_delegate));
            CfxApi.MenuModel.cfx_menu_model_insert_separator_at = (CfxApi.MenuModel.cfx_menu_model_insert_separator_at_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_menu_model_insert_separator_at, typeof(CfxApi.MenuModel.cfx_menu_model_insert_separator_at_delegate));
            CfxApi.MenuModel.cfx_menu_model_insert_item_at = (CfxApi.MenuModel.cfx_menu_model_insert_item_at_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_menu_model_insert_item_at, typeof(CfxApi.MenuModel.cfx_menu_model_insert_item_at_delegate));
            CfxApi.MenuModel.cfx_menu_model_insert_check_item_at = (CfxApi.MenuModel.cfx_menu_model_insert_check_item_at_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_menu_model_insert_check_item_at, typeof(CfxApi.MenuModel.cfx_menu_model_insert_check_item_at_delegate));
            CfxApi.MenuModel.cfx_menu_model_insert_radio_item_at = (CfxApi.MenuModel.cfx_menu_model_insert_radio_item_at_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_menu_model_insert_radio_item_at, typeof(CfxApi.MenuModel.cfx_menu_model_insert_radio_item_at_delegate));
            CfxApi.MenuModel.cfx_menu_model_insert_sub_menu_at = (CfxApi.MenuModel.cfx_menu_model_insert_sub_menu_at_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_menu_model_insert_sub_menu_at, typeof(CfxApi.MenuModel.cfx_menu_model_insert_sub_menu_at_delegate));
            CfxApi.MenuModel.cfx_menu_model_remove = (CfxApi.MenuModel.cfx_menu_model_remove_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_menu_model_remove, typeof(CfxApi.MenuModel.cfx_menu_model_remove_delegate));
            CfxApi.MenuModel.cfx_menu_model_remove_at = (CfxApi.MenuModel.cfx_menu_model_remove_at_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_menu_model_remove_at, typeof(CfxApi.MenuModel.cfx_menu_model_remove_at_delegate));
            CfxApi.MenuModel.cfx_menu_model_get_index_of = (CfxApi.MenuModel.cfx_menu_model_get_index_of_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_menu_model_get_index_of, typeof(CfxApi.MenuModel.cfx_menu_model_get_index_of_delegate));
            CfxApi.MenuModel.cfx_menu_model_get_command_id_at = (CfxApi.MenuModel.cfx_menu_model_get_command_id_at_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_menu_model_get_command_id_at, typeof(CfxApi.MenuModel.cfx_menu_model_get_command_id_at_delegate));
            CfxApi.MenuModel.cfx_menu_model_set_command_id_at = (CfxApi.MenuModel.cfx_menu_model_set_command_id_at_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_menu_model_set_command_id_at, typeof(CfxApi.MenuModel.cfx_menu_model_set_command_id_at_delegate));
            CfxApi.MenuModel.cfx_menu_model_get_label = (CfxApi.MenuModel.cfx_menu_model_get_label_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_menu_model_get_label, typeof(CfxApi.MenuModel.cfx_menu_model_get_label_delegate));
            CfxApi.MenuModel.cfx_menu_model_get_label_at = (CfxApi.MenuModel.cfx_menu_model_get_label_at_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_menu_model_get_label_at, typeof(CfxApi.MenuModel.cfx_menu_model_get_label_at_delegate));
            CfxApi.MenuModel.cfx_menu_model_set_label = (CfxApi.MenuModel.cfx_menu_model_set_label_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_menu_model_set_label, typeof(CfxApi.MenuModel.cfx_menu_model_set_label_delegate));
            CfxApi.MenuModel.cfx_menu_model_set_label_at = (CfxApi.MenuModel.cfx_menu_model_set_label_at_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_menu_model_set_label_at, typeof(CfxApi.MenuModel.cfx_menu_model_set_label_at_delegate));
            CfxApi.MenuModel.cfx_menu_model_get_type = (CfxApi.MenuModel.cfx_menu_model_get_type_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_menu_model_get_type, typeof(CfxApi.MenuModel.cfx_menu_model_get_type_delegate));
            CfxApi.MenuModel.cfx_menu_model_get_type_at = (CfxApi.MenuModel.cfx_menu_model_get_type_at_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_menu_model_get_type_at, typeof(CfxApi.MenuModel.cfx_menu_model_get_type_at_delegate));
            CfxApi.MenuModel.cfx_menu_model_get_group_id = (CfxApi.MenuModel.cfx_menu_model_get_group_id_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_menu_model_get_group_id, typeof(CfxApi.MenuModel.cfx_menu_model_get_group_id_delegate));
            CfxApi.MenuModel.cfx_menu_model_get_group_id_at = (CfxApi.MenuModel.cfx_menu_model_get_group_id_at_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_menu_model_get_group_id_at, typeof(CfxApi.MenuModel.cfx_menu_model_get_group_id_at_delegate));
            CfxApi.MenuModel.cfx_menu_model_set_group_id = (CfxApi.MenuModel.cfx_menu_model_set_group_id_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_menu_model_set_group_id, typeof(CfxApi.MenuModel.cfx_menu_model_set_group_id_delegate));
            CfxApi.MenuModel.cfx_menu_model_set_group_id_at = (CfxApi.MenuModel.cfx_menu_model_set_group_id_at_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_menu_model_set_group_id_at, typeof(CfxApi.MenuModel.cfx_menu_model_set_group_id_at_delegate));
            CfxApi.MenuModel.cfx_menu_model_get_sub_menu = (CfxApi.MenuModel.cfx_menu_model_get_sub_menu_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_menu_model_get_sub_menu, typeof(CfxApi.MenuModel.cfx_menu_model_get_sub_menu_delegate));
            CfxApi.MenuModel.cfx_menu_model_get_sub_menu_at = (CfxApi.MenuModel.cfx_menu_model_get_sub_menu_at_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_menu_model_get_sub_menu_at, typeof(CfxApi.MenuModel.cfx_menu_model_get_sub_menu_at_delegate));
            CfxApi.MenuModel.cfx_menu_model_is_visible = (CfxApi.MenuModel.cfx_menu_model_is_visible_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_menu_model_is_visible, typeof(CfxApi.MenuModel.cfx_menu_model_is_visible_delegate));
            CfxApi.MenuModel.cfx_menu_model_is_visible_at = (CfxApi.MenuModel.cfx_menu_model_is_visible_at_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_menu_model_is_visible_at, typeof(CfxApi.MenuModel.cfx_menu_model_is_visible_at_delegate));
            CfxApi.MenuModel.cfx_menu_model_set_visible = (CfxApi.MenuModel.cfx_menu_model_set_visible_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_menu_model_set_visible, typeof(CfxApi.MenuModel.cfx_menu_model_set_visible_delegate));
            CfxApi.MenuModel.cfx_menu_model_set_visible_at = (CfxApi.MenuModel.cfx_menu_model_set_visible_at_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_menu_model_set_visible_at, typeof(CfxApi.MenuModel.cfx_menu_model_set_visible_at_delegate));
            CfxApi.MenuModel.cfx_menu_model_is_enabled = (CfxApi.MenuModel.cfx_menu_model_is_enabled_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_menu_model_is_enabled, typeof(CfxApi.MenuModel.cfx_menu_model_is_enabled_delegate));
            CfxApi.MenuModel.cfx_menu_model_is_enabled_at = (CfxApi.MenuModel.cfx_menu_model_is_enabled_at_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_menu_model_is_enabled_at, typeof(CfxApi.MenuModel.cfx_menu_model_is_enabled_at_delegate));
            CfxApi.MenuModel.cfx_menu_model_set_enabled = (CfxApi.MenuModel.cfx_menu_model_set_enabled_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_menu_model_set_enabled, typeof(CfxApi.MenuModel.cfx_menu_model_set_enabled_delegate));
            CfxApi.MenuModel.cfx_menu_model_set_enabled_at = (CfxApi.MenuModel.cfx_menu_model_set_enabled_at_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_menu_model_set_enabled_at, typeof(CfxApi.MenuModel.cfx_menu_model_set_enabled_at_delegate));
            CfxApi.MenuModel.cfx_menu_model_is_checked = (CfxApi.MenuModel.cfx_menu_model_is_checked_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_menu_model_is_checked, typeof(CfxApi.MenuModel.cfx_menu_model_is_checked_delegate));
            CfxApi.MenuModel.cfx_menu_model_is_checked_at = (CfxApi.MenuModel.cfx_menu_model_is_checked_at_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_menu_model_is_checked_at, typeof(CfxApi.MenuModel.cfx_menu_model_is_checked_at_delegate));
            CfxApi.MenuModel.cfx_menu_model_set_checked = (CfxApi.MenuModel.cfx_menu_model_set_checked_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_menu_model_set_checked, typeof(CfxApi.MenuModel.cfx_menu_model_set_checked_delegate));
            CfxApi.MenuModel.cfx_menu_model_set_checked_at = (CfxApi.MenuModel.cfx_menu_model_set_checked_at_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_menu_model_set_checked_at, typeof(CfxApi.MenuModel.cfx_menu_model_set_checked_at_delegate));
            CfxApi.MenuModel.cfx_menu_model_has_accelerator = (CfxApi.MenuModel.cfx_menu_model_has_accelerator_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_menu_model_has_accelerator, typeof(CfxApi.MenuModel.cfx_menu_model_has_accelerator_delegate));
            CfxApi.MenuModel.cfx_menu_model_has_accelerator_at = (CfxApi.MenuModel.cfx_menu_model_has_accelerator_at_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_menu_model_has_accelerator_at, typeof(CfxApi.MenuModel.cfx_menu_model_has_accelerator_at_delegate));
            CfxApi.MenuModel.cfx_menu_model_set_accelerator = (CfxApi.MenuModel.cfx_menu_model_set_accelerator_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_menu_model_set_accelerator, typeof(CfxApi.MenuModel.cfx_menu_model_set_accelerator_delegate));
            CfxApi.MenuModel.cfx_menu_model_set_accelerator_at = (CfxApi.MenuModel.cfx_menu_model_set_accelerator_at_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_menu_model_set_accelerator_at, typeof(CfxApi.MenuModel.cfx_menu_model_set_accelerator_at_delegate));
            CfxApi.MenuModel.cfx_menu_model_remove_accelerator = (CfxApi.MenuModel.cfx_menu_model_remove_accelerator_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_menu_model_remove_accelerator, typeof(CfxApi.MenuModel.cfx_menu_model_remove_accelerator_delegate));
            CfxApi.MenuModel.cfx_menu_model_remove_accelerator_at = (CfxApi.MenuModel.cfx_menu_model_remove_accelerator_at_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_menu_model_remove_accelerator_at, typeof(CfxApi.MenuModel.cfx_menu_model_remove_accelerator_at_delegate));
            CfxApi.MenuModel.cfx_menu_model_get_accelerator = (CfxApi.MenuModel.cfx_menu_model_get_accelerator_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_menu_model_get_accelerator, typeof(CfxApi.MenuModel.cfx_menu_model_get_accelerator_delegate));
            CfxApi.MenuModel.cfx_menu_model_get_accelerator_at = (CfxApi.MenuModel.cfx_menu_model_get_accelerator_at_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_menu_model_get_accelerator_at, typeof(CfxApi.MenuModel.cfx_menu_model_get_accelerator_at_delegate));
            CfxApi.MenuModel.cfx_menu_model_set_color = (CfxApi.MenuModel.cfx_menu_model_set_color_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_menu_model_set_color, typeof(CfxApi.MenuModel.cfx_menu_model_set_color_delegate));
            CfxApi.MenuModel.cfx_menu_model_set_color_at = (CfxApi.MenuModel.cfx_menu_model_set_color_at_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_menu_model_set_color_at, typeof(CfxApi.MenuModel.cfx_menu_model_set_color_at_delegate));
            CfxApi.MenuModel.cfx_menu_model_get_color = (CfxApi.MenuModel.cfx_menu_model_get_color_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_menu_model_get_color, typeof(CfxApi.MenuModel.cfx_menu_model_get_color_delegate));
            CfxApi.MenuModel.cfx_menu_model_get_color_at = (CfxApi.MenuModel.cfx_menu_model_get_color_at_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_menu_model_get_color_at, typeof(CfxApi.MenuModel.cfx_menu_model_get_color_at_delegate));
            CfxApi.MenuModel.cfx_menu_model_set_font_list = (CfxApi.MenuModel.cfx_menu_model_set_font_list_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_menu_model_set_font_list, typeof(CfxApi.MenuModel.cfx_menu_model_set_font_list_delegate));
            CfxApi.MenuModel.cfx_menu_model_set_font_list_at = (CfxApi.MenuModel.cfx_menu_model_set_font_list_at_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_menu_model_set_font_list_at, typeof(CfxApi.MenuModel.cfx_menu_model_set_font_list_at_delegate));
        }

        internal static void LoadCfxMenuModelDelegateApi() {
            CfxApi.Probe();
            CfxApi.MenuModelDelegate.cfx_menu_model_delegate_ctor = (CfxApi.cfx_ctor_with_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_menu_model_delegate_ctor, typeof(CfxApi.cfx_ctor_with_gc_handle_delegate));
            CfxApi.MenuModelDelegate.cfx_menu_model_delegate_set_callback = (CfxApi.cfx_set_callback_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_menu_model_delegate_set_callback, typeof(CfxApi.cfx_set_callback_delegate));
            CfxMenuModelDelegate.SetNativeCallbacks();
        }

        internal static void LoadCfxMouseEventApi() {
            CfxApi.Probe();
            CfxApi.MouseEvent.cfx_mouse_event_ctor = (CfxApi.cfx_ctor_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_mouse_event_ctor, typeof(CfxApi.cfx_ctor_delegate));
            CfxApi.MouseEvent.cfx_mouse_event_dtor = (CfxApi.cfx_dtor_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_mouse_event_dtor, typeof(CfxApi.cfx_dtor_delegate));
            CfxApi.MouseEvent.cfx_mouse_event_set_x = (CfxApi.MouseEvent.cfx_mouse_event_set_x_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_mouse_event_set_x, typeof(CfxApi.MouseEvent.cfx_mouse_event_set_x_delegate));
            CfxApi.MouseEvent.cfx_mouse_event_get_x = (CfxApi.MouseEvent.cfx_mouse_event_get_x_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_mouse_event_get_x, typeof(CfxApi.MouseEvent.cfx_mouse_event_get_x_delegate));
            CfxApi.MouseEvent.cfx_mouse_event_set_y = (CfxApi.MouseEvent.cfx_mouse_event_set_y_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_mouse_event_set_y, typeof(CfxApi.MouseEvent.cfx_mouse_event_set_y_delegate));
            CfxApi.MouseEvent.cfx_mouse_event_get_y = (CfxApi.MouseEvent.cfx_mouse_event_get_y_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_mouse_event_get_y, typeof(CfxApi.MouseEvent.cfx_mouse_event_get_y_delegate));
            CfxApi.MouseEvent.cfx_mouse_event_set_modifiers = (CfxApi.MouseEvent.cfx_mouse_event_set_modifiers_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_mouse_event_set_modifiers, typeof(CfxApi.MouseEvent.cfx_mouse_event_set_modifiers_delegate));
            CfxApi.MouseEvent.cfx_mouse_event_get_modifiers = (CfxApi.MouseEvent.cfx_mouse_event_get_modifiers_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_mouse_event_get_modifiers, typeof(CfxApi.MouseEvent.cfx_mouse_event_get_modifiers_delegate));
        }

        internal static void LoadCfxNavigationEntryApi() {
            CfxApi.Probe();
            CfxApi.NavigationEntry.cfx_navigation_entry_is_valid = (CfxApi.NavigationEntry.cfx_navigation_entry_is_valid_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_navigation_entry_is_valid, typeof(CfxApi.NavigationEntry.cfx_navigation_entry_is_valid_delegate));
            CfxApi.NavigationEntry.cfx_navigation_entry_get_url = (CfxApi.NavigationEntry.cfx_navigation_entry_get_url_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_navigation_entry_get_url, typeof(CfxApi.NavigationEntry.cfx_navigation_entry_get_url_delegate));
            CfxApi.NavigationEntry.cfx_navigation_entry_get_display_url = (CfxApi.NavigationEntry.cfx_navigation_entry_get_display_url_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_navigation_entry_get_display_url, typeof(CfxApi.NavigationEntry.cfx_navigation_entry_get_display_url_delegate));
            CfxApi.NavigationEntry.cfx_navigation_entry_get_original_url = (CfxApi.NavigationEntry.cfx_navigation_entry_get_original_url_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_navigation_entry_get_original_url, typeof(CfxApi.NavigationEntry.cfx_navigation_entry_get_original_url_delegate));
            CfxApi.NavigationEntry.cfx_navigation_entry_get_title = (CfxApi.NavigationEntry.cfx_navigation_entry_get_title_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_navigation_entry_get_title, typeof(CfxApi.NavigationEntry.cfx_navigation_entry_get_title_delegate));
            CfxApi.NavigationEntry.cfx_navigation_entry_get_transition_type = (CfxApi.NavigationEntry.cfx_navigation_entry_get_transition_type_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_navigation_entry_get_transition_type, typeof(CfxApi.NavigationEntry.cfx_navigation_entry_get_transition_type_delegate));
            CfxApi.NavigationEntry.cfx_navigation_entry_has_post_data = (CfxApi.NavigationEntry.cfx_navigation_entry_has_post_data_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_navigation_entry_has_post_data, typeof(CfxApi.NavigationEntry.cfx_navigation_entry_has_post_data_delegate));
            CfxApi.NavigationEntry.cfx_navigation_entry_get_completion_time = (CfxApi.NavigationEntry.cfx_navigation_entry_get_completion_time_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_navigation_entry_get_completion_time, typeof(CfxApi.NavigationEntry.cfx_navigation_entry_get_completion_time_delegate));
            CfxApi.NavigationEntry.cfx_navigation_entry_get_http_status_code = (CfxApi.NavigationEntry.cfx_navigation_entry_get_http_status_code_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_navigation_entry_get_http_status_code, typeof(CfxApi.NavigationEntry.cfx_navigation_entry_get_http_status_code_delegate));
            CfxApi.NavigationEntry.cfx_navigation_entry_get_sslstatus = (CfxApi.NavigationEntry.cfx_navigation_entry_get_sslstatus_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_navigation_entry_get_sslstatus, typeof(CfxApi.NavigationEntry.cfx_navigation_entry_get_sslstatus_delegate));
        }

        internal static void LoadCfxNavigationEntryVisitorApi() {
            CfxApi.Probe();
            CfxApi.NavigationEntryVisitor.cfx_navigation_entry_visitor_ctor = (CfxApi.cfx_ctor_with_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_navigation_entry_visitor_ctor, typeof(CfxApi.cfx_ctor_with_gc_handle_delegate));
            CfxApi.NavigationEntryVisitor.cfx_navigation_entry_visitor_set_callback = (CfxApi.cfx_set_callback_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_navigation_entry_visitor_set_callback, typeof(CfxApi.cfx_set_callback_delegate));
            CfxNavigationEntryVisitor.SetNativeCallbacks();
        }

        internal static void LoadCfxPdfPrintCallbackApi() {
            CfxApi.Probe();
            CfxApi.PdfPrintCallback.cfx_pdf_print_callback_ctor = (CfxApi.cfx_ctor_with_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_pdf_print_callback_ctor, typeof(CfxApi.cfx_ctor_with_gc_handle_delegate));
            CfxApi.PdfPrintCallback.cfx_pdf_print_callback_set_callback = (CfxApi.cfx_set_callback_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_pdf_print_callback_set_callback, typeof(CfxApi.cfx_set_callback_delegate));
            CfxPdfPrintCallback.SetNativeCallbacks();
        }

        internal static void LoadCfxPdfPrintSettingsApi() {
            CfxApi.Probe();
            CfxApi.PdfPrintSettings.cfx_pdf_print_settings_ctor = (CfxApi.cfx_ctor_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_pdf_print_settings_ctor, typeof(CfxApi.cfx_ctor_delegate));
            CfxApi.PdfPrintSettings.cfx_pdf_print_settings_dtor = (CfxApi.cfx_dtor_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_pdf_print_settings_dtor, typeof(CfxApi.cfx_dtor_delegate));
            CfxApi.PdfPrintSettings.cfx_pdf_print_settings_set_header_footer_title = (CfxApi.PdfPrintSettings.cfx_pdf_print_settings_set_header_footer_title_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_pdf_print_settings_set_header_footer_title, typeof(CfxApi.PdfPrintSettings.cfx_pdf_print_settings_set_header_footer_title_delegate));
            CfxApi.PdfPrintSettings.cfx_pdf_print_settings_get_header_footer_title = (CfxApi.PdfPrintSettings.cfx_pdf_print_settings_get_header_footer_title_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_pdf_print_settings_get_header_footer_title, typeof(CfxApi.PdfPrintSettings.cfx_pdf_print_settings_get_header_footer_title_delegate));
            CfxApi.PdfPrintSettings.cfx_pdf_print_settings_set_header_footer_url = (CfxApi.PdfPrintSettings.cfx_pdf_print_settings_set_header_footer_url_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_pdf_print_settings_set_header_footer_url, typeof(CfxApi.PdfPrintSettings.cfx_pdf_print_settings_set_header_footer_url_delegate));
            CfxApi.PdfPrintSettings.cfx_pdf_print_settings_get_header_footer_url = (CfxApi.PdfPrintSettings.cfx_pdf_print_settings_get_header_footer_url_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_pdf_print_settings_get_header_footer_url, typeof(CfxApi.PdfPrintSettings.cfx_pdf_print_settings_get_header_footer_url_delegate));
            CfxApi.PdfPrintSettings.cfx_pdf_print_settings_set_page_width = (CfxApi.PdfPrintSettings.cfx_pdf_print_settings_set_page_width_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_pdf_print_settings_set_page_width, typeof(CfxApi.PdfPrintSettings.cfx_pdf_print_settings_set_page_width_delegate));
            CfxApi.PdfPrintSettings.cfx_pdf_print_settings_get_page_width = (CfxApi.PdfPrintSettings.cfx_pdf_print_settings_get_page_width_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_pdf_print_settings_get_page_width, typeof(CfxApi.PdfPrintSettings.cfx_pdf_print_settings_get_page_width_delegate));
            CfxApi.PdfPrintSettings.cfx_pdf_print_settings_set_page_height = (CfxApi.PdfPrintSettings.cfx_pdf_print_settings_set_page_height_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_pdf_print_settings_set_page_height, typeof(CfxApi.PdfPrintSettings.cfx_pdf_print_settings_set_page_height_delegate));
            CfxApi.PdfPrintSettings.cfx_pdf_print_settings_get_page_height = (CfxApi.PdfPrintSettings.cfx_pdf_print_settings_get_page_height_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_pdf_print_settings_get_page_height, typeof(CfxApi.PdfPrintSettings.cfx_pdf_print_settings_get_page_height_delegate));
            CfxApi.PdfPrintSettings.cfx_pdf_print_settings_set_scale_factor = (CfxApi.PdfPrintSettings.cfx_pdf_print_settings_set_scale_factor_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_pdf_print_settings_set_scale_factor, typeof(CfxApi.PdfPrintSettings.cfx_pdf_print_settings_set_scale_factor_delegate));
            CfxApi.PdfPrintSettings.cfx_pdf_print_settings_get_scale_factor = (CfxApi.PdfPrintSettings.cfx_pdf_print_settings_get_scale_factor_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_pdf_print_settings_get_scale_factor, typeof(CfxApi.PdfPrintSettings.cfx_pdf_print_settings_get_scale_factor_delegate));
            CfxApi.PdfPrintSettings.cfx_pdf_print_settings_set_margin_top = (CfxApi.PdfPrintSettings.cfx_pdf_print_settings_set_margin_top_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_pdf_print_settings_set_margin_top, typeof(CfxApi.PdfPrintSettings.cfx_pdf_print_settings_set_margin_top_delegate));
            CfxApi.PdfPrintSettings.cfx_pdf_print_settings_get_margin_top = (CfxApi.PdfPrintSettings.cfx_pdf_print_settings_get_margin_top_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_pdf_print_settings_get_margin_top, typeof(CfxApi.PdfPrintSettings.cfx_pdf_print_settings_get_margin_top_delegate));
            CfxApi.PdfPrintSettings.cfx_pdf_print_settings_set_margin_right = (CfxApi.PdfPrintSettings.cfx_pdf_print_settings_set_margin_right_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_pdf_print_settings_set_margin_right, typeof(CfxApi.PdfPrintSettings.cfx_pdf_print_settings_set_margin_right_delegate));
            CfxApi.PdfPrintSettings.cfx_pdf_print_settings_get_margin_right = (CfxApi.PdfPrintSettings.cfx_pdf_print_settings_get_margin_right_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_pdf_print_settings_get_margin_right, typeof(CfxApi.PdfPrintSettings.cfx_pdf_print_settings_get_margin_right_delegate));
            CfxApi.PdfPrintSettings.cfx_pdf_print_settings_set_margin_bottom = (CfxApi.PdfPrintSettings.cfx_pdf_print_settings_set_margin_bottom_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_pdf_print_settings_set_margin_bottom, typeof(CfxApi.PdfPrintSettings.cfx_pdf_print_settings_set_margin_bottom_delegate));
            CfxApi.PdfPrintSettings.cfx_pdf_print_settings_get_margin_bottom = (CfxApi.PdfPrintSettings.cfx_pdf_print_settings_get_margin_bottom_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_pdf_print_settings_get_margin_bottom, typeof(CfxApi.PdfPrintSettings.cfx_pdf_print_settings_get_margin_bottom_delegate));
            CfxApi.PdfPrintSettings.cfx_pdf_print_settings_set_margin_left = (CfxApi.PdfPrintSettings.cfx_pdf_print_settings_set_margin_left_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_pdf_print_settings_set_margin_left, typeof(CfxApi.PdfPrintSettings.cfx_pdf_print_settings_set_margin_left_delegate));
            CfxApi.PdfPrintSettings.cfx_pdf_print_settings_get_margin_left = (CfxApi.PdfPrintSettings.cfx_pdf_print_settings_get_margin_left_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_pdf_print_settings_get_margin_left, typeof(CfxApi.PdfPrintSettings.cfx_pdf_print_settings_get_margin_left_delegate));
            CfxApi.PdfPrintSettings.cfx_pdf_print_settings_set_margin_type = (CfxApi.PdfPrintSettings.cfx_pdf_print_settings_set_margin_type_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_pdf_print_settings_set_margin_type, typeof(CfxApi.PdfPrintSettings.cfx_pdf_print_settings_set_margin_type_delegate));
            CfxApi.PdfPrintSettings.cfx_pdf_print_settings_get_margin_type = (CfxApi.PdfPrintSettings.cfx_pdf_print_settings_get_margin_type_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_pdf_print_settings_get_margin_type, typeof(CfxApi.PdfPrintSettings.cfx_pdf_print_settings_get_margin_type_delegate));
            CfxApi.PdfPrintSettings.cfx_pdf_print_settings_set_header_footer_enabled = (CfxApi.PdfPrintSettings.cfx_pdf_print_settings_set_header_footer_enabled_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_pdf_print_settings_set_header_footer_enabled, typeof(CfxApi.PdfPrintSettings.cfx_pdf_print_settings_set_header_footer_enabled_delegate));
            CfxApi.PdfPrintSettings.cfx_pdf_print_settings_get_header_footer_enabled = (CfxApi.PdfPrintSettings.cfx_pdf_print_settings_get_header_footer_enabled_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_pdf_print_settings_get_header_footer_enabled, typeof(CfxApi.PdfPrintSettings.cfx_pdf_print_settings_get_header_footer_enabled_delegate));
            CfxApi.PdfPrintSettings.cfx_pdf_print_settings_set_selection_only = (CfxApi.PdfPrintSettings.cfx_pdf_print_settings_set_selection_only_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_pdf_print_settings_set_selection_only, typeof(CfxApi.PdfPrintSettings.cfx_pdf_print_settings_set_selection_only_delegate));
            CfxApi.PdfPrintSettings.cfx_pdf_print_settings_get_selection_only = (CfxApi.PdfPrintSettings.cfx_pdf_print_settings_get_selection_only_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_pdf_print_settings_get_selection_only, typeof(CfxApi.PdfPrintSettings.cfx_pdf_print_settings_get_selection_only_delegate));
            CfxApi.PdfPrintSettings.cfx_pdf_print_settings_set_landscape = (CfxApi.PdfPrintSettings.cfx_pdf_print_settings_set_landscape_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_pdf_print_settings_set_landscape, typeof(CfxApi.PdfPrintSettings.cfx_pdf_print_settings_set_landscape_delegate));
            CfxApi.PdfPrintSettings.cfx_pdf_print_settings_get_landscape = (CfxApi.PdfPrintSettings.cfx_pdf_print_settings_get_landscape_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_pdf_print_settings_get_landscape, typeof(CfxApi.PdfPrintSettings.cfx_pdf_print_settings_get_landscape_delegate));
            CfxApi.PdfPrintSettings.cfx_pdf_print_settings_set_backgrounds_enabled = (CfxApi.PdfPrintSettings.cfx_pdf_print_settings_set_backgrounds_enabled_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_pdf_print_settings_set_backgrounds_enabled, typeof(CfxApi.PdfPrintSettings.cfx_pdf_print_settings_set_backgrounds_enabled_delegate));
            CfxApi.PdfPrintSettings.cfx_pdf_print_settings_get_backgrounds_enabled = (CfxApi.PdfPrintSettings.cfx_pdf_print_settings_get_backgrounds_enabled_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_pdf_print_settings_get_backgrounds_enabled, typeof(CfxApi.PdfPrintSettings.cfx_pdf_print_settings_get_backgrounds_enabled_delegate));
        }

        internal static void LoadCfxPointApi() {
            CfxApi.Probe();
            CfxApi.Point.cfx_point_ctor = (CfxApi.cfx_ctor_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_point_ctor, typeof(CfxApi.cfx_ctor_delegate));
            CfxApi.Point.cfx_point_dtor = (CfxApi.cfx_dtor_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_point_dtor, typeof(CfxApi.cfx_dtor_delegate));
            CfxApi.Point.cfx_point_set_x = (CfxApi.Point.cfx_point_set_x_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_point_set_x, typeof(CfxApi.Point.cfx_point_set_x_delegate));
            CfxApi.Point.cfx_point_get_x = (CfxApi.Point.cfx_point_get_x_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_point_get_x, typeof(CfxApi.Point.cfx_point_get_x_delegate));
            CfxApi.Point.cfx_point_set_y = (CfxApi.Point.cfx_point_set_y_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_point_set_y, typeof(CfxApi.Point.cfx_point_set_y_delegate));
            CfxApi.Point.cfx_point_get_y = (CfxApi.Point.cfx_point_get_y_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_point_get_y, typeof(CfxApi.Point.cfx_point_get_y_delegate));
        }

        internal static void LoadCfxPopupFeaturesApi() {
            CfxApi.Probe();
            CfxApi.PopupFeatures.cfx_popup_features_ctor = (CfxApi.cfx_ctor_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_popup_features_ctor, typeof(CfxApi.cfx_ctor_delegate));
            CfxApi.PopupFeatures.cfx_popup_features_dtor = (CfxApi.cfx_dtor_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_popup_features_dtor, typeof(CfxApi.cfx_dtor_delegate));
            CfxApi.PopupFeatures.cfx_popup_features_set_x = (CfxApi.PopupFeatures.cfx_popup_features_set_x_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_popup_features_set_x, typeof(CfxApi.PopupFeatures.cfx_popup_features_set_x_delegate));
            CfxApi.PopupFeatures.cfx_popup_features_get_x = (CfxApi.PopupFeatures.cfx_popup_features_get_x_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_popup_features_get_x, typeof(CfxApi.PopupFeatures.cfx_popup_features_get_x_delegate));
            CfxApi.PopupFeatures.cfx_popup_features_set_xSet = (CfxApi.PopupFeatures.cfx_popup_features_set_xSet_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_popup_features_set_xSet, typeof(CfxApi.PopupFeatures.cfx_popup_features_set_xSet_delegate));
            CfxApi.PopupFeatures.cfx_popup_features_get_xSet = (CfxApi.PopupFeatures.cfx_popup_features_get_xSet_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_popup_features_get_xSet, typeof(CfxApi.PopupFeatures.cfx_popup_features_get_xSet_delegate));
            CfxApi.PopupFeatures.cfx_popup_features_set_y = (CfxApi.PopupFeatures.cfx_popup_features_set_y_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_popup_features_set_y, typeof(CfxApi.PopupFeatures.cfx_popup_features_set_y_delegate));
            CfxApi.PopupFeatures.cfx_popup_features_get_y = (CfxApi.PopupFeatures.cfx_popup_features_get_y_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_popup_features_get_y, typeof(CfxApi.PopupFeatures.cfx_popup_features_get_y_delegate));
            CfxApi.PopupFeatures.cfx_popup_features_set_ySet = (CfxApi.PopupFeatures.cfx_popup_features_set_ySet_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_popup_features_set_ySet, typeof(CfxApi.PopupFeatures.cfx_popup_features_set_ySet_delegate));
            CfxApi.PopupFeatures.cfx_popup_features_get_ySet = (CfxApi.PopupFeatures.cfx_popup_features_get_ySet_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_popup_features_get_ySet, typeof(CfxApi.PopupFeatures.cfx_popup_features_get_ySet_delegate));
            CfxApi.PopupFeatures.cfx_popup_features_set_width = (CfxApi.PopupFeatures.cfx_popup_features_set_width_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_popup_features_set_width, typeof(CfxApi.PopupFeatures.cfx_popup_features_set_width_delegate));
            CfxApi.PopupFeatures.cfx_popup_features_get_width = (CfxApi.PopupFeatures.cfx_popup_features_get_width_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_popup_features_get_width, typeof(CfxApi.PopupFeatures.cfx_popup_features_get_width_delegate));
            CfxApi.PopupFeatures.cfx_popup_features_set_widthSet = (CfxApi.PopupFeatures.cfx_popup_features_set_widthSet_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_popup_features_set_widthSet, typeof(CfxApi.PopupFeatures.cfx_popup_features_set_widthSet_delegate));
            CfxApi.PopupFeatures.cfx_popup_features_get_widthSet = (CfxApi.PopupFeatures.cfx_popup_features_get_widthSet_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_popup_features_get_widthSet, typeof(CfxApi.PopupFeatures.cfx_popup_features_get_widthSet_delegate));
            CfxApi.PopupFeatures.cfx_popup_features_set_height = (CfxApi.PopupFeatures.cfx_popup_features_set_height_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_popup_features_set_height, typeof(CfxApi.PopupFeatures.cfx_popup_features_set_height_delegate));
            CfxApi.PopupFeatures.cfx_popup_features_get_height = (CfxApi.PopupFeatures.cfx_popup_features_get_height_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_popup_features_get_height, typeof(CfxApi.PopupFeatures.cfx_popup_features_get_height_delegate));
            CfxApi.PopupFeatures.cfx_popup_features_set_heightSet = (CfxApi.PopupFeatures.cfx_popup_features_set_heightSet_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_popup_features_set_heightSet, typeof(CfxApi.PopupFeatures.cfx_popup_features_set_heightSet_delegate));
            CfxApi.PopupFeatures.cfx_popup_features_get_heightSet = (CfxApi.PopupFeatures.cfx_popup_features_get_heightSet_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_popup_features_get_heightSet, typeof(CfxApi.PopupFeatures.cfx_popup_features_get_heightSet_delegate));
            CfxApi.PopupFeatures.cfx_popup_features_set_menuBarVisible = (CfxApi.PopupFeatures.cfx_popup_features_set_menuBarVisible_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_popup_features_set_menuBarVisible, typeof(CfxApi.PopupFeatures.cfx_popup_features_set_menuBarVisible_delegate));
            CfxApi.PopupFeatures.cfx_popup_features_get_menuBarVisible = (CfxApi.PopupFeatures.cfx_popup_features_get_menuBarVisible_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_popup_features_get_menuBarVisible, typeof(CfxApi.PopupFeatures.cfx_popup_features_get_menuBarVisible_delegate));
            CfxApi.PopupFeatures.cfx_popup_features_set_statusBarVisible = (CfxApi.PopupFeatures.cfx_popup_features_set_statusBarVisible_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_popup_features_set_statusBarVisible, typeof(CfxApi.PopupFeatures.cfx_popup_features_set_statusBarVisible_delegate));
            CfxApi.PopupFeatures.cfx_popup_features_get_statusBarVisible = (CfxApi.PopupFeatures.cfx_popup_features_get_statusBarVisible_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_popup_features_get_statusBarVisible, typeof(CfxApi.PopupFeatures.cfx_popup_features_get_statusBarVisible_delegate));
            CfxApi.PopupFeatures.cfx_popup_features_set_toolBarVisible = (CfxApi.PopupFeatures.cfx_popup_features_set_toolBarVisible_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_popup_features_set_toolBarVisible, typeof(CfxApi.PopupFeatures.cfx_popup_features_set_toolBarVisible_delegate));
            CfxApi.PopupFeatures.cfx_popup_features_get_toolBarVisible = (CfxApi.PopupFeatures.cfx_popup_features_get_toolBarVisible_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_popup_features_get_toolBarVisible, typeof(CfxApi.PopupFeatures.cfx_popup_features_get_toolBarVisible_delegate));
            CfxApi.PopupFeatures.cfx_popup_features_set_scrollbarsVisible = (CfxApi.PopupFeatures.cfx_popup_features_set_scrollbarsVisible_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_popup_features_set_scrollbarsVisible, typeof(CfxApi.PopupFeatures.cfx_popup_features_set_scrollbarsVisible_delegate));
            CfxApi.PopupFeatures.cfx_popup_features_get_scrollbarsVisible = (CfxApi.PopupFeatures.cfx_popup_features_get_scrollbarsVisible_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_popup_features_get_scrollbarsVisible, typeof(CfxApi.PopupFeatures.cfx_popup_features_get_scrollbarsVisible_delegate));
        }

        internal static void LoadCfxPostDataApi() {
            CfxApi.Probe();
            CfxApi.PostData.cfx_post_data_create = (CfxApi.PostData.cfx_post_data_create_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_post_data_create, typeof(CfxApi.PostData.cfx_post_data_create_delegate));
            CfxApi.PostData.cfx_post_data_is_read_only = (CfxApi.PostData.cfx_post_data_is_read_only_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_post_data_is_read_only, typeof(CfxApi.PostData.cfx_post_data_is_read_only_delegate));
            CfxApi.PostData.cfx_post_data_has_excluded_elements = (CfxApi.PostData.cfx_post_data_has_excluded_elements_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_post_data_has_excluded_elements, typeof(CfxApi.PostData.cfx_post_data_has_excluded_elements_delegate));
            CfxApi.PostData.cfx_post_data_get_element_count = (CfxApi.PostData.cfx_post_data_get_element_count_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_post_data_get_element_count, typeof(CfxApi.PostData.cfx_post_data_get_element_count_delegate));
            CfxApi.PostData.cfx_post_data_get_elements = (CfxApi.PostData.cfx_post_data_get_elements_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_post_data_get_elements, typeof(CfxApi.PostData.cfx_post_data_get_elements_delegate));
            CfxApi.PostData.cfx_post_data_remove_element = (CfxApi.PostData.cfx_post_data_remove_element_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_post_data_remove_element, typeof(CfxApi.PostData.cfx_post_data_remove_element_delegate));
            CfxApi.PostData.cfx_post_data_add_element = (CfxApi.PostData.cfx_post_data_add_element_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_post_data_add_element, typeof(CfxApi.PostData.cfx_post_data_add_element_delegate));
            CfxApi.PostData.cfx_post_data_remove_elements = (CfxApi.PostData.cfx_post_data_remove_elements_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_post_data_remove_elements, typeof(CfxApi.PostData.cfx_post_data_remove_elements_delegate));
        }

        internal static void LoadCfxPostDataElementApi() {
            CfxApi.Probe();
            CfxApi.PostDataElement.cfx_post_data_element_create = (CfxApi.PostDataElement.cfx_post_data_element_create_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_post_data_element_create, typeof(CfxApi.PostDataElement.cfx_post_data_element_create_delegate));
            CfxApi.PostDataElement.cfx_post_data_element_is_read_only = (CfxApi.PostDataElement.cfx_post_data_element_is_read_only_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_post_data_element_is_read_only, typeof(CfxApi.PostDataElement.cfx_post_data_element_is_read_only_delegate));
            CfxApi.PostDataElement.cfx_post_data_element_set_to_empty = (CfxApi.PostDataElement.cfx_post_data_element_set_to_empty_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_post_data_element_set_to_empty, typeof(CfxApi.PostDataElement.cfx_post_data_element_set_to_empty_delegate));
            CfxApi.PostDataElement.cfx_post_data_element_set_to_file = (CfxApi.PostDataElement.cfx_post_data_element_set_to_file_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_post_data_element_set_to_file, typeof(CfxApi.PostDataElement.cfx_post_data_element_set_to_file_delegate));
            CfxApi.PostDataElement.cfx_post_data_element_set_to_bytes = (CfxApi.PostDataElement.cfx_post_data_element_set_to_bytes_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_post_data_element_set_to_bytes, typeof(CfxApi.PostDataElement.cfx_post_data_element_set_to_bytes_delegate));
            CfxApi.PostDataElement.cfx_post_data_element_get_type = (CfxApi.PostDataElement.cfx_post_data_element_get_type_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_post_data_element_get_type, typeof(CfxApi.PostDataElement.cfx_post_data_element_get_type_delegate));
            CfxApi.PostDataElement.cfx_post_data_element_get_file = (CfxApi.PostDataElement.cfx_post_data_element_get_file_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_post_data_element_get_file, typeof(CfxApi.PostDataElement.cfx_post_data_element_get_file_delegate));
            CfxApi.PostDataElement.cfx_post_data_element_get_bytes_count = (CfxApi.PostDataElement.cfx_post_data_element_get_bytes_count_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_post_data_element_get_bytes_count, typeof(CfxApi.PostDataElement.cfx_post_data_element_get_bytes_count_delegate));
            CfxApi.PostDataElement.cfx_post_data_element_get_bytes = (CfxApi.PostDataElement.cfx_post_data_element_get_bytes_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_post_data_element_get_bytes, typeof(CfxApi.PostDataElement.cfx_post_data_element_get_bytes_delegate));
        }

        internal static void LoadCfxPrintDialogCallbackApi() {
            CfxApi.Probe();
            CfxApi.PrintDialogCallback.cfx_print_dialog_callback_cont = (CfxApi.PrintDialogCallback.cfx_print_dialog_callback_cont_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_print_dialog_callback_cont, typeof(CfxApi.PrintDialogCallback.cfx_print_dialog_callback_cont_delegate));
            CfxApi.PrintDialogCallback.cfx_print_dialog_callback_cancel = (CfxApi.PrintDialogCallback.cfx_print_dialog_callback_cancel_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_print_dialog_callback_cancel, typeof(CfxApi.PrintDialogCallback.cfx_print_dialog_callback_cancel_delegate));
        }

        internal static void LoadCfxPrintHandlerApi() {
            CfxApi.Probe();
            CfxApi.PrintHandler.cfx_print_handler_ctor = (CfxApi.cfx_ctor_with_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_print_handler_ctor, typeof(CfxApi.cfx_ctor_with_gc_handle_delegate));
            CfxApi.PrintHandler.cfx_print_handler_set_callback = (CfxApi.cfx_set_callback_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_print_handler_set_callback, typeof(CfxApi.cfx_set_callback_delegate));
            CfxPrintHandler.SetNativeCallbacks();
        }

        internal static void LoadCfxPrintJobCallbackApi() {
            CfxApi.Probe();
            CfxApi.PrintJobCallback.cfx_print_job_callback_cont = (CfxApi.PrintJobCallback.cfx_print_job_callback_cont_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_print_job_callback_cont, typeof(CfxApi.PrintJobCallback.cfx_print_job_callback_cont_delegate));
        }

        internal static void LoadCfxPrintSettingsApi() {
            CfxApi.Probe();
            CfxApi.PrintSettings.cfx_print_settings_create = (CfxApi.PrintSettings.cfx_print_settings_create_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_print_settings_create, typeof(CfxApi.PrintSettings.cfx_print_settings_create_delegate));
            CfxApi.PrintSettings.cfx_print_settings_is_valid = (CfxApi.PrintSettings.cfx_print_settings_is_valid_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_print_settings_is_valid, typeof(CfxApi.PrintSettings.cfx_print_settings_is_valid_delegate));
            CfxApi.PrintSettings.cfx_print_settings_is_read_only = (CfxApi.PrintSettings.cfx_print_settings_is_read_only_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_print_settings_is_read_only, typeof(CfxApi.PrintSettings.cfx_print_settings_is_read_only_delegate));
            CfxApi.PrintSettings.cfx_print_settings_copy = (CfxApi.PrintSettings.cfx_print_settings_copy_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_print_settings_copy, typeof(CfxApi.PrintSettings.cfx_print_settings_copy_delegate));
            CfxApi.PrintSettings.cfx_print_settings_set_orientation = (CfxApi.PrintSettings.cfx_print_settings_set_orientation_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_print_settings_set_orientation, typeof(CfxApi.PrintSettings.cfx_print_settings_set_orientation_delegate));
            CfxApi.PrintSettings.cfx_print_settings_is_landscape = (CfxApi.PrintSettings.cfx_print_settings_is_landscape_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_print_settings_is_landscape, typeof(CfxApi.PrintSettings.cfx_print_settings_is_landscape_delegate));
            CfxApi.PrintSettings.cfx_print_settings_set_printer_printable_area = (CfxApi.PrintSettings.cfx_print_settings_set_printer_printable_area_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_print_settings_set_printer_printable_area, typeof(CfxApi.PrintSettings.cfx_print_settings_set_printer_printable_area_delegate));
            CfxApi.PrintSettings.cfx_print_settings_set_device_name = (CfxApi.PrintSettings.cfx_print_settings_set_device_name_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_print_settings_set_device_name, typeof(CfxApi.PrintSettings.cfx_print_settings_set_device_name_delegate));
            CfxApi.PrintSettings.cfx_print_settings_get_device_name = (CfxApi.PrintSettings.cfx_print_settings_get_device_name_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_print_settings_get_device_name, typeof(CfxApi.PrintSettings.cfx_print_settings_get_device_name_delegate));
            CfxApi.PrintSettings.cfx_print_settings_set_dpi = (CfxApi.PrintSettings.cfx_print_settings_set_dpi_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_print_settings_set_dpi, typeof(CfxApi.PrintSettings.cfx_print_settings_set_dpi_delegate));
            CfxApi.PrintSettings.cfx_print_settings_get_dpi = (CfxApi.PrintSettings.cfx_print_settings_get_dpi_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_print_settings_get_dpi, typeof(CfxApi.PrintSettings.cfx_print_settings_get_dpi_delegate));
            CfxApi.PrintSettings.cfx_print_settings_set_page_ranges = (CfxApi.PrintSettings.cfx_print_settings_set_page_ranges_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_print_settings_set_page_ranges, typeof(CfxApi.PrintSettings.cfx_print_settings_set_page_ranges_delegate));
            CfxApi.PrintSettings.cfx_print_settings_get_page_ranges_count = (CfxApi.PrintSettings.cfx_print_settings_get_page_ranges_count_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_print_settings_get_page_ranges_count, typeof(CfxApi.PrintSettings.cfx_print_settings_get_page_ranges_count_delegate));
            CfxApi.PrintSettings.cfx_print_settings_get_page_ranges = (CfxApi.PrintSettings.cfx_print_settings_get_page_ranges_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_print_settings_get_page_ranges, typeof(CfxApi.PrintSettings.cfx_print_settings_get_page_ranges_delegate));
            CfxApi.PrintSettings.cfx_print_settings_set_selection_only = (CfxApi.PrintSettings.cfx_print_settings_set_selection_only_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_print_settings_set_selection_only, typeof(CfxApi.PrintSettings.cfx_print_settings_set_selection_only_delegate));
            CfxApi.PrintSettings.cfx_print_settings_is_selection_only = (CfxApi.PrintSettings.cfx_print_settings_is_selection_only_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_print_settings_is_selection_only, typeof(CfxApi.PrintSettings.cfx_print_settings_is_selection_only_delegate));
            CfxApi.PrintSettings.cfx_print_settings_set_collate = (CfxApi.PrintSettings.cfx_print_settings_set_collate_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_print_settings_set_collate, typeof(CfxApi.PrintSettings.cfx_print_settings_set_collate_delegate));
            CfxApi.PrintSettings.cfx_print_settings_will_collate = (CfxApi.PrintSettings.cfx_print_settings_will_collate_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_print_settings_will_collate, typeof(CfxApi.PrintSettings.cfx_print_settings_will_collate_delegate));
            CfxApi.PrintSettings.cfx_print_settings_set_color_model = (CfxApi.PrintSettings.cfx_print_settings_set_color_model_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_print_settings_set_color_model, typeof(CfxApi.PrintSettings.cfx_print_settings_set_color_model_delegate));
            CfxApi.PrintSettings.cfx_print_settings_get_color_model = (CfxApi.PrintSettings.cfx_print_settings_get_color_model_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_print_settings_get_color_model, typeof(CfxApi.PrintSettings.cfx_print_settings_get_color_model_delegate));
            CfxApi.PrintSettings.cfx_print_settings_set_copies = (CfxApi.PrintSettings.cfx_print_settings_set_copies_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_print_settings_set_copies, typeof(CfxApi.PrintSettings.cfx_print_settings_set_copies_delegate));
            CfxApi.PrintSettings.cfx_print_settings_get_copies = (CfxApi.PrintSettings.cfx_print_settings_get_copies_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_print_settings_get_copies, typeof(CfxApi.PrintSettings.cfx_print_settings_get_copies_delegate));
            CfxApi.PrintSettings.cfx_print_settings_set_duplex_mode = (CfxApi.PrintSettings.cfx_print_settings_set_duplex_mode_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_print_settings_set_duplex_mode, typeof(CfxApi.PrintSettings.cfx_print_settings_set_duplex_mode_delegate));
            CfxApi.PrintSettings.cfx_print_settings_get_duplex_mode = (CfxApi.PrintSettings.cfx_print_settings_get_duplex_mode_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_print_settings_get_duplex_mode, typeof(CfxApi.PrintSettings.cfx_print_settings_get_duplex_mode_delegate));
        }

        internal static void LoadCfxProcessMessageApi() {
            CfxApi.Probe();
            CfxApi.ProcessMessage.cfx_process_message_create = (CfxApi.ProcessMessage.cfx_process_message_create_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_process_message_create, typeof(CfxApi.ProcessMessage.cfx_process_message_create_delegate));
            CfxApi.ProcessMessage.cfx_process_message_is_valid = (CfxApi.ProcessMessage.cfx_process_message_is_valid_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_process_message_is_valid, typeof(CfxApi.ProcessMessage.cfx_process_message_is_valid_delegate));
            CfxApi.ProcessMessage.cfx_process_message_is_read_only = (CfxApi.ProcessMessage.cfx_process_message_is_read_only_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_process_message_is_read_only, typeof(CfxApi.ProcessMessage.cfx_process_message_is_read_only_delegate));
            CfxApi.ProcessMessage.cfx_process_message_copy = (CfxApi.ProcessMessage.cfx_process_message_copy_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_process_message_copy, typeof(CfxApi.ProcessMessage.cfx_process_message_copy_delegate));
            CfxApi.ProcessMessage.cfx_process_message_get_name = (CfxApi.ProcessMessage.cfx_process_message_get_name_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_process_message_get_name, typeof(CfxApi.ProcessMessage.cfx_process_message_get_name_delegate));
            CfxApi.ProcessMessage.cfx_process_message_get_argument_list = (CfxApi.ProcessMessage.cfx_process_message_get_argument_list_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_process_message_get_argument_list, typeof(CfxApi.ProcessMessage.cfx_process_message_get_argument_list_delegate));
        }

        internal static void LoadCfxRangeApi() {
            CfxApi.Probe();
            CfxApi.Range.cfx_range_ctor = (CfxApi.cfx_ctor_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_range_ctor, typeof(CfxApi.cfx_ctor_delegate));
            CfxApi.Range.cfx_range_dtor = (CfxApi.cfx_dtor_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_range_dtor, typeof(CfxApi.cfx_dtor_delegate));
            CfxApi.Range.cfx_range_set_from = (CfxApi.Range.cfx_range_set_from_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_range_set_from, typeof(CfxApi.Range.cfx_range_set_from_delegate));
            CfxApi.Range.cfx_range_get_from = (CfxApi.Range.cfx_range_get_from_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_range_get_from, typeof(CfxApi.Range.cfx_range_get_from_delegate));
            CfxApi.Range.cfx_range_set_to = (CfxApi.Range.cfx_range_set_to_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_range_set_to, typeof(CfxApi.Range.cfx_range_set_to_delegate));
            CfxApi.Range.cfx_range_get_to = (CfxApi.Range.cfx_range_get_to_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_range_get_to, typeof(CfxApi.Range.cfx_range_get_to_delegate));
        }

        internal static void LoadCfxReadHandlerApi() {
            CfxApi.Probe();
            CfxApi.ReadHandler.cfx_read_handler_ctor = (CfxApi.cfx_ctor_with_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_read_handler_ctor, typeof(CfxApi.cfx_ctor_with_gc_handle_delegate));
            CfxApi.ReadHandler.cfx_read_handler_set_callback = (CfxApi.cfx_set_callback_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_read_handler_set_callback, typeof(CfxApi.cfx_set_callback_delegate));
            CfxReadHandler.SetNativeCallbacks();
        }

        internal static void LoadCfxRectApi() {
            CfxApi.Probe();
            CfxApi.Rect.cfx_rect_ctor = (CfxApi.cfx_ctor_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_rect_ctor, typeof(CfxApi.cfx_ctor_delegate));
            CfxApi.Rect.cfx_rect_dtor = (CfxApi.cfx_dtor_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_rect_dtor, typeof(CfxApi.cfx_dtor_delegate));
            CfxApi.Rect.cfx_rect_set_x = (CfxApi.Rect.cfx_rect_set_x_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_rect_set_x, typeof(CfxApi.Rect.cfx_rect_set_x_delegate));
            CfxApi.Rect.cfx_rect_get_x = (CfxApi.Rect.cfx_rect_get_x_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_rect_get_x, typeof(CfxApi.Rect.cfx_rect_get_x_delegate));
            CfxApi.Rect.cfx_rect_set_y = (CfxApi.Rect.cfx_rect_set_y_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_rect_set_y, typeof(CfxApi.Rect.cfx_rect_set_y_delegate));
            CfxApi.Rect.cfx_rect_get_y = (CfxApi.Rect.cfx_rect_get_y_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_rect_get_y, typeof(CfxApi.Rect.cfx_rect_get_y_delegate));
            CfxApi.Rect.cfx_rect_set_width = (CfxApi.Rect.cfx_rect_set_width_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_rect_set_width, typeof(CfxApi.Rect.cfx_rect_set_width_delegate));
            CfxApi.Rect.cfx_rect_get_width = (CfxApi.Rect.cfx_rect_get_width_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_rect_get_width, typeof(CfxApi.Rect.cfx_rect_get_width_delegate));
            CfxApi.Rect.cfx_rect_set_height = (CfxApi.Rect.cfx_rect_set_height_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_rect_set_height, typeof(CfxApi.Rect.cfx_rect_set_height_delegate));
            CfxApi.Rect.cfx_rect_get_height = (CfxApi.Rect.cfx_rect_get_height_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_rect_get_height, typeof(CfxApi.Rect.cfx_rect_get_height_delegate));
        }

        internal static void LoadCfxRegisterCdmCallbackApi() {
            CfxApi.Probe();
            CfxApi.RegisterCdmCallback.cfx_register_cdm_callback_ctor = (CfxApi.cfx_ctor_with_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_register_cdm_callback_ctor, typeof(CfxApi.cfx_ctor_with_gc_handle_delegate));
            CfxApi.RegisterCdmCallback.cfx_register_cdm_callback_set_callback = (CfxApi.cfx_set_callback_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_register_cdm_callback_set_callback, typeof(CfxApi.cfx_set_callback_delegate));
            CfxRegisterCdmCallback.SetNativeCallbacks();
        }

        internal static void LoadCfxRenderHandlerApi() {
            CfxApi.Probe();
            CfxApi.RenderHandler.cfx_render_handler_ctor = (CfxApi.cfx_ctor_with_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_render_handler_ctor, typeof(CfxApi.cfx_ctor_with_gc_handle_delegate));
            CfxApi.RenderHandler.cfx_render_handler_set_callback = (CfxApi.cfx_set_callback_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_render_handler_set_callback, typeof(CfxApi.cfx_set_callback_delegate));
            CfxRenderHandler.SetNativeCallbacks();
        }

        internal static void LoadCfxRenderProcessHandlerApi() {
            CfxApi.Probe();
            CfxApi.RenderProcessHandler.cfx_render_process_handler_ctor = (CfxApi.cfx_ctor_with_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_render_process_handler_ctor, typeof(CfxApi.cfx_ctor_with_gc_handle_delegate));
            CfxApi.RenderProcessHandler.cfx_render_process_handler_set_callback = (CfxApi.cfx_set_callback_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_render_process_handler_set_callback, typeof(CfxApi.cfx_set_callback_delegate));
            CfxRenderProcessHandler.SetNativeCallbacks();
        }

        internal static void LoadCfxRequestApi() {
            CfxApi.Probe();
            CfxApi.Request.cfx_request_create = (CfxApi.Request.cfx_request_create_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_create, typeof(CfxApi.Request.cfx_request_create_delegate));
            CfxApi.Request.cfx_request_is_read_only = (CfxApi.Request.cfx_request_is_read_only_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_is_read_only, typeof(CfxApi.Request.cfx_request_is_read_only_delegate));
            CfxApi.Request.cfx_request_get_url = (CfxApi.Request.cfx_request_get_url_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_get_url, typeof(CfxApi.Request.cfx_request_get_url_delegate));
            CfxApi.Request.cfx_request_set_url = (CfxApi.Request.cfx_request_set_url_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_set_url, typeof(CfxApi.Request.cfx_request_set_url_delegate));
            CfxApi.Request.cfx_request_get_method = (CfxApi.Request.cfx_request_get_method_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_get_method, typeof(CfxApi.Request.cfx_request_get_method_delegate));
            CfxApi.Request.cfx_request_set_method = (CfxApi.Request.cfx_request_set_method_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_set_method, typeof(CfxApi.Request.cfx_request_set_method_delegate));
            CfxApi.Request.cfx_request_set_referrer = (CfxApi.Request.cfx_request_set_referrer_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_set_referrer, typeof(CfxApi.Request.cfx_request_set_referrer_delegate));
            CfxApi.Request.cfx_request_get_referrer_url = (CfxApi.Request.cfx_request_get_referrer_url_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_get_referrer_url, typeof(CfxApi.Request.cfx_request_get_referrer_url_delegate));
            CfxApi.Request.cfx_request_get_referrer_policy = (CfxApi.Request.cfx_request_get_referrer_policy_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_get_referrer_policy, typeof(CfxApi.Request.cfx_request_get_referrer_policy_delegate));
            CfxApi.Request.cfx_request_get_post_data = (CfxApi.Request.cfx_request_get_post_data_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_get_post_data, typeof(CfxApi.Request.cfx_request_get_post_data_delegate));
            CfxApi.Request.cfx_request_set_post_data = (CfxApi.Request.cfx_request_set_post_data_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_set_post_data, typeof(CfxApi.Request.cfx_request_set_post_data_delegate));
            CfxApi.Request.cfx_request_get_header_map = (CfxApi.Request.cfx_request_get_header_map_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_get_header_map, typeof(CfxApi.Request.cfx_request_get_header_map_delegate));
            CfxApi.Request.cfx_request_set_header_map = (CfxApi.Request.cfx_request_set_header_map_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_set_header_map, typeof(CfxApi.Request.cfx_request_set_header_map_delegate));
            CfxApi.Request.cfx_request_get_header_by_name = (CfxApi.Request.cfx_request_get_header_by_name_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_get_header_by_name, typeof(CfxApi.Request.cfx_request_get_header_by_name_delegate));
            CfxApi.Request.cfx_request_set_header_by_name = (CfxApi.Request.cfx_request_set_header_by_name_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_set_header_by_name, typeof(CfxApi.Request.cfx_request_set_header_by_name_delegate));
            CfxApi.Request.cfx_request_set = (CfxApi.Request.cfx_request_set_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_set, typeof(CfxApi.Request.cfx_request_set_delegate));
            CfxApi.Request.cfx_request_get_flags = (CfxApi.Request.cfx_request_get_flags_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_get_flags, typeof(CfxApi.Request.cfx_request_get_flags_delegate));
            CfxApi.Request.cfx_request_set_flags = (CfxApi.Request.cfx_request_set_flags_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_set_flags, typeof(CfxApi.Request.cfx_request_set_flags_delegate));
            CfxApi.Request.cfx_request_get_first_party_for_cookies = (CfxApi.Request.cfx_request_get_first_party_for_cookies_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_get_first_party_for_cookies, typeof(CfxApi.Request.cfx_request_get_first_party_for_cookies_delegate));
            CfxApi.Request.cfx_request_set_first_party_for_cookies = (CfxApi.Request.cfx_request_set_first_party_for_cookies_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_set_first_party_for_cookies, typeof(CfxApi.Request.cfx_request_set_first_party_for_cookies_delegate));
            CfxApi.Request.cfx_request_get_resource_type = (CfxApi.Request.cfx_request_get_resource_type_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_get_resource_type, typeof(CfxApi.Request.cfx_request_get_resource_type_delegate));
            CfxApi.Request.cfx_request_get_transition_type = (CfxApi.Request.cfx_request_get_transition_type_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_get_transition_type, typeof(CfxApi.Request.cfx_request_get_transition_type_delegate));
            CfxApi.Request.cfx_request_get_identifier = (CfxApi.Request.cfx_request_get_identifier_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_get_identifier, typeof(CfxApi.Request.cfx_request_get_identifier_delegate));
        }

        internal static void LoadCfxRequestCallbackApi() {
            CfxApi.Probe();
            CfxApi.RequestCallback.cfx_request_callback_cont = (CfxApi.RequestCallback.cfx_request_callback_cont_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_callback_cont, typeof(CfxApi.RequestCallback.cfx_request_callback_cont_delegate));
            CfxApi.RequestCallback.cfx_request_callback_cancel = (CfxApi.RequestCallback.cfx_request_callback_cancel_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_callback_cancel, typeof(CfxApi.RequestCallback.cfx_request_callback_cancel_delegate));
        }

        internal static void LoadCfxRequestContextApi() {
            CfxApi.Probe();
            CfxApi.RequestContext.cfx_request_context_get_global_context = (CfxApi.RequestContext.cfx_request_context_get_global_context_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_context_get_global_context, typeof(CfxApi.RequestContext.cfx_request_context_get_global_context_delegate));
            CfxApi.RequestContext.cfx_request_context_create_context = (CfxApi.RequestContext.cfx_request_context_create_context_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_context_create_context, typeof(CfxApi.RequestContext.cfx_request_context_create_context_delegate));
            CfxApi.RequestContext.cfx_request_context_is_same = (CfxApi.RequestContext.cfx_request_context_is_same_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_context_is_same, typeof(CfxApi.RequestContext.cfx_request_context_is_same_delegate));
            CfxApi.RequestContext.cfx_request_context_is_sharing_with = (CfxApi.RequestContext.cfx_request_context_is_sharing_with_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_context_is_sharing_with, typeof(CfxApi.RequestContext.cfx_request_context_is_sharing_with_delegate));
            CfxApi.RequestContext.cfx_request_context_is_global = (CfxApi.RequestContext.cfx_request_context_is_global_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_context_is_global, typeof(CfxApi.RequestContext.cfx_request_context_is_global_delegate));
            CfxApi.RequestContext.cfx_request_context_get_handler = (CfxApi.RequestContext.cfx_request_context_get_handler_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_context_get_handler, typeof(CfxApi.RequestContext.cfx_request_context_get_handler_delegate));
            CfxApi.RequestContext.cfx_request_context_get_cache_path = (CfxApi.RequestContext.cfx_request_context_get_cache_path_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_context_get_cache_path, typeof(CfxApi.RequestContext.cfx_request_context_get_cache_path_delegate));
            CfxApi.RequestContext.cfx_request_context_get_cookie_manager = (CfxApi.RequestContext.cfx_request_context_get_cookie_manager_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_context_get_cookie_manager, typeof(CfxApi.RequestContext.cfx_request_context_get_cookie_manager_delegate));
            CfxApi.RequestContext.cfx_request_context_register_scheme_handler_factory = (CfxApi.RequestContext.cfx_request_context_register_scheme_handler_factory_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_context_register_scheme_handler_factory, typeof(CfxApi.RequestContext.cfx_request_context_register_scheme_handler_factory_delegate));
            CfxApi.RequestContext.cfx_request_context_clear_scheme_handler_factories = (CfxApi.RequestContext.cfx_request_context_clear_scheme_handler_factories_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_context_clear_scheme_handler_factories, typeof(CfxApi.RequestContext.cfx_request_context_clear_scheme_handler_factories_delegate));
            CfxApi.RequestContext.cfx_request_context_purge_plugin_list_cache = (CfxApi.RequestContext.cfx_request_context_purge_plugin_list_cache_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_context_purge_plugin_list_cache, typeof(CfxApi.RequestContext.cfx_request_context_purge_plugin_list_cache_delegate));
            CfxApi.RequestContext.cfx_request_context_has_preference = (CfxApi.RequestContext.cfx_request_context_has_preference_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_context_has_preference, typeof(CfxApi.RequestContext.cfx_request_context_has_preference_delegate));
            CfxApi.RequestContext.cfx_request_context_get_preference = (CfxApi.RequestContext.cfx_request_context_get_preference_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_context_get_preference, typeof(CfxApi.RequestContext.cfx_request_context_get_preference_delegate));
            CfxApi.RequestContext.cfx_request_context_get_all_preferences = (CfxApi.RequestContext.cfx_request_context_get_all_preferences_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_context_get_all_preferences, typeof(CfxApi.RequestContext.cfx_request_context_get_all_preferences_delegate));
            CfxApi.RequestContext.cfx_request_context_can_set_preference = (CfxApi.RequestContext.cfx_request_context_can_set_preference_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_context_can_set_preference, typeof(CfxApi.RequestContext.cfx_request_context_can_set_preference_delegate));
            CfxApi.RequestContext.cfx_request_context_set_preference = (CfxApi.RequestContext.cfx_request_context_set_preference_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_context_set_preference, typeof(CfxApi.RequestContext.cfx_request_context_set_preference_delegate));
            CfxApi.RequestContext.cfx_request_context_clear_certificate_exceptions = (CfxApi.RequestContext.cfx_request_context_clear_certificate_exceptions_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_context_clear_certificate_exceptions, typeof(CfxApi.RequestContext.cfx_request_context_clear_certificate_exceptions_delegate));
            CfxApi.RequestContext.cfx_request_context_clear_http_auth_credentials = (CfxApi.RequestContext.cfx_request_context_clear_http_auth_credentials_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_context_clear_http_auth_credentials, typeof(CfxApi.RequestContext.cfx_request_context_clear_http_auth_credentials_delegate));
            CfxApi.RequestContext.cfx_request_context_close_all_connections = (CfxApi.RequestContext.cfx_request_context_close_all_connections_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_context_close_all_connections, typeof(CfxApi.RequestContext.cfx_request_context_close_all_connections_delegate));
            CfxApi.RequestContext.cfx_request_context_resolve_host = (CfxApi.RequestContext.cfx_request_context_resolve_host_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_context_resolve_host, typeof(CfxApi.RequestContext.cfx_request_context_resolve_host_delegate));
            CfxApi.RequestContext.cfx_request_context_load_extension = (CfxApi.RequestContext.cfx_request_context_load_extension_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_context_load_extension, typeof(CfxApi.RequestContext.cfx_request_context_load_extension_delegate));
            CfxApi.RequestContext.cfx_request_context_did_load_extension = (CfxApi.RequestContext.cfx_request_context_did_load_extension_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_context_did_load_extension, typeof(CfxApi.RequestContext.cfx_request_context_did_load_extension_delegate));
            CfxApi.RequestContext.cfx_request_context_has_extension = (CfxApi.RequestContext.cfx_request_context_has_extension_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_context_has_extension, typeof(CfxApi.RequestContext.cfx_request_context_has_extension_delegate));
            CfxApi.RequestContext.cfx_request_context_get_extensions = (CfxApi.RequestContext.cfx_request_context_get_extensions_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_context_get_extensions, typeof(CfxApi.RequestContext.cfx_request_context_get_extensions_delegate));
            CfxApi.RequestContext.cfx_request_context_get_extension = (CfxApi.RequestContext.cfx_request_context_get_extension_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_context_get_extension, typeof(CfxApi.RequestContext.cfx_request_context_get_extension_delegate));
        }

        internal static void LoadCfxRequestContextHandlerApi() {
            CfxApi.Probe();
            CfxApi.RequestContextHandler.cfx_request_context_handler_ctor = (CfxApi.cfx_ctor_with_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_context_handler_ctor, typeof(CfxApi.cfx_ctor_with_gc_handle_delegate));
            CfxApi.RequestContextHandler.cfx_request_context_handler_get_gc_handle = (CfxApi.cfx_get_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_context_handler_get_gc_handle, typeof(CfxApi.cfx_get_gc_handle_delegate));
            CfxApi.RequestContextHandler.cfx_request_context_handler_set_callback = (CfxApi.cfx_set_callback_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_context_handler_set_callback, typeof(CfxApi.cfx_set_callback_delegate));
            CfxRequestContextHandler.SetNativeCallbacks();
        }

        internal static void LoadCfxRequestContextSettingsApi() {
            CfxApi.Probe();
            CfxApi.RequestContextSettings.cfx_request_context_settings_ctor = (CfxApi.cfx_ctor_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_context_settings_ctor, typeof(CfxApi.cfx_ctor_delegate));
            CfxApi.RequestContextSettings.cfx_request_context_settings_dtor = (CfxApi.cfx_dtor_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_context_settings_dtor, typeof(CfxApi.cfx_dtor_delegate));
            CfxApi.RequestContextSettings.cfx_request_context_settings_set_cache_path = (CfxApi.RequestContextSettings.cfx_request_context_settings_set_cache_path_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_context_settings_set_cache_path, typeof(CfxApi.RequestContextSettings.cfx_request_context_settings_set_cache_path_delegate));
            CfxApi.RequestContextSettings.cfx_request_context_settings_get_cache_path = (CfxApi.RequestContextSettings.cfx_request_context_settings_get_cache_path_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_context_settings_get_cache_path, typeof(CfxApi.RequestContextSettings.cfx_request_context_settings_get_cache_path_delegate));
            CfxApi.RequestContextSettings.cfx_request_context_settings_set_persist_session_cookies = (CfxApi.RequestContextSettings.cfx_request_context_settings_set_persist_session_cookies_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_context_settings_set_persist_session_cookies, typeof(CfxApi.RequestContextSettings.cfx_request_context_settings_set_persist_session_cookies_delegate));
            CfxApi.RequestContextSettings.cfx_request_context_settings_get_persist_session_cookies = (CfxApi.RequestContextSettings.cfx_request_context_settings_get_persist_session_cookies_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_context_settings_get_persist_session_cookies, typeof(CfxApi.RequestContextSettings.cfx_request_context_settings_get_persist_session_cookies_delegate));
            CfxApi.RequestContextSettings.cfx_request_context_settings_set_persist_user_preferences = (CfxApi.RequestContextSettings.cfx_request_context_settings_set_persist_user_preferences_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_context_settings_set_persist_user_preferences, typeof(CfxApi.RequestContextSettings.cfx_request_context_settings_set_persist_user_preferences_delegate));
            CfxApi.RequestContextSettings.cfx_request_context_settings_get_persist_user_preferences = (CfxApi.RequestContextSettings.cfx_request_context_settings_get_persist_user_preferences_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_context_settings_get_persist_user_preferences, typeof(CfxApi.RequestContextSettings.cfx_request_context_settings_get_persist_user_preferences_delegate));
            CfxApi.RequestContextSettings.cfx_request_context_settings_set_ignore_certificate_errors = (CfxApi.RequestContextSettings.cfx_request_context_settings_set_ignore_certificate_errors_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_context_settings_set_ignore_certificate_errors, typeof(CfxApi.RequestContextSettings.cfx_request_context_settings_set_ignore_certificate_errors_delegate));
            CfxApi.RequestContextSettings.cfx_request_context_settings_get_ignore_certificate_errors = (CfxApi.RequestContextSettings.cfx_request_context_settings_get_ignore_certificate_errors_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_context_settings_get_ignore_certificate_errors, typeof(CfxApi.RequestContextSettings.cfx_request_context_settings_get_ignore_certificate_errors_delegate));
            CfxApi.RequestContextSettings.cfx_request_context_settings_set_enable_net_security_expiration = (CfxApi.RequestContextSettings.cfx_request_context_settings_set_enable_net_security_expiration_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_context_settings_set_enable_net_security_expiration, typeof(CfxApi.RequestContextSettings.cfx_request_context_settings_set_enable_net_security_expiration_delegate));
            CfxApi.RequestContextSettings.cfx_request_context_settings_get_enable_net_security_expiration = (CfxApi.RequestContextSettings.cfx_request_context_settings_get_enable_net_security_expiration_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_context_settings_get_enable_net_security_expiration, typeof(CfxApi.RequestContextSettings.cfx_request_context_settings_get_enable_net_security_expiration_delegate));
            CfxApi.RequestContextSettings.cfx_request_context_settings_set_accept_language_list = (CfxApi.RequestContextSettings.cfx_request_context_settings_set_accept_language_list_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_context_settings_set_accept_language_list, typeof(CfxApi.RequestContextSettings.cfx_request_context_settings_set_accept_language_list_delegate));
            CfxApi.RequestContextSettings.cfx_request_context_settings_get_accept_language_list = (CfxApi.RequestContextSettings.cfx_request_context_settings_get_accept_language_list_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_context_settings_get_accept_language_list, typeof(CfxApi.RequestContextSettings.cfx_request_context_settings_get_accept_language_list_delegate));
        }

        internal static void LoadCfxRequestHandlerApi() {
            CfxApi.Probe();
            CfxApi.RequestHandler.cfx_request_handler_ctor = (CfxApi.cfx_ctor_with_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_handler_ctor, typeof(CfxApi.cfx_ctor_with_gc_handle_delegate));
            CfxApi.RequestHandler.cfx_request_handler_set_callback = (CfxApi.cfx_set_callback_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_request_handler_set_callback, typeof(CfxApi.cfx_set_callback_delegate));
            CfxRequestHandler.SetNativeCallbacks();
        }

        internal static void LoadCfxResolveCallbackApi() {
            CfxApi.Probe();
            CfxApi.ResolveCallback.cfx_resolve_callback_ctor = (CfxApi.cfx_ctor_with_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_resolve_callback_ctor, typeof(CfxApi.cfx_ctor_with_gc_handle_delegate));
            CfxApi.ResolveCallback.cfx_resolve_callback_set_callback = (CfxApi.cfx_set_callback_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_resolve_callback_set_callback, typeof(CfxApi.cfx_set_callback_delegate));
            CfxResolveCallback.SetNativeCallbacks();
        }

        internal static void LoadCfxResourceBundleApi() {
            CfxApi.Probe();
            CfxApi.ResourceBundle.cfx_resource_bundle_get_global = (CfxApi.ResourceBundle.cfx_resource_bundle_get_global_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_resource_bundle_get_global, typeof(CfxApi.ResourceBundle.cfx_resource_bundle_get_global_delegate));
            CfxApi.ResourceBundle.cfx_resource_bundle_get_localized_string = (CfxApi.ResourceBundle.cfx_resource_bundle_get_localized_string_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_resource_bundle_get_localized_string, typeof(CfxApi.ResourceBundle.cfx_resource_bundle_get_localized_string_delegate));
            CfxApi.ResourceBundle.cfx_resource_bundle_get_data_resource = (CfxApi.ResourceBundle.cfx_resource_bundle_get_data_resource_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_resource_bundle_get_data_resource, typeof(CfxApi.ResourceBundle.cfx_resource_bundle_get_data_resource_delegate));
            CfxApi.ResourceBundle.cfx_resource_bundle_get_data_resource_for_scale = (CfxApi.ResourceBundle.cfx_resource_bundle_get_data_resource_for_scale_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_resource_bundle_get_data_resource_for_scale, typeof(CfxApi.ResourceBundle.cfx_resource_bundle_get_data_resource_for_scale_delegate));
        }

        internal static void LoadCfxResourceBundleHandlerApi() {
            CfxApi.Probe();
            CfxApi.ResourceBundleHandler.cfx_resource_bundle_handler_ctor = (CfxApi.cfx_ctor_with_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_resource_bundle_handler_ctor, typeof(CfxApi.cfx_ctor_with_gc_handle_delegate));
            CfxApi.ResourceBundleHandler.cfx_resource_bundle_handler_set_callback = (CfxApi.cfx_set_callback_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_resource_bundle_handler_set_callback, typeof(CfxApi.cfx_set_callback_delegate));
            CfxResourceBundleHandler.SetNativeCallbacks();
        }

        internal static void LoadCfxResourceHandlerApi() {
            CfxApi.Probe();
            CfxApi.ResourceHandler.cfx_resource_handler_ctor = (CfxApi.cfx_ctor_with_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_resource_handler_ctor, typeof(CfxApi.cfx_ctor_with_gc_handle_delegate));
            CfxApi.ResourceHandler.cfx_resource_handler_set_callback = (CfxApi.cfx_set_callback_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_resource_handler_set_callback, typeof(CfxApi.cfx_set_callback_delegate));
            CfxResourceHandler.SetNativeCallbacks();
        }

        internal static void LoadCfxResourceReadCallbackApi() {
            CfxApi.Probe();
            CfxApi.ResourceReadCallback.cfx_resource_read_callback_cont = (CfxApi.ResourceReadCallback.cfx_resource_read_callback_cont_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_resource_read_callback_cont, typeof(CfxApi.ResourceReadCallback.cfx_resource_read_callback_cont_delegate));
        }

        internal static void LoadCfxResourceRequestHandlerApi() {
            CfxApi.Probe();
            CfxApi.ResourceRequestHandler.cfx_resource_request_handler_ctor = (CfxApi.cfx_ctor_with_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_resource_request_handler_ctor, typeof(CfxApi.cfx_ctor_with_gc_handle_delegate));
            CfxApi.ResourceRequestHandler.cfx_resource_request_handler_set_callback = (CfxApi.cfx_set_callback_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_resource_request_handler_set_callback, typeof(CfxApi.cfx_set_callback_delegate));
            CfxResourceRequestHandler.SetNativeCallbacks();
        }

        internal static void LoadCfxResourceSkipCallbackApi() {
            CfxApi.Probe();
            CfxApi.ResourceSkipCallback.cfx_resource_skip_callback_cont = (CfxApi.ResourceSkipCallback.cfx_resource_skip_callback_cont_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_resource_skip_callback_cont, typeof(CfxApi.ResourceSkipCallback.cfx_resource_skip_callback_cont_delegate));
        }

        internal static void LoadCfxResponseApi() {
            CfxApi.Probe();
            CfxApi.Response.cfx_response_create = (CfxApi.Response.cfx_response_create_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_response_create, typeof(CfxApi.Response.cfx_response_create_delegate));
            CfxApi.Response.cfx_response_is_read_only = (CfxApi.Response.cfx_response_is_read_only_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_response_is_read_only, typeof(CfxApi.Response.cfx_response_is_read_only_delegate));
            CfxApi.Response.cfx_response_get_error = (CfxApi.Response.cfx_response_get_error_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_response_get_error, typeof(CfxApi.Response.cfx_response_get_error_delegate));
            CfxApi.Response.cfx_response_set_error = (CfxApi.Response.cfx_response_set_error_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_response_set_error, typeof(CfxApi.Response.cfx_response_set_error_delegate));
            CfxApi.Response.cfx_response_get_status = (CfxApi.Response.cfx_response_get_status_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_response_get_status, typeof(CfxApi.Response.cfx_response_get_status_delegate));
            CfxApi.Response.cfx_response_set_status = (CfxApi.Response.cfx_response_set_status_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_response_set_status, typeof(CfxApi.Response.cfx_response_set_status_delegate));
            CfxApi.Response.cfx_response_get_status_text = (CfxApi.Response.cfx_response_get_status_text_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_response_get_status_text, typeof(CfxApi.Response.cfx_response_get_status_text_delegate));
            CfxApi.Response.cfx_response_set_status_text = (CfxApi.Response.cfx_response_set_status_text_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_response_set_status_text, typeof(CfxApi.Response.cfx_response_set_status_text_delegate));
            CfxApi.Response.cfx_response_get_mime_type = (CfxApi.Response.cfx_response_get_mime_type_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_response_get_mime_type, typeof(CfxApi.Response.cfx_response_get_mime_type_delegate));
            CfxApi.Response.cfx_response_set_mime_type = (CfxApi.Response.cfx_response_set_mime_type_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_response_set_mime_type, typeof(CfxApi.Response.cfx_response_set_mime_type_delegate));
            CfxApi.Response.cfx_response_get_charset = (CfxApi.Response.cfx_response_get_charset_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_response_get_charset, typeof(CfxApi.Response.cfx_response_get_charset_delegate));
            CfxApi.Response.cfx_response_set_charset = (CfxApi.Response.cfx_response_set_charset_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_response_set_charset, typeof(CfxApi.Response.cfx_response_set_charset_delegate));
            CfxApi.Response.cfx_response_get_header = (CfxApi.Response.cfx_response_get_header_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_response_get_header, typeof(CfxApi.Response.cfx_response_get_header_delegate));
            CfxApi.Response.cfx_response_get_header_map = (CfxApi.Response.cfx_response_get_header_map_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_response_get_header_map, typeof(CfxApi.Response.cfx_response_get_header_map_delegate));
            CfxApi.Response.cfx_response_set_header_map = (CfxApi.Response.cfx_response_set_header_map_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_response_set_header_map, typeof(CfxApi.Response.cfx_response_set_header_map_delegate));
            CfxApi.Response.cfx_response_get_url = (CfxApi.Response.cfx_response_get_url_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_response_get_url, typeof(CfxApi.Response.cfx_response_get_url_delegate));
            CfxApi.Response.cfx_response_set_url = (CfxApi.Response.cfx_response_set_url_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_response_set_url, typeof(CfxApi.Response.cfx_response_set_url_delegate));
        }

        internal static void LoadCfxResponseFilterApi() {
            CfxApi.Probe();
            CfxApi.ResponseFilter.cfx_response_filter_ctor = (CfxApi.cfx_ctor_with_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_response_filter_ctor, typeof(CfxApi.cfx_ctor_with_gc_handle_delegate));
            CfxApi.ResponseFilter.cfx_response_filter_set_callback = (CfxApi.cfx_set_callback_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_response_filter_set_callback, typeof(CfxApi.cfx_set_callback_delegate));
            CfxResponseFilter.SetNativeCallbacks();
        }

        internal static void LoadCfxRunContextMenuCallbackApi() {
            CfxApi.Probe();
            CfxApi.RunContextMenuCallback.cfx_run_context_menu_callback_cont = (CfxApi.RunContextMenuCallback.cfx_run_context_menu_callback_cont_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_run_context_menu_callback_cont, typeof(CfxApi.RunContextMenuCallback.cfx_run_context_menu_callback_cont_delegate));
            CfxApi.RunContextMenuCallback.cfx_run_context_menu_callback_cancel = (CfxApi.RunContextMenuCallback.cfx_run_context_menu_callback_cancel_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_run_context_menu_callback_cancel, typeof(CfxApi.RunContextMenuCallback.cfx_run_context_menu_callback_cancel_delegate));
        }

        internal static void LoadCfxRunFileDialogCallbackApi() {
            CfxApi.Probe();
            CfxApi.RunFileDialogCallback.cfx_run_file_dialog_callback_ctor = (CfxApi.cfx_ctor_with_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_run_file_dialog_callback_ctor, typeof(CfxApi.cfx_ctor_with_gc_handle_delegate));
            CfxApi.RunFileDialogCallback.cfx_run_file_dialog_callback_set_callback = (CfxApi.cfx_set_callback_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_run_file_dialog_callback_set_callback, typeof(CfxApi.cfx_set_callback_delegate));
            CfxRunFileDialogCallback.SetNativeCallbacks();
        }

        internal static void LoadCfxSchemeHandlerFactoryApi() {
            CfxApi.Probe();
            CfxApi.SchemeHandlerFactory.cfx_scheme_handler_factory_ctor = (CfxApi.cfx_ctor_with_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_scheme_handler_factory_ctor, typeof(CfxApi.cfx_ctor_with_gc_handle_delegate));
            CfxApi.SchemeHandlerFactory.cfx_scheme_handler_factory_set_callback = (CfxApi.cfx_set_callback_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_scheme_handler_factory_set_callback, typeof(CfxApi.cfx_set_callback_delegate));
            CfxSchemeHandlerFactory.SetNativeCallbacks();
        }

        internal static void LoadCfxSchemeRegistrarApi() {
            CfxApi.Probe();
            CfxApi.SchemeRegistrar.cfx_scheme_registrar_add_custom_scheme = (CfxApi.SchemeRegistrar.cfx_scheme_registrar_add_custom_scheme_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_scheme_registrar_add_custom_scheme, typeof(CfxApi.SchemeRegistrar.cfx_scheme_registrar_add_custom_scheme_delegate));
        }

        internal static void LoadCfxScreenInfoApi() {
            CfxApi.Probe();
            CfxApi.ScreenInfo.cfx_screen_info_ctor = (CfxApi.cfx_ctor_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_screen_info_ctor, typeof(CfxApi.cfx_ctor_delegate));
            CfxApi.ScreenInfo.cfx_screen_info_dtor = (CfxApi.cfx_dtor_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_screen_info_dtor, typeof(CfxApi.cfx_dtor_delegate));
            CfxApi.ScreenInfo.cfx_screen_info_set_device_scale_factor = (CfxApi.ScreenInfo.cfx_screen_info_set_device_scale_factor_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_screen_info_set_device_scale_factor, typeof(CfxApi.ScreenInfo.cfx_screen_info_set_device_scale_factor_delegate));
            CfxApi.ScreenInfo.cfx_screen_info_get_device_scale_factor = (CfxApi.ScreenInfo.cfx_screen_info_get_device_scale_factor_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_screen_info_get_device_scale_factor, typeof(CfxApi.ScreenInfo.cfx_screen_info_get_device_scale_factor_delegate));
            CfxApi.ScreenInfo.cfx_screen_info_set_depth = (CfxApi.ScreenInfo.cfx_screen_info_set_depth_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_screen_info_set_depth, typeof(CfxApi.ScreenInfo.cfx_screen_info_set_depth_delegate));
            CfxApi.ScreenInfo.cfx_screen_info_get_depth = (CfxApi.ScreenInfo.cfx_screen_info_get_depth_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_screen_info_get_depth, typeof(CfxApi.ScreenInfo.cfx_screen_info_get_depth_delegate));
            CfxApi.ScreenInfo.cfx_screen_info_set_depth_per_component = (CfxApi.ScreenInfo.cfx_screen_info_set_depth_per_component_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_screen_info_set_depth_per_component, typeof(CfxApi.ScreenInfo.cfx_screen_info_set_depth_per_component_delegate));
            CfxApi.ScreenInfo.cfx_screen_info_get_depth_per_component = (CfxApi.ScreenInfo.cfx_screen_info_get_depth_per_component_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_screen_info_get_depth_per_component, typeof(CfxApi.ScreenInfo.cfx_screen_info_get_depth_per_component_delegate));
            CfxApi.ScreenInfo.cfx_screen_info_set_is_monochrome = (CfxApi.ScreenInfo.cfx_screen_info_set_is_monochrome_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_screen_info_set_is_monochrome, typeof(CfxApi.ScreenInfo.cfx_screen_info_set_is_monochrome_delegate));
            CfxApi.ScreenInfo.cfx_screen_info_get_is_monochrome = (CfxApi.ScreenInfo.cfx_screen_info_get_is_monochrome_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_screen_info_get_is_monochrome, typeof(CfxApi.ScreenInfo.cfx_screen_info_get_is_monochrome_delegate));
            CfxApi.ScreenInfo.cfx_screen_info_set_rect = (CfxApi.ScreenInfo.cfx_screen_info_set_rect_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_screen_info_set_rect, typeof(CfxApi.ScreenInfo.cfx_screen_info_set_rect_delegate));
            CfxApi.ScreenInfo.cfx_screen_info_get_rect = (CfxApi.ScreenInfo.cfx_screen_info_get_rect_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_screen_info_get_rect, typeof(CfxApi.ScreenInfo.cfx_screen_info_get_rect_delegate));
            CfxApi.ScreenInfo.cfx_screen_info_set_available_rect = (CfxApi.ScreenInfo.cfx_screen_info_set_available_rect_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_screen_info_set_available_rect, typeof(CfxApi.ScreenInfo.cfx_screen_info_set_available_rect_delegate));
            CfxApi.ScreenInfo.cfx_screen_info_get_available_rect = (CfxApi.ScreenInfo.cfx_screen_info_get_available_rect_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_screen_info_get_available_rect, typeof(CfxApi.ScreenInfo.cfx_screen_info_get_available_rect_delegate));
        }

        internal static void LoadCfxSelectClientCertificateCallbackApi() {
            CfxApi.Probe();
            CfxApi.SelectClientCertificateCallback.cfx_select_client_certificate_callback_select = (CfxApi.SelectClientCertificateCallback.cfx_select_client_certificate_callback_select_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_select_client_certificate_callback_select, typeof(CfxApi.SelectClientCertificateCallback.cfx_select_client_certificate_callback_select_delegate));
        }

        internal static void LoadCfxServerApi() {
            CfxApi.Probe();
            CfxApi.Server.cfx_server_create = (CfxApi.Server.cfx_server_create_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_server_create, typeof(CfxApi.Server.cfx_server_create_delegate));
            CfxApi.Server.cfx_server_get_task_runner = (CfxApi.Server.cfx_server_get_task_runner_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_server_get_task_runner, typeof(CfxApi.Server.cfx_server_get_task_runner_delegate));
            CfxApi.Server.cfx_server_shutdown = (CfxApi.Server.cfx_server_shutdown_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_server_shutdown, typeof(CfxApi.Server.cfx_server_shutdown_delegate));
            CfxApi.Server.cfx_server_is_running = (CfxApi.Server.cfx_server_is_running_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_server_is_running, typeof(CfxApi.Server.cfx_server_is_running_delegate));
            CfxApi.Server.cfx_server_get_address = (CfxApi.Server.cfx_server_get_address_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_server_get_address, typeof(CfxApi.Server.cfx_server_get_address_delegate));
            CfxApi.Server.cfx_server_has_connection = (CfxApi.Server.cfx_server_has_connection_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_server_has_connection, typeof(CfxApi.Server.cfx_server_has_connection_delegate));
            CfxApi.Server.cfx_server_is_valid_connection = (CfxApi.Server.cfx_server_is_valid_connection_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_server_is_valid_connection, typeof(CfxApi.Server.cfx_server_is_valid_connection_delegate));
            CfxApi.Server.cfx_server_send_http200response = (CfxApi.Server.cfx_server_send_http200response_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_server_send_http200response, typeof(CfxApi.Server.cfx_server_send_http200response_delegate));
            CfxApi.Server.cfx_server_send_http404response = (CfxApi.Server.cfx_server_send_http404response_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_server_send_http404response, typeof(CfxApi.Server.cfx_server_send_http404response_delegate));
            CfxApi.Server.cfx_server_send_http500response = (CfxApi.Server.cfx_server_send_http500response_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_server_send_http500response, typeof(CfxApi.Server.cfx_server_send_http500response_delegate));
            CfxApi.Server.cfx_server_send_http_response = (CfxApi.Server.cfx_server_send_http_response_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_server_send_http_response, typeof(CfxApi.Server.cfx_server_send_http_response_delegate));
            CfxApi.Server.cfx_server_send_raw_data = (CfxApi.Server.cfx_server_send_raw_data_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_server_send_raw_data, typeof(CfxApi.Server.cfx_server_send_raw_data_delegate));
            CfxApi.Server.cfx_server_close_connection = (CfxApi.Server.cfx_server_close_connection_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_server_close_connection, typeof(CfxApi.Server.cfx_server_close_connection_delegate));
            CfxApi.Server.cfx_server_send_web_socket_message = (CfxApi.Server.cfx_server_send_web_socket_message_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_server_send_web_socket_message, typeof(CfxApi.Server.cfx_server_send_web_socket_message_delegate));
        }

        internal static void LoadCfxServerHandlerApi() {
            CfxApi.Probe();
            CfxApi.ServerHandler.cfx_server_handler_ctor = (CfxApi.cfx_ctor_with_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_server_handler_ctor, typeof(CfxApi.cfx_ctor_with_gc_handle_delegate));
            CfxApi.ServerHandler.cfx_server_handler_set_callback = (CfxApi.cfx_set_callback_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_server_handler_set_callback, typeof(CfxApi.cfx_set_callback_delegate));
            CfxServerHandler.SetNativeCallbacks();
        }

        internal static void LoadCfxSetCookieCallbackApi() {
            CfxApi.Probe();
            CfxApi.SetCookieCallback.cfx_set_cookie_callback_ctor = (CfxApi.cfx_ctor_with_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_set_cookie_callback_ctor, typeof(CfxApi.cfx_ctor_with_gc_handle_delegate));
            CfxApi.SetCookieCallback.cfx_set_cookie_callback_set_callback = (CfxApi.cfx_set_callback_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_set_cookie_callback_set_callback, typeof(CfxApi.cfx_set_callback_delegate));
            CfxSetCookieCallback.SetNativeCallbacks();
        }

        internal static void LoadCfxSettingsApi() {
            CfxApi.Probe();
            CfxApi.Settings.cfx_settings_ctor = (CfxApi.cfx_ctor_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_ctor, typeof(CfxApi.cfx_ctor_delegate));
            CfxApi.Settings.cfx_settings_dtor = (CfxApi.cfx_dtor_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_dtor, typeof(CfxApi.cfx_dtor_delegate));
            CfxApi.Settings.cfx_settings_set_no_sandbox = (CfxApi.Settings.cfx_settings_set_no_sandbox_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_set_no_sandbox, typeof(CfxApi.Settings.cfx_settings_set_no_sandbox_delegate));
            CfxApi.Settings.cfx_settings_get_no_sandbox = (CfxApi.Settings.cfx_settings_get_no_sandbox_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_get_no_sandbox, typeof(CfxApi.Settings.cfx_settings_get_no_sandbox_delegate));
            CfxApi.Settings.cfx_settings_set_browser_subprocess_path = (CfxApi.Settings.cfx_settings_set_browser_subprocess_path_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_set_browser_subprocess_path, typeof(CfxApi.Settings.cfx_settings_set_browser_subprocess_path_delegate));
            CfxApi.Settings.cfx_settings_get_browser_subprocess_path = (CfxApi.Settings.cfx_settings_get_browser_subprocess_path_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_get_browser_subprocess_path, typeof(CfxApi.Settings.cfx_settings_get_browser_subprocess_path_delegate));
            CfxApi.Settings.cfx_settings_set_framework_dir_path = (CfxApi.Settings.cfx_settings_set_framework_dir_path_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_set_framework_dir_path, typeof(CfxApi.Settings.cfx_settings_set_framework_dir_path_delegate));
            CfxApi.Settings.cfx_settings_get_framework_dir_path = (CfxApi.Settings.cfx_settings_get_framework_dir_path_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_get_framework_dir_path, typeof(CfxApi.Settings.cfx_settings_get_framework_dir_path_delegate));
            CfxApi.Settings.cfx_settings_set_main_bundle_path = (CfxApi.Settings.cfx_settings_set_main_bundle_path_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_set_main_bundle_path, typeof(CfxApi.Settings.cfx_settings_set_main_bundle_path_delegate));
            CfxApi.Settings.cfx_settings_get_main_bundle_path = (CfxApi.Settings.cfx_settings_get_main_bundle_path_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_get_main_bundle_path, typeof(CfxApi.Settings.cfx_settings_get_main_bundle_path_delegate));
            CfxApi.Settings.cfx_settings_set_multi_threaded_message_loop = (CfxApi.Settings.cfx_settings_set_multi_threaded_message_loop_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_set_multi_threaded_message_loop, typeof(CfxApi.Settings.cfx_settings_set_multi_threaded_message_loop_delegate));
            CfxApi.Settings.cfx_settings_get_multi_threaded_message_loop = (CfxApi.Settings.cfx_settings_get_multi_threaded_message_loop_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_get_multi_threaded_message_loop, typeof(CfxApi.Settings.cfx_settings_get_multi_threaded_message_loop_delegate));
            CfxApi.Settings.cfx_settings_set_external_message_pump = (CfxApi.Settings.cfx_settings_set_external_message_pump_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_set_external_message_pump, typeof(CfxApi.Settings.cfx_settings_set_external_message_pump_delegate));
            CfxApi.Settings.cfx_settings_get_external_message_pump = (CfxApi.Settings.cfx_settings_get_external_message_pump_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_get_external_message_pump, typeof(CfxApi.Settings.cfx_settings_get_external_message_pump_delegate));
            CfxApi.Settings.cfx_settings_set_windowless_rendering_enabled = (CfxApi.Settings.cfx_settings_set_windowless_rendering_enabled_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_set_windowless_rendering_enabled, typeof(CfxApi.Settings.cfx_settings_set_windowless_rendering_enabled_delegate));
            CfxApi.Settings.cfx_settings_get_windowless_rendering_enabled = (CfxApi.Settings.cfx_settings_get_windowless_rendering_enabled_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_get_windowless_rendering_enabled, typeof(CfxApi.Settings.cfx_settings_get_windowless_rendering_enabled_delegate));
            CfxApi.Settings.cfx_settings_set_command_line_args_disabled = (CfxApi.Settings.cfx_settings_set_command_line_args_disabled_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_set_command_line_args_disabled, typeof(CfxApi.Settings.cfx_settings_set_command_line_args_disabled_delegate));
            CfxApi.Settings.cfx_settings_get_command_line_args_disabled = (CfxApi.Settings.cfx_settings_get_command_line_args_disabled_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_get_command_line_args_disabled, typeof(CfxApi.Settings.cfx_settings_get_command_line_args_disabled_delegate));
            CfxApi.Settings.cfx_settings_set_cache_path = (CfxApi.Settings.cfx_settings_set_cache_path_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_set_cache_path, typeof(CfxApi.Settings.cfx_settings_set_cache_path_delegate));
            CfxApi.Settings.cfx_settings_get_cache_path = (CfxApi.Settings.cfx_settings_get_cache_path_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_get_cache_path, typeof(CfxApi.Settings.cfx_settings_get_cache_path_delegate));
            CfxApi.Settings.cfx_settings_set_root_cache_path = (CfxApi.Settings.cfx_settings_set_root_cache_path_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_set_root_cache_path, typeof(CfxApi.Settings.cfx_settings_set_root_cache_path_delegate));
            CfxApi.Settings.cfx_settings_get_root_cache_path = (CfxApi.Settings.cfx_settings_get_root_cache_path_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_get_root_cache_path, typeof(CfxApi.Settings.cfx_settings_get_root_cache_path_delegate));
            CfxApi.Settings.cfx_settings_set_user_data_path = (CfxApi.Settings.cfx_settings_set_user_data_path_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_set_user_data_path, typeof(CfxApi.Settings.cfx_settings_set_user_data_path_delegate));
            CfxApi.Settings.cfx_settings_get_user_data_path = (CfxApi.Settings.cfx_settings_get_user_data_path_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_get_user_data_path, typeof(CfxApi.Settings.cfx_settings_get_user_data_path_delegate));
            CfxApi.Settings.cfx_settings_set_persist_session_cookies = (CfxApi.Settings.cfx_settings_set_persist_session_cookies_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_set_persist_session_cookies, typeof(CfxApi.Settings.cfx_settings_set_persist_session_cookies_delegate));
            CfxApi.Settings.cfx_settings_get_persist_session_cookies = (CfxApi.Settings.cfx_settings_get_persist_session_cookies_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_get_persist_session_cookies, typeof(CfxApi.Settings.cfx_settings_get_persist_session_cookies_delegate));
            CfxApi.Settings.cfx_settings_set_persist_user_preferences = (CfxApi.Settings.cfx_settings_set_persist_user_preferences_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_set_persist_user_preferences, typeof(CfxApi.Settings.cfx_settings_set_persist_user_preferences_delegate));
            CfxApi.Settings.cfx_settings_get_persist_user_preferences = (CfxApi.Settings.cfx_settings_get_persist_user_preferences_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_get_persist_user_preferences, typeof(CfxApi.Settings.cfx_settings_get_persist_user_preferences_delegate));
            CfxApi.Settings.cfx_settings_set_user_agent = (CfxApi.Settings.cfx_settings_set_user_agent_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_set_user_agent, typeof(CfxApi.Settings.cfx_settings_set_user_agent_delegate));
            CfxApi.Settings.cfx_settings_get_user_agent = (CfxApi.Settings.cfx_settings_get_user_agent_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_get_user_agent, typeof(CfxApi.Settings.cfx_settings_get_user_agent_delegate));
            CfxApi.Settings.cfx_settings_set_product_version = (CfxApi.Settings.cfx_settings_set_product_version_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_set_product_version, typeof(CfxApi.Settings.cfx_settings_set_product_version_delegate));
            CfxApi.Settings.cfx_settings_get_product_version = (CfxApi.Settings.cfx_settings_get_product_version_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_get_product_version, typeof(CfxApi.Settings.cfx_settings_get_product_version_delegate));
            CfxApi.Settings.cfx_settings_set_locale = (CfxApi.Settings.cfx_settings_set_locale_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_set_locale, typeof(CfxApi.Settings.cfx_settings_set_locale_delegate));
            CfxApi.Settings.cfx_settings_get_locale = (CfxApi.Settings.cfx_settings_get_locale_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_get_locale, typeof(CfxApi.Settings.cfx_settings_get_locale_delegate));
            CfxApi.Settings.cfx_settings_set_log_file = (CfxApi.Settings.cfx_settings_set_log_file_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_set_log_file, typeof(CfxApi.Settings.cfx_settings_set_log_file_delegate));
            CfxApi.Settings.cfx_settings_get_log_file = (CfxApi.Settings.cfx_settings_get_log_file_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_get_log_file, typeof(CfxApi.Settings.cfx_settings_get_log_file_delegate));
            CfxApi.Settings.cfx_settings_set_log_severity = (CfxApi.Settings.cfx_settings_set_log_severity_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_set_log_severity, typeof(CfxApi.Settings.cfx_settings_set_log_severity_delegate));
            CfxApi.Settings.cfx_settings_get_log_severity = (CfxApi.Settings.cfx_settings_get_log_severity_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_get_log_severity, typeof(CfxApi.Settings.cfx_settings_get_log_severity_delegate));
            CfxApi.Settings.cfx_settings_set_javascript_flags = (CfxApi.Settings.cfx_settings_set_javascript_flags_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_set_javascript_flags, typeof(CfxApi.Settings.cfx_settings_set_javascript_flags_delegate));
            CfxApi.Settings.cfx_settings_get_javascript_flags = (CfxApi.Settings.cfx_settings_get_javascript_flags_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_get_javascript_flags, typeof(CfxApi.Settings.cfx_settings_get_javascript_flags_delegate));
            CfxApi.Settings.cfx_settings_set_resources_dir_path = (CfxApi.Settings.cfx_settings_set_resources_dir_path_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_set_resources_dir_path, typeof(CfxApi.Settings.cfx_settings_set_resources_dir_path_delegate));
            CfxApi.Settings.cfx_settings_get_resources_dir_path = (CfxApi.Settings.cfx_settings_get_resources_dir_path_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_get_resources_dir_path, typeof(CfxApi.Settings.cfx_settings_get_resources_dir_path_delegate));
            CfxApi.Settings.cfx_settings_set_locales_dir_path = (CfxApi.Settings.cfx_settings_set_locales_dir_path_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_set_locales_dir_path, typeof(CfxApi.Settings.cfx_settings_set_locales_dir_path_delegate));
            CfxApi.Settings.cfx_settings_get_locales_dir_path = (CfxApi.Settings.cfx_settings_get_locales_dir_path_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_get_locales_dir_path, typeof(CfxApi.Settings.cfx_settings_get_locales_dir_path_delegate));
            CfxApi.Settings.cfx_settings_set_pack_loading_disabled = (CfxApi.Settings.cfx_settings_set_pack_loading_disabled_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_set_pack_loading_disabled, typeof(CfxApi.Settings.cfx_settings_set_pack_loading_disabled_delegate));
            CfxApi.Settings.cfx_settings_get_pack_loading_disabled = (CfxApi.Settings.cfx_settings_get_pack_loading_disabled_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_get_pack_loading_disabled, typeof(CfxApi.Settings.cfx_settings_get_pack_loading_disabled_delegate));
            CfxApi.Settings.cfx_settings_set_remote_debugging_port = (CfxApi.Settings.cfx_settings_set_remote_debugging_port_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_set_remote_debugging_port, typeof(CfxApi.Settings.cfx_settings_set_remote_debugging_port_delegate));
            CfxApi.Settings.cfx_settings_get_remote_debugging_port = (CfxApi.Settings.cfx_settings_get_remote_debugging_port_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_get_remote_debugging_port, typeof(CfxApi.Settings.cfx_settings_get_remote_debugging_port_delegate));
            CfxApi.Settings.cfx_settings_set_uncaught_exception_stack_size = (CfxApi.Settings.cfx_settings_set_uncaught_exception_stack_size_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_set_uncaught_exception_stack_size, typeof(CfxApi.Settings.cfx_settings_set_uncaught_exception_stack_size_delegate));
            CfxApi.Settings.cfx_settings_get_uncaught_exception_stack_size = (CfxApi.Settings.cfx_settings_get_uncaught_exception_stack_size_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_get_uncaught_exception_stack_size, typeof(CfxApi.Settings.cfx_settings_get_uncaught_exception_stack_size_delegate));
            CfxApi.Settings.cfx_settings_set_ignore_certificate_errors = (CfxApi.Settings.cfx_settings_set_ignore_certificate_errors_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_set_ignore_certificate_errors, typeof(CfxApi.Settings.cfx_settings_set_ignore_certificate_errors_delegate));
            CfxApi.Settings.cfx_settings_get_ignore_certificate_errors = (CfxApi.Settings.cfx_settings_get_ignore_certificate_errors_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_get_ignore_certificate_errors, typeof(CfxApi.Settings.cfx_settings_get_ignore_certificate_errors_delegate));
            CfxApi.Settings.cfx_settings_set_enable_net_security_expiration = (CfxApi.Settings.cfx_settings_set_enable_net_security_expiration_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_set_enable_net_security_expiration, typeof(CfxApi.Settings.cfx_settings_set_enable_net_security_expiration_delegate));
            CfxApi.Settings.cfx_settings_get_enable_net_security_expiration = (CfxApi.Settings.cfx_settings_get_enable_net_security_expiration_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_get_enable_net_security_expiration, typeof(CfxApi.Settings.cfx_settings_get_enable_net_security_expiration_delegate));
            CfxApi.Settings.cfx_settings_set_background_color = (CfxApi.Settings.cfx_settings_set_background_color_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_set_background_color, typeof(CfxApi.Settings.cfx_settings_set_background_color_delegate));
            CfxApi.Settings.cfx_settings_get_background_color = (CfxApi.Settings.cfx_settings_get_background_color_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_get_background_color, typeof(CfxApi.Settings.cfx_settings_get_background_color_delegate));
            CfxApi.Settings.cfx_settings_set_accept_language_list = (CfxApi.Settings.cfx_settings_set_accept_language_list_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_set_accept_language_list, typeof(CfxApi.Settings.cfx_settings_set_accept_language_list_delegate));
            CfxApi.Settings.cfx_settings_get_accept_language_list = (CfxApi.Settings.cfx_settings_get_accept_language_list_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_get_accept_language_list, typeof(CfxApi.Settings.cfx_settings_get_accept_language_list_delegate));
            CfxApi.Settings.cfx_settings_set_application_client_id_for_file_scanning = (CfxApi.Settings.cfx_settings_set_application_client_id_for_file_scanning_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_set_application_client_id_for_file_scanning, typeof(CfxApi.Settings.cfx_settings_set_application_client_id_for_file_scanning_delegate));
            CfxApi.Settings.cfx_settings_get_application_client_id_for_file_scanning = (CfxApi.Settings.cfx_settings_get_application_client_id_for_file_scanning_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_settings_get_application_client_id_for_file_scanning, typeof(CfxApi.Settings.cfx_settings_get_application_client_id_for_file_scanning_delegate));
        }

        internal static void LoadCfxSizeApi() {
            CfxApi.Probe();
            CfxApi.Size.cfx_size_ctor = (CfxApi.cfx_ctor_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_size_ctor, typeof(CfxApi.cfx_ctor_delegate));
            CfxApi.Size.cfx_size_dtor = (CfxApi.cfx_dtor_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_size_dtor, typeof(CfxApi.cfx_dtor_delegate));
            CfxApi.Size.cfx_size_set_width = (CfxApi.Size.cfx_size_set_width_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_size_set_width, typeof(CfxApi.Size.cfx_size_set_width_delegate));
            CfxApi.Size.cfx_size_get_width = (CfxApi.Size.cfx_size_get_width_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_size_get_width, typeof(CfxApi.Size.cfx_size_get_width_delegate));
            CfxApi.Size.cfx_size_set_height = (CfxApi.Size.cfx_size_set_height_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_size_set_height, typeof(CfxApi.Size.cfx_size_set_height_delegate));
            CfxApi.Size.cfx_size_get_height = (CfxApi.Size.cfx_size_get_height_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_size_get_height, typeof(CfxApi.Size.cfx_size_get_height_delegate));
        }

        internal static void LoadCfxSslInfoApi() {
            CfxApi.Probe();
            CfxApi.SslInfo.cfx_sslinfo_get_cert_status = (CfxApi.SslInfo.cfx_sslinfo_get_cert_status_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_sslinfo_get_cert_status, typeof(CfxApi.SslInfo.cfx_sslinfo_get_cert_status_delegate));
            CfxApi.SslInfo.cfx_sslinfo_get_x509certificate = (CfxApi.SslInfo.cfx_sslinfo_get_x509certificate_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_sslinfo_get_x509certificate, typeof(CfxApi.SslInfo.cfx_sslinfo_get_x509certificate_delegate));
        }

        internal static void LoadCfxSslStatusApi() {
            CfxApi.Probe();
            CfxApi.SslStatus.cfx_sslstatus_is_secure_connection = (CfxApi.SslStatus.cfx_sslstatus_is_secure_connection_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_sslstatus_is_secure_connection, typeof(CfxApi.SslStatus.cfx_sslstatus_is_secure_connection_delegate));
            CfxApi.SslStatus.cfx_sslstatus_get_cert_status = (CfxApi.SslStatus.cfx_sslstatus_get_cert_status_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_sslstatus_get_cert_status, typeof(CfxApi.SslStatus.cfx_sslstatus_get_cert_status_delegate));
            CfxApi.SslStatus.cfx_sslstatus_get_sslversion = (CfxApi.SslStatus.cfx_sslstatus_get_sslversion_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_sslstatus_get_sslversion, typeof(CfxApi.SslStatus.cfx_sslstatus_get_sslversion_delegate));
            CfxApi.SslStatus.cfx_sslstatus_get_content_status = (CfxApi.SslStatus.cfx_sslstatus_get_content_status_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_sslstatus_get_content_status, typeof(CfxApi.SslStatus.cfx_sslstatus_get_content_status_delegate));
            CfxApi.SslStatus.cfx_sslstatus_get_x509certificate = (CfxApi.SslStatus.cfx_sslstatus_get_x509certificate_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_sslstatus_get_x509certificate, typeof(CfxApi.SslStatus.cfx_sslstatus_get_x509certificate_delegate));
        }

        internal static void LoadCfxStreamReaderApi() {
            CfxApi.Probe();
            CfxApi.StreamReader.cfx_stream_reader_create_for_file = (CfxApi.StreamReader.cfx_stream_reader_create_for_file_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_stream_reader_create_for_file, typeof(CfxApi.StreamReader.cfx_stream_reader_create_for_file_delegate));
            CfxApi.StreamReader.cfx_stream_reader_create_for_data = (CfxApi.StreamReader.cfx_stream_reader_create_for_data_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_stream_reader_create_for_data, typeof(CfxApi.StreamReader.cfx_stream_reader_create_for_data_delegate));
            CfxApi.StreamReader.cfx_stream_reader_create_for_handler = (CfxApi.StreamReader.cfx_stream_reader_create_for_handler_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_stream_reader_create_for_handler, typeof(CfxApi.StreamReader.cfx_stream_reader_create_for_handler_delegate));
            CfxApi.StreamReader.cfx_stream_reader_read = (CfxApi.StreamReader.cfx_stream_reader_read_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_stream_reader_read, typeof(CfxApi.StreamReader.cfx_stream_reader_read_delegate));
            CfxApi.StreamReader.cfx_stream_reader_seek = (CfxApi.StreamReader.cfx_stream_reader_seek_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_stream_reader_seek, typeof(CfxApi.StreamReader.cfx_stream_reader_seek_delegate));
            CfxApi.StreamReader.cfx_stream_reader_tell = (CfxApi.StreamReader.cfx_stream_reader_tell_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_stream_reader_tell, typeof(CfxApi.StreamReader.cfx_stream_reader_tell_delegate));
            CfxApi.StreamReader.cfx_stream_reader_eof = (CfxApi.StreamReader.cfx_stream_reader_eof_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_stream_reader_eof, typeof(CfxApi.StreamReader.cfx_stream_reader_eof_delegate));
            CfxApi.StreamReader.cfx_stream_reader_may_block = (CfxApi.StreamReader.cfx_stream_reader_may_block_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_stream_reader_may_block, typeof(CfxApi.StreamReader.cfx_stream_reader_may_block_delegate));
        }

        internal static void LoadCfxStreamWriterApi() {
            CfxApi.Probe();
            CfxApi.StreamWriter.cfx_stream_writer_create_for_file = (CfxApi.StreamWriter.cfx_stream_writer_create_for_file_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_stream_writer_create_for_file, typeof(CfxApi.StreamWriter.cfx_stream_writer_create_for_file_delegate));
            CfxApi.StreamWriter.cfx_stream_writer_create_for_handler = (CfxApi.StreamWriter.cfx_stream_writer_create_for_handler_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_stream_writer_create_for_handler, typeof(CfxApi.StreamWriter.cfx_stream_writer_create_for_handler_delegate));
            CfxApi.StreamWriter.cfx_stream_writer_write = (CfxApi.StreamWriter.cfx_stream_writer_write_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_stream_writer_write, typeof(CfxApi.StreamWriter.cfx_stream_writer_write_delegate));
            CfxApi.StreamWriter.cfx_stream_writer_seek = (CfxApi.StreamWriter.cfx_stream_writer_seek_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_stream_writer_seek, typeof(CfxApi.StreamWriter.cfx_stream_writer_seek_delegate));
            CfxApi.StreamWriter.cfx_stream_writer_tell = (CfxApi.StreamWriter.cfx_stream_writer_tell_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_stream_writer_tell, typeof(CfxApi.StreamWriter.cfx_stream_writer_tell_delegate));
            CfxApi.StreamWriter.cfx_stream_writer_flush = (CfxApi.StreamWriter.cfx_stream_writer_flush_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_stream_writer_flush, typeof(CfxApi.StreamWriter.cfx_stream_writer_flush_delegate));
            CfxApi.StreamWriter.cfx_stream_writer_may_block = (CfxApi.StreamWriter.cfx_stream_writer_may_block_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_stream_writer_may_block, typeof(CfxApi.StreamWriter.cfx_stream_writer_may_block_delegate));
        }

        internal static void LoadCfxStringVisitorApi() {
            CfxApi.Probe();
            CfxApi.StringVisitor.cfx_string_visitor_ctor = (CfxApi.cfx_ctor_with_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_string_visitor_ctor, typeof(CfxApi.cfx_ctor_with_gc_handle_delegate));
            CfxApi.StringVisitor.cfx_string_visitor_set_callback = (CfxApi.cfx_set_callback_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_string_visitor_set_callback, typeof(CfxApi.cfx_set_callback_delegate));
            CfxStringVisitor.SetNativeCallbacks();
        }

        internal static void LoadCfxTaskApi() {
            CfxApi.Probe();
            CfxApi.Task.cfx_task_ctor = (CfxApi.cfx_ctor_with_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_task_ctor, typeof(CfxApi.cfx_ctor_with_gc_handle_delegate));
            CfxApi.Task.cfx_task_set_callback = (CfxApi.cfx_set_callback_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_task_set_callback, typeof(CfxApi.cfx_set_callback_delegate));
            CfxTask.SetNativeCallbacks();
        }

        internal static void LoadCfxTaskRunnerApi() {
            CfxApi.Probe();
            CfxApi.TaskRunner.cfx_task_runner_get_for_current_thread = (CfxApi.TaskRunner.cfx_task_runner_get_for_current_thread_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_task_runner_get_for_current_thread, typeof(CfxApi.TaskRunner.cfx_task_runner_get_for_current_thread_delegate));
            CfxApi.TaskRunner.cfx_task_runner_get_for_thread = (CfxApi.TaskRunner.cfx_task_runner_get_for_thread_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_task_runner_get_for_thread, typeof(CfxApi.TaskRunner.cfx_task_runner_get_for_thread_delegate));
            CfxApi.TaskRunner.cfx_task_runner_is_same = (CfxApi.TaskRunner.cfx_task_runner_is_same_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_task_runner_is_same, typeof(CfxApi.TaskRunner.cfx_task_runner_is_same_delegate));
            CfxApi.TaskRunner.cfx_task_runner_belongs_to_current_thread = (CfxApi.TaskRunner.cfx_task_runner_belongs_to_current_thread_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_task_runner_belongs_to_current_thread, typeof(CfxApi.TaskRunner.cfx_task_runner_belongs_to_current_thread_delegate));
            CfxApi.TaskRunner.cfx_task_runner_belongs_to_thread = (CfxApi.TaskRunner.cfx_task_runner_belongs_to_thread_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_task_runner_belongs_to_thread, typeof(CfxApi.TaskRunner.cfx_task_runner_belongs_to_thread_delegate));
            CfxApi.TaskRunner.cfx_task_runner_post_task = (CfxApi.TaskRunner.cfx_task_runner_post_task_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_task_runner_post_task, typeof(CfxApi.TaskRunner.cfx_task_runner_post_task_delegate));
            CfxApi.TaskRunner.cfx_task_runner_post_delayed_task = (CfxApi.TaskRunner.cfx_task_runner_post_delayed_task_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_task_runner_post_delayed_task, typeof(CfxApi.TaskRunner.cfx_task_runner_post_delayed_task_delegate));
        }

        internal static void LoadCfxThreadApi() {
            CfxApi.Probe();
            CfxApi.Thread.cfx_thread_create = (CfxApi.Thread.cfx_thread_create_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_thread_create, typeof(CfxApi.Thread.cfx_thread_create_delegate));
            CfxApi.Thread.cfx_thread_get_task_runner = (CfxApi.Thread.cfx_thread_get_task_runner_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_thread_get_task_runner, typeof(CfxApi.Thread.cfx_thread_get_task_runner_delegate));
            CfxApi.Thread.cfx_thread_get_platform_thread_id = (CfxApi.Thread.cfx_thread_get_platform_thread_id_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_thread_get_platform_thread_id, typeof(CfxApi.Thread.cfx_thread_get_platform_thread_id_delegate));
            CfxApi.Thread.cfx_thread_stop = (CfxApi.Thread.cfx_thread_stop_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_thread_stop, typeof(CfxApi.Thread.cfx_thread_stop_delegate));
            CfxApi.Thread.cfx_thread_is_running = (CfxApi.Thread.cfx_thread_is_running_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_thread_is_running, typeof(CfxApi.Thread.cfx_thread_is_running_delegate));
        }

        internal static void LoadCfxTimeApi() {
            CfxApi.Probe();
            CfxApi.Time.cfx_time_ctor = (CfxApi.cfx_ctor_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_time_ctor, typeof(CfxApi.cfx_ctor_delegate));
            CfxApi.Time.cfx_time_dtor = (CfxApi.cfx_dtor_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_time_dtor, typeof(CfxApi.cfx_dtor_delegate));
            CfxApi.Time.cfx_time_set_year = (CfxApi.Time.cfx_time_set_year_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_time_set_year, typeof(CfxApi.Time.cfx_time_set_year_delegate));
            CfxApi.Time.cfx_time_get_year = (CfxApi.Time.cfx_time_get_year_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_time_get_year, typeof(CfxApi.Time.cfx_time_get_year_delegate));
            CfxApi.Time.cfx_time_set_month = (CfxApi.Time.cfx_time_set_month_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_time_set_month, typeof(CfxApi.Time.cfx_time_set_month_delegate));
            CfxApi.Time.cfx_time_get_month = (CfxApi.Time.cfx_time_get_month_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_time_get_month, typeof(CfxApi.Time.cfx_time_get_month_delegate));
            CfxApi.Time.cfx_time_set_day_of_week = (CfxApi.Time.cfx_time_set_day_of_week_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_time_set_day_of_week, typeof(CfxApi.Time.cfx_time_set_day_of_week_delegate));
            CfxApi.Time.cfx_time_get_day_of_week = (CfxApi.Time.cfx_time_get_day_of_week_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_time_get_day_of_week, typeof(CfxApi.Time.cfx_time_get_day_of_week_delegate));
            CfxApi.Time.cfx_time_set_day_of_month = (CfxApi.Time.cfx_time_set_day_of_month_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_time_set_day_of_month, typeof(CfxApi.Time.cfx_time_set_day_of_month_delegate));
            CfxApi.Time.cfx_time_get_day_of_month = (CfxApi.Time.cfx_time_get_day_of_month_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_time_get_day_of_month, typeof(CfxApi.Time.cfx_time_get_day_of_month_delegate));
            CfxApi.Time.cfx_time_set_hour = (CfxApi.Time.cfx_time_set_hour_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_time_set_hour, typeof(CfxApi.Time.cfx_time_set_hour_delegate));
            CfxApi.Time.cfx_time_get_hour = (CfxApi.Time.cfx_time_get_hour_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_time_get_hour, typeof(CfxApi.Time.cfx_time_get_hour_delegate));
            CfxApi.Time.cfx_time_set_minute = (CfxApi.Time.cfx_time_set_minute_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_time_set_minute, typeof(CfxApi.Time.cfx_time_set_minute_delegate));
            CfxApi.Time.cfx_time_get_minute = (CfxApi.Time.cfx_time_get_minute_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_time_get_minute, typeof(CfxApi.Time.cfx_time_get_minute_delegate));
            CfxApi.Time.cfx_time_set_second = (CfxApi.Time.cfx_time_set_second_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_time_set_second, typeof(CfxApi.Time.cfx_time_set_second_delegate));
            CfxApi.Time.cfx_time_get_second = (CfxApi.Time.cfx_time_get_second_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_time_get_second, typeof(CfxApi.Time.cfx_time_get_second_delegate));
            CfxApi.Time.cfx_time_set_millisecond = (CfxApi.Time.cfx_time_set_millisecond_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_time_set_millisecond, typeof(CfxApi.Time.cfx_time_set_millisecond_delegate));
            CfxApi.Time.cfx_time_get_millisecond = (CfxApi.Time.cfx_time_get_millisecond_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_time_get_millisecond, typeof(CfxApi.Time.cfx_time_get_millisecond_delegate));
        }

        internal static void LoadCfxTouchEventApi() {
            CfxApi.Probe();
            CfxApi.TouchEvent.cfx_touch_event_ctor = (CfxApi.cfx_ctor_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_touch_event_ctor, typeof(CfxApi.cfx_ctor_delegate));
            CfxApi.TouchEvent.cfx_touch_event_dtor = (CfxApi.cfx_dtor_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_touch_event_dtor, typeof(CfxApi.cfx_dtor_delegate));
            CfxApi.TouchEvent.cfx_touch_event_set_id = (CfxApi.TouchEvent.cfx_touch_event_set_id_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_touch_event_set_id, typeof(CfxApi.TouchEvent.cfx_touch_event_set_id_delegate));
            CfxApi.TouchEvent.cfx_touch_event_get_id = (CfxApi.TouchEvent.cfx_touch_event_get_id_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_touch_event_get_id, typeof(CfxApi.TouchEvent.cfx_touch_event_get_id_delegate));
            CfxApi.TouchEvent.cfx_touch_event_set_x = (CfxApi.TouchEvent.cfx_touch_event_set_x_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_touch_event_set_x, typeof(CfxApi.TouchEvent.cfx_touch_event_set_x_delegate));
            CfxApi.TouchEvent.cfx_touch_event_get_x = (CfxApi.TouchEvent.cfx_touch_event_get_x_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_touch_event_get_x, typeof(CfxApi.TouchEvent.cfx_touch_event_get_x_delegate));
            CfxApi.TouchEvent.cfx_touch_event_set_y = (CfxApi.TouchEvent.cfx_touch_event_set_y_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_touch_event_set_y, typeof(CfxApi.TouchEvent.cfx_touch_event_set_y_delegate));
            CfxApi.TouchEvent.cfx_touch_event_get_y = (CfxApi.TouchEvent.cfx_touch_event_get_y_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_touch_event_get_y, typeof(CfxApi.TouchEvent.cfx_touch_event_get_y_delegate));
            CfxApi.TouchEvent.cfx_touch_event_set_radius_x = (CfxApi.TouchEvent.cfx_touch_event_set_radius_x_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_touch_event_set_radius_x, typeof(CfxApi.TouchEvent.cfx_touch_event_set_radius_x_delegate));
            CfxApi.TouchEvent.cfx_touch_event_get_radius_x = (CfxApi.TouchEvent.cfx_touch_event_get_radius_x_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_touch_event_get_radius_x, typeof(CfxApi.TouchEvent.cfx_touch_event_get_radius_x_delegate));
            CfxApi.TouchEvent.cfx_touch_event_set_radius_y = (CfxApi.TouchEvent.cfx_touch_event_set_radius_y_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_touch_event_set_radius_y, typeof(CfxApi.TouchEvent.cfx_touch_event_set_radius_y_delegate));
            CfxApi.TouchEvent.cfx_touch_event_get_radius_y = (CfxApi.TouchEvent.cfx_touch_event_get_radius_y_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_touch_event_get_radius_y, typeof(CfxApi.TouchEvent.cfx_touch_event_get_radius_y_delegate));
            CfxApi.TouchEvent.cfx_touch_event_set_rotation_angle = (CfxApi.TouchEvent.cfx_touch_event_set_rotation_angle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_touch_event_set_rotation_angle, typeof(CfxApi.TouchEvent.cfx_touch_event_set_rotation_angle_delegate));
            CfxApi.TouchEvent.cfx_touch_event_get_rotation_angle = (CfxApi.TouchEvent.cfx_touch_event_get_rotation_angle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_touch_event_get_rotation_angle, typeof(CfxApi.TouchEvent.cfx_touch_event_get_rotation_angle_delegate));
            CfxApi.TouchEvent.cfx_touch_event_set_pressure = (CfxApi.TouchEvent.cfx_touch_event_set_pressure_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_touch_event_set_pressure, typeof(CfxApi.TouchEvent.cfx_touch_event_set_pressure_delegate));
            CfxApi.TouchEvent.cfx_touch_event_get_pressure = (CfxApi.TouchEvent.cfx_touch_event_get_pressure_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_touch_event_get_pressure, typeof(CfxApi.TouchEvent.cfx_touch_event_get_pressure_delegate));
            CfxApi.TouchEvent.cfx_touch_event_set_type = (CfxApi.TouchEvent.cfx_touch_event_set_type_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_touch_event_set_type, typeof(CfxApi.TouchEvent.cfx_touch_event_set_type_delegate));
            CfxApi.TouchEvent.cfx_touch_event_get_type = (CfxApi.TouchEvent.cfx_touch_event_get_type_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_touch_event_get_type, typeof(CfxApi.TouchEvent.cfx_touch_event_get_type_delegate));
            CfxApi.TouchEvent.cfx_touch_event_set_modifiers = (CfxApi.TouchEvent.cfx_touch_event_set_modifiers_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_touch_event_set_modifiers, typeof(CfxApi.TouchEvent.cfx_touch_event_set_modifiers_delegate));
            CfxApi.TouchEvent.cfx_touch_event_get_modifiers = (CfxApi.TouchEvent.cfx_touch_event_get_modifiers_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_touch_event_get_modifiers, typeof(CfxApi.TouchEvent.cfx_touch_event_get_modifiers_delegate));
            CfxApi.TouchEvent.cfx_touch_event_set_pointer_type = (CfxApi.TouchEvent.cfx_touch_event_set_pointer_type_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_touch_event_set_pointer_type, typeof(CfxApi.TouchEvent.cfx_touch_event_set_pointer_type_delegate));
            CfxApi.TouchEvent.cfx_touch_event_get_pointer_type = (CfxApi.TouchEvent.cfx_touch_event_get_pointer_type_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_touch_event_get_pointer_type, typeof(CfxApi.TouchEvent.cfx_touch_event_get_pointer_type_delegate));
        }

        internal static void LoadCfxUrlPartsApi() {
            CfxApi.Probe();
            CfxApi.UrlParts.cfx_urlparts_ctor = (CfxApi.cfx_ctor_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_urlparts_ctor, typeof(CfxApi.cfx_ctor_delegate));
            CfxApi.UrlParts.cfx_urlparts_dtor = (CfxApi.cfx_dtor_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_urlparts_dtor, typeof(CfxApi.cfx_dtor_delegate));
            CfxApi.UrlParts.cfx_urlparts_set_spec = (CfxApi.UrlParts.cfx_urlparts_set_spec_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_urlparts_set_spec, typeof(CfxApi.UrlParts.cfx_urlparts_set_spec_delegate));
            CfxApi.UrlParts.cfx_urlparts_get_spec = (CfxApi.UrlParts.cfx_urlparts_get_spec_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_urlparts_get_spec, typeof(CfxApi.UrlParts.cfx_urlparts_get_spec_delegate));
            CfxApi.UrlParts.cfx_urlparts_set_scheme = (CfxApi.UrlParts.cfx_urlparts_set_scheme_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_urlparts_set_scheme, typeof(CfxApi.UrlParts.cfx_urlparts_set_scheme_delegate));
            CfxApi.UrlParts.cfx_urlparts_get_scheme = (CfxApi.UrlParts.cfx_urlparts_get_scheme_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_urlparts_get_scheme, typeof(CfxApi.UrlParts.cfx_urlparts_get_scheme_delegate));
            CfxApi.UrlParts.cfx_urlparts_set_username = (CfxApi.UrlParts.cfx_urlparts_set_username_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_urlparts_set_username, typeof(CfxApi.UrlParts.cfx_urlparts_set_username_delegate));
            CfxApi.UrlParts.cfx_urlparts_get_username = (CfxApi.UrlParts.cfx_urlparts_get_username_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_urlparts_get_username, typeof(CfxApi.UrlParts.cfx_urlparts_get_username_delegate));
            CfxApi.UrlParts.cfx_urlparts_set_password = (CfxApi.UrlParts.cfx_urlparts_set_password_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_urlparts_set_password, typeof(CfxApi.UrlParts.cfx_urlparts_set_password_delegate));
            CfxApi.UrlParts.cfx_urlparts_get_password = (CfxApi.UrlParts.cfx_urlparts_get_password_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_urlparts_get_password, typeof(CfxApi.UrlParts.cfx_urlparts_get_password_delegate));
            CfxApi.UrlParts.cfx_urlparts_set_host = (CfxApi.UrlParts.cfx_urlparts_set_host_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_urlparts_set_host, typeof(CfxApi.UrlParts.cfx_urlparts_set_host_delegate));
            CfxApi.UrlParts.cfx_urlparts_get_host = (CfxApi.UrlParts.cfx_urlparts_get_host_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_urlparts_get_host, typeof(CfxApi.UrlParts.cfx_urlparts_get_host_delegate));
            CfxApi.UrlParts.cfx_urlparts_set_port = (CfxApi.UrlParts.cfx_urlparts_set_port_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_urlparts_set_port, typeof(CfxApi.UrlParts.cfx_urlparts_set_port_delegate));
            CfxApi.UrlParts.cfx_urlparts_get_port = (CfxApi.UrlParts.cfx_urlparts_get_port_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_urlparts_get_port, typeof(CfxApi.UrlParts.cfx_urlparts_get_port_delegate));
            CfxApi.UrlParts.cfx_urlparts_set_origin = (CfxApi.UrlParts.cfx_urlparts_set_origin_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_urlparts_set_origin, typeof(CfxApi.UrlParts.cfx_urlparts_set_origin_delegate));
            CfxApi.UrlParts.cfx_urlparts_get_origin = (CfxApi.UrlParts.cfx_urlparts_get_origin_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_urlparts_get_origin, typeof(CfxApi.UrlParts.cfx_urlparts_get_origin_delegate));
            CfxApi.UrlParts.cfx_urlparts_set_path = (CfxApi.UrlParts.cfx_urlparts_set_path_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_urlparts_set_path, typeof(CfxApi.UrlParts.cfx_urlparts_set_path_delegate));
            CfxApi.UrlParts.cfx_urlparts_get_path = (CfxApi.UrlParts.cfx_urlparts_get_path_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_urlparts_get_path, typeof(CfxApi.UrlParts.cfx_urlparts_get_path_delegate));
            CfxApi.UrlParts.cfx_urlparts_set_query = (CfxApi.UrlParts.cfx_urlparts_set_query_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_urlparts_set_query, typeof(CfxApi.UrlParts.cfx_urlparts_set_query_delegate));
            CfxApi.UrlParts.cfx_urlparts_get_query = (CfxApi.UrlParts.cfx_urlparts_get_query_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_urlparts_get_query, typeof(CfxApi.UrlParts.cfx_urlparts_get_query_delegate));
        }

        internal static void LoadCfxUrlRequestApi() {
            CfxApi.Probe();
            CfxApi.UrlRequest.cfx_urlrequest_create = (CfxApi.UrlRequest.cfx_urlrequest_create_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_urlrequest_create, typeof(CfxApi.UrlRequest.cfx_urlrequest_create_delegate));
            CfxApi.UrlRequest.cfx_urlrequest_get_request = (CfxApi.UrlRequest.cfx_urlrequest_get_request_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_urlrequest_get_request, typeof(CfxApi.UrlRequest.cfx_urlrequest_get_request_delegate));
            CfxApi.UrlRequest.cfx_urlrequest_get_client = (CfxApi.UrlRequest.cfx_urlrequest_get_client_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_urlrequest_get_client, typeof(CfxApi.UrlRequest.cfx_urlrequest_get_client_delegate));
            CfxApi.UrlRequest.cfx_urlrequest_get_request_status = (CfxApi.UrlRequest.cfx_urlrequest_get_request_status_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_urlrequest_get_request_status, typeof(CfxApi.UrlRequest.cfx_urlrequest_get_request_status_delegate));
            CfxApi.UrlRequest.cfx_urlrequest_get_request_error = (CfxApi.UrlRequest.cfx_urlrequest_get_request_error_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_urlrequest_get_request_error, typeof(CfxApi.UrlRequest.cfx_urlrequest_get_request_error_delegate));
            CfxApi.UrlRequest.cfx_urlrequest_get_response = (CfxApi.UrlRequest.cfx_urlrequest_get_response_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_urlrequest_get_response, typeof(CfxApi.UrlRequest.cfx_urlrequest_get_response_delegate));
            CfxApi.UrlRequest.cfx_urlrequest_response_was_cached = (CfxApi.UrlRequest.cfx_urlrequest_response_was_cached_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_urlrequest_response_was_cached, typeof(CfxApi.UrlRequest.cfx_urlrequest_response_was_cached_delegate));
            CfxApi.UrlRequest.cfx_urlrequest_cancel = (CfxApi.UrlRequest.cfx_urlrequest_cancel_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_urlrequest_cancel, typeof(CfxApi.UrlRequest.cfx_urlrequest_cancel_delegate));
        }

        internal static void LoadCfxUrlRequestClientApi() {
            CfxApi.Probe();
            CfxApi.UrlRequestClient.cfx_urlrequest_client_ctor = (CfxApi.cfx_ctor_with_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_urlrequest_client_ctor, typeof(CfxApi.cfx_ctor_with_gc_handle_delegate));
            CfxApi.UrlRequestClient.cfx_urlrequest_client_get_gc_handle = (CfxApi.cfx_get_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_urlrequest_client_get_gc_handle, typeof(CfxApi.cfx_get_gc_handle_delegate));
            CfxApi.UrlRequestClient.cfx_urlrequest_client_set_callback = (CfxApi.cfx_set_callback_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_urlrequest_client_set_callback, typeof(CfxApi.cfx_set_callback_delegate));
            CfxUrlRequestClient.SetNativeCallbacks();
        }

        internal static void LoadCfxV8AccessorApi() {
            CfxApi.Probe();
            CfxApi.V8Accessor.cfx_v8accessor_ctor = (CfxApi.cfx_ctor_with_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8accessor_ctor, typeof(CfxApi.cfx_ctor_with_gc_handle_delegate));
            CfxApi.V8Accessor.cfx_v8accessor_set_callback = (CfxApi.cfx_set_callback_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8accessor_set_callback, typeof(CfxApi.cfx_set_callback_delegate));
            CfxV8Accessor.SetNativeCallbacks();
        }

        internal static void LoadCfxV8ArrayBufferReleaseCallbackApi() {
            CfxApi.Probe();
            CfxApi.V8ArrayBufferReleaseCallback.cfx_v8array_buffer_release_callback_ctor = (CfxApi.cfx_ctor_with_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8array_buffer_release_callback_ctor, typeof(CfxApi.cfx_ctor_with_gc_handle_delegate));
            CfxApi.V8ArrayBufferReleaseCallback.cfx_v8array_buffer_release_callback_get_gc_handle = (CfxApi.cfx_get_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8array_buffer_release_callback_get_gc_handle, typeof(CfxApi.cfx_get_gc_handle_delegate));
            CfxApi.V8ArrayBufferReleaseCallback.cfx_v8array_buffer_release_callback_set_callback = (CfxApi.cfx_set_callback_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8array_buffer_release_callback_set_callback, typeof(CfxApi.cfx_set_callback_delegate));
            CfxV8ArrayBufferReleaseCallback.SetNativeCallbacks();
        }

        internal static void LoadCfxV8ContextApi() {
            CfxApi.Probe();
            CfxApi.V8Context.cfx_v8context_get_current_context = (CfxApi.V8Context.cfx_v8context_get_current_context_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8context_get_current_context, typeof(CfxApi.V8Context.cfx_v8context_get_current_context_delegate));
            CfxApi.V8Context.cfx_v8context_get_entered_context = (CfxApi.V8Context.cfx_v8context_get_entered_context_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8context_get_entered_context, typeof(CfxApi.V8Context.cfx_v8context_get_entered_context_delegate));
            CfxApi.V8Context.cfx_v8context_in_context = (CfxApi.V8Context.cfx_v8context_in_context_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8context_in_context, typeof(CfxApi.V8Context.cfx_v8context_in_context_delegate));
            CfxApi.V8Context.cfx_v8context_get_task_runner = (CfxApi.V8Context.cfx_v8context_get_task_runner_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8context_get_task_runner, typeof(CfxApi.V8Context.cfx_v8context_get_task_runner_delegate));
            CfxApi.V8Context.cfx_v8context_is_valid = (CfxApi.V8Context.cfx_v8context_is_valid_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8context_is_valid, typeof(CfxApi.V8Context.cfx_v8context_is_valid_delegate));
            CfxApi.V8Context.cfx_v8context_get_browser = (CfxApi.V8Context.cfx_v8context_get_browser_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8context_get_browser, typeof(CfxApi.V8Context.cfx_v8context_get_browser_delegate));
            CfxApi.V8Context.cfx_v8context_get_frame = (CfxApi.V8Context.cfx_v8context_get_frame_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8context_get_frame, typeof(CfxApi.V8Context.cfx_v8context_get_frame_delegate));
            CfxApi.V8Context.cfx_v8context_get_global = (CfxApi.V8Context.cfx_v8context_get_global_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8context_get_global, typeof(CfxApi.V8Context.cfx_v8context_get_global_delegate));
            CfxApi.V8Context.cfx_v8context_enter = (CfxApi.V8Context.cfx_v8context_enter_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8context_enter, typeof(CfxApi.V8Context.cfx_v8context_enter_delegate));
            CfxApi.V8Context.cfx_v8context_exit = (CfxApi.V8Context.cfx_v8context_exit_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8context_exit, typeof(CfxApi.V8Context.cfx_v8context_exit_delegate));
            CfxApi.V8Context.cfx_v8context_is_same = (CfxApi.V8Context.cfx_v8context_is_same_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8context_is_same, typeof(CfxApi.V8Context.cfx_v8context_is_same_delegate));
            CfxApi.V8Context.cfx_v8context_eval = (CfxApi.V8Context.cfx_v8context_eval_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8context_eval, typeof(CfxApi.V8Context.cfx_v8context_eval_delegate));
        }

        internal static void LoadCfxV8ExceptionApi() {
            CfxApi.Probe();
            CfxApi.V8Exception.cfx_v8exception_get_message = (CfxApi.V8Exception.cfx_v8exception_get_message_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8exception_get_message, typeof(CfxApi.V8Exception.cfx_v8exception_get_message_delegate));
            CfxApi.V8Exception.cfx_v8exception_get_source_line = (CfxApi.V8Exception.cfx_v8exception_get_source_line_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8exception_get_source_line, typeof(CfxApi.V8Exception.cfx_v8exception_get_source_line_delegate));
            CfxApi.V8Exception.cfx_v8exception_get_script_resource_name = (CfxApi.V8Exception.cfx_v8exception_get_script_resource_name_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8exception_get_script_resource_name, typeof(CfxApi.V8Exception.cfx_v8exception_get_script_resource_name_delegate));
            CfxApi.V8Exception.cfx_v8exception_get_line_number = (CfxApi.V8Exception.cfx_v8exception_get_line_number_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8exception_get_line_number, typeof(CfxApi.V8Exception.cfx_v8exception_get_line_number_delegate));
            CfxApi.V8Exception.cfx_v8exception_get_start_position = (CfxApi.V8Exception.cfx_v8exception_get_start_position_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8exception_get_start_position, typeof(CfxApi.V8Exception.cfx_v8exception_get_start_position_delegate));
            CfxApi.V8Exception.cfx_v8exception_get_end_position = (CfxApi.V8Exception.cfx_v8exception_get_end_position_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8exception_get_end_position, typeof(CfxApi.V8Exception.cfx_v8exception_get_end_position_delegate));
            CfxApi.V8Exception.cfx_v8exception_get_start_column = (CfxApi.V8Exception.cfx_v8exception_get_start_column_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8exception_get_start_column, typeof(CfxApi.V8Exception.cfx_v8exception_get_start_column_delegate));
            CfxApi.V8Exception.cfx_v8exception_get_end_column = (CfxApi.V8Exception.cfx_v8exception_get_end_column_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8exception_get_end_column, typeof(CfxApi.V8Exception.cfx_v8exception_get_end_column_delegate));
        }

        internal static void LoadCfxV8HandlerApi() {
            CfxApi.Probe();
            CfxApi.V8Handler.cfx_v8handler_ctor = (CfxApi.cfx_ctor_with_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8handler_ctor, typeof(CfxApi.cfx_ctor_with_gc_handle_delegate));
            CfxApi.V8Handler.cfx_v8handler_get_gc_handle = (CfxApi.cfx_get_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8handler_get_gc_handle, typeof(CfxApi.cfx_get_gc_handle_delegate));
            CfxApi.V8Handler.cfx_v8handler_set_callback = (CfxApi.cfx_set_callback_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8handler_set_callback, typeof(CfxApi.cfx_set_callback_delegate));
            CfxV8Handler.SetNativeCallbacks();
        }

        internal static void LoadCfxV8InterceptorApi() {
            CfxApi.Probe();
            CfxApi.V8Interceptor.cfx_v8interceptor_ctor = (CfxApi.cfx_ctor_with_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8interceptor_ctor, typeof(CfxApi.cfx_ctor_with_gc_handle_delegate));
            CfxApi.V8Interceptor.cfx_v8interceptor_set_callback = (CfxApi.cfx_set_callback_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8interceptor_set_callback, typeof(CfxApi.cfx_set_callback_delegate));
            CfxV8Interceptor.SetNativeCallbacks();
        }

        internal static void LoadCfxV8StackFrameApi() {
            CfxApi.Probe();
            CfxApi.V8StackFrame.cfx_v8stack_frame_is_valid = (CfxApi.V8StackFrame.cfx_v8stack_frame_is_valid_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8stack_frame_is_valid, typeof(CfxApi.V8StackFrame.cfx_v8stack_frame_is_valid_delegate));
            CfxApi.V8StackFrame.cfx_v8stack_frame_get_script_name = (CfxApi.V8StackFrame.cfx_v8stack_frame_get_script_name_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8stack_frame_get_script_name, typeof(CfxApi.V8StackFrame.cfx_v8stack_frame_get_script_name_delegate));
            CfxApi.V8StackFrame.cfx_v8stack_frame_get_script_name_or_source_url = (CfxApi.V8StackFrame.cfx_v8stack_frame_get_script_name_or_source_url_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8stack_frame_get_script_name_or_source_url, typeof(CfxApi.V8StackFrame.cfx_v8stack_frame_get_script_name_or_source_url_delegate));
            CfxApi.V8StackFrame.cfx_v8stack_frame_get_function_name = (CfxApi.V8StackFrame.cfx_v8stack_frame_get_function_name_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8stack_frame_get_function_name, typeof(CfxApi.V8StackFrame.cfx_v8stack_frame_get_function_name_delegate));
            CfxApi.V8StackFrame.cfx_v8stack_frame_get_line_number = (CfxApi.V8StackFrame.cfx_v8stack_frame_get_line_number_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8stack_frame_get_line_number, typeof(CfxApi.V8StackFrame.cfx_v8stack_frame_get_line_number_delegate));
            CfxApi.V8StackFrame.cfx_v8stack_frame_get_column = (CfxApi.V8StackFrame.cfx_v8stack_frame_get_column_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8stack_frame_get_column, typeof(CfxApi.V8StackFrame.cfx_v8stack_frame_get_column_delegate));
            CfxApi.V8StackFrame.cfx_v8stack_frame_is_eval = (CfxApi.V8StackFrame.cfx_v8stack_frame_is_eval_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8stack_frame_is_eval, typeof(CfxApi.V8StackFrame.cfx_v8stack_frame_is_eval_delegate));
            CfxApi.V8StackFrame.cfx_v8stack_frame_is_constructor = (CfxApi.V8StackFrame.cfx_v8stack_frame_is_constructor_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8stack_frame_is_constructor, typeof(CfxApi.V8StackFrame.cfx_v8stack_frame_is_constructor_delegate));
        }

        internal static void LoadCfxV8StackTraceApi() {
            CfxApi.Probe();
            CfxApi.V8StackTrace.cfx_v8stack_trace_get_current = (CfxApi.V8StackTrace.cfx_v8stack_trace_get_current_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8stack_trace_get_current, typeof(CfxApi.V8StackTrace.cfx_v8stack_trace_get_current_delegate));
            CfxApi.V8StackTrace.cfx_v8stack_trace_is_valid = (CfxApi.V8StackTrace.cfx_v8stack_trace_is_valid_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8stack_trace_is_valid, typeof(CfxApi.V8StackTrace.cfx_v8stack_trace_is_valid_delegate));
            CfxApi.V8StackTrace.cfx_v8stack_trace_get_frame_count = (CfxApi.V8StackTrace.cfx_v8stack_trace_get_frame_count_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8stack_trace_get_frame_count, typeof(CfxApi.V8StackTrace.cfx_v8stack_trace_get_frame_count_delegate));
            CfxApi.V8StackTrace.cfx_v8stack_trace_get_frame = (CfxApi.V8StackTrace.cfx_v8stack_trace_get_frame_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8stack_trace_get_frame, typeof(CfxApi.V8StackTrace.cfx_v8stack_trace_get_frame_delegate));
        }

        internal static void LoadCfxV8ValueApi() {
            CfxApi.Probe();
            CfxApi.V8Value.cfx_v8value_create_undefined = (CfxApi.V8Value.cfx_v8value_create_undefined_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_create_undefined, typeof(CfxApi.V8Value.cfx_v8value_create_undefined_delegate));
            CfxApi.V8Value.cfx_v8value_create_null = (CfxApi.V8Value.cfx_v8value_create_null_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_create_null, typeof(CfxApi.V8Value.cfx_v8value_create_null_delegate));
            CfxApi.V8Value.cfx_v8value_create_bool = (CfxApi.V8Value.cfx_v8value_create_bool_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_create_bool, typeof(CfxApi.V8Value.cfx_v8value_create_bool_delegate));
            CfxApi.V8Value.cfx_v8value_create_int = (CfxApi.V8Value.cfx_v8value_create_int_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_create_int, typeof(CfxApi.V8Value.cfx_v8value_create_int_delegate));
            CfxApi.V8Value.cfx_v8value_create_uint = (CfxApi.V8Value.cfx_v8value_create_uint_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_create_uint, typeof(CfxApi.V8Value.cfx_v8value_create_uint_delegate));
            CfxApi.V8Value.cfx_v8value_create_double = (CfxApi.V8Value.cfx_v8value_create_double_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_create_double, typeof(CfxApi.V8Value.cfx_v8value_create_double_delegate));
            CfxApi.V8Value.cfx_v8value_create_date = (CfxApi.V8Value.cfx_v8value_create_date_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_create_date, typeof(CfxApi.V8Value.cfx_v8value_create_date_delegate));
            CfxApi.V8Value.cfx_v8value_create_string = (CfxApi.V8Value.cfx_v8value_create_string_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_create_string, typeof(CfxApi.V8Value.cfx_v8value_create_string_delegate));
            CfxApi.V8Value.cfx_v8value_create_object = (CfxApi.V8Value.cfx_v8value_create_object_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_create_object, typeof(CfxApi.V8Value.cfx_v8value_create_object_delegate));
            CfxApi.V8Value.cfx_v8value_create_array = (CfxApi.V8Value.cfx_v8value_create_array_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_create_array, typeof(CfxApi.V8Value.cfx_v8value_create_array_delegate));
            CfxApi.V8Value.cfx_v8value_create_array_buffer = (CfxApi.V8Value.cfx_v8value_create_array_buffer_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_create_array_buffer, typeof(CfxApi.V8Value.cfx_v8value_create_array_buffer_delegate));
            CfxApi.V8Value.cfx_v8value_create_function = (CfxApi.V8Value.cfx_v8value_create_function_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_create_function, typeof(CfxApi.V8Value.cfx_v8value_create_function_delegate));
            CfxApi.V8Value.cfx_v8value_is_valid = (CfxApi.V8Value.cfx_v8value_is_valid_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_is_valid, typeof(CfxApi.V8Value.cfx_v8value_is_valid_delegate));
            CfxApi.V8Value.cfx_v8value_is_undefined = (CfxApi.V8Value.cfx_v8value_is_undefined_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_is_undefined, typeof(CfxApi.V8Value.cfx_v8value_is_undefined_delegate));
            CfxApi.V8Value.cfx_v8value_is_null = (CfxApi.V8Value.cfx_v8value_is_null_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_is_null, typeof(CfxApi.V8Value.cfx_v8value_is_null_delegate));
            CfxApi.V8Value.cfx_v8value_is_bool = (CfxApi.V8Value.cfx_v8value_is_bool_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_is_bool, typeof(CfxApi.V8Value.cfx_v8value_is_bool_delegate));
            CfxApi.V8Value.cfx_v8value_is_int = (CfxApi.V8Value.cfx_v8value_is_int_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_is_int, typeof(CfxApi.V8Value.cfx_v8value_is_int_delegate));
            CfxApi.V8Value.cfx_v8value_is_uint = (CfxApi.V8Value.cfx_v8value_is_uint_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_is_uint, typeof(CfxApi.V8Value.cfx_v8value_is_uint_delegate));
            CfxApi.V8Value.cfx_v8value_is_double = (CfxApi.V8Value.cfx_v8value_is_double_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_is_double, typeof(CfxApi.V8Value.cfx_v8value_is_double_delegate));
            CfxApi.V8Value.cfx_v8value_is_date = (CfxApi.V8Value.cfx_v8value_is_date_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_is_date, typeof(CfxApi.V8Value.cfx_v8value_is_date_delegate));
            CfxApi.V8Value.cfx_v8value_is_string = (CfxApi.V8Value.cfx_v8value_is_string_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_is_string, typeof(CfxApi.V8Value.cfx_v8value_is_string_delegate));
            CfxApi.V8Value.cfx_v8value_is_object = (CfxApi.V8Value.cfx_v8value_is_object_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_is_object, typeof(CfxApi.V8Value.cfx_v8value_is_object_delegate));
            CfxApi.V8Value.cfx_v8value_is_array = (CfxApi.V8Value.cfx_v8value_is_array_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_is_array, typeof(CfxApi.V8Value.cfx_v8value_is_array_delegate));
            CfxApi.V8Value.cfx_v8value_is_array_buffer = (CfxApi.V8Value.cfx_v8value_is_array_buffer_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_is_array_buffer, typeof(CfxApi.V8Value.cfx_v8value_is_array_buffer_delegate));
            CfxApi.V8Value.cfx_v8value_is_function = (CfxApi.V8Value.cfx_v8value_is_function_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_is_function, typeof(CfxApi.V8Value.cfx_v8value_is_function_delegate));
            CfxApi.V8Value.cfx_v8value_is_same = (CfxApi.V8Value.cfx_v8value_is_same_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_is_same, typeof(CfxApi.V8Value.cfx_v8value_is_same_delegate));
            CfxApi.V8Value.cfx_v8value_get_bool_value = (CfxApi.V8Value.cfx_v8value_get_bool_value_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_get_bool_value, typeof(CfxApi.V8Value.cfx_v8value_get_bool_value_delegate));
            CfxApi.V8Value.cfx_v8value_get_int_value = (CfxApi.V8Value.cfx_v8value_get_int_value_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_get_int_value, typeof(CfxApi.V8Value.cfx_v8value_get_int_value_delegate));
            CfxApi.V8Value.cfx_v8value_get_uint_value = (CfxApi.V8Value.cfx_v8value_get_uint_value_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_get_uint_value, typeof(CfxApi.V8Value.cfx_v8value_get_uint_value_delegate));
            CfxApi.V8Value.cfx_v8value_get_double_value = (CfxApi.V8Value.cfx_v8value_get_double_value_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_get_double_value, typeof(CfxApi.V8Value.cfx_v8value_get_double_value_delegate));
            CfxApi.V8Value.cfx_v8value_get_date_value = (CfxApi.V8Value.cfx_v8value_get_date_value_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_get_date_value, typeof(CfxApi.V8Value.cfx_v8value_get_date_value_delegate));
            CfxApi.V8Value.cfx_v8value_get_string_value = (CfxApi.V8Value.cfx_v8value_get_string_value_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_get_string_value, typeof(CfxApi.V8Value.cfx_v8value_get_string_value_delegate));
            CfxApi.V8Value.cfx_v8value_is_user_created = (CfxApi.V8Value.cfx_v8value_is_user_created_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_is_user_created, typeof(CfxApi.V8Value.cfx_v8value_is_user_created_delegate));
            CfxApi.V8Value.cfx_v8value_has_exception = (CfxApi.V8Value.cfx_v8value_has_exception_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_has_exception, typeof(CfxApi.V8Value.cfx_v8value_has_exception_delegate));
            CfxApi.V8Value.cfx_v8value_get_exception = (CfxApi.V8Value.cfx_v8value_get_exception_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_get_exception, typeof(CfxApi.V8Value.cfx_v8value_get_exception_delegate));
            CfxApi.V8Value.cfx_v8value_clear_exception = (CfxApi.V8Value.cfx_v8value_clear_exception_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_clear_exception, typeof(CfxApi.V8Value.cfx_v8value_clear_exception_delegate));
            CfxApi.V8Value.cfx_v8value_will_rethrow_exceptions = (CfxApi.V8Value.cfx_v8value_will_rethrow_exceptions_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_will_rethrow_exceptions, typeof(CfxApi.V8Value.cfx_v8value_will_rethrow_exceptions_delegate));
            CfxApi.V8Value.cfx_v8value_set_rethrow_exceptions = (CfxApi.V8Value.cfx_v8value_set_rethrow_exceptions_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_set_rethrow_exceptions, typeof(CfxApi.V8Value.cfx_v8value_set_rethrow_exceptions_delegate));
            CfxApi.V8Value.cfx_v8value_has_value_bykey = (CfxApi.V8Value.cfx_v8value_has_value_bykey_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_has_value_bykey, typeof(CfxApi.V8Value.cfx_v8value_has_value_bykey_delegate));
            CfxApi.V8Value.cfx_v8value_has_value_byindex = (CfxApi.V8Value.cfx_v8value_has_value_byindex_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_has_value_byindex, typeof(CfxApi.V8Value.cfx_v8value_has_value_byindex_delegate));
            CfxApi.V8Value.cfx_v8value_delete_value_bykey = (CfxApi.V8Value.cfx_v8value_delete_value_bykey_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_delete_value_bykey, typeof(CfxApi.V8Value.cfx_v8value_delete_value_bykey_delegate));
            CfxApi.V8Value.cfx_v8value_delete_value_byindex = (CfxApi.V8Value.cfx_v8value_delete_value_byindex_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_delete_value_byindex, typeof(CfxApi.V8Value.cfx_v8value_delete_value_byindex_delegate));
            CfxApi.V8Value.cfx_v8value_get_value_bykey = (CfxApi.V8Value.cfx_v8value_get_value_bykey_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_get_value_bykey, typeof(CfxApi.V8Value.cfx_v8value_get_value_bykey_delegate));
            CfxApi.V8Value.cfx_v8value_get_value_byindex = (CfxApi.V8Value.cfx_v8value_get_value_byindex_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_get_value_byindex, typeof(CfxApi.V8Value.cfx_v8value_get_value_byindex_delegate));
            CfxApi.V8Value.cfx_v8value_set_value_bykey = (CfxApi.V8Value.cfx_v8value_set_value_bykey_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_set_value_bykey, typeof(CfxApi.V8Value.cfx_v8value_set_value_bykey_delegate));
            CfxApi.V8Value.cfx_v8value_set_value_byindex = (CfxApi.V8Value.cfx_v8value_set_value_byindex_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_set_value_byindex, typeof(CfxApi.V8Value.cfx_v8value_set_value_byindex_delegate));
            CfxApi.V8Value.cfx_v8value_set_value_byaccessor = (CfxApi.V8Value.cfx_v8value_set_value_byaccessor_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_set_value_byaccessor, typeof(CfxApi.V8Value.cfx_v8value_set_value_byaccessor_delegate));
            CfxApi.V8Value.cfx_v8value_get_keys = (CfxApi.V8Value.cfx_v8value_get_keys_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_get_keys, typeof(CfxApi.V8Value.cfx_v8value_get_keys_delegate));
            CfxApi.V8Value.cfx_v8value_set_user_data = (CfxApi.V8Value.cfx_v8value_set_user_data_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_set_user_data, typeof(CfxApi.V8Value.cfx_v8value_set_user_data_delegate));
            CfxApi.V8Value.cfx_v8value_get_user_data = (CfxApi.V8Value.cfx_v8value_get_user_data_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_get_user_data, typeof(CfxApi.V8Value.cfx_v8value_get_user_data_delegate));
            CfxApi.V8Value.cfx_v8value_get_externally_allocated_memory = (CfxApi.V8Value.cfx_v8value_get_externally_allocated_memory_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_get_externally_allocated_memory, typeof(CfxApi.V8Value.cfx_v8value_get_externally_allocated_memory_delegate));
            CfxApi.V8Value.cfx_v8value_adjust_externally_allocated_memory = (CfxApi.V8Value.cfx_v8value_adjust_externally_allocated_memory_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_adjust_externally_allocated_memory, typeof(CfxApi.V8Value.cfx_v8value_adjust_externally_allocated_memory_delegate));
            CfxApi.V8Value.cfx_v8value_get_array_length = (CfxApi.V8Value.cfx_v8value_get_array_length_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_get_array_length, typeof(CfxApi.V8Value.cfx_v8value_get_array_length_delegate));
            CfxApi.V8Value.cfx_v8value_get_array_buffer_release_callback = (CfxApi.V8Value.cfx_v8value_get_array_buffer_release_callback_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_get_array_buffer_release_callback, typeof(CfxApi.V8Value.cfx_v8value_get_array_buffer_release_callback_delegate));
            CfxApi.V8Value.cfx_v8value_neuter_array_buffer = (CfxApi.V8Value.cfx_v8value_neuter_array_buffer_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_neuter_array_buffer, typeof(CfxApi.V8Value.cfx_v8value_neuter_array_buffer_delegate));
            CfxApi.V8Value.cfx_v8value_get_function_name = (CfxApi.V8Value.cfx_v8value_get_function_name_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_get_function_name, typeof(CfxApi.V8Value.cfx_v8value_get_function_name_delegate));
            CfxApi.V8Value.cfx_v8value_get_function_handler = (CfxApi.V8Value.cfx_v8value_get_function_handler_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_get_function_handler, typeof(CfxApi.V8Value.cfx_v8value_get_function_handler_delegate));
            CfxApi.V8Value.cfx_v8value_execute_function = (CfxApi.V8Value.cfx_v8value_execute_function_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_execute_function, typeof(CfxApi.V8Value.cfx_v8value_execute_function_delegate));
            CfxApi.V8Value.cfx_v8value_execute_function_with_context = (CfxApi.V8Value.cfx_v8value_execute_function_with_context_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_v8value_execute_function_with_context, typeof(CfxApi.V8Value.cfx_v8value_execute_function_with_context_delegate));
        }

        internal static void LoadCfxValueApi() {
            CfxApi.Probe();
            CfxApi.Value.cfx_value_create = (CfxApi.Value.cfx_value_create_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_value_create, typeof(CfxApi.Value.cfx_value_create_delegate));
            CfxApi.Value.cfx_value_is_valid = (CfxApi.Value.cfx_value_is_valid_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_value_is_valid, typeof(CfxApi.Value.cfx_value_is_valid_delegate));
            CfxApi.Value.cfx_value_is_owned = (CfxApi.Value.cfx_value_is_owned_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_value_is_owned, typeof(CfxApi.Value.cfx_value_is_owned_delegate));
            CfxApi.Value.cfx_value_is_read_only = (CfxApi.Value.cfx_value_is_read_only_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_value_is_read_only, typeof(CfxApi.Value.cfx_value_is_read_only_delegate));
            CfxApi.Value.cfx_value_is_same = (CfxApi.Value.cfx_value_is_same_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_value_is_same, typeof(CfxApi.Value.cfx_value_is_same_delegate));
            CfxApi.Value.cfx_value_is_equal = (CfxApi.Value.cfx_value_is_equal_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_value_is_equal, typeof(CfxApi.Value.cfx_value_is_equal_delegate));
            CfxApi.Value.cfx_value_copy = (CfxApi.Value.cfx_value_copy_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_value_copy, typeof(CfxApi.Value.cfx_value_copy_delegate));
            CfxApi.Value.cfx_value_get_type = (CfxApi.Value.cfx_value_get_type_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_value_get_type, typeof(CfxApi.Value.cfx_value_get_type_delegate));
            CfxApi.Value.cfx_value_get_bool = (CfxApi.Value.cfx_value_get_bool_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_value_get_bool, typeof(CfxApi.Value.cfx_value_get_bool_delegate));
            CfxApi.Value.cfx_value_get_int = (CfxApi.Value.cfx_value_get_int_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_value_get_int, typeof(CfxApi.Value.cfx_value_get_int_delegate));
            CfxApi.Value.cfx_value_get_double = (CfxApi.Value.cfx_value_get_double_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_value_get_double, typeof(CfxApi.Value.cfx_value_get_double_delegate));
            CfxApi.Value.cfx_value_get_string = (CfxApi.Value.cfx_value_get_string_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_value_get_string, typeof(CfxApi.Value.cfx_value_get_string_delegate));
            CfxApi.Value.cfx_value_get_binary = (CfxApi.Value.cfx_value_get_binary_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_value_get_binary, typeof(CfxApi.Value.cfx_value_get_binary_delegate));
            CfxApi.Value.cfx_value_get_dictionary = (CfxApi.Value.cfx_value_get_dictionary_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_value_get_dictionary, typeof(CfxApi.Value.cfx_value_get_dictionary_delegate));
            CfxApi.Value.cfx_value_get_list = (CfxApi.Value.cfx_value_get_list_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_value_get_list, typeof(CfxApi.Value.cfx_value_get_list_delegate));
            CfxApi.Value.cfx_value_set_null = (CfxApi.Value.cfx_value_set_null_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_value_set_null, typeof(CfxApi.Value.cfx_value_set_null_delegate));
            CfxApi.Value.cfx_value_set_bool = (CfxApi.Value.cfx_value_set_bool_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_value_set_bool, typeof(CfxApi.Value.cfx_value_set_bool_delegate));
            CfxApi.Value.cfx_value_set_int = (CfxApi.Value.cfx_value_set_int_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_value_set_int, typeof(CfxApi.Value.cfx_value_set_int_delegate));
            CfxApi.Value.cfx_value_set_double = (CfxApi.Value.cfx_value_set_double_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_value_set_double, typeof(CfxApi.Value.cfx_value_set_double_delegate));
            CfxApi.Value.cfx_value_set_string = (CfxApi.Value.cfx_value_set_string_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_value_set_string, typeof(CfxApi.Value.cfx_value_set_string_delegate));
            CfxApi.Value.cfx_value_set_binary = (CfxApi.Value.cfx_value_set_binary_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_value_set_binary, typeof(CfxApi.Value.cfx_value_set_binary_delegate));
            CfxApi.Value.cfx_value_set_dictionary = (CfxApi.Value.cfx_value_set_dictionary_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_value_set_dictionary, typeof(CfxApi.Value.cfx_value_set_dictionary_delegate));
            CfxApi.Value.cfx_value_set_list = (CfxApi.Value.cfx_value_set_list_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_value_set_list, typeof(CfxApi.Value.cfx_value_set_list_delegate));
        }

        internal static void LoadCfxWaitableEventApi() {
            CfxApi.Probe();
            CfxApi.WaitableEvent.cfx_waitable_event_create = (CfxApi.WaitableEvent.cfx_waitable_event_create_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_waitable_event_create, typeof(CfxApi.WaitableEvent.cfx_waitable_event_create_delegate));
            CfxApi.WaitableEvent.cfx_waitable_event_reset = (CfxApi.WaitableEvent.cfx_waitable_event_reset_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_waitable_event_reset, typeof(CfxApi.WaitableEvent.cfx_waitable_event_reset_delegate));
            CfxApi.WaitableEvent.cfx_waitable_event_signal = (CfxApi.WaitableEvent.cfx_waitable_event_signal_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_waitable_event_signal, typeof(CfxApi.WaitableEvent.cfx_waitable_event_signal_delegate));
            CfxApi.WaitableEvent.cfx_waitable_event_is_signaled = (CfxApi.WaitableEvent.cfx_waitable_event_is_signaled_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_waitable_event_is_signaled, typeof(CfxApi.WaitableEvent.cfx_waitable_event_is_signaled_delegate));
            CfxApi.WaitableEvent.cfx_waitable_event_wait = (CfxApi.WaitableEvent.cfx_waitable_event_wait_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_waitable_event_wait, typeof(CfxApi.WaitableEvent.cfx_waitable_event_wait_delegate));
            CfxApi.WaitableEvent.cfx_waitable_event_timed_wait = (CfxApi.WaitableEvent.cfx_waitable_event_timed_wait_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_waitable_event_timed_wait, typeof(CfxApi.WaitableEvent.cfx_waitable_event_timed_wait_delegate));
        }

        internal static void LoadCfxWebPluginInfoApi() {
            CfxApi.Probe();
            CfxApi.WebPluginInfo.cfx_web_plugin_info_get_name = (CfxApi.WebPluginInfo.cfx_web_plugin_info_get_name_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_web_plugin_info_get_name, typeof(CfxApi.WebPluginInfo.cfx_web_plugin_info_get_name_delegate));
            CfxApi.WebPluginInfo.cfx_web_plugin_info_get_path = (CfxApi.WebPluginInfo.cfx_web_plugin_info_get_path_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_web_plugin_info_get_path, typeof(CfxApi.WebPluginInfo.cfx_web_plugin_info_get_path_delegate));
            CfxApi.WebPluginInfo.cfx_web_plugin_info_get_version = (CfxApi.WebPluginInfo.cfx_web_plugin_info_get_version_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_web_plugin_info_get_version, typeof(CfxApi.WebPluginInfo.cfx_web_plugin_info_get_version_delegate));
            CfxApi.WebPluginInfo.cfx_web_plugin_info_get_description = (CfxApi.WebPluginInfo.cfx_web_plugin_info_get_description_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_web_plugin_info_get_description, typeof(CfxApi.WebPluginInfo.cfx_web_plugin_info_get_description_delegate));
        }

        internal static void LoadCfxWebPluginInfoVisitorApi() {
            CfxApi.Probe();
            CfxApi.WebPluginInfoVisitor.cfx_web_plugin_info_visitor_ctor = (CfxApi.cfx_ctor_with_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_web_plugin_info_visitor_ctor, typeof(CfxApi.cfx_ctor_with_gc_handle_delegate));
            CfxApi.WebPluginInfoVisitor.cfx_web_plugin_info_visitor_set_callback = (CfxApi.cfx_set_callback_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_web_plugin_info_visitor_set_callback, typeof(CfxApi.cfx_set_callback_delegate));
            CfxWebPluginInfoVisitor.SetNativeCallbacks();
        }

        internal static void LoadCfxWebPluginUnstableCallbackApi() {
            CfxApi.Probe();
            CfxApi.WebPluginUnstableCallback.cfx_web_plugin_unstable_callback_ctor = (CfxApi.cfx_ctor_with_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_web_plugin_unstable_callback_ctor, typeof(CfxApi.cfx_ctor_with_gc_handle_delegate));
            CfxApi.WebPluginUnstableCallback.cfx_web_plugin_unstable_callback_set_callback = (CfxApi.cfx_set_callback_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_web_plugin_unstable_callback_set_callback, typeof(CfxApi.cfx_set_callback_delegate));
            CfxWebPluginUnstableCallback.SetNativeCallbacks();
        }

        internal static void LoadCfxWindowInfoLinuxApi() {
            CfxApi.Probe();
            CfxApi.WindowInfoLinux.cfx_window_info_linux_ctor = (CfxApi.cfx_ctor_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_window_info_linux_ctor, typeof(CfxApi.cfx_ctor_delegate));
            CfxApi.WindowInfoLinux.cfx_window_info_linux_dtor = (CfxApi.cfx_dtor_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_window_info_linux_dtor, typeof(CfxApi.cfx_dtor_delegate));
            CfxApi.WindowInfoLinux.cfx_window_info_linux_set_x = (CfxApi.WindowInfoLinux.cfx_window_info_linux_set_x_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_window_info_linux_set_x, typeof(CfxApi.WindowInfoLinux.cfx_window_info_linux_set_x_delegate));
            CfxApi.WindowInfoLinux.cfx_window_info_linux_get_x = (CfxApi.WindowInfoLinux.cfx_window_info_linux_get_x_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_window_info_linux_get_x, typeof(CfxApi.WindowInfoLinux.cfx_window_info_linux_get_x_delegate));
            CfxApi.WindowInfoLinux.cfx_window_info_linux_set_y = (CfxApi.WindowInfoLinux.cfx_window_info_linux_set_y_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_window_info_linux_set_y, typeof(CfxApi.WindowInfoLinux.cfx_window_info_linux_set_y_delegate));
            CfxApi.WindowInfoLinux.cfx_window_info_linux_get_y = (CfxApi.WindowInfoLinux.cfx_window_info_linux_get_y_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_window_info_linux_get_y, typeof(CfxApi.WindowInfoLinux.cfx_window_info_linux_get_y_delegate));
            CfxApi.WindowInfoLinux.cfx_window_info_linux_set_width = (CfxApi.WindowInfoLinux.cfx_window_info_linux_set_width_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_window_info_linux_set_width, typeof(CfxApi.WindowInfoLinux.cfx_window_info_linux_set_width_delegate));
            CfxApi.WindowInfoLinux.cfx_window_info_linux_get_width = (CfxApi.WindowInfoLinux.cfx_window_info_linux_get_width_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_window_info_linux_get_width, typeof(CfxApi.WindowInfoLinux.cfx_window_info_linux_get_width_delegate));
            CfxApi.WindowInfoLinux.cfx_window_info_linux_set_height = (CfxApi.WindowInfoLinux.cfx_window_info_linux_set_height_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_window_info_linux_set_height, typeof(CfxApi.WindowInfoLinux.cfx_window_info_linux_set_height_delegate));
            CfxApi.WindowInfoLinux.cfx_window_info_linux_get_height = (CfxApi.WindowInfoLinux.cfx_window_info_linux_get_height_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_window_info_linux_get_height, typeof(CfxApi.WindowInfoLinux.cfx_window_info_linux_get_height_delegate));
            CfxApi.WindowInfoLinux.cfx_window_info_linux_set_parent_window = (CfxApi.WindowInfoLinux.cfx_window_info_linux_set_parent_window_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_window_info_linux_set_parent_window, typeof(CfxApi.WindowInfoLinux.cfx_window_info_linux_set_parent_window_delegate));
            CfxApi.WindowInfoLinux.cfx_window_info_linux_get_parent_window = (CfxApi.WindowInfoLinux.cfx_window_info_linux_get_parent_window_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_window_info_linux_get_parent_window, typeof(CfxApi.WindowInfoLinux.cfx_window_info_linux_get_parent_window_delegate));
            CfxApi.WindowInfoLinux.cfx_window_info_linux_set_windowless_rendering_enabled = (CfxApi.WindowInfoLinux.cfx_window_info_linux_set_windowless_rendering_enabled_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_window_info_linux_set_windowless_rendering_enabled, typeof(CfxApi.WindowInfoLinux.cfx_window_info_linux_set_windowless_rendering_enabled_delegate));
            CfxApi.WindowInfoLinux.cfx_window_info_linux_get_windowless_rendering_enabled = (CfxApi.WindowInfoLinux.cfx_window_info_linux_get_windowless_rendering_enabled_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_window_info_linux_get_windowless_rendering_enabled, typeof(CfxApi.WindowInfoLinux.cfx_window_info_linux_get_windowless_rendering_enabled_delegate));
            CfxApi.WindowInfoLinux.cfx_window_info_linux_set_shared_texture_enabled = (CfxApi.WindowInfoLinux.cfx_window_info_linux_set_shared_texture_enabled_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_window_info_linux_set_shared_texture_enabled, typeof(CfxApi.WindowInfoLinux.cfx_window_info_linux_set_shared_texture_enabled_delegate));
            CfxApi.WindowInfoLinux.cfx_window_info_linux_get_shared_texture_enabled = (CfxApi.WindowInfoLinux.cfx_window_info_linux_get_shared_texture_enabled_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_window_info_linux_get_shared_texture_enabled, typeof(CfxApi.WindowInfoLinux.cfx_window_info_linux_get_shared_texture_enabled_delegate));
            CfxApi.WindowInfoLinux.cfx_window_info_linux_set_external_begin_frame_enabled = (CfxApi.WindowInfoLinux.cfx_window_info_linux_set_external_begin_frame_enabled_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_window_info_linux_set_external_begin_frame_enabled, typeof(CfxApi.WindowInfoLinux.cfx_window_info_linux_set_external_begin_frame_enabled_delegate));
            CfxApi.WindowInfoLinux.cfx_window_info_linux_get_external_begin_frame_enabled = (CfxApi.WindowInfoLinux.cfx_window_info_linux_get_external_begin_frame_enabled_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_window_info_linux_get_external_begin_frame_enabled, typeof(CfxApi.WindowInfoLinux.cfx_window_info_linux_get_external_begin_frame_enabled_delegate));
            CfxApi.WindowInfoLinux.cfx_window_info_linux_set_window = (CfxApi.WindowInfoLinux.cfx_window_info_linux_set_window_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_window_info_linux_set_window, typeof(CfxApi.WindowInfoLinux.cfx_window_info_linux_set_window_delegate));
            CfxApi.WindowInfoLinux.cfx_window_info_linux_get_window = (CfxApi.WindowInfoLinux.cfx_window_info_linux_get_window_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_window_info_linux_get_window, typeof(CfxApi.WindowInfoLinux.cfx_window_info_linux_get_window_delegate));
        }

        internal static void LoadCfxWindowInfoWindowsApi() {
            CfxApi.Probe();
            CfxApi.WindowInfoWindows.cfx_window_info_windows_ctor = (CfxApi.cfx_ctor_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_window_info_windows_ctor, typeof(CfxApi.cfx_ctor_delegate));
            CfxApi.WindowInfoWindows.cfx_window_info_windows_dtor = (CfxApi.cfx_dtor_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_window_info_windows_dtor, typeof(CfxApi.cfx_dtor_delegate));
            CfxApi.WindowInfoWindows.cfx_window_info_windows_set_ex_style = (CfxApi.WindowInfoWindows.cfx_window_info_windows_set_ex_style_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_window_info_windows_set_ex_style, typeof(CfxApi.WindowInfoWindows.cfx_window_info_windows_set_ex_style_delegate));
            CfxApi.WindowInfoWindows.cfx_window_info_windows_get_ex_style = (CfxApi.WindowInfoWindows.cfx_window_info_windows_get_ex_style_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_window_info_windows_get_ex_style, typeof(CfxApi.WindowInfoWindows.cfx_window_info_windows_get_ex_style_delegate));
            CfxApi.WindowInfoWindows.cfx_window_info_windows_set_window_name = (CfxApi.WindowInfoWindows.cfx_window_info_windows_set_window_name_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_window_info_windows_set_window_name, typeof(CfxApi.WindowInfoWindows.cfx_window_info_windows_set_window_name_delegate));
            CfxApi.WindowInfoWindows.cfx_window_info_windows_get_window_name = (CfxApi.WindowInfoWindows.cfx_window_info_windows_get_window_name_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_window_info_windows_get_window_name, typeof(CfxApi.WindowInfoWindows.cfx_window_info_windows_get_window_name_delegate));
            CfxApi.WindowInfoWindows.cfx_window_info_windows_set_style = (CfxApi.WindowInfoWindows.cfx_window_info_windows_set_style_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_window_info_windows_set_style, typeof(CfxApi.WindowInfoWindows.cfx_window_info_windows_set_style_delegate));
            CfxApi.WindowInfoWindows.cfx_window_info_windows_get_style = (CfxApi.WindowInfoWindows.cfx_window_info_windows_get_style_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_window_info_windows_get_style, typeof(CfxApi.WindowInfoWindows.cfx_window_info_windows_get_style_delegate));
            CfxApi.WindowInfoWindows.cfx_window_info_windows_set_x = (CfxApi.WindowInfoWindows.cfx_window_info_windows_set_x_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_window_info_windows_set_x, typeof(CfxApi.WindowInfoWindows.cfx_window_info_windows_set_x_delegate));
            CfxApi.WindowInfoWindows.cfx_window_info_windows_get_x = (CfxApi.WindowInfoWindows.cfx_window_info_windows_get_x_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_window_info_windows_get_x, typeof(CfxApi.WindowInfoWindows.cfx_window_info_windows_get_x_delegate));
            CfxApi.WindowInfoWindows.cfx_window_info_windows_set_y = (CfxApi.WindowInfoWindows.cfx_window_info_windows_set_y_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_window_info_windows_set_y, typeof(CfxApi.WindowInfoWindows.cfx_window_info_windows_set_y_delegate));
            CfxApi.WindowInfoWindows.cfx_window_info_windows_get_y = (CfxApi.WindowInfoWindows.cfx_window_info_windows_get_y_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_window_info_windows_get_y, typeof(CfxApi.WindowInfoWindows.cfx_window_info_windows_get_y_delegate));
            CfxApi.WindowInfoWindows.cfx_window_info_windows_set_width = (CfxApi.WindowInfoWindows.cfx_window_info_windows_set_width_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_window_info_windows_set_width, typeof(CfxApi.WindowInfoWindows.cfx_window_info_windows_set_width_delegate));
            CfxApi.WindowInfoWindows.cfx_window_info_windows_get_width = (CfxApi.WindowInfoWindows.cfx_window_info_windows_get_width_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_window_info_windows_get_width, typeof(CfxApi.WindowInfoWindows.cfx_window_info_windows_get_width_delegate));
            CfxApi.WindowInfoWindows.cfx_window_info_windows_set_height = (CfxApi.WindowInfoWindows.cfx_window_info_windows_set_height_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_window_info_windows_set_height, typeof(CfxApi.WindowInfoWindows.cfx_window_info_windows_set_height_delegate));
            CfxApi.WindowInfoWindows.cfx_window_info_windows_get_height = (CfxApi.WindowInfoWindows.cfx_window_info_windows_get_height_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_window_info_windows_get_height, typeof(CfxApi.WindowInfoWindows.cfx_window_info_windows_get_height_delegate));
            CfxApi.WindowInfoWindows.cfx_window_info_windows_set_parent_window = (CfxApi.WindowInfoWindows.cfx_window_info_windows_set_parent_window_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_window_info_windows_set_parent_window, typeof(CfxApi.WindowInfoWindows.cfx_window_info_windows_set_parent_window_delegate));
            CfxApi.WindowInfoWindows.cfx_window_info_windows_get_parent_window = (CfxApi.WindowInfoWindows.cfx_window_info_windows_get_parent_window_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_window_info_windows_get_parent_window, typeof(CfxApi.WindowInfoWindows.cfx_window_info_windows_get_parent_window_delegate));
            CfxApi.WindowInfoWindows.cfx_window_info_windows_set_menu = (CfxApi.WindowInfoWindows.cfx_window_info_windows_set_menu_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_window_info_windows_set_menu, typeof(CfxApi.WindowInfoWindows.cfx_window_info_windows_set_menu_delegate));
            CfxApi.WindowInfoWindows.cfx_window_info_windows_get_menu = (CfxApi.WindowInfoWindows.cfx_window_info_windows_get_menu_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_window_info_windows_get_menu, typeof(CfxApi.WindowInfoWindows.cfx_window_info_windows_get_menu_delegate));
            CfxApi.WindowInfoWindows.cfx_window_info_windows_set_windowless_rendering_enabled = (CfxApi.WindowInfoWindows.cfx_window_info_windows_set_windowless_rendering_enabled_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_window_info_windows_set_windowless_rendering_enabled, typeof(CfxApi.WindowInfoWindows.cfx_window_info_windows_set_windowless_rendering_enabled_delegate));
            CfxApi.WindowInfoWindows.cfx_window_info_windows_get_windowless_rendering_enabled = (CfxApi.WindowInfoWindows.cfx_window_info_windows_get_windowless_rendering_enabled_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_window_info_windows_get_windowless_rendering_enabled, typeof(CfxApi.WindowInfoWindows.cfx_window_info_windows_get_windowless_rendering_enabled_delegate));
            CfxApi.WindowInfoWindows.cfx_window_info_windows_set_shared_texture_enabled = (CfxApi.WindowInfoWindows.cfx_window_info_windows_set_shared_texture_enabled_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_window_info_windows_set_shared_texture_enabled, typeof(CfxApi.WindowInfoWindows.cfx_window_info_windows_set_shared_texture_enabled_delegate));
            CfxApi.WindowInfoWindows.cfx_window_info_windows_get_shared_texture_enabled = (CfxApi.WindowInfoWindows.cfx_window_info_windows_get_shared_texture_enabled_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_window_info_windows_get_shared_texture_enabled, typeof(CfxApi.WindowInfoWindows.cfx_window_info_windows_get_shared_texture_enabled_delegate));
            CfxApi.WindowInfoWindows.cfx_window_info_windows_set_external_begin_frame_enabled = (CfxApi.WindowInfoWindows.cfx_window_info_windows_set_external_begin_frame_enabled_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_window_info_windows_set_external_begin_frame_enabled, typeof(CfxApi.WindowInfoWindows.cfx_window_info_windows_set_external_begin_frame_enabled_delegate));
            CfxApi.WindowInfoWindows.cfx_window_info_windows_get_external_begin_frame_enabled = (CfxApi.WindowInfoWindows.cfx_window_info_windows_get_external_begin_frame_enabled_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_window_info_windows_get_external_begin_frame_enabled, typeof(CfxApi.WindowInfoWindows.cfx_window_info_windows_get_external_begin_frame_enabled_delegate));
            CfxApi.WindowInfoWindows.cfx_window_info_windows_set_window = (CfxApi.WindowInfoWindows.cfx_window_info_windows_set_window_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_window_info_windows_set_window, typeof(CfxApi.WindowInfoWindows.cfx_window_info_windows_set_window_delegate));
            CfxApi.WindowInfoWindows.cfx_window_info_windows_get_window = (CfxApi.WindowInfoWindows.cfx_window_info_windows_get_window_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_window_info_windows_get_window, typeof(CfxApi.WindowInfoWindows.cfx_window_info_windows_get_window_delegate));
        }

        internal static void LoadCfxWriteHandlerApi() {
            CfxApi.Probe();
            CfxApi.WriteHandler.cfx_write_handler_ctor = (CfxApi.cfx_ctor_with_gc_handle_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_write_handler_ctor, typeof(CfxApi.cfx_ctor_with_gc_handle_delegate));
            CfxApi.WriteHandler.cfx_write_handler_set_callback = (CfxApi.cfx_set_callback_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_write_handler_set_callback, typeof(CfxApi.cfx_set_callback_delegate));
            CfxWriteHandler.SetNativeCallbacks();
        }

        internal static void LoadCfxX509CertPrincipalApi() {
            CfxApi.Probe();
            CfxApi.X509CertPrincipal.cfx_x509cert_principal_get_display_name = (CfxApi.X509CertPrincipal.cfx_x509cert_principal_get_display_name_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_x509cert_principal_get_display_name, typeof(CfxApi.X509CertPrincipal.cfx_x509cert_principal_get_display_name_delegate));
            CfxApi.X509CertPrincipal.cfx_x509cert_principal_get_common_name = (CfxApi.X509CertPrincipal.cfx_x509cert_principal_get_common_name_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_x509cert_principal_get_common_name, typeof(CfxApi.X509CertPrincipal.cfx_x509cert_principal_get_common_name_delegate));
            CfxApi.X509CertPrincipal.cfx_x509cert_principal_get_locality_name = (CfxApi.X509CertPrincipal.cfx_x509cert_principal_get_locality_name_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_x509cert_principal_get_locality_name, typeof(CfxApi.X509CertPrincipal.cfx_x509cert_principal_get_locality_name_delegate));
            CfxApi.X509CertPrincipal.cfx_x509cert_principal_get_state_or_province_name = (CfxApi.X509CertPrincipal.cfx_x509cert_principal_get_state_or_province_name_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_x509cert_principal_get_state_or_province_name, typeof(CfxApi.X509CertPrincipal.cfx_x509cert_principal_get_state_or_province_name_delegate));
            CfxApi.X509CertPrincipal.cfx_x509cert_principal_get_country_name = (CfxApi.X509CertPrincipal.cfx_x509cert_principal_get_country_name_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_x509cert_principal_get_country_name, typeof(CfxApi.X509CertPrincipal.cfx_x509cert_principal_get_country_name_delegate));
            CfxApi.X509CertPrincipal.cfx_x509cert_principal_get_street_addresses = (CfxApi.X509CertPrincipal.cfx_x509cert_principal_get_street_addresses_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_x509cert_principal_get_street_addresses, typeof(CfxApi.X509CertPrincipal.cfx_x509cert_principal_get_street_addresses_delegate));
            CfxApi.X509CertPrincipal.cfx_x509cert_principal_get_organization_names = (CfxApi.X509CertPrincipal.cfx_x509cert_principal_get_organization_names_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_x509cert_principal_get_organization_names, typeof(CfxApi.X509CertPrincipal.cfx_x509cert_principal_get_organization_names_delegate));
            CfxApi.X509CertPrincipal.cfx_x509cert_principal_get_organization_unit_names = (CfxApi.X509CertPrincipal.cfx_x509cert_principal_get_organization_unit_names_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_x509cert_principal_get_organization_unit_names, typeof(CfxApi.X509CertPrincipal.cfx_x509cert_principal_get_organization_unit_names_delegate));
            CfxApi.X509CertPrincipal.cfx_x509cert_principal_get_domain_components = (CfxApi.X509CertPrincipal.cfx_x509cert_principal_get_domain_components_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_x509cert_principal_get_domain_components, typeof(CfxApi.X509CertPrincipal.cfx_x509cert_principal_get_domain_components_delegate));
        }

        internal static void LoadCfxX509CertificateApi() {
            CfxApi.Probe();
            CfxApi.X509Certificate.cfx_x509certificate_get_subject = (CfxApi.X509Certificate.cfx_x509certificate_get_subject_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_x509certificate_get_subject, typeof(CfxApi.X509Certificate.cfx_x509certificate_get_subject_delegate));
            CfxApi.X509Certificate.cfx_x509certificate_get_issuer = (CfxApi.X509Certificate.cfx_x509certificate_get_issuer_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_x509certificate_get_issuer, typeof(CfxApi.X509Certificate.cfx_x509certificate_get_issuer_delegate));
            CfxApi.X509Certificate.cfx_x509certificate_get_serial_number = (CfxApi.X509Certificate.cfx_x509certificate_get_serial_number_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_x509certificate_get_serial_number, typeof(CfxApi.X509Certificate.cfx_x509certificate_get_serial_number_delegate));
            CfxApi.X509Certificate.cfx_x509certificate_get_valid_start = (CfxApi.X509Certificate.cfx_x509certificate_get_valid_start_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_x509certificate_get_valid_start, typeof(CfxApi.X509Certificate.cfx_x509certificate_get_valid_start_delegate));
            CfxApi.X509Certificate.cfx_x509certificate_get_valid_expiry = (CfxApi.X509Certificate.cfx_x509certificate_get_valid_expiry_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_x509certificate_get_valid_expiry, typeof(CfxApi.X509Certificate.cfx_x509certificate_get_valid_expiry_delegate));
            CfxApi.X509Certificate.cfx_x509certificate_get_derencoded = (CfxApi.X509Certificate.cfx_x509certificate_get_derencoded_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_x509certificate_get_derencoded, typeof(CfxApi.X509Certificate.cfx_x509certificate_get_derencoded_delegate));
            CfxApi.X509Certificate.cfx_x509certificate_get_pemencoded = (CfxApi.X509Certificate.cfx_x509certificate_get_pemencoded_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_x509certificate_get_pemencoded, typeof(CfxApi.X509Certificate.cfx_x509certificate_get_pemencoded_delegate));
            CfxApi.X509Certificate.cfx_x509certificate_get_issuer_chain_size = (CfxApi.X509Certificate.cfx_x509certificate_get_issuer_chain_size_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_x509certificate_get_issuer_chain_size, typeof(CfxApi.X509Certificate.cfx_x509certificate_get_issuer_chain_size_delegate));
            CfxApi.X509Certificate.cfx_x509certificate_get_derencoded_issuer_chain = (CfxApi.X509Certificate.cfx_x509certificate_get_derencoded_issuer_chain_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_x509certificate_get_derencoded_issuer_chain, typeof(CfxApi.X509Certificate.cfx_x509certificate_get_derencoded_issuer_chain_delegate));
            CfxApi.X509Certificate.cfx_x509certificate_get_pemencoded_issuer_chain = (CfxApi.X509Certificate.cfx_x509certificate_get_pemencoded_issuer_chain_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_x509certificate_get_pemencoded_issuer_chain, typeof(CfxApi.X509Certificate.cfx_x509certificate_get_pemencoded_issuer_chain_delegate));
        }

        internal static void LoadCfxXmlReaderApi() {
            CfxApi.Probe();
            CfxApi.XmlReader.cfx_xml_reader_create = (CfxApi.XmlReader.cfx_xml_reader_create_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_xml_reader_create, typeof(CfxApi.XmlReader.cfx_xml_reader_create_delegate));
            CfxApi.XmlReader.cfx_xml_reader_move_to_next_node = (CfxApi.XmlReader.cfx_xml_reader_move_to_next_node_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_xml_reader_move_to_next_node, typeof(CfxApi.XmlReader.cfx_xml_reader_move_to_next_node_delegate));
            CfxApi.XmlReader.cfx_xml_reader_close = (CfxApi.XmlReader.cfx_xml_reader_close_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_xml_reader_close, typeof(CfxApi.XmlReader.cfx_xml_reader_close_delegate));
            CfxApi.XmlReader.cfx_xml_reader_has_error = (CfxApi.XmlReader.cfx_xml_reader_has_error_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_xml_reader_has_error, typeof(CfxApi.XmlReader.cfx_xml_reader_has_error_delegate));
            CfxApi.XmlReader.cfx_xml_reader_get_error = (CfxApi.XmlReader.cfx_xml_reader_get_error_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_xml_reader_get_error, typeof(CfxApi.XmlReader.cfx_xml_reader_get_error_delegate));
            CfxApi.XmlReader.cfx_xml_reader_get_type = (CfxApi.XmlReader.cfx_xml_reader_get_type_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_xml_reader_get_type, typeof(CfxApi.XmlReader.cfx_xml_reader_get_type_delegate));
            CfxApi.XmlReader.cfx_xml_reader_get_depth = (CfxApi.XmlReader.cfx_xml_reader_get_depth_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_xml_reader_get_depth, typeof(CfxApi.XmlReader.cfx_xml_reader_get_depth_delegate));
            CfxApi.XmlReader.cfx_xml_reader_get_local_name = (CfxApi.XmlReader.cfx_xml_reader_get_local_name_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_xml_reader_get_local_name, typeof(CfxApi.XmlReader.cfx_xml_reader_get_local_name_delegate));
            CfxApi.XmlReader.cfx_xml_reader_get_prefix = (CfxApi.XmlReader.cfx_xml_reader_get_prefix_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_xml_reader_get_prefix, typeof(CfxApi.XmlReader.cfx_xml_reader_get_prefix_delegate));
            CfxApi.XmlReader.cfx_xml_reader_get_qualified_name = (CfxApi.XmlReader.cfx_xml_reader_get_qualified_name_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_xml_reader_get_qualified_name, typeof(CfxApi.XmlReader.cfx_xml_reader_get_qualified_name_delegate));
            CfxApi.XmlReader.cfx_xml_reader_get_namespace_uri = (CfxApi.XmlReader.cfx_xml_reader_get_namespace_uri_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_xml_reader_get_namespace_uri, typeof(CfxApi.XmlReader.cfx_xml_reader_get_namespace_uri_delegate));
            CfxApi.XmlReader.cfx_xml_reader_get_base_uri = (CfxApi.XmlReader.cfx_xml_reader_get_base_uri_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_xml_reader_get_base_uri, typeof(CfxApi.XmlReader.cfx_xml_reader_get_base_uri_delegate));
            CfxApi.XmlReader.cfx_xml_reader_get_xml_lang = (CfxApi.XmlReader.cfx_xml_reader_get_xml_lang_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_xml_reader_get_xml_lang, typeof(CfxApi.XmlReader.cfx_xml_reader_get_xml_lang_delegate));
            CfxApi.XmlReader.cfx_xml_reader_is_empty_element = (CfxApi.XmlReader.cfx_xml_reader_is_empty_element_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_xml_reader_is_empty_element, typeof(CfxApi.XmlReader.cfx_xml_reader_is_empty_element_delegate));
            CfxApi.XmlReader.cfx_xml_reader_has_value = (CfxApi.XmlReader.cfx_xml_reader_has_value_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_xml_reader_has_value, typeof(CfxApi.XmlReader.cfx_xml_reader_has_value_delegate));
            CfxApi.XmlReader.cfx_xml_reader_get_value = (CfxApi.XmlReader.cfx_xml_reader_get_value_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_xml_reader_get_value, typeof(CfxApi.XmlReader.cfx_xml_reader_get_value_delegate));
            CfxApi.XmlReader.cfx_xml_reader_has_attributes = (CfxApi.XmlReader.cfx_xml_reader_has_attributes_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_xml_reader_has_attributes, typeof(CfxApi.XmlReader.cfx_xml_reader_has_attributes_delegate));
            CfxApi.XmlReader.cfx_xml_reader_get_attribute_count = (CfxApi.XmlReader.cfx_xml_reader_get_attribute_count_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_xml_reader_get_attribute_count, typeof(CfxApi.XmlReader.cfx_xml_reader_get_attribute_count_delegate));
            CfxApi.XmlReader.cfx_xml_reader_get_attribute_byindex = (CfxApi.XmlReader.cfx_xml_reader_get_attribute_byindex_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_xml_reader_get_attribute_byindex, typeof(CfxApi.XmlReader.cfx_xml_reader_get_attribute_byindex_delegate));
            CfxApi.XmlReader.cfx_xml_reader_get_attribute_byqname = (CfxApi.XmlReader.cfx_xml_reader_get_attribute_byqname_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_xml_reader_get_attribute_byqname, typeof(CfxApi.XmlReader.cfx_xml_reader_get_attribute_byqname_delegate));
            CfxApi.XmlReader.cfx_xml_reader_get_attribute_bylname = (CfxApi.XmlReader.cfx_xml_reader_get_attribute_bylname_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_xml_reader_get_attribute_bylname, typeof(CfxApi.XmlReader.cfx_xml_reader_get_attribute_bylname_delegate));
            CfxApi.XmlReader.cfx_xml_reader_get_inner_xml = (CfxApi.XmlReader.cfx_xml_reader_get_inner_xml_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_xml_reader_get_inner_xml, typeof(CfxApi.XmlReader.cfx_xml_reader_get_inner_xml_delegate));
            CfxApi.XmlReader.cfx_xml_reader_get_outer_xml = (CfxApi.XmlReader.cfx_xml_reader_get_outer_xml_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_xml_reader_get_outer_xml, typeof(CfxApi.XmlReader.cfx_xml_reader_get_outer_xml_delegate));
            CfxApi.XmlReader.cfx_xml_reader_get_line_number = (CfxApi.XmlReader.cfx_xml_reader_get_line_number_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_xml_reader_get_line_number, typeof(CfxApi.XmlReader.cfx_xml_reader_get_line_number_delegate));
            CfxApi.XmlReader.cfx_xml_reader_move_to_attribute_byindex = (CfxApi.XmlReader.cfx_xml_reader_move_to_attribute_byindex_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_xml_reader_move_to_attribute_byindex, typeof(CfxApi.XmlReader.cfx_xml_reader_move_to_attribute_byindex_delegate));
            CfxApi.XmlReader.cfx_xml_reader_move_to_attribute_byqname = (CfxApi.XmlReader.cfx_xml_reader_move_to_attribute_byqname_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_xml_reader_move_to_attribute_byqname, typeof(CfxApi.XmlReader.cfx_xml_reader_move_to_attribute_byqname_delegate));
            CfxApi.XmlReader.cfx_xml_reader_move_to_attribute_bylname = (CfxApi.XmlReader.cfx_xml_reader_move_to_attribute_bylname_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_xml_reader_move_to_attribute_bylname, typeof(CfxApi.XmlReader.cfx_xml_reader_move_to_attribute_bylname_delegate));
            CfxApi.XmlReader.cfx_xml_reader_move_to_first_attribute = (CfxApi.XmlReader.cfx_xml_reader_move_to_first_attribute_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_xml_reader_move_to_first_attribute, typeof(CfxApi.XmlReader.cfx_xml_reader_move_to_first_attribute_delegate));
            CfxApi.XmlReader.cfx_xml_reader_move_to_next_attribute = (CfxApi.XmlReader.cfx_xml_reader_move_to_next_attribute_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_xml_reader_move_to_next_attribute, typeof(CfxApi.XmlReader.cfx_xml_reader_move_to_next_attribute_delegate));
            CfxApi.XmlReader.cfx_xml_reader_move_to_carrying_element = (CfxApi.XmlReader.cfx_xml_reader_move_to_carrying_element_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_xml_reader_move_to_carrying_element, typeof(CfxApi.XmlReader.cfx_xml_reader_move_to_carrying_element_delegate));
        }

        internal static void LoadCfxZipReaderApi() {
            CfxApi.Probe();
            CfxApi.ZipReader.cfx_zip_reader_create = (CfxApi.ZipReader.cfx_zip_reader_create_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_zip_reader_create, typeof(CfxApi.ZipReader.cfx_zip_reader_create_delegate));
            CfxApi.ZipReader.cfx_zip_reader_move_to_first_file = (CfxApi.ZipReader.cfx_zip_reader_move_to_first_file_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_zip_reader_move_to_first_file, typeof(CfxApi.ZipReader.cfx_zip_reader_move_to_first_file_delegate));
            CfxApi.ZipReader.cfx_zip_reader_move_to_next_file = (CfxApi.ZipReader.cfx_zip_reader_move_to_next_file_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_zip_reader_move_to_next_file, typeof(CfxApi.ZipReader.cfx_zip_reader_move_to_next_file_delegate));
            CfxApi.ZipReader.cfx_zip_reader_move_to_file = (CfxApi.ZipReader.cfx_zip_reader_move_to_file_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_zip_reader_move_to_file, typeof(CfxApi.ZipReader.cfx_zip_reader_move_to_file_delegate));
            CfxApi.ZipReader.cfx_zip_reader_close = (CfxApi.ZipReader.cfx_zip_reader_close_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_zip_reader_close, typeof(CfxApi.ZipReader.cfx_zip_reader_close_delegate));
            CfxApi.ZipReader.cfx_zip_reader_get_file_name = (CfxApi.ZipReader.cfx_zip_reader_get_file_name_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_zip_reader_get_file_name, typeof(CfxApi.ZipReader.cfx_zip_reader_get_file_name_delegate));
            CfxApi.ZipReader.cfx_zip_reader_get_file_size = (CfxApi.ZipReader.cfx_zip_reader_get_file_size_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_zip_reader_get_file_size, typeof(CfxApi.ZipReader.cfx_zip_reader_get_file_size_delegate));
            CfxApi.ZipReader.cfx_zip_reader_get_file_last_modified = (CfxApi.ZipReader.cfx_zip_reader_get_file_last_modified_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_zip_reader_get_file_last_modified, typeof(CfxApi.ZipReader.cfx_zip_reader_get_file_last_modified_delegate));
            CfxApi.ZipReader.cfx_zip_reader_open_file = (CfxApi.ZipReader.cfx_zip_reader_open_file_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_zip_reader_open_file, typeof(CfxApi.ZipReader.cfx_zip_reader_open_file_delegate));
            CfxApi.ZipReader.cfx_zip_reader_close_file = (CfxApi.ZipReader.cfx_zip_reader_close_file_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_zip_reader_close_file, typeof(CfxApi.ZipReader.cfx_zip_reader_close_file_delegate));
            CfxApi.ZipReader.cfx_zip_reader_read_file = (CfxApi.ZipReader.cfx_zip_reader_read_file_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_zip_reader_read_file, typeof(CfxApi.ZipReader.cfx_zip_reader_read_file_delegate));
            CfxApi.ZipReader.cfx_zip_reader_tell = (CfxApi.ZipReader.cfx_zip_reader_tell_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_zip_reader_tell, typeof(CfxApi.ZipReader.cfx_zip_reader_tell_delegate));
            CfxApi.ZipReader.cfx_zip_reader_eof = (CfxApi.ZipReader.cfx_zip_reader_eof_delegate)CfxApi.GetDelegate(FunctionIndex.cfx_zip_reader_eof, typeof(CfxApi.ZipReader.cfx_zip_reader_eof_delegate));
        }

    }
}
