function createWaves() {
  const conf = {
    nx: 44,
    ny: 100,
    cscale: chroma
      .scale(["#3c65c5", "#524d96", "#8bb539", "dc0f4c"])
      .mode("hsl"),
    darken: -1.96,
    angle: Math.PI * 1.25,
    timeCoef: 0.15,
  };
  //["#3c65c5", "#524d96", "#8bb539", "dc0f4c"]
  //["#FF7DE4", "#74B4ED", "#7CFCE7"]
  let renderer, scene, camera;
  let width, height;
  const { randFloat: rnd } = THREE.Math;

  const uTime = { value: 0 },
    uTimeCoef = { value: conf.timeCoef };
  const polylines = [];

  init();

  function init() {
    renderer = new THREE.WebGLRenderer({
      canvas: document.getElementById("canvas"),
      antialias: true,
    });
    camera = new THREE.PerspectiveCamera();

    updateSize();
    window.addEventListener("resize", updateSize, false);
    // document.body.addEventListener("click", initRandomScene);
    initScene();
    requestAnimationFrame(animate);
  }

  function initScene() {
    scene = new THREE.Scene();
    const vertexShader = `
        uniform float uTime, uTimeCoef;
        uniform float uSize;
        uniform mat2 uMat2;
        uniform vec3 uRnd1;
        uniform vec3 uRnd2;
        uniform vec3 uRnd3;
        uniform vec3 uRnd4;
        uniform vec3 uRnd5;
        attribute vec3 next, prev;
        attribute float side;
        varying vec2 vUv;

        vec2 dp(vec2 sv) {
          return (1.5 * sv * uMat2);
        }

        void main() {
          vUv = uv;

          vec2 pos = dp(position.xy);
          vec2 sprev = dp(prev.xy);
          vec2 snext = dp(next.xy);

          vec2 tangent = normalize(snext - sprev);
          vec2 normal = vec2(-tangent.y, tangent.x);

          float dist = length(snext - sprev);
          normal *= smoothstep(0.0, 0.02, dist);

          normal *= uSize;

          float time = uTime * uTimeCoef;
          vec3 rnd1 = vec3(cos(time * uRnd1.x + uRnd3.x), cos(time * uRnd1.y + uRnd3.y), cos(time * uRnd1.z + uRnd3.z));
          vec3 rnd2 = vec3(cos(time * uRnd2.x + uRnd4.x), cos(time * uRnd2.y + uRnd4.y), cos(time * uRnd2.z + uRnd4.z));
          normal *= 1.0
            + uRnd5.x * (cos((position.y + rnd1.x) * 20.0 * rnd1.y) + 1.0)
            + uRnd5.y * (sin((position.y + rnd2.x) * 20.0 * rnd2.y) + 1.0)
            + uRnd5.z * (cos((position.y + rnd1.z) * 20.0 * rnd2.z) + 1.0);
          pos.xy -= normal * side;

          gl_Position = vec4(pos, 0.0, 1.0);
        }
      `;

    const fragmentShader = `
        uniform vec3 uColor1;
        uniform vec3 uColor2;
        varying vec2 vUv;
        void main() {
          gl_FragColor = vec4(mix(uColor1, uColor2, vUv.x), 1.0);
        }
      `;

    const dx = 2 / conf.nx,
      dy = -2 / (conf.ny - 1);
    const ox = -1 + dx / 2,
      oy = 1;
    const mat2 = Float32Array.from([
      Math.cos(conf.angle),
      -Math.sin(conf.angle),
      Math.sin(conf.angle),
      Math.cos(conf.angle),
    ]);
    for (let i = 0; i < conf.nx; i++) {
      const points = [];
      for (let j = 0; j < conf.ny; j++) {
        const x = ox + i * dx,
          y = oy + j * dy;
        points.push(new THREE.Vector3(x, y, 0));
      }
      const polyline = new Polyline({ points });
      polylines.push(polyline);

      const material = new THREE.ShaderMaterial({
        uniforms: {
          uTime,
          uTimeCoef,
          uMat2: { value: mat2 },
          uSize: { value: 1.5 / conf.nx },
          uRnd1: {
            value: new THREE.Vector3(rnd(-1, 1), rnd(-1, 1), rnd(-1, 1)),
          },
          uRnd2: {
            value: new THREE.Vector3(rnd(-1, 1), rnd(-1, 1), rnd(-1, 1)),
          },
          uRnd3: {
            value: new THREE.Vector3(rnd(-1, 1), rnd(-1, 1), rnd(-1, 1)),
          },
          uRnd4: {
            value: new THREE.Vector3(rnd(-1, 1), rnd(-1, 1), rnd(-1, 1)),
          },
          uRnd5: {
            value: new THREE.Vector3(
              rnd(0.2, 0.5),
              rnd(0.3, 0.6),
              rnd(0.4, 0.7)
            ),
          },
          uColor1: {
            value: new THREE.Color(conf.cscale(i / conf.nx).hex()),
          },
          uColor2: {
            value: new THREE.Color(
              conf
                .cscale(i / conf.nx)
                .darken(conf.darken)
                .hex()
            ),
          },
        },
        vertexShader,
        fragmentShader,
      });
      const mesh = new THREE.Mesh(polyline.geometry, material);
      scene.add(mesh);
    }
  }

  function initRandomScene() {
    conf.nx = Math.floor(rnd(20, 200));
    conf.cscale = randomCScale();
    conf.darken = rnd(0, 1) > 0.5 ? rnd(-4, -0.5) : rnd(0.5, 4);
    conf.angle = rnd(0, 2 * Math.PI);
    uTimeCoef.value = rnd(0.05, 0.2);
    disposeScene();
    initScene();

    console.log(conf);
  }

  function disposeScene() {
    for (let i = 0; i < scene.children.length; i++) {
      const mesh = scene.children[i];
      scene.remove(mesh);
      mesh.geometry.dispose();
      mesh.material.dispose();
    }
    scene.dispose();
  }

  function randomCScale() {
    const colors = [],
      n = 2 + Math.floor(rnd(0, 4));
    for (let i = 0; i < n; i++) {
      colors.push(chroma.random());
    }
    const c = chroma.scale(colors).mode("lch");

    colors.forEach((v) => {
      console.log(v.toString());
    });

    return c;
  }

  function animate(t) {
    uTime.value = t * 0.001;
    renderer.render(scene, camera);
    requestAnimationFrame(animate);
  }

  function updateSize() {
    width = window.innerWidth;
    height = window.innerHeight;
    renderer.setSize(width, height);
  }
}

