# JanAR
Immersive AR Storytelling for the Baiterek Monument in Astana
**JanAR** (derived from the Kazakh word "Жан" - *soul/life* and **AR** - *Augmented Reality*) is an interactive mobile AR experience that breathes life into the iconic **Baiterek Monument** in Astana, Kazakhstan. 

By leveraging cutting-edge **Visual Positioning System (VPS)** technology, the app anchors a synchronized multimedia show directly onto the physical monument, retelling the ancient Turkic legend of the Tree of Life, the sacred bird Samruk, and the Golden Egg (the Sun).

---

## 📱 Features

- **Geospatial AR & VPS:** Utilizes **ARCore Geospatial API (AR Foundation)** to precisely align digital 3D models with the physical Baiterek tower in real-time, achieving high-accuracy outdoor tracking (<1.5m error).
- **Interactive Storytelling Timeline:** A custom script-director orchestrates the sequential reveal of the legend:
  1. *The Roots & Vines:* Mystical 3D vines grow and wrap around the tower.
  2. *The Sacred Bird:* The mythical bird Samruk appears in a golden burst of particles and hovers above.
  3. *The Golden Egg:* The sphere at the top glows dynamically (HDR Emission) representing the Sun.
- **Multilingual Support (Localization):** Fully localized interactive UI and subtitle text in three languages (**Kazakh, Russian, and English**) utilizing `PlayerPrefs` to store user preferences.
- **Atmospheric Soundtrack:** Immersive national küy/ambient music playing continuously across scenes.
- **Robust Calibration UI:** A clean "Neo-Nomad" style main menu and language settings screen, with automatic 3-second spawning once high GPS accuracy is locked.
- **"Tap-to-Place" Mode:** Built-in diagnostic scene for offline/indoor testing and scaling of assets.

---

## 🛠️ Tech Stack & Tools

- **Engine:** Unity 2021.3.16f1 LTS (Android Build Support)
- **AR Framework:** AR Foundation 5.x / ARCore XR Plugin
- **Location Engine:** ARCore Extensions (Geospatial API)
- **UI:** TextMeshPro (World Space & Screen Space Overlay)
- **Asset Generation:** AI-driven 3D generation (Meshy AI) & Adobe Mixamo for skeletal animation rigging.

---

## 📁 Repository Structure

```text
Assets/
├── AR_Baiterek/               # Custom project assets
│   ├── Content/               # 3D Models, Materials, Prefabs (Bai-Fin)
│   ├── Scenes/                # MenuScene, SettingsScene, ARScene
│   └── Scripts/               # LegendDirector.cs, AutoSpawnController.cs, Billboard.cs, etc.
└── Samples/                   # ARCore Extensions samples (TapToPlace base)
🚀 Setup & Installation
To run or build this project, you will need:
Unity 2021.3.16f1 LTS or newer with the Android Build Support module.
Google Cloud Platform (GCP) API Key:
Enable ARCore API in your GCP Console.
Generate an API Key.
In Unity, go to Edit -> Project Settings -> XR Plug-in Management -> ARCore Extensions and paste your key into the Android API Key field.
Android Build Settings:
Platform: Android (IL2CPP, ARM64 target architecture).
Minimum API Level: Android 8.0 (API 26) or higher.
Graphics API: Remove Vulkan (use OpenGLES3 only to prevent camera rendering issues).
📍 Coordinates for Testing (Baiterek, Astana)
If you are testing the Geospatial Scene on-site at the Baiterek monument, use these tested coordinates:
Latitude: 51.128302
Longitude: 71.430531
Altitude: 0 (with Force Put On Terrain checked)
Heading: 0 (North)
Note: For testing at home, please use the 2-TapToPlace scene with the Bai-Fin prefab to place the model on any flat surface (AR Plane).
👥 Team & Acknowledgements
Developed as an MVP for the Astana Innovations Accelerator 2026 by student developers at Nazarbayev Intellectual Schools (NIS), Astana, Kazakhstan. Special thanks to the open-source community and the Takashi Yoshinaga Geospatial Starter Kit.
