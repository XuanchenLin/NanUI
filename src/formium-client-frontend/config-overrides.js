const { override, addWebpackAlias } = require("customize-cra");

const path = require("path");

process.env.GENERATE_SOURCEMAP = false;

module.exports = override(
  addWebpackAlias({
    "@": path.resolve(__dirname, "src"),
  }),
  (config) => {
    Object.assign(config.output, {
      filename: "static/js/[name].bundle.[hash:8].js",
      chunkFilename: "static/js/[name].chunk.[chunkhash:8].js",
    });

    const paths = require("react-scripts/config/paths");

    const buildPath = path.resolve(__dirname, "../FormiumClient/wwwroot");

    paths.appBuild = buildPath;
    config.output.path = buildPath;

    return config;
  }
);
