const { override, addWebpackAlias } = require("customize-cra");
const path = require("path");

module.exports = override(
  addWebpackAlias({
    "@": path.resolve(__dirname, "src"),
  }),
  (config) => {
    // Object.assign(config.output, {
    //   filename: "static/js/[name].bundle.js",
    //   chunkFilename: "static/js/[name].chunk.js",
    // });

    return config;
  }
);
