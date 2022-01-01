import { BrowserRouter, Routes, Route } from 'react-router-dom';
import './App.scss';
import BorderlessWindow from './pages/BorderlessWindow';
import KioskWindow from './pages/KioskWindow';
import LayeredWindow from './pages/LayeredWindow';
import SystemBorderlessWindow from './pages/SystemBorderlessWindow';
import SystemWindow from './pages/SystemWindow';

function App() {
  return (
    <div className="app">
      <BrowserRouter basename={window.PUBLIC_URL && window.PUBLIC_URL.length > 0 ? window.PUBLIC_URL : "/"}>
        <Routes>
          <Route path="/system-window" element={<SystemWindow />} />
          <Route path="/borderless-window" element={<BorderlessWindow />} />
          <Route path="/system-borderless-window" element={<SystemBorderlessWindow />} />
          <Route path="/layered-window" element={<LayeredWindow />} />
          <Route path="/kiosk-window" element={<KioskWindow />} />
        </Routes>
      </BrowserRouter>
    </div>
  );
}

export default App;
