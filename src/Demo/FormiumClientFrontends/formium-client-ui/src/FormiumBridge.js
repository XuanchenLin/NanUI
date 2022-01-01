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

export const openSystemWindowDemo = () => {
  const func = window.Formium?.external?.windowExamples?.openSystemWindowDemo;
  func && func();
};

export const openBorderlessWindowDemo = () => {
  const func = window.Formium?.external?.windowExamples?.openBorderlessWindowDemo;
  func && func();
};

export const openSystemBorderlessWindowDemo = () => {
  const func = window.Formium?.external?.windowExamples?.openSystemBorderlessWindowDemo;
  func && func();
};

export const openLayeredWindowDemo = () => {
  const func = window.Formium?.external?.windowExamples?.openLayeredWindowDemo;
  func && func();
};

export const openKioskWindowDemo = () => {
  const func = window.Formium?.external?.windowExamples?.openKioskWindowDemo;
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
