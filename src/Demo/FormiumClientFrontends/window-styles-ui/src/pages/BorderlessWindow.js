import CommandBar from "./components/CommandBar";
import ContentView from "./components/ContentView";

export default function BorderlessWindow() {
  return <div className="window borderless-window">
    <CommandBar text="Borderless Window" />
    <ContentView>
      <>
        <p>This example is using <b>Borderless Window Style</b></p>
        <p>当前示例正在使用 <b>无边框窗体</b></p>
      </>
    </ContentView>
  </div>
}