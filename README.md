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

## 🚀 Setup & Configuration

### Prerequisites
Before building the project, ensure you have the following requirements met:
*   **Unity Editor:** Version `2021.3.16f1 LTS` (or newer) with **Android Build Support** installed.
*   **Google Cloud API Key:** An active API Key with the **ARCore API** enabled in the Google Cloud Console.

### 1. Unity Project Settings
1. Go to `Edit` -> `Project Settings` -> `XR Plug-in Management` -> `ARCore Extensions`.
2. Paste your Google Cloud API key into the **Android API Key** field.
3. Ensure **Geospatial** is set to **Enabled**.
4. In `Project Settings` -> `Player` -> `Other Settings`:
   *   **Graphics APIs:** Remove **Vulkan** from the list (keep only **OpenGLES3**).
   *   **Minimum API Level:** Set to **Android 8.0 (API Level 26)** or higher.
   *   **Scripting Backend:** Set to **IL2CPP**.
   *   **Target Architectures:** Check **ARM64** (uncheck ARMv7).

---

## 🎭 Scene & Animation Setup

### 1. UI & Language Settings
The application supports multilingual localization (**Kazakh, Russian, and English**).
*   The transition sequence begins in the `SettingsScene` where the user selects their preferred language.
*   The choice is saved locally via `PlayerPrefs` and automatically configures the text overlays and triggers in the main AR scene.

### 2. The AR Experience (Baiterek Scene)
*   **The Legend Director:** A unified `LegendDirector` script handles the visual storytelling. It coordinates the text blocks, background music, and 3D animations dynamically over a timeline.
*   **Vines (Lianas):** The custom-generated vine model grows dynamically using a vertical scale transition (Y-axis scaling from 0 to 1) and rotation, simulating organic growth.
*   **Golden Egg (Sun):** Formed using a high-fidelity Unity Sphere with HDR Emissive materials and an internal Point Light, pulsing in sync with the third chapter of the legend.
*   **The Samruk Bird:** Animated using a smooth hovering loop in the air above the golden egg, creating a lifelike spiritual presence.

---

## 📍 Coordinates for Testing (Baiterek, Astana)

If you are testing the **Geospatial Scene** on-site at the Baiterek monument, configure your spawner with the following parameters:

*   **Latitude:** `51.128302`
*   **Longitude:** `71.430531`
*   **Altitude:** `0` (Ensure `Force Put On Terrain` is checked to snap the anchor to the ground)
*   **Heading:** `0` (North)

> 💡 **Tip for Offline/Indoor Testing:** If you are not near the monument, please use the `2-TapToPlace` scene. This allows you to tap on any detected flat surface (AR Plane) to spawn a 1:10 scaled version of the Baiterek scene with all animations and audio fully functional.

---

## 👥 Team & Acknowledgements

*   **Developers:** Student team at **Nazarbayev Intellectual Schools (NIS)**, Astana, Kazakhstan. Created as an MVP submission for the **Astana Innovations Accelerator 2026**.
*   **External Assets:** 3D models generated via **Meshy AI**, character rigging via **Adobe Mixamo**, and templates adapted from the **Takashi Yoshinaga Geospatial Starter Kit**.

--- 

## 📁 Repository Structure

```text
Assets/
├── AR_Baiterek/               # Custom project assets
│   ├── Content/               # 3D Models, Materials, Prefabs (Bai-Fin)
│   ├── Scenes/                # MenuScene, SettingsScene, ARScene
│   └── Scripts/               # LegendDirector.cs, AutoSpawnController.cs, Billboard.cs, etc.
└── Samples/                   # ARCore Extensions samples (TapToPlace base)


