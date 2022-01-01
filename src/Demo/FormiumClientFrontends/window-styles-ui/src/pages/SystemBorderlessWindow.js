import CommandBar from "./components/CommandBar";
import ContentView from "./components/ContentView";

export default function SystemBorderlessWindow() {
  return <div className="window system-borderless-window">
    <CommandBar text="System Borderless Window" />
    <ContentView>
      <>
        <p>This example is using <b>Borderless Window Style</b> by DWM</p>
        <p>当前示例正在使用由DWM呈现的 <b>无边框窗体</b></p>
      </>
    </ContentView>
  </div>
}