---
name: Obsidian Slate
colors:
  surface: '#1E1E1E'
  surface-dim: '#131313'
  surface-bright: '#393939'
  surface-container-lowest: '#0e0e0e'
  surface-container-low: '#1c1b1b'
  surface-container: '#2B2B2B'
  surface-container-high: '#2a2a2a'
  surface-container-highest: '#353534'
  on-surface: '#e5e2e1'
  on-surface-variant: '#cac3d8'
  inverse-surface: '#e5e2e1'
  inverse-on-surface: '#313030'
  outline: '#444444'
  outline-variant: '#494455'
  surface-tint: '#cdbdff'
  primary: '#cdbdff'
  on-primary: '#FFFFFF'
  primary-container: '#7c4dff'
  on-primary-container: '#fcf6ff'
  inverse-primary: '#6833ea'
  secondary: '#8dcdff'
  on-secondary: '#00344f'
  secondary-container: '#00affe'
  on-secondary-container: '#003f5f'
  tertiary: '#bfc8cc'
  on-tertiary: '#293235'
  tertiary-container: '#6b7478'
  on-tertiary-container: '#f2fbff'
  error: '#FF5252'
  on-error: '#690005'
  error-container: '#93000a'
  on-error-container: '#ffdad6'
  primary-fixed: '#e8deff'
  primary-fixed-dim: '#cdbdff'
  on-primary-fixed: '#20005f'
  on-primary-fixed-variant: '#4f00d0'
  secondary-fixed: '#cae6ff'
  secondary-fixed-dim: '#8dcdff'
  on-secondary-fixed: '#001e30'
  on-secondary-fixed-variant: '#004b70'
  tertiary-fixed: '#dbe4e8'
  tertiary-fixed-dim: '#bfc8cc'
  on-tertiary-fixed: '#141d20'
  on-tertiary-fixed-variant: '#3f484c'
  background: '#131313'
  on-background: '#e5e2e1'
  surface-variant: '#3D3D3D'
  success: '#00E676'
typography:
  display-lg:
    fontFamily: Inter
    fontSize: 57px
    fontWeight: '700'
    lineHeight: 64px
    letterSpacing: -0.25px
  headline-lg:
    fontFamily: Inter
    fontSize: 32px
    fontWeight: '600'
    lineHeight: 40px
  headline-lg-mobile:
    fontFamily: Inter
    fontSize: 28px
    fontWeight: '600'
    lineHeight: 36px
  title-lg:
    fontFamily: Inter
    fontSize: 22px
    fontWeight: '500'
    lineHeight: 28px
  title-md:
    fontFamily: Inter
    fontSize: 16px
    fontWeight: '500'
    lineHeight: 24px
    letterSpacing: 0.15px
  body-lg:
    fontFamily: Inter
    fontSize: 16px
    fontWeight: '400'
    lineHeight: 24px
    letterSpacing: 0.5px
  body-md:
    fontFamily: Inter
    fontSize: 14px
    fontWeight: '400'
    lineHeight: 20px
    letterSpacing: 0.25px
  label-lg:
    fontFamily: Inter
    fontSize: 14px
    fontWeight: '500'
    lineHeight: 20px
    letterSpacing: 0.1px
  label-md:
    fontFamily: Inter
    fontSize: 12px
    fontWeight: '500'
    lineHeight: 16px
    letterSpacing: 0.5px
rounded:
  sm: 0.25rem
  DEFAULT: 0.5rem
  md: 0.75rem
  lg: 1rem
  xl: 1.5rem
  full: 9999px
spacing:
  sidebar-width: 280px
  sidebar-collapsed: 80px
  gutter: 24px
  margin-mobile: 16px
  margin-desktop: 32px
  stack-sm: 8px
  stack-md: 16px
  stack-lg: 24px
---

## Brand & Style

This design system is engineered for high-density administrative interfaces, prioritizing clarity, hierarchy, and efficiency. It adopts a **Modern Corporate** aesthetic heavily influenced by **Material Design 3 (MD3)**, specifically optimized for a professional dark-themed environment. 

The visual narrative centers on "Precision through Contrast." By utilizing a deep charcoal foundation paired with vibrant primary accents, the UI directs user attention to critical data and primary actions without causing eye fatigue during long sessions. The style avoids excessive ornamentation, relying instead on MD3’s tonal layering and purposeful motion to guide the user through complex workflows. The result is a workspace that feels authoritative, responsive, and technologically advanced.