// adapted from https://github.com/oframe/ogl/blob/master/src/extras/Polyline.js
const Polyline = (function () {
  const tmp = new THREE.Vector3();

  class Polyline {
    constructor(params) {
      const { points } = params;
      this.points = points;
      this.count = points.length;
      this.init();
      this.updateGeometry();
    }

    init() {
      this.geometry = new THREE.BufferGeometry();
      this.position = new Float32Array(this.count * 3 * 2);
      this.prev = new Float32Array(this.count * 3 * 2);
      this.next = new Float32Array(this.count * 3 * 2);
      const side = new Float32Array(this.count * 1 * 2);
      const uv = new Float32Array(this.count * 2 * 2);
      const index = new Uint16Array((this.count - 1) * 3 * 2);

      for (let i = 0; i < this.count; i++) {
        const i2 = i * 2;
        side.set([-1, 1], i2);
        const v = i / (this.count - 1);
        uv.set([0, v, 1, v], i * 4);

        if (i === this.count - 1) continue;
        index.set([i2 + 0, i2 + 1, i2 + 2], (i2 + 0) * 3);
        index.set([i2 + 2, i2 + 1, i2 + 3], (i2 + 1) * 3);
      }

      this.geometry.setAttribute(
        "position",
        new THREE.BufferAttribute(this.position, 3)
      );
      this.geometry.setAttribute(
        "prev",
        new THREE.BufferAttribute(this.prev, 3)
      );
      this.geometry.setAttribute(
        "next",
        new THREE.BufferAttribute(this.next, 3)
      );
      this.geometry.setAttribute(
        "side",
        new THREE.BufferAttribute(side, 1)
      );
      this.geometry.setAttribute("uv", new THREE.BufferAttribute(uv, 2));
      this.geometry.setIndex(new THREE.BufferAttribute(index, 1));
    }

    updateGeometry() {
      this.points.forEach((p, i) => {
        p.toArray(this.position, i * 3 * 2);
        p.toArray(this.position, i * 3 * 2 + 3);

        if (!i) {
          tmp
            .copy(p)
            .sub(this.points[i + 1])
            .add(p);
          tmp.toArray(this.prev, i * 3 * 2);
          tmp.toArray(this.prev, i * 3 * 2 + 3);
        } else {
          p.toArray(this.next, (i - 1) * 3 * 2);
          p.toArray(this.next, (i - 1) * 3 * 2 + 3);
        }

        if (i === this.points.length - 1) {
          tmp
            .copy(p)
            .sub(this.points[i - 1])
            .add(p);
          tmp.toArray(this.next, i * 3 * 2);
          tmp.toArray(this.next, i * 3 * 2 + 3);
        } else {
          p.toArray(this.prev, (i + 1) * 3 * 2);
          p.toArray(this.prev, (i + 1) * 3 * 2 + 3);
        }
      });

      this.geometry.attributes.position.needsUpdate = true;
      this.geometry.attributes.prev.needsUpdate = true;
      this.geometry.attributes.next.needsUpdate = true;
    }
  }

  return Polyline;
})();
