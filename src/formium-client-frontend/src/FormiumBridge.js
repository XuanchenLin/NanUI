export const openLicenseWindow = () => {
  const openLicenseWindow = window.Formium?.external?.demo?.openLicenseWindow;
  openLicenseWindow && openLicenseWindow();
};

export const navigateToGitHub = () => {
  const navigateToGitHub = window.Formium?.external?.demo?.navigateToGitHub;
  navigateToGitHub && navigateToGitHub();
};

export const openDevTools = () => {
  const openDevTools = window.Formium?.external?.demo?.openDevTools;
  openDevTools && openDevTools();
};

export const openLocalFileResourceFolder = () => {
  const openFolder =
    window.Formium?.external?.demo?.openLocalFileResourceFolder;
  openFolder && openFolder();
};

export const openNativeStyleForm = () => {
  const func = window.Formium?.external?.windowExamples?.openNativeStyleForm;
  func && func();
};

export const openKisokModeForm = () => {
  const func = window.Formium?.external?.windowExamples?.openKisokModeForm;
  func && func();
};

export const openAcrylicStyleForm = () => {
  const func = window.Formium?.external?.windowExamples?.openAcrylicStyleForm;
  func && func();
};
export const openLayeredStyleForm = () => {
  const func = window.Formium?.external?.windowExamples?.openLayeredStyleForm;
  func && func();
};

export const executeJavaScriptWithoutRetval = () => {
  const func =
    window.Formium?.external?.jsExamples?.executeJavaScriptWithoutRetval;
  func && func();
};

export const executeJavaScriptWithRetval = () => {
  const func =
    window.Formium?.external?.jsExamples?.executeJavaScriptWithRetval;
  func && func();
};
