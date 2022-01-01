import ContentView from "./components/ContentView";
import "./KioskWindow.scss";
export default function KioskWindow() {
  return <div className="window kiosk-window">
    <ContentView>
      <>
        <p>This example is using fullscreen <b>KIOSK Window Style</b></p>
        <p>当前示例正在使用全屏的 <b>KIOSK模式窗体</b></p>
        <p>您需要使用 <kbd>ALT+F4</kbd> 关闭 / Use <kbd>ALT+F4</kbd> to close</p>
      </>
    </ContentView>
  </div>
}