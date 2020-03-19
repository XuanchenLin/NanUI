# 2020/03/19

- 修复了FormiumRequest的QueryString集合，当键值不存在时抛异常的问题。现在修改为当键值不存在时返回null。

# 2020/03/18

- 分离内置的三种ResourceHandler到单独的项目中
- 修复了原生样式窗口StartPosition设置为CenterParent无效的问题。

# 2020/02/06

- Upgrade NanUI to 0.7
- Add well HiDpi support for Windows 10 (Creators Update and above)
- New API for users to build html window easily.