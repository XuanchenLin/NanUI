import React, { useState } from "react";
import { openLocalFileResourceFolder } from "../../FormiumBridge";
const IFRAME_URL = "http://static.app.local";

const Page = () => {
  const iframeRef = React.createRef();

  const refreshFrame = () => {
    const iframe = iframeRef.current?.contentWindow;

    if (iframe) {
      iframe.postMessage("refresh", IFRAME_URL);
    }
  };

  const [isPostingDataToDataService, setIsPostingDataToDataService] = useState(
    false
  );

  return (
    <article>
      <section>
        <h2>Resources</h2>
        <p>
          Resource handler is an important component of NanUI to load external
          resources. NanUI encapsulates and simplifies the resource handler of
          CEF, you don't need to deal with data flow and various resource
          interfaces by yourself.
        </p>
        <p>
          NanUI implements four commonly used resource controllers in the form
          of extension plugins:
        </p>
        <ul>
          <li>
            <h5>EmbeddedFileResource</h5>
            <p>
              EmbeddedFileResource is used to load resource files embedded in
              the assembly.
            </p>
            <p>
              The web resources used by the currently running example are
              processed using the <b>EmbeddedFileResource</b>.
            </p>
          </li>
          <li>
            <h5>ZippedResource</h5>
            <p>
              ZippedResource is used to load resource files compressed with ZIP
              in the assembly or in the physical path.
            </p>
            <p>
              The resource used in the <b>Acrylic Form Example</b> in the{" "}
              <b>Form Styles</b> tab is obtained from the Zip package using the{" "}
              <b>ZippedResource</b>. The compressed package is embedded in the
              assembly as a resource for this example.
            </p>
          </li>
          <li>
            <h5>LocalFileResource</h5>
            <p>
              LocalFileResource is used to load resource files in the specified
              physical folder.
            </p>
            <p>
              When the resource file is too large, it is unrealistic to embed
              the large file into the assembly or package it. So if the resource
              file is relatively large, such as video, audio, etc., or the
              resource file needs to be dynamically operated, such as downloaded
              pictures, dynamically generated documents, etc., then using a file
              resource processor will be a good choice.
            </p>
            <p>
              <iframe
                src={IFRAME_URL}
                ref={iframeRef}
                allow="autoplay"
                id={`resource_page_eng`}
                title="resource_page_eng"
              ></iframe>
            </p>
            <p>
              <button
                className="btn btn-primary"
                onClick={() => refreshFrame()}
              >
                Refresh
              </button>{" "}
              <button
                className="btn btn-light"
                onClick={() => openLocalFileResourceFolder()}
              >
                Open Resource Folder
              </button>
            </p>
            <p>
              The files in the above iframe come from the <b>LocalFiles</b>{" "}
              folder under the currently running example directory. You can try
              to modify the files in the folder and refresh the iframe while the
              example is running to see the changes.
            </p>
          </li>
          <li>
            <h5>DataServiceResource</h5>
            <p>
              DataServiceResource is used to provide background data to the
              front-end environment. If you have used the Asp.Net Mvc controller
              before, DataServiceResource will provide a similar development
              experience.
            </p>
            <p>
              You can now open <b>Developer Tools</b> from the left and enter
              the following code in the console to test the DataServiceResource.
            </p>
            <p>Get data from the DataService by using GET method.</p>
            <div className="alert alert-secondary">
              {`fetch("https://api.app.local/Hello/Hi").then(response=>response.text()).then(text=>console.log(text));`}
            </div>
            <p>
              <button
                className="btn btn-primary"
                onClick={(e) => {
                  fetch("https://api.app.local/Hello/Hi")
                    .then((response) => response.text())
                    .then((text) => alert(`Result:\n${text}`));
                }}
              >
                Result
              </button>
            </p>
            <p>
              Pass the JSON object to the DataService by using POST method and
              it will get the response data later.
            </p>
            <div className="alert alert-secondary">
              {`fetch("https://api.app.local/account/user/login",{ method:"post",body:JSON.stringify( {passport:'我是你爸爸',password:'I Love NanUI'}), headers: new Headers({'Content-Type':'application/json'}) }).then(response=>response.json()).then(json=>console.log(json));`}
            </div>
            <p>
              <button
                className="btn btn-primary"
                disabled={isPostingDataToDataService}
                onClick={(e) => {
                  alert(
                    `The following data will be submmited by POST method and using JSON format: {passport:"admin", password:"I Love NanUI"}. The data service will return the result after a simulation delay of 2 seconds.`
                  );

                  setIsPostingDataToDataService(true);

                  fetch("https://api.app.local/account/user/login", {
                    method: "post",
                    body: JSON.stringify({
                      passport: "admin",
                      password: "I Love NanUI",
                    }),
                    headers: new Headers({
                      "Content-Type": "application/json",
                    }),
                  })
                    .then((response) => response.json())
                    .then((json) => alert(`Response:\n${JSON.stringify(json)}`))
                    .finally(() => setIsPostingDataToDataService(false));
                }}
              >
                {isPostingDataToDataService ? "Processing..." : "Result"}
              </button>
            </p>
            <p>
              You can learn more about the data service processor by viewing the
              source code in the <b>DataServices</b> folder of this example.
            </p>
          </li>
        </ul>
      </section>
    </article>
  );
};

export default Page;