## Colors

The palette is anchored in a dark-mode-first architecture. The **Primary** color is a vibrant Violet, used for high-emphasis actions and active states. The **Secondary** Blue provides a cooler alternative for informational highlights or secondary navigation elements.

**Surface Tiers:**
- **Level 0 (#121212):** The main application background.
- **Level 1 (#1E1E1E):** Standard card backgrounds and sidebars.
- **Level 2 (#2B2B2B):** Hover states and raised components like dialogs.

Typography remains consistently high-contrast using pure white or near-white for headers, and a slightly muted grey for secondary body text to maintain a comfortable reading experience.

## Typography

This design system uses **Inter** exclusively to ensure maximum legibility across different resolutions and pixel densities. The typeface's neutral but modern personality fits the administrative context perfectly.

- **Weight Usage:** Use **Bold (700)** only for display levels. **Semi-Bold (600)** or **Medium (500)** should be used for headlines and navigation labels to create a clear visual hierarchy against the dark background.
- **Contrast:** Ensure that all body text maintains at least a 7:1 contrast ratio against surface colors. 
- **Scale:** On mobile devices, large headlines automatically scale down to prevent text wrapping issues in tight dashboards.

## Layout & Spacing

The layout utilizes a **hybrid grid system** designed for administrative workflows.

- **Desktop (>1240px):** Permanent left-hand sidebar (280px) with a fluid content area. Navigation is persistent to allow for rapid context switching.
- **Tablet (768px - 1239px):** Sidebar collapses into an icon-only rail (80px) or becomes a dismissible drawer depending on the task density.
- **Mobile (<767px):** Full-screen fluid layout. The sidebar is hidden behind a hamburger menu and manifests as a modal bottom-sheet or side-drawer.

**Rhythm:** An 8px base grid governs all padding and margins. Use "stack" variables to maintain vertical consistency between dashboard widgets.

## Elevation & Depth

In this dark-themed system, elevation is conveyed through **Tonal Layers** and **Subtle Glows** rather than heavy shadows.

1.  **Surface Tiers:** Higher elevation levels are represented by lighter surface colors. A "floating" card will have a lighter charcoal hex than the background it sits on.
2.  **Shadows:** When used, shadows are sharp and narrow (low blur), using a darker black with 40-60% opacity to "cut" the element out from the background.
3.  **Active States:** Interactive elements (buttons, active nav items) use the Primary color's luminosity to simulate depth. An active sidebar item receives a subtle inner glow or a high-chroma left-border indicator.
4.  **Borders:** Use 1px solid `outline` (#444444) for structural separation where tonal shifts are insufficient.

## Shapes

The shape language follows the **MD3 Rounded** philosophy.

- **Standard Elements:** Buttons, text fields, and small cards use a 0.5rem (8px) radius to feel modern and approachable.
- **Large Containers:** Dashboard widgets and main content panels use a 1rem (16px) radius to create a distinct framing effect.
- **Interaction Feedback:** Hover states and selection overlays should mirror the corner radius of their parent element perfectly.
- **Icons:** Use the "Material Symbols Rounded" set to match the UI’s corner treatments.

## Components

**Sidebars & Navigation:**
- The active state in the sidebar uses a "pill" background container in a semi-transparent version of the primary color (15% opacity) with a solid primary-colored icon.
- Navigation items should include a 4px vertical bar on the leading edge when active to provide a secondary visual cue.

**Modern Cards:**
- Cards are unbordered on level-1 surfaces, relying on `surface-container` coloring for definition. 
- Use a consistent 24px internal padding for dashboard cards.

**Buttons:**
- **Primary:** Solid Violet with white text.
- **Secondary:** Outlined with Primary color, 1px width.
- **Tertiary:** Ghost style with primary colored text, used for low-priority actions in tables.

**Input Fields:**
- Filled style with a bottom-line indicator is preferred for high-density forms. 
- The background of the field should be slightly darker or lighter than the container to ensure the input area is unmistakable.

**Chips & Tags:**
- Used for status indicators (e.g., "Active", "Pending"). Use low-saturation background tints of success/error colors with high-saturation text for readability.